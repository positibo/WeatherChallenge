﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using WeatherChallenge.Source.Domain.BusinessRules.Base;

namespace WeatherChallenge.Source.Utilities
{
    public class ErrorDetails
	{
		public int statusCode { get; set; }
		public string message { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}

	public static class GlobalExceptionHandler
	{
		public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.ContentType = "application/json";

					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						string errorJson;
						if (contextFeature.Error is BusinessRulesException)
						{
							var error = (BusinessRulesException)contextFeature.Error;
							context.Response.StatusCode = (int)error.StatusCode;
							errorJson = JsonConvert.SerializeObject(new ErrorDetails()
							{
								statusCode = (int)error.StatusCode,
								message = error.Message
							});
							await context.Response.WriteAsync(errorJson);
						}
						else
						{
							context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
							errorJson = JsonConvert.SerializeObject(new ErrorDetails()
							{
								statusCode = context.Response.StatusCode,
								message = "Internal Server Error"
							});
							await context.Response.WriteAsync(errorJson);
						}
						logger.LogError(errorJson);
					}
				});
			});
		}
	}
}

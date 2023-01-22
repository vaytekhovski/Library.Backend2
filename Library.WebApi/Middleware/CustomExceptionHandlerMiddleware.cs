﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Library.App.Common.Exceptions;

namespace Library.WebApi.Middleware
{
	public class CustomExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch(Exception exception)
			{
				await HandleExceptionAsync(context, exception);
			}
		}

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
			var code = HttpStatusCode.InternalServerError;
			var result = string.Empty;
			switch (exception)
			{
				case ValidationException validationException:
					code = HttpStatusCode.BadRequest;
					result = JsonSerializer.Serialize(validationException.Data);
					break;
				case NotFoundException:
					code = HttpStatusCode.NotFound;
					break;
            }
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;

			if (string.IsNullOrEmpty(result))
			{
				result = JsonSerializer.Serialize(new { error = exception.Message });
			}

			return context.Response.WriteAsync(result);
        }
    }
}


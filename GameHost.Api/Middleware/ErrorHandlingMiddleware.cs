using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace GameHost.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public ErrorHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch(FluentValidation.ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;
                
                var result = JsonSerializer.Serialize(ex.Errors);
                await context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = "An error occured" });
            context.Response.ContentType= "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }


    }


}

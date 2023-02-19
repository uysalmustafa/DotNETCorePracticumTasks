﻿using System.Net;
using System.Net.Mime;
using System.Text.Json;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                message = ex.Message,
                statusCode = response.StatusCode,
                title = "Error"
            };

            var errorJson = JsonSerializer.Serialize(errorResponse);

            await response.WriteAsync(errorJson);
        }
    }
}
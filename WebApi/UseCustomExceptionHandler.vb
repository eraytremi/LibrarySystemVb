Imports Core
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Diagnostics
Imports Microsoft.AspNetCore.Http
Imports System.Text.Json

Module UseCustomExceptionHandler
    <System.Runtime.CompilerServices.Extension>
    Public Sub UseCustomException(ByVal app As IApplicationBuilder)
        app.UseExceptionHandler(Sub(config)
                                    config.Run(Function(context) HandleExceptionAsync(context))
                                End Sub)
    End Sub

    Private Async Function HandleExceptionAsync(ByVal context As HttpContext) As Task
        context.Response.ContentType = "application/json"
        Dim exceptionFeature = context.Features.Get(Of IExceptionHandlerFeature)()
        Dim statusCode = StatusCodes.Status500InternalServerError

        Select Case exceptionFeature.Error.GetType()
            Case GetType(BadRequestException)
                statusCode = StatusCodes.Status400BadRequest
            Case GetType(UnauthorizedAccessException)
                statusCode = StatusCodes.Status401Unauthorized
            Case GetType(NotFoundException)
                statusCode = StatusCodes.Status404NotFound
        End Select

        context.Response.StatusCode = statusCode
        Dim response = ApiResponse(Of NoData).Fail(statusCode, exceptionFeature.Error.Message)
        Await context.Response.WriteAsync(JsonSerializer.Serialize(response))
    End Function
End Module

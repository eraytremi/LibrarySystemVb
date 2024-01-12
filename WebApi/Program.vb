Imports System
Imports AutoMapper
Imports Business
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports Microsoft.OpenApi
Imports Microsoft.OpenApi.Models

Module Program
    Sub Main(args As String())
        Dim builder = WebApplication.CreateBuilder(args)

        ' Konteynere servis ekle.
        builder.Services.AddControllers()
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddBusinessService()
        builder.Services.AddSwaggerGen()
        builder.Services.AddWebApiServices(builder.Configuration)
        builder.Services.AddAuthServices(builder.Configuration)

        Dim app = builder.Build()

        ' HTTP istek pipeline'ýný yapýlandýr.
        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If
        app.UseHttpsRedirection()
        app.UseAuthorization()
        app.MapControllers()

        app.Run()
    End Sub
End Module

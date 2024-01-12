Imports System.IdentityModel.Tokens.Jwt
Imports System.Security.Claims
Imports Business
Imports Core
Imports Microsoft.AspNetCore.Authorization
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.Extensions.Configuration
Imports Models

Namespace API.Controllers
    <Route("api/[controller]")>
    <ApiController>
    Public Class BookController
        Inherits ControllerBase
        Private ReadOnly _service As IBookService
        Private ReadOnly _configuration As IConfiguration


        Public Sub New(ByVal service As IBookService, configuration As IConfiguration)
            _configuration = configuration
            _service = service
        End Sub

        <HttpPost("getall")>
        Public Async Function GetAll() As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.GetAll(currentUserId)
            Return StatusCode(response.StatusCode, response)
        End Function


        <HttpPost>
        Public Async Function Post(<FromBody> ByVal dto As PostBook) As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.InsertBook(dto, currentUserId)
            Return StatusCode(response.StatusCode, response)
        End Function

        <HttpPut>
        Public Async Function Update(<FromBody> ByVal dto As UpdateBook) As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.UpdateBook(dto, currentUserId)
            Return StatusCode(response.StatusCode, response)
        End Function

        <HttpDelete>
        Public Async Function Delete(<FromBody> ByVal id As Integer) As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.Delete(id, currentUserId)
            Return StatusCode(response.StatusCode, response)
        End Function


    End Class
End Namespace

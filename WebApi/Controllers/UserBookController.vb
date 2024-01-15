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
    Public Class UserBookController
        Inherits ControllerBase
        Private ReadOnly _service As IUserBookService
        Private ReadOnly _configuration As IConfiguration


        Public Sub New(ByVal service As IUserBookService, configuration As IConfiguration)
            _configuration = configuration
            _service = service
        End Sub

        <HttpGet("getall")>
        Public Async Function GetAll() As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.GetAll(currentUserId)
            Return StatusCode(response.StatusCode, response)
        End Function


        <HttpPost>
        Public Async Function Post(<FromBody> ByVal dto As PostUserBook) As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.Insert(dto, currentUserId)
            Return StatusCode(response.StatusCode, response)
        End Function

        <HttpPut>
        Public Async Function Update(<FromBody> ByVal dto As UpdateUserBook) As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.Update(dto, currentUserId)
            Return StatusCode(response.StatusCode, response)
        End Function

        <HttpDelete>
        Public Async Function Delete(<FromBody> ByVal id As Integer) As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.Delete(id, currentUserId)
            Return StatusCode(response.StatusCode, response)
        End Function

        <HttpGet("myloans")>
        Public Async Function MyLoans() As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.MyLoans(currentUserId, "Book")
            Return StatusCode(response.StatusCode, response)
        End Function

        <HttpGet("myreadbooks")>
        Public Async Function MyReadBooks() As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.MyReadBooks(currentUserId, "Book")
            Return StatusCode(response.StatusCode, response)
        End Function
    End Class
End Namespace

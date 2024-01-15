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
    Public Class UserController
        Inherits ControllerBase
        Private ReadOnly _service As IUserService
        Private ReadOnly _configuration As IConfiguration


        Public Sub New(ByVal service As IUserService, configuration As IConfiguration)
            _configuration = configuration
            _service = service
        End Sub

        <HttpPost>
        Public Async Function Post(<FromBody> ByVal dto As PostUser) As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.Register(dto)
            Return StatusCode(response.StatusCode, response)
        End Function


        <HttpPost("login")>
        Public Async Function Login(dto As LoginData) As Task(Of IActionResult)
            Dim response = Await _service.Login(dto.EMail, dto.Password)

            Dim claims = New List(Of Claim)()
            If response.Data IsNot Nothing Then
                Dim userId As Long = response.Data.Id
                claims.Add(New Claim(JwtRegisteredClaimNames.NameId, userId.ToString()))
            End If

            claims.Add(New Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()))
            Dim accessToken = New JwtGenerator(_configuration).CreateAccessToken(claims)
            If response IsNot Nothing AndAlso response.Data IsNot Nothing AndAlso accessToken IsNot Nothing Then
                response.Data.Token = accessToken.Token
            End If
            Return StatusCode(response.StatusCode, response)
        End Function

        <HttpPost("updatepassword")>
        Public Async Function UpdatePassword(dto As LoginData) As Task(Of IActionResult)
            Dim currentUserId = CurrentUser.Get(HttpContext)
            Dim response = Await _service.UpdatePassword(dto.EMail, dto.Password)
            Return StatusCode(response.StatusCode, response)
        End Function

    End Class
End Namespace

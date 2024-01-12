Imports Microsoft.Extensions.Configuration
Imports Microsoft.IdentityModel.Tokens
Imports System.IdentityModel.Tokens.Jwt
Imports System.Security.Claims
Imports System.Text

Public Class JwtGenerator
    Private ReadOnly _configuration As IConfiguration
    Private _tokenOptions As TokenOptions
    Private _expiration As DateTime

    Public Sub New(configuration As IConfiguration)
        _configuration = configuration
        _tokenOptions = New TokenOptions()

        Dim tokenOptionsSection = _configuration.GetSection("TokenOptions")

        _tokenOptions.TokenExpiration = Integer.Parse(tokenOptionsSection("TokenExpiration"))
        _tokenOptions.SecurityKey = tokenOptionsSection("SecurityKey")
        _tokenOptions.Issuer = tokenOptionsSection("Issuer")
        _tokenOptions.Audience = tokenOptionsSection("Audience")
    End Sub

    Public Function CreateAccessToken(Optional claims As List(Of Claim) = Nothing) As AccessToken
        _expiration = DateTime.Now.AddDays(_tokenOptions.TokenExpiration)

        Dim securityKey = New SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey))
        Dim signingCredentials = New SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)

        Dim jwt = CreateJwtSecurityToken(_tokenOptions, signingCredentials, claims)

        Dim claimList As New List(Of String)()
        Dim i As Integer = 1
        If claims IsNot Nothing Then
            For Each claim In claims
                claimList.Add($"claim{i}")
                i += 1
            Next
        End If

        Dim jwtHandler = New JwtSecurityTokenHandler()
        Dim token = jwtHandler.WriteToken(jwt)

        Return New AccessToken With {
            .Token = token,
            .Expiration = _expiration,
            .Claims = New List(Of String) From {"claim1", "claim2", "claim3"}
        }
    End Function

    Private Function CreateJwtSecurityToken(tokenOptions As TokenOptions, signingCredentials As SigningCredentials, Optional claims As List(Of Claim) = Nothing) As JwtSecurityToken
        If claims Is Nothing Then
            claims = New List(Of Claim)() From {
                New Claim("key1", "value1"),
                New Claim("key2", "value2"),
                New Claim("key2", "value2")
            }
        End If

        Dim jwtSecurityToken = New JwtSecurityToken(
            issuer:=tokenOptions.Issuer,
            audience:=tokenOptions.Audience,
            expires:=_expiration,
            notBefore:=DateTime.Now,
            claims:=claims,
            signingCredentials:=signingCredentials)

        Return jwtSecurityToken
    End Function
End Class

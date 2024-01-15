Imports AutoMapper
Imports Core
Imports DataAccess
Imports Microsoft.AspNetCore.Http
Imports Models

Public Class UserService
    Implements IUserService

    Private ReadOnly _userRepo As IUserRepository
    Private ReadOnly _mapper As IMapper
    Public Sub New(userRepo As IUserRepository, mapper As IMapper)
        _userRepo = userRepo
        _mapper = mapper
    End Sub

    Public Async Function Register(dto As PostUser) As Task(Of ApiResponse(Of NoData)) Implements IUserService.Register
        Dim mapping = _mapper.Map(Of User)(dto)

        Await _userRepo.AddAsync(mapping)
        Return ApiResponse(Of NoData).Success(StatusCodes.Status201Created)

    End Function

    Public Async Function Login(Email As String, password As String) As Task(Of ApiResponse(Of GetUser)) Implements IUserService.Login
        Dim control = Await _userRepo.GetAsync(Function(p) p.EMail.Equals(Email) And p.Password.Equals(password))
        If control Is Nothing Then
            Return ApiResponse(Of GetUser).Fail(StatusCodes.Status400BadRequest, "Giriş başarısız")
        End If

        Dim mapping = _mapper.Map(Of GetUser)(control)
        Return ApiResponse(Of GetUser).Success(StatusCodes.Status200OK, mapping)
    End Function

    Public Async Function UpdatePassword(Email As String, password As String) As Task(Of ApiResponse(Of LoginData)) Implements IUserService.UpdatePassword
        Dim control = Await _userRepo.GetAsync(Function(s) s.EMail.Equals(Email))
        If control Is Nothing Then
            Return ApiResponse(Of LoginData).Fail(StatusCodes.Status400BadRequest, "böyle bir kullanıcı yok!")
        End If
        control.Password = password
        Await _userRepo.UpdateAsync(control)
        Return ApiResponse(Of LoginData).Success(StatusCodes.Status200OK)
    End Function


End Class

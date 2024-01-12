Imports Core
Imports Models

Public Interface IUserService
    Function Register(dto As PostUser) As Task(Of ApiResponse(Of NoData))
    Function Login(Email As String, password As String) As Task(Of ApiResponse(Of GetUser))
    Function UpdatePassword(Email As String, password As String) As Task(Of ApiResponse(Of LoginData))
End Interface

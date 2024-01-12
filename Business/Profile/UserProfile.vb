Imports AutoMapper
Imports Models

Public Class UserProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of PostUser, User)()
        CreateMap(Of User, GetUser)()
    End Sub
End Class

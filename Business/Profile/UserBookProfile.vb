Imports AutoMapper
Imports Models

Public Class UserBookProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of PostUserBook, UserBook)()
        CreateMap(Of UpdateUserBook, UserBook)()
        CreateMap(Of UserBook, GetUserBook)()
    End Sub
End Class

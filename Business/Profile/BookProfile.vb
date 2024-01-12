Imports AutoMapper
Imports Models

Public Class BookProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of PostBook, Book)()
        CreateMap(Of UpdateBook, Book)()
        CreateMap(Of Book, GetBook)()

    End Sub
End Class

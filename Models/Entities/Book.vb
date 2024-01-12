Imports Core

Public Class Book
    Inherits BaseEntity(Of Integer)

    Public Property Name As String
    Public Property AuthorName As String
    Public Property Type As String
    Public Property IsLoan As Boolean = False
End Class

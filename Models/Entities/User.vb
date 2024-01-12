Imports Core

Public Class User
    Inherits BaseEntity(Of Long)

    Public Property Name As String
    Public Property LastName As String
    Public Property PhoneNumber As String
    Public Property IdNumber As String
    Public Property EMail As String
    Public Property Password As String
    Public Property Photo As String
    Public Property Books As List(Of Book)
    Public Property UserBook As UserBook
End Class

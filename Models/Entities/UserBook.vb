Imports System.ComponentModel.DataAnnotations.Schema
Imports Core

Public Class UserBook
    Inherits BaseEntity(Of Long)

    Public Property BookId As Integer
    <ForeignKey("BookId")>
    Public Property Book As Book
    Public Property UserId As Long
    <ForeignKey("UserId")>
    Public Property User As List(Of User)
End Class

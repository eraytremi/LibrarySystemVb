Imports Core
Imports Models

Public Interface IBookService
    Function GetAll(currentUserId As Long) As Task(Of ApiResponse(Of List(Of Book)))
    Function InsertBook(dto As PostBook, currentUserId As Long) As Task(Of ApiResponse(Of NoData))
    Function UpdateBook(dto As UpdateBook, currentUserId As Long) As Task(Of ApiResponse(Of NoData))
    Function Delete(id As Integer, currentUserId As Long) As Task(Of ApiResponse(Of NoData))
End Interface

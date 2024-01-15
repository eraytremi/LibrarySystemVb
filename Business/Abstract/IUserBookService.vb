Imports Core
Imports Models

Public Interface IUserBookService
    Function GetAll(currentUserId As Long) As Task(Of ApiResponse(Of List(Of GetUserBook)))
    Function Insert(dto As PostUserBook, currentUserId As Long) As Task(Of ApiResponse(Of NoData))
    Function Update(dto As UpdateUserBook, currentUserId As Long) As Task(Of ApiResponse(Of NoData))
    Function Delete(id As Long, currentUserId As Long) As Task(Of ApiResponse(Of NoData))
    Function MyLoans(currentUserId As Long, ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of GetBook)))
    Function MyReadBooks(currentUserId As Long, ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of GetBook)))


End Interface

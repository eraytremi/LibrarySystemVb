Imports AutoMapper
Imports Core
Imports DataAccess
Imports Microsoft.AspNetCore.Http
Imports Models

Public Class BookService
    Implements IBookService

    Private ReadOnly _repo As IBookRepository
    Private ReadOnly _mapper As IMapper
    Public Sub New(repo As IBookRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetAll(currentUserId As Long) As Task(Of ApiResponse(Of List(Of Book))) Implements IBookService.GetAll
        Dim currentUser = Await _repo.GetByIdAsync(currentUserId)
        If currentUser Is Nothing Then
            Throw New BadRequestException("Kullanıcının yetkisi yok!!")
        End If
        Dim getListBook = Await _repo.GetAllAsync(Function(p) p.IsDeleted = False And p.IsLoan = False)
        Return ApiResponse(Of List(Of Book)).Success(StatusCodes.Status200OK, getListBook)
    End Function

    Public Async Function InsertBook(dto As PostBook, currentUserId As Long) As Task(Of ApiResponse(Of NoData)) Implements IBookService.InsertBook
        Dim mapping = _mapper.Map(Of Book)(dto)
        Await _repo.AddAsync(mapping)
        Return ApiResponse(Of NoData).Success(StatusCodes.Status201Created)
    End Function

    Public Async Function UpdateBook(dto As UpdateBook, currentUserId As Long) As Task(Of ApiResponse(Of NoData)) Implements IBookService.UpdateBook
        Dim getById = Await _repo.GetByIdAsync(dto.Id)
        Await _repo.UpdateAsync(getById)
        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function Delete(id As Integer, currentUserId As Long) As Task(Of ApiResponse(Of NoData)) Implements IBookService.Delete
        Dim getById = Await _repo.GetByIdAsync(id)
        getById.IsDeleted = True
        Await _repo.UpdateAsync(getById)
        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function
End Class

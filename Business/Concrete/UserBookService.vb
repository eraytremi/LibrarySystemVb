Imports System.IO
Imports AutoMapper
Imports Core
Imports DataAccess
Imports Microsoft.AspNetCore.Http
Imports Models

Public Class UserBookService
    Implements IUserBookService

    Private ReadOnly _repo As IUserBookRepository
    Private ReadOnly _mapper As IMapper
    Private ReadOnly _repoBook As IBookRepository
    Private ReadOnly _repoUser As IUserRepository
    Public Sub New(repo As IUserBookRepository, mapper As IMapper, repoBook As IBookRepository, repoUser As IUserRepository)
        _repo = repo
        _mapper = mapper
        _repoBook = repoBook
        _repoUser = repoUser
    End Sub

    Public Async Function GetAll(currentUserId As Long) As Task(Of ApiResponse(Of List(Of GetUserBook))) Implements IUserBookService.GetAll
        Dim currentUser = Await _repoUser.GetByIdAsync(currentUserId)
        If currentUser Is Nothing Then
            Throw New BadRequestException("Kullanıcının yetkisi yok!!")
        End If
        Dim getListBook = Await _repo.GetAllAsync(Function(p) p.IsDeleted = False)
        Dim mapp = _mapper.Map(Of List(Of GetUserBook))(getListBook)
        Return ApiResponse(Of List(Of GetUserBook)).Success(StatusCodes.Status200OK, mapp)
    End Function

    Public Async Function Insert(dto As PostUserBook, currentUserId As Long) As Task(Of ApiResponse(Of NoData)) Implements IUserBookService.Insert
        Dim currentUser = Await _repoUser.GetByIdAsync(currentUserId)
        If currentUser Is Nothing Then
            Throw New BadRequestException("Kullanıcının yetkisi yok!!")
        End If

        Dim getList = Await _repo.GetAllAsync(Function(p) p.UserId = currentUserId)

        Dim bookCount = getList.Select(Function(p) p.BookId).Count()

        If bookCount >= 3 Then
            Throw New BadRequestException("bir kullanıcı 3'ten fazla kitap alamaz!!")
        End If

        Dim existBook = Await _repo.AnyAsync(Function(p) p.BookId = dto.BookId)
        If existBook Then
            Throw New BadRequestException("bu kitap zaten ödünç alınmış!!")
        End If

        Dim mapping = _mapper.Map(Of UserBook)(dto)
        Await _repo.AddAsync(mapping)

        Dim getBookId = Await _repoBook.GetByIdAsync(dto.BookId)
        getBookId.IsLoan = True
        Await _repoBook.UpdateAsync(getBookId)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status201Created)
    End Function

    Public Async Function Update(dto As UpdateUserBook, currentUserId As Long) As Task(Of ApiResponse(Of NoData)) Implements IUserBookService.Update
        Dim currentUser = Await _repoUser.GetByIdAsync(currentUserId)
        If currentUser Is Nothing Then
            Throw New BadRequestException("Kullanıcının yetkisi yok!!")
        End If
        Dim getById = Await _repo.GetByIdAsync(dto.Id)
        Await _repo.UpdateAsync(getById)
        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function Delete(id As Long, currentUserId As Long) As Task(Of ApiResponse(Of NoData)) Implements IUserBookService.Delete
        Dim currentUser = Await _repoUser.GetByIdAsync(currentUserId)
        If currentUser Is Nothing Then
            Throw New BadRequestException("Kullanıcının yetkisi yok!!")
        End If
        Dim getById = Await _repo.GetByIdAsync(id)
        getById.IsDeleted = True
        Await _repo.UpdateAsync(getById)
        Dim getbyIdBook = Await _repoBook.GetByIdAsync(id)
        getbyIdBook.IsLoan = False
        Await _repoBook.UpdateAsync(getbyIdBook)
        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function MyLoans(currentUserId As Long, ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of GetBook))) Implements IUserBookService.MyLoans
        Dim currentUser = Await _repoUser.GetByIdAsync(currentUserId)
        If currentUser Is Nothing Then
            Throw New BadRequestException("Kullanıcının yetkisi yok!!")
        End If

        Dim getList = Await _repo.GetAllAsync(Function(k) k.IsDeleted = False, includeList)
        Dim getListBooks = getList.Where(Function(p) p.UserId = currentUserId).Select(Function(p) p.Book).ToList()

        Dim mapping = _mapper.Map(Of List(Of GetBook))(getListBooks)
        Return ApiResponse(Of List(Of GetBook)).Success(StatusCodes.Status200OK, mapping)
    End Function

    Public Async Function MyReadBooks(currentUserId As Long, ParamArray includeList() As String) As Task(Of ApiResponse(Of List(Of GetBook))) Implements IUserBookService.MyReadBooks
        Dim currentUser = Await _repoUser.GetByIdAsync(currentUserId)
        If currentUser Is Nothing Then
            Throw New BadRequestException("Kullanıcının yetkisi yok!!")
        End If
        Dim getList = Await _repo.GetAllAsync(Function(k) k.IsDeleted = True, includeList)
        Dim getListBooks = getList.Where(Function(p) p.UserId = currentUserId).Select(Function(p) p.Book).ToList()
        Dim mapping = _mapper.Map(Of List(Of GetBook))(getListBooks)
        Return ApiResponse(Of List(Of GetBook)).Success(StatusCodes.Status200OK, mapping)
    End Function
End Class

Imports Core
Imports Models

Public Class BookRepository
    Inherits BaseRepository(Of Book, Integer, LibraryContext)
    Implements IBookRepository
End Class

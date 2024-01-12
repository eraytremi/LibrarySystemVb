Imports Core
Imports Models

Public Class UserRepository
    Inherits BaseRepository(Of User, Long, LibraryContext)
    Implements IUserRepository
End Class

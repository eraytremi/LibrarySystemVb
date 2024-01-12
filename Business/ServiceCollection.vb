Imports DataAccess
Imports Microsoft.Extensions.DependencyInjection

Public Module ServiceCollection
    <System.Runtime.CompilerServices.Extension()>
    Public Sub AddBusinessService(services As IServiceCollection)
        services.AddAutoMapper(GetType(UserProfile))

        services.AddSingleton(Of IUserRepository, UserRepository)
        services.AddSingleton(Of IUserService, UserService)

        services.AddSingleton(Of IBookRepository, BookRepository)
        services.AddSingleton(Of IBookService, BookService)

        services.AddSingleton(Of IUserBookRepository, UserBookRepository)
        services.AddSingleton(Of IUserBookService, UserBookService)

    End Sub
End Module

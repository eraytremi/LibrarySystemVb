
Imports Microsoft.EntityFrameworkCore
Imports Models

Public Class LibraryContext
    Inherits DbContext

    Public Property Users As DbSet(Of User)
    Public Property Books As DbSet(Of Book)
    Public Property UserBooks As DbSet(Of UserBook)
    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlServer("server=DESKTOP-R04PVQ3\SQLEXPRESS;database=LibrarySystemDb;trusted_connection=true; trustServerCertificate=true;")
    End Sub
End Class

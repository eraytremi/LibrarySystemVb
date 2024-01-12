Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Global.DataAccess.Migrations
    ''' <inheritdoc />
    Partial Public Class mig1
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.AddColumn(Of String)(
                name:="Photo",
                table:="Users",
                type:="nvarchar(max)",
                nullable:=True)
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropColumn(
                name:="Photo",
                table:="Users")
        End Sub
    End Class
End Namespace

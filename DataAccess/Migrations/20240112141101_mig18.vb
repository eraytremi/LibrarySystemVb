Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Global.DataAccess.Migrations
    ''' <inheritdoc />
    Partial Public Class mig18
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropIndex(
                name:="IX_UserBooks_BookId",
                table:="UserBooks")

            migrationBuilder.CreateIndex(
                name:="IX_UserBooks_BookId",
                table:="UserBooks",
                column:="BookId")
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropIndex(
                name:="IX_UserBooks_BookId",
                table:="UserBooks")

            migrationBuilder.CreateIndex(
                name:="IX_UserBooks_BookId",
                table:="UserBooks",
                column:="BookId",
                unique:=True)
        End Sub
    End Class
End Namespace

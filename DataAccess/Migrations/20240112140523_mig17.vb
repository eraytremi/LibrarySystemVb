Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Global.DataAccess.Migrations
    ''' <inheritdoc />
    Partial Public Class mig17
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropForeignKey(
                name:="FK_UserBooks_Users_UserId",
                table:="UserBooks")

            migrationBuilder.DropIndex(
                name:="IX_UserBooks_UserId",
                table:="UserBooks")

            migrationBuilder.AddColumn(Of Long)(
                name:="UserId",
                table:="Users",
                type:="bigint",
                nullable:=True)

            migrationBuilder.CreateIndex(
                name:="IX_Users_UserId",
                table:="Users",
                column:="UserId")

            migrationBuilder.AddForeignKey(
                name:="FK_Users_UserBooks_UserId",
                table:="Users",
                column:="UserId",
                principalTable:="UserBooks",
                principalColumn:="Id")
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropForeignKey(
                name:="FK_Users_UserBooks_UserId",
                table:="Users")

            migrationBuilder.DropIndex(
                name:="IX_Users_UserId",
                table:="Users")

            migrationBuilder.DropColumn(
                name:="UserId",
                table:="Users")

            migrationBuilder.CreateIndex(
                name:="IX_UserBooks_UserId",
                table:="UserBooks",
                column:="UserId")

            migrationBuilder.AddForeignKey(
                name:="FK_UserBooks_Users_UserId",
                table:="UserBooks",
                column:="UserId",
                principalTable:="Users",
                principalColumn:="Id",
                onDelete:=ReferentialAction.Cascade)
        End Sub
    End Class
End Namespace

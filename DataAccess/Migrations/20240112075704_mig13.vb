Imports System
Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Global.DataAccess.Migrations
    ''' <inheritdoc />
    Partial Public Class mig13
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(
                name:="UserBooks",
                columns:=Function(table) New With {
                    .Id = table.Column(Of Long)(type:="bigint", nullable:=False).
                        Annotation("SqlServer:Identity", "1, 1"),
                    .BookId = table.Column(Of Integer)(type:="int", nullable:=False),
                    .UserId = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .CreatedDate = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .CreatedBy = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .UpdatedDate = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .UpdatedBy = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .DeletedDate = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .DeletedBy = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .IsDeleted = table.Column(Of Boolean)(type:="bit", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_UserBooks", Function(x) x.Id)
                    table.ForeignKey(
                        name:="FK_UserBooks_Books_BookId",
                        column:=Function(x) x.BookId,
                        principalTable:="Books",
                        principalColumn:="Id",
                        onDelete:=ReferentialAction.Cascade)
                    table.ForeignKey(
                        name:="FK_UserBooks_Users_UserId",
                        column:=Function(x) x.UserId,
                        principalTable:="Users",
                        principalColumn:="Id",
                        onDelete:=ReferentialAction.Cascade)
                End Sub)

            migrationBuilder.CreateIndex(
                name:="IX_UserBooks_BookId",
                table:="UserBooks",
                column:="BookId")

            migrationBuilder.CreateIndex(
                name:="IX_UserBooks_UserId",
                table:="UserBooks",
                column:="UserId")
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(
                name:="UserBooks")
        End Sub
    End Class
End Namespace

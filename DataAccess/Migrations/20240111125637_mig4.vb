Imports System
Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Global.DataAccess.Migrations
    ''' <inheritdoc />
    Partial Public Class mig4
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(
                name:="Books",
                columns:=Function(table) New With {
                    .Id = table.Column(Of Integer)(type:="int", nullable:=False).
                        Annotation("SqlServer:Identity", "1, 1"),
                    .Name = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .AuthorName = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .Type = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .UserId = table.Column(Of Long)(type:="bigint", nullable:=True),
                    .CreatedDate = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .CreatedBy = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .UpdatedDate = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .UpdatedBy = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .DeletedDate = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .DeletedBy = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .IsDeleted = table.Column(Of Boolean)(type:="bit", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_Books", Function(x) x.Id)
                    table.ForeignKey(
                        name:="FK_Books_Users_UserId",
                        column:=Function(x) x.UserId,
                        principalTable:="Users",
                        principalColumn:="Id")
                End Sub)

            migrationBuilder.CreateIndex(
                name:="IX_Books_UserId",
                table:="Books",
                column:="UserId")
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(
                name:="Books")
        End Sub
    End Class
End Namespace

Imports System
Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Global.DataAccess.Migrations
    ''' <inheritdoc />
    Partial Public Class mig
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(
                name:="Users",
                columns:=Function(table) New With {
                    .Id = table.Column(Of Long)(type:="bigint", nullable:=False).
                        Annotation("SqlServer:Identity", "1, 1"),
                    .Name = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .LastName = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .PhoneNumber = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .IdNumber = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .EMail = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .Password = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .CreatedDate = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .CreatedBy = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .UpdatedDate = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .UpdatedBy = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .DeletedDate = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .DeletedBy = table.Column(Of Long)(type:="bigint", nullable:=False),
                    .IsDeleted = table.Column(Of Boolean)(type:="bit", nullable:=False)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_Users", Function(x) x.Id)
                End Sub)
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(
                name:="Users")
        End Sub
    End Class
End Namespace

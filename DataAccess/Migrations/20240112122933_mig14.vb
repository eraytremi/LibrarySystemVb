Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Global.DataAccess.Migrations
    ''' <inheritdoc />
    Partial Public Class mig14
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.AddColumn(Of Boolean)(
                name:="IsLoan",
                table:="Books",
                type:="bit",
                nullable:=False,
                defaultValue:=False)
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropColumn(
                name:="IsLoan",
                table:="Books")
        End Sub
    End Class
End Namespace

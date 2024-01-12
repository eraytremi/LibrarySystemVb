Imports Microsoft.AspNetCore.Http

Public Module CurrentUser
    Public Function [Get](httpContext As HttpContext) As Long?
        Try
            Dim ccl = httpContext.User.Claims.FirstOrDefault(Function(k) k.Type.Contains("nameidentifier"))
            If ccl IsNot Nothing Then
                Dim result As Long
                If Long.TryParse(ccl.Value, result) Then
                    Return result
                Else
                    Return Nothing ' Dönüşüm başarısız olduysa null dönebilirsiniz.
                End If
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Module
Public Class BaseEntity(Of TId)
    Implements IEntity

    Public Property Id As TId
    Public Property CreatedDate As DateTime
    Public Property CreatedBy As Long
    Public Property UpdatedDate As DateTime
    Public Property UpdatedBy As Long
    Public Property DeletedDate As DateTime
    Public Property DeletedBy As Long
    Public Property IsDeleted As Boolean = False
End Class

Imports System.Linq.Expressions
Imports Microsoft.EntityFrameworkCore

Public Class BaseRepository(Of TEntity As {BaseEntity(Of TId)}, TId, TContext As {DbContext, New})
    Implements IBaseRepository(Of TEntity, TId)

    Public Async Function GetAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), Optional includeList As ICollection(Of String) = Nothing) As Task(Of TEntity) Implements IBaseRepository(Of TEntity, TId).GetAsync
        Using context = New TContext()
            Dim dbSet = context.Set(Of TEntity)()
            If includeList IsNot Nothing Then
                For Each include As String In includeList
                    dbSet = dbSet.Include(include)
                Next
            End If
            Dim a = Await dbSet.Where(Function(entity) entity.IsDeleted = False).SingleOrDefaultAsync(predicate)
            Return a
        End Using
    End Function

    Public Async Function AddAsync(entity As TEntity) As Task Implements IBaseRepository(Of TEntity, TId).AddAsync
        Using context = New TContext()
            Dim dbset = context.Set(Of TEntity)()
            entity.CreatedDate = DateTime.Now
            Await dbset.AddAsync(entity)
            Await context.SaveChangesAsync()

        End Using
    End Function

    Public Async Function UpdateAsync(entity As TEntity) As Task Implements IBaseRepository(Of TEntity, TId).UpdateAsync
        Using context = New TContext()
            Dim dbSet = context.Set(Of TEntity)()
            entity.UpdatedDate = DateTime.Now
            dbSet.Update(entity)
            Await context.SaveChangesAsync()
        End Using
    End Function

    Public Async Function DeleteAsync(entity As TEntity) As Task Implements IBaseRepository(Of TEntity, TId).DeleteAsync
        Using context = New TContext()
            Dim dbSet = context.Set(Of TEntity)
            dbSet.Update(entity)
            entity.IsDeleted = True
            entity.DeletedDate = DateTime.Now
            Await context.SaveChangesAsync()
        End Using
    End Function

    Public Async Function AddRangeAsync(entities As ICollection(Of TEntity)) As Task Implements IBaseRepository(Of TEntity, TId).AddRangeAsync
        Using context = New TContext()
            Dim dbSet = context.Set(Of TEntity)
            For Each entity As TEntity In entities
                entity.CreatedDate = DateTime.Now
            Next

            Await dbSet.AddRangeAsync(entities)
            Await context.SaveChangesAsync()

        End Using
    End Function

    Public Async Function AnyAsync(predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of Boolean) Implements IBaseRepository(Of TEntity, TId).AnyAsync
        Using context = New TContext()
            Return Await context.Set(Of TEntity).AnyAsync(predicate)
        End Using
    End Function

    Public Async Function GetByIdAsync(id As TId, Optional includeList As ICollection(Of String) = Nothing) As Task(Of TEntity) Implements IBaseRepository(Of TEntity, TId).GetByIdAsync
        Using context = New TContext()
            Dim dbSet = context.Set(Of TEntity)()

            If includeList IsNot Nothing AndAlso includeList.Count > 0 Then
                For Each include As String In includeList
                    dbSet = dbSet.Include(include)
                Next
            End If
            Return Await dbSet.Where(Function(e) e.IsDeleted = False).FirstOrDefaultAsync(Function(e) e.Id.Equals(id))
        End Using
    End Function

    Public Async Function GetAllAsync(Optional predicate As Expression(Of Func(Of TEntity, Boolean)) = Nothing, Optional includeList As ICollection(Of String) = Nothing) As Task(Of List(Of TEntity)) Implements IBaseRepository(Of TEntity, TId).GetAllAsync
        Using context = New TContext()
            Dim dbSet As IQueryable(Of TEntity) = context.Set(Of TEntity)()

            If includeList IsNot Nothing AndAlso includeList.Count > 0 Then
                For Each include As String In includeList
                    dbSet = dbSet.Include(include)
                Next
            End If

            If predicate Is Nothing Then
                Return Await dbSet.ToListAsync()
            End If

            Return Await dbSet.Where(predicate).ToListAsync()

        End Using
    End Function
End Class

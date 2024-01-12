Imports System.Linq.Expressions

Public Interface IBaseRepository(Of TEntity As BaseEntity(Of TId), TId)
    Function GetAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), Optional includeList As ICollection(Of String) = Nothing) As Task(Of TEntity)
    Function AddAsync(entity As TEntity) As Task
    Function UpdateAsync(entity As TEntity) As Task
    Function DeleteAsync(entity As TEntity) As Task
    Function AddRangeAsync(entities As ICollection(Of TEntity)) As Task
    Function AnyAsync(predicate As Expression(Of Func(Of TEntity, Boolean))) As Task(Of Boolean)
    Function GetByIdAsync(id As TId, Optional includeList As ICollection(Of String) = Nothing) As Task(Of TEntity)
    Function GetAllAsync(Optional predicate As Expression(Of Func(Of TEntity, Boolean)) = Nothing, Optional includeList As ICollection(Of String) = Nothing) As Task(Of List(Of TEntity))
End Interface

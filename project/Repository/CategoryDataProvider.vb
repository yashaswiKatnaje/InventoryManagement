Public Class CategoryDataProvider
    Public Shared ReadOnly Property Categories As New List(Of Category)()

    Public Shared Sub AddCategory(category As Category)
        Categories.Add(category)
    End Sub

    Public Shared Sub UpdateCategory(index As Integer, category As Category)
        Categories(index) = category
    End Sub
    Public Shared Function GetCategories() As List(Of Category)
        Return Categories
    End Function
    Public Shared Sub DeleteProduct(index As Integer)
        Categories.RemoveAt(index)
    End Sub
End Class

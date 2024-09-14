Public Class ProductDataProvider
    Public Shared Products As New List(Of Product)()

    Public Shared Function GetProducts() As List(Of Product)
        Return Products
    End Function

    Public Shared Sub AddProduct(product As Product)
        Products.Add(product)
    End Sub

    Public Shared Sub UpdateProduct(index As Integer, product As Product)
        Products(index) = product
    End Sub

    Public Shared Sub DeleteProduct(index As Integer)
        Products.RemoveAt(index)
    End Sub
End Class

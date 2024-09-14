Public Class Product
    Public Property ProductId As Integer
    Public Property Name As String
    Public Property Description As String
    Public Property Price As Decimal
    Public Property Quantity As Integer
    Public Property Category As String

    Public Function Validate() As Boolean
        Return Not String.IsNullOrEmpty(Name) AndAlso Price > 0 AndAlso Quantity >= 0
    End Function
End Class

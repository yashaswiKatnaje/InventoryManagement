Public Class Customer
    Public Property CustomerId As Integer
    Public Property Name As String
    Public Property Email As String
    Public Property Address As String
    Public Property ContactNumber As String

    Public Function Validate() As Boolean
        Return Not String.IsNullOrEmpty(Name) AndAlso Not String.IsNullOrEmpty(Email) AndAlso Not String.IsNullOrEmpty(Address)
    End Function
End Class

Public Class Category
    Public Property Name As String
    Public Property Description As String

    Public Function Validate() As Boolean
        Return Not String.IsNullOrEmpty(Name)
    End Function
End Class

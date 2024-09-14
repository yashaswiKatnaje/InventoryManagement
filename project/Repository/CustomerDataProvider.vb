Public Class CustomerDataProvider
    Public Shared ReadOnly Property Customers As New List(Of Customer)()

    Public Shared Sub AddCustomer(customer As Customer)
        Customers.Add(customer)
    End Sub

    Public Shared Sub UpdateCustomer(index As Integer, customer As Customer)
        Customers(index) = customer
    End Sub
    Public Shared Function GetCustomers() As List(Of Customer)
        Return Customers
    End Function
    Public Shared Sub DeleteCustomer(index As Integer)
        Customers.RemoveAt(index)
    End Sub
End Class

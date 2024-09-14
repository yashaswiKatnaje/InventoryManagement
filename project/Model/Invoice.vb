Public Class Invoice
    Public Property Customer As Customer
    Public Property Products As List(Of Product)
    Public Property TotalAmount As Decimal
    Public Property PaymentOption As String
    Public Property Discounts As Decimal

    Public Sub New(customer As Customer, products As List(Of Product), paymentOption As String, Optional discounts As Decimal = 0)
        Me.Customer = customer
        Me.Products = products
        Me.PaymentOption = paymentOption
        Me.Discounts = discounts
    End Sub


End Class

Imports System.Collections.Generic
Imports System.Web.UI

Public Class Invoicing
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Dim mainContent As ContentPlaceHolder = CType(Master.FindControl("MainContent"), ContentPlaceHolder)

            If Not IsPostBack Then
                PopulateDropdowns(mainContent)
            End If

            'If IsPostBack Then
            '    GenerateInvoice()
            'End If
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Private Sub PopulateDropdowns(mainContent As ContentPlaceHolder)
        Try
            Dim customers As List(Of Customer) = CustomerDataProvider.Customers
            Dim products As List(Of Product) = ProductDataProvider.Products


            If mainContent IsNot Nothing Then
                Dim ddlCustomer As DropDownList = CType(mainContent.FindControl("ddlCustomer"), DropDownList)
                Dim ddlProduct As DropDownList = CType(mainContent.FindControl("ddlProduct"), DropDownList)

                If ddlCustomer IsNot Nothing AndAlso ddlProduct IsNot Nothing Then
                    ddlCustomer.Items.Clear()
                    ddlProduct.Items.Clear()

                    ddlCustomer.Items.Insert(0, "Please Select")
                    ddlCustomer.SelectedIndex = 0
                    ddlProduct.Items.Insert(0, "Please Select")
                    ddlProduct.SelectedIndex = 0

                    For Each customer As Customer In customers
                        ddlCustomer.Items.Add(New ListItem(customer.Name, customer.Email))
                    Next

                    For Each product As Product In products
                        ddlProduct.Items.Add(New ListItem(product.Name, product.Name))
                    Next
                Else
                    ' Handle the case where the dropdowns are not found

                End If
            Else
                ' Handle the case where the ContentPlaceHolder is not found

            End If
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub


    Protected Sub GenerateInvoice(sender As Object, e As EventArgs)
        Try
            'This method i'm not using. Handled in Javascript
            Dim mainContent As ContentPlaceHolder = CType(Master.FindControl("MainContent"), ContentPlaceHolder)
            Dim ddlCustomer As DropDownList = CType(mainContent.FindControl("ddlCustomer"), DropDownList)
            Dim ddlProduct As DropDownList = CType(mainContent.FindControl("ddlProduct"), DropDownList)
            Dim txtPrice As TextBox = CType(mainContent.FindControl("txtPrice"), TextBox)
            Dim txtQuantity As TextBox = CType(mainContent.FindControl("txtQuantity"), TextBox)
            Dim txtDiscount As TextBox = CType(mainContent.FindControl("txtDiscount"), TextBox)
            Dim txtTax As TextBox = CType(mainContent.FindControl("txtTax"), TextBox)
            Dim txtTotalAmount As TextBox = CType(mainContent.FindControl("txtTotalAmount"), TextBox)
            Dim invoiceDetails As Literal = CType(mainContent.FindControl("invoiceDetails"), Literal)

            ' Retrieve selected values from the controls
            Dim customerEmail As String = ddlCustomer.SelectedValue
            Dim productName As String = ddlProduct.SelectedValue
            Dim price As Decimal = Convert.ToDecimal(txtPrice.Text)
            Dim quantity As Integer = Convert.ToInt32(txtQuantity.Text)
            Dim discount As Decimal = Convert.ToDecimal(txtDiscount.Text)
            Dim tax As Decimal = Convert.ToDecimal(txtTax.Text)

            ' Calculate total amount
            Dim subtotal As Decimal = price * quantity
            Dim discountAmount As Decimal = subtotal * (discount / 100)
            Dim taxAmount As Decimal = (subtotal - discountAmount) * (tax / 100)
            Dim totalAmount As Decimal = subtotal - discountAmount + taxAmount

            ' Display total amount
            txtTotalAmount.Text = totalAmount.ToString("C")

            ' Generate invoice HTML
            Dim invoiceHtml As New System.Text.StringBuilder()
            invoiceHtml.AppendLine($"<h3>Invoice for {customerEmail}</h3>")
            invoiceHtml.AppendLine($"<p>Product: {productName}</p>")
            invoiceHtml.AppendLine($"<p>Price: {price:C}</p>")
            invoiceHtml.AppendLine($"<p>Quantity: {quantity}</p>")
            invoiceHtml.AppendLine($"<p>Discount: {discount}%</p>")
            invoiceHtml.AppendLine($"<p>Tax: {tax}%</p>")
            invoiceHtml.AppendLine($"<p>Total Amount: {totalAmount:C}</p>")

            invoiceDetails.Text = invoiceHtml.ToString()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub ddlProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProduct.SelectedIndexChanged
        Try
            CalculateTotalAmount()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try

    End Sub

    Public Sub CalculateTotalAmount()
        Try
            Dim selectedProductName As String = ddlProduct.SelectedValue
            Dim selectedProduct As Product = ProductDataProvider.Products.FirstOrDefault(Function(p) p.Name = selectedProductName)
            If selectedProduct IsNot Nothing Then
                Dim totalAmount As Decimal
                Dim totalDiscount As Decimal
                Dim totalTax As Decimal
                txtPrice.Text = selectedProduct.Price.ToString("F2")
                txtQuantity.Text = selectedProduct.Quantity
                totalAmount = selectedProduct.Price * selectedProduct.Quantity
                totalDiscount = totalAmount / 10    '10% discount applied

                totalAmount = totalAmount - totalDiscount
                totalTax = totalAmount * (18 / 100)   '18% tax applied
                txtDiscount.Text = totalDiscount.ToString("F2")
                txtTax.Text = totalTax.ToString("F2")
                txtTotalAmount.Text = (totalAmount + totalTax).ToString("F2")
            End If
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub txtQuantity_TextChanged(sender As Object, e As EventArgs)
        Try
            If txtQuantity.Text > 0 Then
                CalculateTotalAmount()
            End If
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub
End Class

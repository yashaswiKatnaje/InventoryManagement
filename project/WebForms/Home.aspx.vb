Imports System
Imports System.Web.UI

Namespace Inventory.WebForms
    Public Class Home
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                LoadStatistics()
            End If
        End Sub

        Private Sub LoadStatistics()
            ' Example code to load statistics
            Dim totalProducts = ProductDataProvider.Products.Count
            Dim totalCategories = CategoryDataProvider.Categories.Count
            Dim totalCustomers = CustomerDataProvider.Customers.Count

            ' Set statistics
            totalProductsLabel.Text = totalProducts.ToString()
            totalCategoriesLabel.Text = totalCategories.ToString()
            totalCustomersLabel.Text = totalCustomers.ToString()
        End Sub
    End Class
End Namespace

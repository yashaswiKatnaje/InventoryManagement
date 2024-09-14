
Public Class ProductManagementNew
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            BindProducts()
            PopulateCategoryDropdown()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub
    Private Sub PopulateCategoryDropdown()
        Try
            ddlCategory.Items.Clear()
            Dim Categories As List(Of Category) = CategoryDataProvider.Categories

            For Each category1 As Category In Categories
                ddlCategory.Items.Add(New ListItem(category1.Name, category1.Description))
            Next

        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub
    Protected Sub AddProduct_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If ddlCategory.Items.Count > 0 Then
                Dim product As New Product() With {
                .Name = productName.Text,
                .Description = productDescription.Text,
                .Price = Convert.ToDecimal(productPrice.Text),
                .Quantity = Convert.ToInt32(productQuantity.Text),
                .Category = ddlCategory.SelectedItem.Value
                 }
                ProductDataProvider.AddProduct(product)
                BindProducts()
                clearFieds()
            Else
                lblError.Text = "Category can not be empty"
            End If


        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub
    Private Sub BindProducts()
        Try
            ProductsGridView.DataSource = ProductDataProvider.GetProducts()
            ProductsGridView.DataBind()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub ProductsGridView_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Try
            ProductsGridView.EditIndex = e.NewEditIndex
            BindProducts()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub ProductsGridView_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        Try
            Dim index As Integer = e.RowIndex
            Dim row As GridViewRow = ProductsGridView.Rows(index)
            Dim product As New Product() With {
                .Name = CType(row.Cells(0).Controls(0), TextBox).Text,
                .Description = CType(row.Cells(1).Controls(0), TextBox).Text,
                .Price = Convert.ToDecimal(CType(row.Cells(2).Controls(0), TextBox).Text),
                .Quantity = Convert.ToInt32(CType(row.Cells(3).Controls(0), TextBox).Text),
                .Category = CType(row.Cells(4).Controls(0), TextBox).Text
            }
            ProductDataProvider.UpdateProduct(index, product)
            ProductsGridView.EditIndex = -1
            BindProducts()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub ProductsGridView_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        Try
            ProductsGridView.EditIndex = -1
            BindProducts()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub ProductsGridView_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
        Try
            Dim index As Integer = e.RowIndex
            ProductDataProvider.DeleteProduct(index)
            BindProducts()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub
    Private Sub clearFieds()
        productName.Text = ""
        productDescription.Text = ""
        productPrice.Text = ""
        productQuantity.Text = ""

    End Sub
End Class
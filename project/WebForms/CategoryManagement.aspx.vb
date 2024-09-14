Public Class CategoryManagementNew
    Inherits System.Web.UI.Page


    '' Declare the controls
    'Protected WithEvents txtCategoryName1 As TextBox
    'Protected WithEvents txtCategoryDescription As TextBox
    'Protected WithEvents btnAddCategory As Button
    'Protected WithEvents lblError As Label
    'Protected WithEvents categoryList As GridView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                BindCategoryList()
            End If
        Catch ex As Exception
            lblError.Text = "Please try again"
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub btnAddCategory_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim categoryName As String = txtCategoryName.Text.Trim()
            Dim categoryDescription As String = txtCategoryDescription.Text.Trim()

            If Not String.IsNullOrEmpty(categoryName) Then
                Dim newCategory As New Category() With {
                    .Name = categoryName,
                    .Description = categoryDescription
                }
                CategoryDataProvider.AddCategory(newCategory)
                BindCategoryList()
                ClearForm()
            Else
                lblError.Text = "Category Name is required."

            End If
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Private Sub BindCategoryList()

        categoryList.DataSource = CategoryDataProvider.GetCategories()
        categoryList.DataBind()
    End Sub

    Private Sub ClearForm()
        txtCategoryName.Text = String.Empty
        txtCategoryDescription.Text = String.Empty
        lblError.Text = String.Empty
    End Sub

    Protected Sub categoryList_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Try
            Dim index As Integer = e.RowIndex
            Dim row As GridViewRow = categoryList.Rows(index)

            Dim Category As New Category() With {
            .Name = CType(row.Cells(0).Controls(0), TextBox).Text,
            .Description = CType(row.Cells(1).Controls(0), TextBox).Text
            }
            CategoryDataProvider.UpdateCategory(index, Category)
            categoryList.EditIndex = -1
            BindCategoryList()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub categoryList_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim index As Integer = e.RowIndex
            CategoryDataProvider.DeleteProduct(index)
            BindCategoryList()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub categoryList_RowEditing(sender As Object, e As GridViewEditEventArgs)
        Try
            categoryList.EditIndex = e.NewEditIndex
            BindCategoryList()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub

    Protected Sub categoryList_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        Try
            categoryList.EditIndex = -1
            BindCategoryList()
        Catch ex As Exception
            Logger.LogException(ex)
        End Try
    End Sub
End Class
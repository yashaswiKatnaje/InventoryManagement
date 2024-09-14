Imports System.Collections.Generic
Imports System.Web.UI
Namespace CustomerManagement.WebForms
    Public Class CustomerManagement
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Try
                BindCustomers()
            Catch ex As Exception
                Logger.LogException(ex)
            End Try
        End Sub
        Private Sub BindCustomers()
            CustomersGridView.DataSource = CustomerDataProvider.GetCustomers()
            CustomersGridView.DataBind()
        End Sub

        Private Sub ClearForm()
            'Clear Form inputs
            txtName.Text = ""
            txtEmail.Text = ""
            txtAddress.Text = ""
            txtContactNumber.Text = ""
        End Sub

        Protected Sub btnAddCustomer_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim customer As New Customer() With {
            .Name = txtName.Text,
            .Email = txtEmail.Text,
            .Address = txtAddress.Text,
            .ContactNumber = txtContactNumber.Text
        }
                CustomerDataProvider.AddCustomer(customer)
                BindCustomers()
                ClearForm()
            Catch ex As Exception
                Logger.LogException(ex)
            End Try
        End Sub

        Protected Sub CustomersGridView_RowEditing(sender As Object, e As GridViewEditEventArgs)
            Try
                CustomersGridView.EditIndex = e.NewEditIndex
                BindCustomers()
            Catch ex As Exception
                Logger.LogException(ex)
            End Try
        End Sub

        Protected Sub CustomersGridView_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
            Try
                Dim index As Integer = e.RowIndex
                CustomerDataProvider.DeleteCustomer(index)
                BindCustomers()
            Catch ex As Exception
                Logger.LogException(ex)
            End Try
        End Sub

        Protected Sub CustomersGridView_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
            Try
                Dim index As Integer = e.RowIndex
                Dim row As GridViewRow = CustomersGridView.Rows(index)
                Dim customer As New Customer() With {
                    .Name = CType(row.Cells(0).Controls(0), TextBox).Text,
                    .Email = CType(row.Cells(1).Controls(0), TextBox).Text,
                    .Address = CType(row.Cells(2).Controls(0), TextBox).Text,
                    .ContactNumber = CType(row.Cells(3).Controls(0), TextBox).Text
                }
                CustomerDataProvider.UpdateCustomer(index, customer)
                CustomersGridView.EditIndex = -1
                BindCustomers()
            Catch ex As Exception
                Logger.LogException(ex)
            End Try
        End Sub
    End Class
End Namespace
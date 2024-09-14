<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="CategoryManagement.aspx.vb" Inherits="InventoryManagement.CategoryManagementNew" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Category Management</h2>
        
        <!-- Form to Add New Category -->
 
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />

            <div class="form-group">
                <asp:Label ID="lblCategoryName" runat="server" Text="Category Name" AssociatedControlID="txtCategoryName" />
                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblCategoryDescription" runat="server" Text="Description" AssociatedControlID="txtCategoryDescription" />
                <asp:TextBox ID="txtCategoryDescription" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnAddCategory" runat="server" CssClass="btn btn-primary" Text="Add Category" OnClick="btnAddCategory_Click" />
        
        
        <!-- Panel to Display Categories -->
            <asp:GridView ID="categoryList" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowUpdating="categoryList_RowUpdating" OnRowDeleting="categoryList_RowDeleting" OnRowEditing="categoryList_RowEditing" OnRowCancelingEdit="categoryList_RowCancelingEdit" >
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                     <asp:BoundField DataField="Description" HeaderText="Description"/>
                     <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
    </div>
</asp:Content>
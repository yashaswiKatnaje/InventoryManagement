<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="ProductManagement.aspx.vb" Inherits="InventoryManagement.ProductManagementNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        
            <h2>Product Management</h2>
         <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            <div class="form-group">
                <label for="productName">Name</label>
                <asp:TextBox ID="productName" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                <div class="invalid-feedback">Please enter a product name.</div>
            </div>
            <div class="form-group">
                <label for="productDescription">Description</label>
                <asp:TextBox ID="productDescription" runat="server" TextMode="MultiLine" CssClass="form-control" required="required"></asp:TextBox>
                <div class="invalid-feedback">Please enter a product description.</div>
            </div>
            <div class="form-group">
                <label for="productPrice">Price</label>
                <asp:TextBox ID="productPrice" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                <div class="invalid-feedback">Please enter a product price.</div>
            </div>
            <div class="form-group">
                <label for="productQuantity">Quantity</label>
                <asp:TextBox ID="productQuantity" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                <div class="invalid-feedback">Please enter a product quantity.</div>
            </div>
            <div class="form-group">
                <label for="ddlCategory">Category</label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">

                </asp:DropDownList>
            </div>

            <asp:Button ID="AddProductButton" runat="server" Text="Add Product" CssClass="btn btn-primary" OnClick="AddProduct_Click" />
            <hr />
            <asp:GridView ID="ProductsGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="ProductsGridView_RowEditing" OnRowUpdating="ProductsGridView_RowUpdating" OnRowDeleting="ProductsGridView_RowDeleting" OnRowCancelingEdit="ProductsGridView_RowCancelingEdit" CssClass ="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>

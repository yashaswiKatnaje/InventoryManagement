<%@ Page Language="vb" MasterPageFile="~/site.master" AutoEventWireup="false" CodeBehind="CustomerManagement.aspx.vb" Inherits="InventoryManagement.CustomerManagement.WebForms.CustomerManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Customer Management</h2>
        <div class="form-group">
            <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress" Text="Address"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblContactNumber" runat="server" AssociatedControlID="txtContactNumber" Text="Contact Number"></asp:Label>
            <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnAddCustomer" runat="server" CssClass="btn btn-primary" Text="Add Customer" OnClick="btnAddCustomer_Click" />

        <asp:GridView ID="CustomersGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="CustomersGridView_RowDeleting" OnRowEditing="CustomersGridView_RowEditing" OnRowUpdating="CustomersGridView_RowUpdating" CssClass="table table-striped">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="ContactNumber" HeaderText="ContactNumber" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

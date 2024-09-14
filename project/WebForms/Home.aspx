<%@ Page Language="vb" MasterPageFile="~/site.master" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="InventoryManagement.Inventory.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid my-5">
        <div class="row mb-4">
            <!-- Navigation Cards -->
               <div class="col-lg-3 col-md-6 mb-4 extpad">
                <div class="card dashboard-card shadow-lg border-0 rounded-lg">
                    <div class="card-body text-center">
                        <i class="fas fa-tags fa-4x mb-3 text-success"></i>
                        <h5 class="card-title font-weight-bold mb-3">Manage Categories</h5>
                        <a href="CategoryManagement.aspx" class="btn btn-success btn-lg">Go to Categories</a>
                    </div>
                </div>
            </div>

            <div class="col-lg-3 col-md-6 mb-4 extpad">
                <div class="card dashboard-card shadow-lg border-0 rounded-lg">
                    <div class="card-body text-center">
                        <i class="fas fa-box fa-4x mb-3 text-primary"></i>
                        <h5 class="card-title font-weight-bold mb-3">Manage Products</h5>
                        <a href="ProductManagement.aspx" class="btn btn-primary btn-lg">Go to Products</a>
                    </div>
                </div>
            </div>
         
            <div class="col-lg-3 col-md-6 mb-4 extpad">
                <div class="card dashboard-card shadow-lg border-0 rounded-lg">
                    <div class="card-body text-center">
                        <i class="fas fa-users fa-4x mb-3 text-info"></i>
                        <h5 class="card-title font-weight-bold mb-3">Manage Customers</h5>
                        <a href="CustomerManagement.aspx" class="btn btn-info btn-lg">Go to Customers</a>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 col-md-6 mb-4 extpad">
                <div class="card dashboard-card shadow-lg border-0 rounded-lg">
                    <div class="card-body text-center">
                        <i class="fas fa-file-invoice fa-4x mb-3 text-danger"></i>
                        <h5 class="card-title font-weight-bold mb-3">Generate Invoices</h5>
                        <a href="Invoicing.aspx" class="btn btn-danger btn-lg">Go to Invoices</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <!-- Dashboard Overview -->
             <div class="col-lg-4 col-md-6 mb-4 extpad">
                <div class="card dashboard-card shadow-lg border-0 rounded-lg">
                    <div class="card-body">
                        <h5 class="card-title font-weight-bold mb-3">Category Statistics</h5>
                        <p class="font-weight-bold">Total Categories: <asp:Label ID="totalCategoriesLabel" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>

            <div class="col-lg-4 col-md-6 mb-4 extpad">
                <div class="card dashboard-card shadow-lg border-0 rounded-lg">
                    <div class="card-body">
                        <h5 class="card-title font-weight-bold mb-3">Product Statistics</h5>
                        <p class="font-weight-bold">Total Products: <asp:Label ID="totalProductsLabel" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
           
            <div class="col-lg-4 col-md-6 mb-4 extpad">
                <div class="card dashboard-card shadow-lg border-0 rounded-lg">
                    <div class="card-body">
                        <h5 class="card-title font-weight-bold mb-3">Customer Statistics</h5>
                        <p class="font-weight-bold">Total Customers: <asp:Label ID="totalCustomersLabel" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
            
        </div>
    </div>
</asp:Content>

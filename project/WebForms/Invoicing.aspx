<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Invoicing.aspx.vb" Inherits="InventoryManagement.Invoicing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Invoice Form</h2>
         <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        <div class="form-group">
            <asp:Label ID="lblCustomer" runat="server" Text="Customer" AssociatedControlID="ddlCustomer" CssClass="form-control-label"></asp:Label>
            <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control">
             
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblProduct" runat="server" Text="Product" AssociatedControlID="ddlProduct" CssClass="form-control-label"></asp:Label>
            <asp:DropDownList ID="ddlProduct" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" AutoPostBack="true">
               
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPrice" runat="server" Text="Price" AssociatedControlID="txtPrice" CssClass="form-control-label"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity" AssociatedControlID="txtQuantity" CssClass="form-control-label"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" OnTextChanged ="txtQuantity_TextChanged"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDiscount" runat="server" Text="Discount (%)" AssociatedControlID="txtDiscount" CssClass="form-control-label"></asp:Label>
            <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblTax" runat="server" Text="Tax (%)" AssociatedControlID="txtTax" CssClass="form-control-label"></asp:Label>
            <asp:TextBox ID="txtTax" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount" AssociatedControlID="txtTotalAmount" CssClass="form-control-label"></asp:Label>
            <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <asp:Button ID="btnGenerateInvoice" runat="server" CssClass="btn btn-primary" Text="Generate Invoice" OnClientClick="generateInvoice(); return false;"  />
      <%--  <asp:Literal ID="invoiceDetails" runat="server" />--%>
         
        <div class="invoice-popup" id="invoicePopup">
        <button class="close-btn" onclick="closePopup()">Close</button>
        <h2>Invoice</h2>
        <div id="invoiceContent"></div>
        <button class="print-btn" onclick="printInvoice()">Print</button>
        <button class="download-btn" onclick="downloadInvoice()">Download</button>
    </div>
    </div>
    <script>
        
        function generateInvoice() {
          
            var ddlCustomer = document.getElementById('<%= ddlCustomer.ClientID %>');
            var ddlProduct = document.getElementById('<%= ddlProduct.ClientID %>');
            var selectedCustomer = ddlCustomer.options[ddlCustomer.selectedIndex].value;
            var selectedProduct = ddlProduct.options[ddlProduct.selectedIndex].value;

            const customerName = selectedCustomer;
            const productName = selectedProduct;
            debugger;
            if (customerName != "Please Select") {
                const price = parseFloat(document.getElementById('<%=txtPrice.ClientID%>').value) || 0;
                const quantity = parseFloat(document.getElementById('<%=txtQuantity.ClientID%>').value) || 0;
                const discount = parseFloat(document.getElementById('<%=txtDiscount.ClientID%>').value) || 0;
                const tax = parseFloat(document.getElementById('<%=txtTax.ClientID%>').value) || 0;
                const totalAmount = parseFloat(document.getElementById('<%=txtTotalAmount.ClientID%>').value) || 0;


                const invoiceContent = `
                <p><strong>Customer Name:</strong> ${customerName}</p>
                <p><strong>Product Name:</strong> ${productName}</p>
                <p><strong>Price:</strong> ${price}</p>
                <p><strong>Quantity:</strong> ${quantity}</p>
                <p><strong>Discount Amount:</strong> ${discount}</p>
                <p><strong>Tax Amount:</strong> ${tax}</p>
                <p><strong>Total Amount:</strong> ${totalAmount}</p>
            `;

                document.getElementById('invoiceContent').innerHTML = invoiceContent;
                document.getElementById('invoicePopup').style.display = 'block';
                setTimeout(() => {
                    console.log("Waited 20 seconds");
                }, 20000);
            } else {
                document.getElementById('<%=lblError.ClientID%>').innerText="Please Select the Customer"
            }
            
        }

        function closePopup() {
            document.getElementById('invoicePopup').style.display = 'none';
        }

        function printInvoice() {
            const printContents = document.getElementById('invoicePopup').innerHTML;
            const originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
            window.location.reload();
        }

        function downloadInvoice() {
            const invoiceContent = document.getElementById('invoiceContent').innerHTML;
            const blob = new Blob([invoiceContent], { type: 'text/html' });
            const url = URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = 'invoice.html';
            a.click();
            URL.revokeObjectURL(url);
        }
    </script>
</asp:Content>


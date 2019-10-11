<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="DBWebApp.Protected.Invoice" %>
<%@ OutputCache Location="None" NoStore="true" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DBWebApp</title>
</head>
<body>
    <h1>Welcome Customer <asp:Label ID="CustomerIdLabel" runat="server" /></h1>
    <h4>Your Invoice</h4>
    <form id="form1" runat="server">
        <asp:GridView ID="InvoiceGridView" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="InvoiceDataSource" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="OrderDate" DataFormatString="{0:yyyy-MMM-dd}" HeaderText="Order Date" SortExpression="OrderDate" />
                <asp:BoundField DataField="ProductNo" HeaderText="Product No" SortExpression="ProductNo" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="True" SortExpression="Amount" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ObjectDataSource ID="InvoiceDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DBWebApp.ShopDataSetTableAdapters.InvoiceTableAdapter">
            <SelectParameters>
                <asp:ControlParameter ControlID="CustomerIdLabel" Name="customerId" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <p>
            <asp:LinkButton ID="LogoutLinkButton" Text="Logout" OnClick="LogoutLinkButton_Click" runat="server" />
        </p>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="DBWebApp.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DBWebApp</title>
</head>
<body>
    <h1>Our Products</h1>
    <form id="form1" runat="server">
        <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="ProductNo" DataSourceID="ProductDataSource" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="ProductNo" HeaderText="Product No" ReadOnly="True" SortExpression="ProductNo" />
                <asp:BoundField DataField="Price" HeaderText="Unit Price" SortExpression="Price" />
                <asp:BoundField DataField="Stock" HeaderText="Available Stock" SortExpression="Stock" />
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
        <asp:ObjectDataSource ID="ProductDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DBWebApp.ShopDataSetTableAdapters.ProductTableAdapter"></asp:ObjectDataSource>
    </form>
    <p>
        <asp:HyperLink NavigateUrl="Customer.aspx" runat="server">Customer Log In</asp:HyperLink>
    </p>
</body>
</html>

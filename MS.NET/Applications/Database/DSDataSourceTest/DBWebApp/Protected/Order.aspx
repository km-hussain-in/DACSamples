<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="DBWebApp.Protected.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DBWebApp</title>
</head>
<body>
    <h1>Welcome Customer <asp:Label ID="CustomerIdLabel" runat="server" /></h1>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>Product No:</td>
                <td><asp:DropDownList ID="ProductNoDropDownList" runat="server" DataSourceID="ProductDataSource" DataTextField="ProductNo" DataValueField="ProductNo" />
                    <asp:ObjectDataSource ID="ProductDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DBWebApp.ShopDataSetTableAdapters.ProductTableAdapter"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>Quantity:</td>
                <td>
                    <asp:TextBox ID="QuantityTextBox" runat="server" />
                    <asp:RequiredFieldValidator ControlToValidate="QuantityTextBox" ErrorMessage="*" runat="server" />
                    <asp:RegularExpressionValidator ControlToValidate="QuantityTextBox" ValidationExpression="[1-9][0-9]*" ErrorMessage="Number expected" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="OrderButton" Text="Order" OnClick="OrderButton_Click" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="OutputLabel" runat="server" />
                </td>
            </tr>
        </table>
        <p>
            <asp:HyperLink Text="View Your Invoice" NavigateUrl="~/Protected/Invoice.aspx" runat="server" />
        </p>
    </form>
</body>
</html>

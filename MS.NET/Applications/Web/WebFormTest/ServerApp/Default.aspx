<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServerApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ServerApp</title>
</head>
<body>
    <h1><asp:Label ID="OutputLabel" Text="Welcome Visitor" runat="server" /></h1>
    <form id="form1" runat="server">
        <p>
            <b>Person:</b>
            <asp:TextBox ID="PersonTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="PersonTextBox"></asp:RequiredFieldValidator>
        </p>
        <p>
            <b>Period:</b>
            <asp:DropDownList ID="PeriodDropDownList" runat="server">
                <asp:ListItem>Night</asp:ListItem>
                <asp:ListItem>Morning</asp:ListItem>
                <asp:ListItem>Afternoon</asp:ListItem>
                <asp:ListItem>Evening</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="GreetButton" runat="server" Text="Greet" OnClick="GreetButton_Click" />
        </p>
    </form>
</body>
</html>

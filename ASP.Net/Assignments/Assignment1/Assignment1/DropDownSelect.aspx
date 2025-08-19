<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropDownSelect.aspx.cs" Inherits="Assignment1.DropDownSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="products" runat="server" AutoPostBack="true" OnSelectedIndexChanged="products_SelectedIndexChanged"></asp:DropDownList>
            <br /><br />
            <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px"  Visible="false"/>
            <br /><br />
            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" Visible="false"/>
            <br /><br />
            <asp:Label ID="lblPrice" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>

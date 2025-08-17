<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <h1 style="color : red; text-align:center">Validation Form</h1>
        <br />
        <br />
        <br />
       <div>
            <h2>Insert your details:</h2>

            Name:
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="false" ControlToValidate="txtName" Text="* required" ErrorMessage="Name" ForeColor="Red"  />
            <br /><br />

            Family Name:
            <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="false" ControlToValidate="txtFamilyName" Text="* required" ErrorMessage="Family Name" ForeColor="Red" Display="Dynamic" />
            <asp:CompareValidator ID="CompareValidator1" runat="server" EnableClientScript="false" Text="* Family Name should be different from Name" ErrorMessage="Family Name" ControlToValidate="txtFamilyName" ControlToCompare="txtName" Operator="NotEqual" Type="String" ForeColor="Red"></asp:CompareValidator>
            <br /><br />

            Address:
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtAddress" Text="* required" ErrorMessage="Address" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="revAddress" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtAddress" ValidationExpression=".{2,}" Text="* must be atleast 2 chars" ErrorMessage="Address" ForeColor="Red" >* must be atleast 2 chars</asp:RegularExpressionValidator>
            <br /><br />

            City:
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtCity" Text="* required" ErrorMessage="Ciy" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="revCity" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtCity" ValidationExpression=".{2,}" Text="* must be atleast 2 chars" ErrorMessage="City" ForeColor="Red" >* must be atleast 2 chars</asp:RegularExpressionValidator>
            <br /><br />

            Zip Code:
            <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtZip" Text="* required" ErrorMessage="Zip Code" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="revZip" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtZip" ValidationExpression="^\d{6}$" Text="* Should be Equal to 6 digits" ErrorMessage="Zip Code" ForeColor="Red" >* Should be Equal to 6 digits</asp:RegularExpressionValidator>
            <br /><br />

            Phone:
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtPhone" Text="* required" ErrorMessage="Phone" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="revPhone" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtPhone" ValidationExpression="^\d{2,3}-\d{7}$" Text="* Should be in the Format (xx-xxxxxxx or xxx-xxxxxxx)" ErrorMessage="Phone" ForeColor="Red" >* Should be in the Format (xx-xxxxxxx or xxx-xxxxxxx)</asp:RegularExpressionValidator>
            <br /><br />

            E-Mail:
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtEmail" Text="* required" ErrorMessage="EMail" ForeColor="Red" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" EnableClientScript="false" Display="Dynamic" ControlToValidate="txtEmail" ValidationExpression="^[\w\.-]+@[\w\.-]+\.\w{2,}$" Text="* Invalid email" ErrorMessage="Email" ForeColor="Red" >* Invalid email</asp:RegularExpressionValidator>
            <br /><br />

            <asp:Button ID="btnSubmit" runat="server" Text="Check" OnClick="btnSubmit_Click"/>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
       </div>
    </form>
</body>
</html>

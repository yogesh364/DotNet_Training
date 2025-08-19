<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="BilingPortal.aspx.cs" Inherits="EB_Prj.BilingPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PrimaryContent" runat="server">
    <style>
        .form-container {
            width: 400px;
            margin: 50px auto;
            background: white; padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px #aaa;
        }
        .form-container h2 {
            text-align: center;
        }
        .form { 
            margin-bottom: 12px; 
            padding : 20px 10px;

        }
        .form label { 
            display: block; 
            font-weight: bold;
             margin-bottom: 20px; 

        }
        .form input {
            width: 95%;
            padding: 8px;
        }
        .btn { 
            padding: 8px 16px;
            margin-top: 10px;
            cursor: pointer; 

        }
        .btn-primary { 
            background: #007BFF;
            color: white;
            border: none; 
            border-radius: 5px;

        }
    </style>
    
    <form id="form1" runat="server">
    <div class="form-container">
        <h2>Electricity Billing Portal</h2>
       <div class="form">
            <asp:Label ID="txtlbl1" runat="server" Text="Enter Number of Bills to Add : "></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtno" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* required" ControlToValidate="txtno" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtno" ValidationExpression="^\d+$" ErrorMessage="* Only Numbers Allowed" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>

        <div class="form">
            <asp:Label ID="txtlbl2" runat="server" Text="Enter The Customer Number : " ></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtcustno" runat="server" OnTextChanged="txtcustno_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* required" ControlToValidate="txtcustno" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtcustno" ValidationExpression="^EB\d{5}$" ErrorMessage="* Must be EB followed by 5 digits (e.g., EB12345)" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtcustno" OnServerValidate="CustomValidator1_ServerValidate" ErrorMessage="* Customer ID already exists!" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>

        </div>

        <div class="form">
            <asp:Label ID="txtlbl3" runat="server" Text="Enter The Customer Name : "></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* required" ControlToValidate="txtname" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtname" ValidationExpression="^[A-Za-z\s]+$" ErrorMessage="* Only Alphabets Allowed" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>

        <div class="form">
            <asp:Label ID="txtlbl4" runat="server" Text="Enter The Units Consumed : "></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtunits" runat="server" AutoPostBack="true" OnTextChanged="txtunits_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* required" ControlToValidate="txtunits" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtunits" ValidationExpression="^\d+$" ErrorMessage="* Only Numbers Allowed" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
        </div>

        <div class="form">
         <asp:Label ID="txtlbl5" runat="server" Text="The Bill Amount : "></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtamt" runat="server" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="form" id="success" runat="server" visible="false">
         <asp:Label ID="txtsuccess" runat="server" Text="The Bill Added Successfully" ForeColor="Green"></asp:Label>
        </div>

         <div class="form">
                <asp:Button ID="btnSave" Text="Save Bill" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click"  />
         </div>

        <div class="form">
            <asp:Button ID="btnRetrieve" Text="Retrieve Bills" CssClass="btn btn-primary" runat="server"  Visible="false" OnClick="btnRetrieve_Click" CausesValidation="false" />
        </div>
    </div>
    </form>
</asp:Content>

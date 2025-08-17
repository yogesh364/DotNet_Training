<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="EB_Prj.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        body, html {
             height: 100%;
             margin: 0;
        }
        body{
            display : flex;
            justify-content: center;
            align-items:center;
            background-color :#51d0de;
        }
        .center{
            width: 400px;
            height: 380px;
            text-align : center;
            border-radius : 50px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            background-color: #d9d9d9;
            color: #2c3e50;

        }
        p{
            text-align : left;
            padding : 0 0 0 20px;
            margin-left: 40px;
        }
        .btn{
            height : 30px;
            width : 60px;
            border-radius: 5px;
            background-color: #4a90e2;
            transition : transform 0.3s ease;
        }
        .btn:hover{
            height : 40px;
            width : 70px;
            border-radius : 7px;
            background-color: #357ABD;
            font-size : 15px;
            padding-bottom : 3px;
        }
        #txtmail #txtpass{
            border-radius : 10px;
        }

        .input-row {
         display: flex;
         align-items: center;
         gap: 10px;
         justify-content: center;
         margin-bottom: 10px;
        }

        .validator {
         font-size: 20px;
        color: red;
        }  
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">
            <h2 class="mid" style="padding : 20px 0 0 0;">Sign In</h2>
          
            <p>&nbsp;</p>
            <p>Enter Your Email:</p>
            <div class="input-row">
             <asp:TextBox ID="txtmail" runat="server" Width="169px" CssClass="mid" Height="24px"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="txtmail" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator>
            </div>
            <br />
            <p>Enter Your Password:</p>
            <div class="input-row">
            <asp:TextBox ID="txtpass" runat="server" Width="169px" CssClass="mid" Height="24px" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* required" ForeColor="Red" ControlToValidate="txtpass" Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="LogIn" CssClass="btn" BackColor="#0099CC" ForeColor="White" OnClick="Button1_Click"/>

        </div>
    </form>
</body>
</html>

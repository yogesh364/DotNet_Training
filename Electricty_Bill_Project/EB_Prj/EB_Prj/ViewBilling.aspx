<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewBilling.aspx.cs" Inherits="EB_Prj.ViewBilling" %>
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
        <h2>View Biling Portal</h2>
       <div class="form">
            <asp:Label ID="txtlbl1" runat="server" Text="Enter The Starting Date : "></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtst" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* required" ControlToValidate="txtst" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form">
            <asp:Label ID="txtlbl2" runat="server" Text="Enter The Ending Date : "></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtend" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* required" ControlToValidate="txtend" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

         <div class="form">
                <asp:Button ID="btnGet" Text="View Bills" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click"  />
         </div>
    </div>
    </form>
</asp:Content>

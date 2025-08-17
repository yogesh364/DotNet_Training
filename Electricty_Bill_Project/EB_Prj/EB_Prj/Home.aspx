<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EB_Prj.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PrimaryContent" runat="server">
    <style>

    .wel-container{
        padding : 20px 40px;
        text-align : center;
    }

    .welcome-msg {
        font-size: 24px;
        font-weight: bold;
        color: #004466;
        margin: 20px 0;
    }

    .container{
        display: flex;
        justify-content : space-evenly;
        padding : 40px 0;
    }
    .home-card-link {
        text-decoration: none;
        color: inherit;
    }

    .home-card-link:hover {
        text-decoration: none;
    }

    .home-card {
        background-color: #ffffff;
        width: 280px;
        padding: 30px 20px;
        border-radius: 12px;
        box-shadow: 0 4px 15px rgba(0,0,0,0.1);
        text-align: center;
        transition: transform 0.3s ease;
    }

    .home-card:hover {
        transform: translateY(-8px);
        box-shadow: 0 6px 18px rgba(0,0,0,0.15);
    }

    .stats {
        display: flex;
        justify-content: space-around;
        background-color: #e0f0f5;
        padding: 30px 20px;
        text-align: center;
    }

    .stat h3 {
         font-size: 28px;
        color: #006699;
         margin: 0;
    }

    .stat p {
        font-size: 14px;
        color: #333;
        margin-top: 5px;
    }        

    </style>

   
    <div class="wel-container">
    <asp:Label ID="lblWelcome" runat="server" Text="Welcome, Admin!" CssClass="welcome-msg"></asp:Label>

    </div>

    <div class="container">
        <a href="BilingPortal.aspx" class="home-card-link">
        <div class="home-card">
            <h3>Add New Bill</h3>
            <p>Create and upload a new electricity bill for a consumer.</p>
        </div>
        </a>

        <a href="ViewBilling.aspx" class="home-card-link">
        <div class="home-card">
            <h3>View All Bills</h3>
            <p>Access, manage, and download existing consumer bills.</p>
        </div>
        </a>
    </div>

    <section class="stats">
        <div class="stat">
            <h3><asp:Label ID="lblTotalBills" runat="server" /></h3>
            <p>Total Bills</p>
        </div>
        <div class="stat">
            <h3><asp:Label ID="lblTotalUnits" runat="server" /></h3>
            <p>Total Units</p>
        </div>
        <div class="stat">
            <h3>₹<asp:Label ID="lblTotalRevenue" runat="server" /></h3>
            <p>Total Revenue</p>
        </div>
    </section>
</asp:Content>

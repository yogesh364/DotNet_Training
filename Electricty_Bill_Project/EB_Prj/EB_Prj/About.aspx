<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="EB_Prj.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PrimaryContent" runat="server">
    <style>
        .heading {
            background-color: #004466;
            color: white;
            text-align: center;
            padding: 50px 0 50px 0;
        }

        .heading h1 {
            font-size: 36px;
            margin-bottom: 10px;
        }

        .heading p {
            font-size: 18px;
            color: #cde6f5;
        }

        .cards {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            gap: 30px;
            padding: 40px 20px;
            background-color: #f4f4f4;
        }

        .card {
            background-color: white;
            border-radius: 10px;
            padding: 30px;
            width: 300px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }

        .card:hover {
            transform: translateY(-5px);
        }

        .card h2 {
            color: #004466;
            margin-bottom: 15px;
        }

        .card p {
            color: #444;
            font-size: 15px;
            line-height: 1.6;
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

    <section class="heading">
        <h1>Empowering Tamil Nadu</h1>
        <p>Your trusted electricity provider since 1957</p>
    </section>

    <section class="cards">
        <div class="card">
            <h2>Who We Are</h2>
            <p>
                Tamil Nadu Electricity Board (TNEB) is a state-owned power utility serving millions of consumers across Tamil Nadu. 
                With decades of expertise, we ensure efficient generation, transmission, and distribution of electricity.
            </p>
        </div>

        <div class="card">
            <h2>Our Vision</h2>
            <p>
                To deliver uninterrupted, sustainable and clean energy, using cutting-edge technology to fuel Tamil Nadu’s progress.
            </p>
        </div>

        <div class="card">
            <h2>Our Mission</h2>
            <p>
                We are committed to providing affordable electricity with transparency, reliability and customer satisfaction at the core.
            </p>
        </div>
    </section>

    <section class="stats">
        <div class="stat">
            <h3>75M+</h3>
            <p>Consumers Served</p>
        </div>
        <div class="stat">
            <h3>24x7</h3>
            <p>Customer Service</p>
        </div>
        <div class="stat">
            <h3>₹5000 Cr+</h3>
            <p>Invested in Infrastructure</p>
        </div>
    </section>

</asp:Content>

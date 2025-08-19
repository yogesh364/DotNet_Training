<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrieveRecent.aspx.cs" Inherits="EB_Prj.RetrieveRecent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            display: flex;
            justify-content: center;   
            align-items: center;     
            min-height: 100vh;      
            margin: 0;
            background: #f5f7fa;     
        }
        .container {
            width: 800px;
            margin: 40px auto;
            background: #fff;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
            padding: 20px 30px;
            font-family: Arial, sans-serif;
            text-align : center;
        }
        .btn{
            display: inline-block;
            padding: 10px 20px;
            margin-top: 15px;
            background: #007BFF;
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            transition: background 0.3s;
            text-decoration: none;
        }

        .btn:hover {
            background: #0056b3;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Latest Added Bills
            </h1>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Width="791px" AutoGenerateColumns="False" DataKeyNames="Bill_ID">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="Bill_ID" HeaderText="Bill_ID" InsertVisible="False" ReadOnly="True" SortExpression="Bill_ID" />
                    <asp:BoundField DataField="Customer_number" HeaderText="Customer_number" SortExpression="Customer_number" />
                    <asp:BoundField DataField="Customer_name" HeaderText="Customer_name" SortExpression="Customer_name" />
                    <asp:BoundField DataField="Units_consumed" HeaderText="Units_consumed" SortExpression="Units_consumed" />
                    <asp:BoundField DataField="Bill_amount" HeaderText="Bill_amount" SortExpression="Bill_amount" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElectricityBillDBConnectionString %>" SelectCommand="SELECT TOP (@count) Bill_ID, Customer_number, Customer_name, Units_consumed, Bill_amount FROM customer
ORDER BY Bill_ID DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="2" Name="count" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" Text="Go Back" CssClass="btn" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>

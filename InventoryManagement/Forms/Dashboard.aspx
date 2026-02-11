<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="InventoryManagement.Forms.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-weight: 700">
        &nbsp;<asp:Label ID="Label1" runat="server" Text="Products"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" CellPadding="5" Enabled="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <br />
            <br />
            <asp:Button ID="StockInBtn" runat="server" OnClick="StockInBtn_Click" Text="StockIn" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="StockOutBtn" runat="server" OnClick="StockOutBtn_Click" Text="StockOut" />
        </div>
    </form>
</body>
</html>

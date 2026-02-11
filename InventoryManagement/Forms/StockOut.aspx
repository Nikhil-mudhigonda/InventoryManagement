<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOut.aspx.cs" Inherits="InventoryManagement.Forms.StockOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" CellPadding="5">
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="StockOutProductlbl" runat="server" Text="Products"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="StockOutDropDownList" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="StockOutQtylbl" runat="server" Text="Quantity"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="StockOutQtyTxt" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="StockOutBtn" runat="server" OnClick="StockOutBtn_Click" Text="StockOut" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="StockOutBackbtn" runat="server" Text="Back" />
            <br />
            <br />
            <asp:Label ID="stockOutInfolbl" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>

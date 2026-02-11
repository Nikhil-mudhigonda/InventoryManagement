<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockIn.aspx.cs" Inherits="InventoryManagement.Forms.StockIn" %>

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
            <asp:Label ID="Productslbl" runat="server" Text="Products"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ProductsDropDownList" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Supplierlbl" runat="server" Text="Supplier"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="SupplierDropDownList" runat="server">
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Quantitylbl" runat="server" Text="Quantity"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="QtyTxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="StockInBtn" runat="server" OnClick="StockInBtn_Click" Text="StockIn" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="StockInBackBtn" runat="server" OnClick="StockInBackBtn_Click" Text="Back" />
            <br />
            <br />
            <asp:Label ID="StockInInfolbl" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

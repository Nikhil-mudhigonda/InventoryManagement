s<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="InventoryManagement.Forms.ignIn" %>

<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title></title></head><body><form id="form1" runat="server">
        <div>
            <asp:Label ID="SgnUsername" runat="server" Text="Username"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="SgnUsernameTxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="SgnPassword" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="SgnPasswordTxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Rolelbl" runat="server" Text="Role"></asp:Label>
            <asp:RadioButtonList ID="RoleButtonList1" runat="server">
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>Management</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="SigninBtn" runat="server" OnClick="SigninBtn_Click1" Text="SignIn" />
            <br />
            <asp:Label ID="SignInTxt" runat="server" Text="Already sign in? please "></asp:Label>
&nbsp;<asp:Button ID="sgnloginBtn" runat="server" OnClick="sgnloginBtn_Click1" Text="Login" />
&nbsp;<asp:Label ID="Label3" runat="server" Text="here"></asp:Label>
            <br />
            <br />
            <asp:Label ID="InfoTxt" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>


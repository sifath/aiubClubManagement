<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="aiubClubs.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="content/site.css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div id ="logInPanel">
        <h2>Log in</h2>
        <br/>
        <asp:Label ID="LabeluserId" runat="server" Text="User Id"></asp:Label>
        <br/>
        <asp:TextBox ID="TextBoxuserId" runat="server"></asp:TextBox>
        <br/><br/>
        <asp:Label ID="Labelpassword" runat="server" Text="Password"></asp:Label>
        <br/>
        <asp:TextBox ID="TextBoxpassword" runat="server" TextMode="Password"></asp:TextBox>
        <br/><br/>
        <asp:Button ID="ButtonlogIn" runat="server" Text="Log In" OnClick="ButtonlogIn_Click" />
        <br /><br />
        <asp:Label ID="labelErrorMassege" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Label ID="LabelnoAccount" runat="server" Text="To Register as a New Member ?"></asp:Label>
        <asp:LinkButton ID="LinkButtonclickHere" runat="server" OnClick="LinkButtonclickHere_Click">Click Here</asp:LinkButton>
    </div>
    </form>
</body>
</html>

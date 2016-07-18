<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrationPage.aspx.cs" Inherits="aiubClubs.registrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/content/site.css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div id = "registration">
        <h2>Registration</h2>
        <br /> 
        <asp:Label ID="LabeluserId" runat="server" Text="User Id"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxuserId" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabeluserName" runat="server" Text="Name"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxuserName" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="Labelpassword" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxpassword" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabelrePassword" runat="server" Text="Retype Password"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxrePassword" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="Labelemail" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxemail" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="Labelphone" runat="server" Text="Phone"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxphone" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabelaiubId" runat="server" Text="AIUB Id"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxaiubId" runat="server"></asp:TextBox>  
        <br /><br />
        Select the Clubs where You Want to join
        <br/>
        <asp:CheckBoxList ID="CheckBoxListClubs" runat="server"></asp:CheckBoxList>
        <br /><br />
        <asp:Label ID="labelErrorMassege" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:Button ID="Buttonregister" runat="server" Text="Register" OnClick="Buttonregister_Click" />
    </div>
    </form>
</body>
</html>

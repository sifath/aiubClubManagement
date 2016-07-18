<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="aiubClubs.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

      <script src="content/bootstrap/js/jquery-1.11.3.min.js"></script>
  <link href="content/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
  <script src="content/bootstrap/js/bootstrap.min.js"></script>
  <link rel="stylesheet" type="text/css" href="content/site.css"/>

</head>
<body>

        <nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">AIUB Club Managment System</a>
    </div>
    <ul class="nav navbar-nav">
        <li><a href="profile.aspx">Profile</a></li>
      <li><a href="logout.aspx">Logout</a></li>

    </ul>
  </div>
</nav>

    <br/><br/>

    <form id="form1" runat="server">
    <div id = "registration">

        <h2>Change Your Profile Here</h2>
        <br /> 
        <asp:Label ID="LabeluserId" runat="server" Text="User Id"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxuserId" runat="server" ReadOnly="True"></asp:TextBox>    
        <br /><br />
        Change Name<br />
        <asp:TextBox ID="TextBoxchangeUserName" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabeloldPassword" runat="server" Text="Old Password"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxoldPassword" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabelnewPassword" runat="server" Text="New Password"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxnewPassword" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabelrePassword" runat="server" Text="Retype Password"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxrePassword" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabelchangeEmail" runat="server" Text="Change Email"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxchangeEmail" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabelchangePhone" runat="server" Text="Change Phone"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxchangePhone" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabelaiubId" runat="server" Text="AIUB Id"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxaiubId" runat="server" ReadOnly="True"></asp:TextBox>  
        <br /><br />
        <asp:Label ID="labelErrorMassege" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="LabelerrorMessege2" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="Buttonregister_Click" />
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createEvent.aspx.cs" Inherits="aiubClubs.createEvent" %>

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
      <li class="active"><a href="president.aspx">Home</a></li>
        <li><a href="profile.aspx">Profile</a></li>
      <li><a href="logout.aspx">Logout</a></li>

    </ul>
  </div>
</nav>

    <br/><br/>


    <form id="form1" runat="server">
    <div id = "createEvent">
        <h2><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2>
        <br />
        <asp:Label ID="LabelClubId" runat="server" Text="" Visible="False"></asp:Label>

        <asp:Label ID="LabeleventName" runat="server" Text="Event Name"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxeventName" runat="server"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabeleventDate" runat="server" Text="Event Date"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxeventDate" runat="server" TextMode="DateTimeLocal"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="LabeleventDetail" runat="server" Text="Event Detail"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxeventDetail" runat="server" TextMode="MultiLine"></asp:TextBox>    
        <br /><br />
        <asp:Label ID="labelErrorMassege" runat="server" Text=""></asp:Label>
        <asp:Button ID="ButtoncreateEvent" runat="server" Text="Create Event" OnClick="ButtoncreateEvent_Click" />
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registered.aspx.cs" Inherits="aiubClubs.registered" %>

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
      <li class="active"><a href="registered.aspx">Home</a></li>
        <li><a href="profile.aspx">Profile</a></li>
      <li><a href="logout.aspx">Logout</a></li>

    </ul>
  </div>
</nav>



    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabeluName" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="LabeluId" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="LabeluType" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:LinkButton ID="LinkButtonredirectToProfile" runat="server" OnClick="LinkButtonredirectToProfile_Click">Manage Profile</asp:LinkButton>
        <br />
        <br />
        <h2>All the events of Your Club</h2>
        <asp:GridView ID="GridViewclubEvents" runat="server" AutoGenerateColumns="False" DataKeyNames="eventId">
            <Columns>
                <asp:BoundField DataField="eventId" HeaderText="Event Id" InsertVisible="False" ReadOnly="True" SortExpression="eventId" />
                <asp:BoundField DataField="clubId" HeaderText="Club Id" SortExpression="clubId" />
                <asp:BoundField DataField="eventName" HeaderText="Event Name" SortExpression="eventName" />
                <asp:BoundField DataField="eventDate" HeaderText="Event Date" SortExpression="eventDate" />
                <asp:BoundField DataField="eventDetail" HeaderText="Detail" SortExpression="eventDetail" />
            </Columns>

        </asp:GridView>
        <br />
        <br />
        <h2>Events you assigned in</h2>
        <asp:GridView ID="GridViewassignedEvents" runat="server" AutoGenerateColumns="False" DataKeyNames="eventId">
            <Columns>
                <asp:BoundField DataField="eventId" HeaderText="Event Id" InsertVisible="False" ReadOnly="True" SortExpression="eventId" />
                <asp:BoundField DataField="clubId" HeaderText="Club Id" SortExpression="clubId" />
                <asp:BoundField DataField="eventName" HeaderText="Event Name" SortExpression="eventName" />
                <asp:BoundField DataField="eventDate" HeaderText="Event Date" SortExpression="eventDate" />
                <asp:BoundField DataField="eventDetail" HeaderText="Detail" SortExpression="eventDetail" />
            </Columns>
        </asp:GridView>

      
    
    </div>
    </form>
</body>
</html>

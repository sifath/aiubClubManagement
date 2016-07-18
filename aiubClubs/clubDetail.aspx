<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clubDetail.aspx.cs" Inherits="aiubClubs.clubDetail" %>

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
      <li class="active"><a href="~/admin.aspx">Home</a></li>
        <li><a href="profile.aspx">Profile</a></li>
      <li><a href="logout.aspx">Logout</a></li>

    </ul>
  </div>
</nav>

    <br/><br/>

    <form id="form1" runat="server">
    <div>
    <h2>Detail of <asp:Label ID="clubName" runat="server" Text=""></asp:Label></h2>
        <hr/>
        <h3>Number of Members of this club:  <asp:Label ID="memberNo" runat="server" Text=""></asp:Label></h3>

        <hr/><br/>
        <h3>Search Eveny By Time Bound</h3>
        From&nbsp;&nbsp;
        <asp:TextBox ID="startDate" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;to&nbsp;&nbsp;
        <asp:TextBox ID="endDate" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br/><br/>
        <h3>Number of Events Arranged By This Club: <asp:Label ID="eventNo" runat="server" Text=""></asp:Label></h3>
        <h3>Event List:</h3>
        <asp:GridView ID="events" runat="server" AutoGenerateColumns="False" DataKeyNames="eventId">
            <Columns>
                <asp:BoundField DataField="eventId" HeaderText="Event Id" InsertVisible="False" ReadOnly="True" SortExpression="eventId" />
                <asp:BoundField DataField="clubId" HeaderText="Club Id" SortExpression="clubId" ReadOnly="True" />
                <asp:BoundField DataField="eventName" HeaderText="Event Name" SortExpression="eventName" />
                <asp:BoundField DataField="eventDate" HeaderText="Event Date" SortExpression="eventDate" />
                <asp:BoundField DataField="eventDetail" HeaderText="Event Detail" SortExpression="eventDetail" />
            </Columns>
        </asp:GridView>


    </div>
    </form>
</body>
</html>

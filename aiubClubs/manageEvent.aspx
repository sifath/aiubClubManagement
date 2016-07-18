<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageEvent.aspx.cs" Inherits="aiubClubs.manageEvent" %>

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
    <div>
        <h2>Events List of You Club</h2>
        <asp:GridView ID="events" runat="server" AutoGenerateColumns="False" DataKeyNames="eventId" OnSelectedIndexChanged="events_SelectedIndexChanged" OnRowCancelingEdit="events_RowCancelingEdit" OnRowDeleting="events_RowDeleting" OnRowEditing="events_RowEditing" OnRowUpdating="events_RowUpdating">
            <Columns>
                <asp:BoundField DataField="eventId" HeaderText="Event Id" InsertVisible="False" ReadOnly="True" SortExpression="eventId" />
                <asp:BoundField DataField="clubId" HeaderText="Club Id" SortExpression="clubId" ReadOnly="True" />
                <asp:BoundField DataField="eventName" HeaderText="Event Name" SortExpression="eventName" />
                <asp:BoundField DataField="eventDate" HeaderText="Event Date" SortExpression="eventDate" />
                <asp:BoundField DataField="eventDetail" HeaderText="Event Detail" SortExpression="eventDetail" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:CommandField SelectText="Add/Remove Member" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
       
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="managePresidents.aspx.cs" Inherits="aiubClubs.managePresidents" %>

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
      <li class="active"><a href="admin.aspx">Home</a></li>
        <li><a href="profile.aspx">Profile</a></li>
      <li><a href="logout.aspx">Logout</a></li>

    </ul>
  </div>
</nav>

    <br/><br/>

    <form id="form1" runat="server">
    <div>
    
        

        <h2 class="modal-title">Appoint/Change President for <asp:Label ID="LabelClubName" runat="server" Text=""></asp:Label></h2>
<hr/>
          <h3>Current Presidents List</h3>
       
          <asp:GridView ID="currentPresidents" runat="server" AutoGenerateColumns="False" DataKeyNames="userId" OnRowDeleting="currentPresidents_RowDeleting" >
             <Columns>
                 <asp:BoundField DataField="userId" HeaderText="userId" ReadOnly="True" SortExpression="userId" />
                 <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" Visible="False" />
                 <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                 <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                 <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="phone" />
                 <asp:BoundField DataField="type" HeaderText="type"  SortExpression="type"/>
                 
                 <asp:CommandField DeleteText="Dismiss Presidency" ShowDeleteButton="True" />
             </Columns>
          </asp:GridView>
          <br/><br/>
          <hr/>
          <br/>

          <h3>Search an User Id to Appoint President</h3>
          <asp:TextBox ID="userId" runat="server"></asp:TextBox>
          <asp:Button ID="search" runat="server" Text="Search" OnClick="search_Click" />

          <br/><br/>
          <h3>Members List</h3>
         <asp:GridView ID="clubMembers" runat="server" AutoGenerateColumns="False" DataKeyNames="userId" OnSelectedIndexChanged="clubMembers_SelectedIndexChanged">
             <Columns>
                 <asp:BoundField DataField="userId" HeaderText="userId" ReadOnly="True" SortExpression="userId" />
                 <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" Visible="False" />
                 <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                 <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                 <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="phone" />
                 <asp:BoundField DataField="type" HeaderText="type"  SortExpression="type"/>
                 
                 <asp:CommandField SelectText="Appoint" ShowSelectButton="True" />
             </Columns>
              
          </asp:GridView>



    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="president.aspx.cs" Inherits="aiubClubs.president" %>

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
    <div id="presidentHome">
        <br/><br/><br/><br/><br/> 
        <button id="btnPendingRequests" type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">
            <asp:Label ID="LabelPendingRequests" runat="server" Text="Pending Requests"></asp:Label>
        </button>
        <br/><br/><br/> 
        
            <ul>
                <li><a href="manageEvent.aspx">Manage Events</a></li>
                <li><a href="createEvent.aspx">Create New Events</a></li>
               <!-- <li><a href="manageMembers.aspx">Manage Club Members</a></li> -->
                <li><a href="profile.aspx">Manage Your Profile</a></li>
            </ul>


 <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Pending Requests</h4>
      </div>
      <div class="modal-body">
           <asp:ScriptManager runat="server" ID="sm">
            </asp:ScriptManager>
            <asp:updatepanel runat="server">
                <ContentTemplate>
                   
          <asp:GridView ID="GridViewPendingRequests" runat="server" AutoGenerateColumns="False" DataKeyNames="userId,clubChoices" OnRowDeleting="GridViewPendingRequests_RowDeleting" OnSelectedIndexChanged="GridViewPendingRequests_SelectedIndexChanged">
             <Columns>
                 <asp:BoundField DataField="userId" HeaderText="userId" ReadOnly="True" SortExpression="userId" />
                 <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" Visible="False" />
                 <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                 <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                 <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="phone" />
                 <asp:BoundField DataField="aiubId" HeaderText="AIUB Id" SortExpression="aiubId" />
                 <asp:BoundField DataField="clubChoices" HeaderText="Club Choices" ReadOnly="True" SortExpression="clubChoices" Visible="False" />
                 
                 <asp:CommandField ShowDeleteButton="True" DeleteText="Reject" />
                 <asp:CommandField SelectText="Accept" ShowSelectButton="True" />
             </Columns>
              
          </asp:GridView>

                </ContentTemplate>
            </asp:updatepanel>
 
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>


    </div> 
    </form>

</body>
</html>

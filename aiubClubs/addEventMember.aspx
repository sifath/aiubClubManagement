<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addEventMember.aspx.cs" Inherits="aiubClubs.addEventMember" %>

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


    <br/><br/>

    <form id="form1" runat="server">
    <div>
        
       <asp:ScriptManager runat="server" ID="sm">
          </asp:ScriptManager>
          <asp:updatepanel runat="server">
              <ContentTemplate>
                <h2>Existing Members of the event</h2> 
        <asp:GridView ID="GridViewExistingMembers" runat="server" AutoGenerateColumns="False" DataKeyNames="userId"  OnRowDeleting="GridViewExistingMembers_RowDeleting">
            <Columns>
                <asp:BoundField DataField="userId" HeaderText="userId" ReadOnly="True" SortExpression="userId" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" Visible="False" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                <asp:BoundField DataField="aiubId" HeaderText="aiubId" SortExpression="aiubId" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type"/>
               
                <asp:CommandField DeleteText="Remove From Event" ShowDeleteButton="True" />
               
            </Columns>
        </asp:GridView>



        <br/><br/><br/><br/>
 
           
               <h2>Add New Members to the Event</h2> 
        <asp:GridView ID="GridViewClubMembers" runat="server" AutoGenerateColumns="False" DataKeyNames="userId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="userId" HeaderText="userId" ReadOnly="True" SortExpression="userId" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" Visible="False" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                <asp:BoundField DataField="aiubId" HeaderText="aiubId" SortExpression="aiubId" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type"/>
                <asp:CommandField SelectText="Add to Event" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
                   
         </ContentTemplate>
        </asp:updatepanel>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="aiubClubs.admin" %>

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
        <asp:Label ID="LabeladminName" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:LinkButton ID="LinkButtonmanageProfiel" runat="server" OnClick="LinkButtonmanageProfiel_Click">Manage Profile</asp:LinkButton>
        <br />
        <br />
        <h2>Create A Club</h2>
        <br />
        Club Name:<br />
&nbsp;<asp:TextBox ID="TextBoxclubName" runat="server"></asp:TextBox>
        <br />
        <br />
        Inaugration Date:<br />
&nbsp;<asp:TextBox ID="TextBoxiDate" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="labelErrorMassege" runat="server" Text="" ></asp:Label>
        <br />
        <asp:Button ID="ButtoncreateClub" runat="server" Text="Create Club" OnClick="ButtoncreateClub_Click" style="height: 26px" />
        <br /><br /><br />
        <hr/>
        <br />
        <h2>All Clubs</h2>

        <asp:GridView ID="GridViewClubs" runat="server" AutoGenerateColumns="False" DataKeyNames="clubId" OnRowCommand="GridViewClubs_RowCommand" >
            <Columns>
                <asp:BoundField DataField="clubId" HeaderText="clubId" InsertVisible="False" ReadOnly="True" SortExpression="clubId" />
                <asp:BoundField DataField="clubName" HeaderText="clubName" SortExpression="clubName" />
                <asp:BoundField DataField="inagurationDate" HeaderText="inagurationDate" SortExpression="inagurationDate" />

            <asp:TemplateField>
                <ItemTemplate>
                <asp:Button ID="btndetail" runat="server" CommandName="detail" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="Detail" OnClientClick='$("#detailModal").modal()' />
                </ItemTemplate> 
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                <asp:Button ID="btnAppointPresident" runat="server" CommandName="appointPresident" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="Appoint/Change President" OnClientClick='$("#apointPresidentModal").modal()' />
                </ItemTemplate> 
            </asp:TemplateField>
            </Columns>
        </asp:GridView>


    
        <br/><br/>


        
    </form>



</body>
</html>

using aiubClubs.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aiubClubs
{
    public partial class president : System.Web.UI.Page
    {
        string clubId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] == null || Session["userType"].ToString().Trim() != "President")
            {
                Response.Redirect("~/home.aspx");
            }

            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM clubs WHERE clubId=(SELECT clubId From presidents WHERE president='" + Session["currentUser"] + "')", "clubs", new string[] { "clubId" });
            DataSet ds = (DataSet)Cache["dataSet"];

            this.clubId = ds.Tables["clubs"].Rows[0]["clubId"].ToString();

            loadGridView();

           
        }


        private void loadGridView()
        {
            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM pendingRequests WHERE clubChoices='"+ clubId + "'", "pendingRequests", new string[] { "userId", "clubChoices" });
            DataSet ds = (DataSet)Cache["dataSet"];

            GridViewPendingRequests.DataSource = ds.Tables["pendingRequests"];
            GridViewPendingRequests.DataBind();
        }

        protected void GridViewPendingRequests_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM pendingRequests", "pendingRequests", new string[] { "userId", "clubChoices" });
            DataSet ds = (DataSet)Cache["dataSet"];

            DataRow dr = ds.Tables["pendingRequests"].Rows.Find(new object []{ e.Keys["userId"],e.Keys["clubChoices"]});
            dr.Delete();
            dbAccess.updateDatabase("pendingRequests");
            
            this.loadGridView();
        }

        protected void GridViewPendingRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewPendingRequests.SelectedRow;
            //Response.Write("[0]: "+row.Cells[0].Text+ "<br/>[6]: " + row.Cells[6].Text);

            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM pendingRequests WHERE status='unapproved' AND clubChoices='"+clubId+"'", "pendingRequests", new string[] { "userId", "clubChoices" });
            DataSet ds = (DataSet)Cache["dataSet"];

            DataRow dr = ds.Tables["pendingRequests"].Rows.Find(new object[] { (object)row.Cells[0].Text.ToString().Trim(), (object)clubId });
            string[] selectedRow = {
                dr["userId"].ToString(),
                dr["password"].ToString(),
                dr["name"].ToString(),
                dr["email"].ToString(),
                dr["phone"].ToString(),
                dr["aiubId"].ToString(),
                dr["clubChoices"].ToString() };

            dr.Delete();
            dbAccess.updateDatabase("pendingRequests");


            dbAccess.loadDatabaseTable("SELECT * FROM users", "users", new string[] { "userId"});
            ds = (DataSet)Cache["dataSet"];

            dr = ds.Tables["users"].NewRow();
            dr["userId"] = selectedRow[0];
            dr["password"] = selectedRow[1];
            dr["name"] = selectedRow[2];
            dr["email"] = selectedRow[3];
            dr["phone"] = selectedRow[4];
            dr["aiubId"] = selectedRow[5];
            dr["type"] = "Registered";
            ds.Tables["users"].Rows.Add(dr);
            dbAccess.updateDatabase("users");

            dbAccess.loadDatabaseTable("SELECT * FROM clubMembers", "clubMembers", new string[] { "clubId", "memberId" });
            ds = (DataSet)Cache["dataSet"];

            dr = ds.Tables["clubMembers"].NewRow();
            dr["clubId"] = clubId;
            dr["memberId"] = selectedRow[0];
            ds.Tables["clubMembers"].Rows.Add(dr);
            dbAccess.updateDatabase("clubMembers");

            this.loadGridView();
       
        }






    }
}
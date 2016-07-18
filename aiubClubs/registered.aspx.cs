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
    public partial class registered : System.Web.UI.Page
    {

        string clubId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] == null || Session["userType"].ToString().Trim() != "Registered")
            {
                Response.Redirect("~/home.aspx");
            }

            dataBaseAccess dba = new dataBaseAccess();
            dba.loadDatabaseTable("SELECT * FROM users", "users", new string[] { "userId" });

            DataSet ds = (DataSet)Cache["dataSet"];
            DataRow row = ds.Tables["users"].Rows.Find(Session["currentUser"]);

         
            LabeluName.Text = row["name"].ToString();
            LabeluId.Text = row["aiubId"].ToString();
            LabeluType.Text = row["type"].ToString();


            dba.loadDatabaseTable("SELECT * FROM clubMembers WHERE memberId='" + Session["currentUser"] + "'", "clubMembers", new string[] { "clubId", "memberId" });

            ds = (DataSet)Cache["dataSet"];
            clubId=ds.Tables["clubMembers"].Rows[0]["clubId"].ToString();
            Label1.Text = clubId;

            loadGridViewAllEvents();
            loadAssignedEvents();


        }


        private void loadGridViewAllEvents()
        {
            dataBaseAccess dba = new dataBaseAccess();
            dba.loadDatabaseTable("SELECT * FROM events WHERE clubId='"+clubId+"'", "events", new string[] { "eventId"});

            DataSet ds = (DataSet)Cache["dataSet"];


            GridViewclubEvents.DataSource = ds.Tables["events"];
            GridViewclubEvents.DataBind();
        }


        private void loadAssignedEvents()
        {
            dataBaseAccess dba = new dataBaseAccess();
            dba.loadDatabaseTable("SELECT * FROM eventMembers WHERE memberId='" + Session["currentUser"] + "'", "eventMembers", new string[] { "eventsId","memberId" });

            DataSet ds = (DataSet)Cache["dataSet"];

            //List<string> assignedEvents;
            dba.loadDatabaseTable("SELECT * FROM events", "events", new string[] { "eventId" });

            DataSet dsAss = (DataSet)Cache["dataSet"];
            dsAss.Tables["events"].Rows.Clear();

            //Response.Write("<h2>eventsId: " + ds.Tables["eventMembers"].Rows.Count + "<h2/>");

            foreach (DataRow dr in ds.Tables["eventMembers"].Rows)
            {
                dba.loadDatabaseTable("SELECT * FROM events WHERE eventId='" + dr["eventsId"]+ "'", "events", new string[] { "eventId"});
                
                DataSet dsE = (DataSet)Cache["dataSet"];
                 
                DataRow row=dsAss.Tables["events"].NewRow();
                row[0] =dsE.Tables["events"].Rows[0][0];
                row[1] = dsE.Tables["events"].Rows[0][1];
                row[2] = dsE.Tables["events"].Rows[0][2];
                row[3] = dsE.Tables["events"].Rows[0][3];
                row[4] = dsE.Tables["events"].Rows[0][4];
                dsAss.Tables["events"].Rows.Add(row);
            }

            
            GridViewassignedEvents.DataSource = dsAss.Tables["events"];
            GridViewassignedEvents.DataBind();
        }

        protected void LinkButtonredirectToProfile_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/profile.aspx");

        }
    }
}
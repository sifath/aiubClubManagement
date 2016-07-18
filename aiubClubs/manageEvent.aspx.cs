using aiubClubs.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;


namespace aiubClubs
{
    public partial class manageEvent : System.Web.UI.Page
    {
        string clubId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] == null || Session["userType"].ToString().Trim() != "President")
            {
                Response.Redirect("~/home.aspx");
            }




            dataBaseAccess dbAccess = new dataBaseAccess();
            DataSet ds;


            dbAccess.loadDatabaseTable("SELECT * FROM clubs WHERE clubId=(SELECT clubId From presidents WHERE president='" + Session["currentUser"] + "')", "clubs", new string[] { "clubId" });
            ds = (DataSet)Cache["dataSet"];
            this.clubId = ds.Tables["clubs"].Rows[0]["clubId"].ToString();

            if (!IsPostBack)
            {
                dbAccess.loadDatabaseTable("SELECT * FROM events WHERE clubId='" + clubId + "'", "events", new string[] { "eventId" });
                ds = (DataSet)Cache["dataSet"];

                events.DataSource = ds.Tables["events"];
                events.DataBind();
            }

        }

        protected void events_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = events.SelectedRow;

            Session["eventId"] = row.Cells[0].Text.ToString().Trim();
            Response.Redirect("~/addEventMember.aspx");
        }

        protected void events_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string eventId = e.Keys["eventId"].ToString();
            dataBaseAccess dbAccess = new dataBaseAccess();
            
            dbAccess.loadDatabaseTable("SELECT * FROM events WHERE clubId='" + clubId + "'", "events", new string[] { "eventId" });
            DataSet ds = (DataSet)Cache["dataSet"];
            ds.Tables["events"].Rows.Find(eventId).Delete();

            Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
            dbAccess.updateDatabase("events");

            events.DataSource = ds.Tables["events"];
            events.DataBind();
        }

        protected void events_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string eventId = e.Keys["eventId"].ToString();
            dataBaseAccess dbAccess = new dataBaseAccess();
            
            dbAccess.loadDatabaseTable("SELECT * FROM events WHERE clubId='" + clubId + "'", "events", new string[] { "eventId" });
            DataSet ds = (DataSet)Cache["dataSet"];
            
            DataRow dr = ds.Tables["events"].Rows.Find(eventId);
            //Response.Write("<h2>"+ dr["eventName"] + "</h2>");

            dr["eventName"] = e.NewValues["eventName"];
            dr["eventDate"] = e.NewValues["eventDate"];
            dr["eventDetail"] = e.NewValues["eventDetail"];
            Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
            dbAccess.updateDatabase("events");
            
            events.EditIndex = -1;
            events.DataSource = ds.Tables["events"];
            events.DataBind();
        }

        protected void events_RowEditing(object sender, GridViewEditEventArgs e)
        {
            events.EditIndex = e.NewEditIndex;
            dataBaseAccess dbAccess = new dataBaseAccess();
            
            dbAccess.loadDatabaseTable("SELECT * FROM events WHERE clubId='" + clubId + "'", "events", new string[] { "eventId" });
            DataSet ds = (DataSet)Cache["dataSet"];
            events.DataSource = ds.Tables["events"];
            events.DataBind();
        }

        protected void events_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            events.EditIndex = -1;
            dataBaseAccess dbAccess = new dataBaseAccess();
            
            dbAccess.loadDatabaseTable("SELECT * FROM events WHERE clubId='" + clubId + "'", "events", new string[] { "eventId" });
            DataSet ds = (DataSet)Cache["dataSet"];

            events.DataSource = ds.Tables["events"];
            events.DataBind();
        }
    }
}
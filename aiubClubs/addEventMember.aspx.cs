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
    public partial class addEventMember : System.Web.UI.Page
    {
        string clubId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] == null || Session["userType"].ToString().Trim() != "President")
            {
                Response.Redirect("~/home.aspx");
            }
            else
            {
                if(Session["eventId"]==null)
                {
                    Response.Redirect("~/manageEvent.aspx");
                }
            }



            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM events WHERE eventId='" + Session["eventId"] + "'", "events", new string[] { "events" });
            DataSet ds = (DataSet)Cache["dataSet"];
            clubId = ds.Tables["events"].Rows[0]["clubId"].ToString();

                loadGridViewEventMembers();
                loadGridViewClubMembers();

        }


        private void loadGridViewEventMembers()
        {
            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM users WHERE userId IN(SELECT memberID FROM eventMembers WHERE eventsId='" + Session["eventId"] + "')", "users", new string[] { "userId" });
            DataSet ds = (DataSet)Cache["dataSet"];

            GridViewExistingMembers.DataSource = ds.Tables["users"];
            GridViewExistingMembers.DataBind();
        }



        private void loadGridViewClubMembers()
        {
            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM users WHERE userId NOT IN(SELECT memberID FROM eventMembers WHERE eventsId='" + Session["eventId"] + "') AND userId IN(SELECT memberId from clubMembers WHERE clubId='" + clubId + "')", "users", new string[] { "userId" });
            DataSet ds = (DataSet)Cache["dataSet"];
            GridViewClubMembers.DataSource = ds.Tables["users"];
            GridViewClubMembers.DataBind();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewClubMembers.SelectedRow;
            string userId= row.Cells[0].Text.ToString().Trim();


            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM eventMembers", "eventMembers", new string[] { "eventsId","memberId" });
            DataSet ds = (DataSet)Cache["dataSet"];
            DataRow dr = ds.Tables["eventMembers"].NewRow();

            dr["eventsId"] = Session["eventId"];
            dr["memberId"] = userId;
            ds.Tables["eventMembers"].Rows.Add(dr);
            dbAccess.updateDatabase("eventMembers");

            loadGridViewEventMembers();
            loadGridViewClubMembers();
        }


        protected void GridViewExistingMembers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string memberId = e.Keys["userId"].ToString();
            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM eventMembers", "eventMembers", new string[] { "eventsId", "memberId" });
            DataSet ds = (DataSet)Cache["dataSet"];
            ds.Tables["eventMembers"].Rows.Find(new object[] { Session["eventId"], memberId }).Delete();
            //Response.Write("<h2>"+ memberId + "</h2>");
            Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            dbAccess.updateDatabase("eventMembers");
            loadGridViewEventMembers();
            loadGridViewClubMembers();
        }
    }
}
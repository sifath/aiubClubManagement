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
    public partial class clubDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] == null || Session["userType"].ToString().Trim() != "Admin")
            {
                Response.Redirect("~/home.aspx");
            }

            if (Session["clubId"] == null)
            {
                Response.Redirect("~/admin.aspx");
            }

            dataBaseAccess dbaccess = new dataBaseAccess();
            DataSet ds;
            if (!IsPostBack)
            {
                
                dbaccess.loadDatabaseTable("SELECT * FROM events", "events", new string[] { "eventId" });
                ds = (DataSet)Cache["dataSet"];
                events.DataSource = ds.Tables["events"];
                events.DataBind();
                eventNo.Text = ds.Tables["events"].Rows.Count.ToString();
            }

            dbaccess.loadDatabaseTable("SELECT * FROM clubMembers WHERE clubId='" + Session["clubId"] + "'", "clubMembers", new string[] { "clubId", "memberId" });
            ds = (DataSet)Cache["dataSet"];
            memberNo.Text = ds.Tables["clubMembers"].Rows.Count.ToString();
            clubName.Text = Session["clubName"].ToString();

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            dataBaseAccess dbaccess = new dataBaseAccess();
            dbaccess.loadDatabaseTable("SELECT * FROM events WHERE eventDate BETWEEN '"+ Convert.ToDateTime(startDate.Text.Trim())+"' AND '"+ Convert.ToDateTime(endDate.Text.Trim()) +"'", "events", new string[] { "eventId" });
            DataSet ds = (DataSet)Cache["dataSet"];
            events.DataSource = ds.Tables["events"];
            events.DataBind();
            eventNo.Text = ds.Tables["events"].Rows.Count.ToString();
        }
    }
}
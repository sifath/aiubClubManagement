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
    public partial class createEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] == null || Session["userType"].ToString().Trim() != "President")
            {
                Response.Redirect("~/home.aspx");
            }

            if(!IsPostBack)
            {
                dataBaseAccess dbAccess = new dataBaseAccess();
                dbAccess.loadDatabaseTable("SELECT * FROM clubs WHERE clubId=(SELECT clubId From presidents WHERE president='"+Session["currentUser"]+"')", "clubs", new string[] { "clubId" });
                DataSet ds = (DataSet)Cache["dataSet"];
                DataRow dr=ds.Tables["clubs"].Rows[0];
                Label1.Text = "Create New Event for " + dr["clubName"];
                LabelClubId.Text = dr["clubId"].ToString();
            }
        }

        private bool validation()
        {
            string erroMassege = "";
            if(TextBoxeventName.Text.Trim()=="")
            {
                erroMassege += "Please give an event name<br>";
            }
            if(TextBoxeventDetail.Text.Trim()=="")
            {
                erroMassege += "Please give an event description<br>";
            }


            labelErrorMassege.Text = erroMassege;
            if (erroMassege=="")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        protected void ButtoncreateEvent_Click(object sender, EventArgs e)
        {

            if(validation())
            {
                dataBaseAccess dbAccess = new dataBaseAccess();
                dbAccess.loadDatabaseTable("SELECT * FROM events", "events", new string[] { "eventId" });
                DataSet ds = (DataSet)Cache["dataSet"];

                DataRow dr = ds.Tables["events"].NewRow();
                dr["eventId"] = -1;
                dr["clubId"] = LabelClubId.Text.Trim();
                dr["eventName"] = TextBoxeventName.Text.Trim();
                dr["eventDate"] = TextBoxeventDate.Text;
                dr["eventDetail"] = TextBoxeventDetail.Text;
                ds.Tables["events"].Rows.Add(dr);

                Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                dbAccess.updateDatabase("events");
            }

        }
    }
}
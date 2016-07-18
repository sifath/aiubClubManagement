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
    public partial class managePresidents : System.Web.UI.Page
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

            LabelClubName.Text = Session["clubName"].ToString();
            if (!IsPostBack)
            {
                loadGridViewCurrentPresidents();
                loadGridViewclubMembers();
            }

        }



        private void loadGridViewCurrentPresidents()
        {
            dataBaseAccess db = new dataBaseAccess();
            db.loadDatabaseTable("SELECT * FROM users WHERE userId IN(SELECT president FROM presidents WHERE clubId='" + Session["clubId"] + "')", "users", new string[] { "userId" });

            DataSet ds = (DataSet)Cache["dataSet"];

            currentPresidents.DataSource = ds.Tables["users"];
            currentPresidents.DataBind();
        }

        private void loadGridViewclubMembers()
        {
            dataBaseAccess db = new dataBaseAccess();
            db.loadDatabaseTable("SELECT * FROM users WHERE userId NOT IN(SELECT president FROM presidents WHERE clubId='" + Session["clubId"] + "') AND userId IN(SELECT memberID FROM clubMembers WHERE clubId='" + Session["clubId"] + "')", "users", new string[] { "userId" });

            DataSet ds = (DataSet)Cache["dataSet"];

            clubMembers.DataSource = ds.Tables["users"];
            clubMembers.DataBind();
        }



        protected void currentPresidents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userId = e.Keys["userId"].ToString();
            //string clubId;

            dataBaseAccess dbaccess = new dataBaseAccess();

            dbaccess.loadDatabaseTable("SELECT * FROM presidents WHERE clubId='" + Session["clubId"] + "' AND president='" + userId + "'", "presidents", new string[] { "clubId", "presidents" });
            DataSet ds = (DataSet)Cache["dataSet"];

            //clubId = ds.Tables["presidents"].Rows[0]["clubId"].ToString();
            ds.Tables["presidents"].Rows[0].Delete();
            Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);

            dbaccess.updateDatabase("presidents");
            loadGridViewCurrentPresidents();
            loadGridViewclubMembers();

            dbaccess.loadDatabaseTable("SELECT * FROM users WHERE userId='" + userId + "'", "users", new string[] { "userId" });
            ds = (DataSet)Cache["dataSet"];
            ds.Tables["users"].Rows[0]["type"] = "Registered";
            Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            dbaccess.updateDatabase("users");
        }

        protected void clubMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = clubMembers.SelectedRow;
            string userId = row.Cells[0].Text;
            string clubId;

            dataBaseAccess dbaccess = new dataBaseAccess();

            dbaccess.loadDatabaseTable("SELECT * FROM presidents WHERE clubId='" + ViewState["clubId"] + "' AND president='" + userId + "'", "presidents", new string[] { "clubId", "presidents" });
            DataSet ds = (DataSet)Cache["dataSet"];

            clubId = Session["clubId"].ToString();
            DataRow dr = ds.Tables["presidents"].NewRow();
            dr["clubId"] = clubId;
            dr["president"] = userId;
            ds.Tables["presidents"].Rows.Add(dr);
            Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);

            dbaccess.updateDatabase("presidents");
            loadGridViewCurrentPresidents();
            loadGridViewclubMembers();

            dbaccess.loadDatabaseTable("SELECT * FROM users WHERE userId='" + userId + "'", "users", new string[] { "userId" });
            ds = (DataSet)Cache["dataSet"];
            ds.Tables["users"].Rows[0]["type"] = "President";
            Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            dbaccess.updateDatabase("users");
        }

        protected void search_Click(object sender, EventArgs e)
        {

        }




    }
}
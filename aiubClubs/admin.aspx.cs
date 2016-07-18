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
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] == null || Session["userType"].ToString().Trim() != "Admin")
            {
                Response.Redirect("~/home.aspx");
            }



            if (!IsPostBack)
            {
                dataBaseAccess db = new dataBaseAccess();
                db.loadDatabaseTable("SELECT * FROM users", "users", new string[] { "userId" });

                DataSet ds = (DataSet)Cache["dataSet"];
                DataRow row = ds.Tables["users"].Rows.Find(Session["currentUser"]);
                LabeladminName.Text = row["name"].ToString();
            }
            if(!IsPostBack)
            {
                loadClubsGridView();
            }
            
        }


        private void loadClubsGridView()
        {
            dataBaseAccess db = new dataBaseAccess();
            db.loadDatabaseTable("SELECT * FROM clubs", "clubs", new string[] { "clubId" });

            DataSet ds = (DataSet)Cache["dataSet"];

            GridViewClubs.DataSource = ds.Tables["clubs"];
            GridViewClubs.DataBind();
        }




        protected void LinkButtonmanageProfiel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/profile.aspx");
        }



        private bool Validation()
        {
            string error = "";

            if(TextBoxclubName.Text=="")
            {
                error += "Please Give a Club Name<br>";
            }

            if(TextBoxiDate.Text=="")
            {
                error += "Inaguration Date is Required<br>";
            }

            labelErrorMassege.Text = error;
            if(error=="")
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        protected void ButtoncreateClub_Click(object sender, EventArgs e)
        {
            if(Validation())
            {
                dataBaseAccess dbaccess = new dataBaseAccess();
                dbaccess.loadDatabaseTable("SELECT * FROM clubs", "clubs", new string[] { "clubId" });
                DataSet ds = (DataSet)Cache["dataSet"];

                DataRow row = ds.Tables["clubs"].NewRow();
                row["clubId"] = -1;
                row["clubName"] = TextBoxclubName.Text.Trim();
                row["inagurationDate"] = TextBoxiDate.Text.Trim();
                ds.Tables["clubs"].Rows.Add(row);
                Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                dbaccess.updateDatabase("clubs");
                labelErrorMassege.Text = "Club Created Successfully<br>";
                loadClubsGridView();
            }
        }





        protected void GridViewClubs_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            dataBaseAccess dbaccess = new dataBaseAccess();
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewClubs.Rows[index];
            string clubId = row.Cells[0].Text;
            Session["clubId"] = clubId;
            Session["clubName"]= row.Cells[1].Text;
            //Response.Write("<h3> ClubId: " + clubId + "</h3>");
            if (e.CommandName == "detail")
            {
                Response.Redirect("~/clubDetail.aspx");
            }
            else
            if (e.CommandName == "appointPresident")
            {
                Response.Redirect("~/managePresidents.aspx");
            }
        }

    }
}
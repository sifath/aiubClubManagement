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
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["currentUser"] == null)
            {
                Response.Redirect("~/home.aspx");
            }

            if(!IsPostBack)
            {
                dataBaseAccess dba = new dataBaseAccess();
                dba.loadDatabaseTable("SELECT * FROM users", "users", new string[] { "userId" });

                DataSet ds = (DataSet)Cache["dataSet"];
                DataRow row = ds.Tables["users"].Rows.Find(Session["currentUser"]);

                TextBoxuserId.Text = row["userId"].ToString();
                TextBoxchangeUserName.Text = row["name"].ToString();
                TextBoxchangeEmail.Text = row["email"].ToString();
                TextBoxchangePhone.Text = row["phone"].ToString();
                TextBoxaiubId.Text = row["aiubId"].ToString();
            }


        }

        protected void Buttonregister_Click(object sender, EventArgs e)
        {
            string pass = TextBoxoldPassword.Text.ToString();
            dataBaseAccess dba = new dataBaseAccess();
       
            DataSet ds = (DataSet)Cache["dataSet"];
           
            DataRow dr = ds.Tables["users"].Rows.Find(Session["currentUser"]);
            
            if(pass == dr["password"].ToString())
            {
                if(TextBoxnewPassword.Text.ToString() == TextBoxrePassword.Text.ToString())
                {
                    dr["password"] = TextBoxnewPassword.Text.Trim();
                }
                else
                {
                    LabelerrorMessege2.Text = "new Password is Not Matching with retyped password";
                }
            }
            else
            {
                LabelerrorMessege2.Text = "Old Password is Not Matching";
            }
            dr["name"] = TextBoxchangeUserName.Text.Trim();
            dr["email"] = TextBoxchangeEmail.Text.Trim();
            dr["phone"] = TextBoxchangePhone.Text.Trim();
       
            Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
            dba.updateDatabase("users");

            labelErrorMassege.Text = "Updated Successfully";
            
        }
    }
}
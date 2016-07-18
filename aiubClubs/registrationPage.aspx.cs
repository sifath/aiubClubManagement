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
    public partial class registrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataBaseAccess dbAccess = new dataBaseAccess();
                dbAccess.loadDatabaseTable("SELECT * FROM clubs", "clubs", new string[] { "clubId" });
                DataSet ds = (DataSet)Cache["dataSet"];

                CheckBoxListClubs.DataSource = ds.Tables["clubs"];
                CheckBoxListClubs.DataTextField = "clubName";
                CheckBoxListClubs.DataValueField = "clubId";
                CheckBoxListClubs.DataBind();
            }
        }


        private bool validation()
        {
            dataBaseAccess dbAccess = new dataBaseAccess();
          
            
            dbAccess.loadDatabaseTable("SELECT * FROM users", "users", new string[] { "userId" });
            DataSet ds = (DataSet)Cache["dataSet"];
            DataRow rowUser = ds.Tables["users"].Rows.Find(TextBoxuserId.Text.Trim());

            dbAccess.loadDatabaseTable("SELECT * FROM pendingRequests WHERE userId='"+ TextBoxuserId.Text.Trim() +"'", "pendingRequests", new string[] { "userId", "clubChoices"});
            ds = (DataSet)Cache["dataSet"];

            int selectedClub = 0;
            foreach (ListItem item in CheckBoxListClubs.Items)
            {
                if (item.Selected)
                {
                    selectedClub++;
                }
            }

            string errorMessage = "";
            if (rowUser != null || ds.Tables["pendingRequests"].Rows.Count>0)
            {
                errorMessage += "The User Name is Already Taken<br>";
            }

            if (!TextBoxpassword.Text.Trim().Equals(TextBoxrePassword.Text.Trim()))
            {
                errorMessage += "Password and Retype Password Must be same<br>";
            }

            if(selectedClub < 1)
            {
                errorMessage += "You have to check at least one club<br>";
            }

            labelErrorMassege.Text = errorMessage;

            if (errorMessage.Equals(""))
                return true;
            else
                return false;


        }


        protected void Buttonregister_Click(object sender, EventArgs e)
        {

            dataBaseAccess dbAccess = new dataBaseAccess();
            if (validation())
            {
                dbAccess.loadDatabaseTable("SELECT * FROM pendingRequests", "pendingRequests", new string[] { "userId", "clubChoices" });
                DataSet ds = (DataSet)Cache["dataSet"];
                foreach (ListItem item in CheckBoxListClubs.Items)
                {
                    if (item.Selected)
                    {

                        DataRow dr = ds.Tables["pendingRequests"].NewRow();
                        dr["userId"] = TextBoxuserId.Text.Trim();
                        dr["password"] = TextBoxrePassword.Text.Trim();
                        dr["name"] = TextBoxuserName.Text.Trim();
                        dr["email"] = TextBoxemail.Text.Trim();
                        dr["phone"] = TextBoxphone.Text.Trim();
                        dr["type"] = "Registered";
                        dr["aiubId"] = TextBoxaiubId.Text.Trim();
                        dr["clubChoices"] = item.Value;
                        ds.Tables["pendingRequests"].Rows.Add(dr);
                    }
                }

                Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                dbAccess.updateDatabase("pendingRequests");

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using aiubClubs.DataAccess;

namespace aiubClubs
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonlogIn_Click(object sender, EventArgs e)
        {
            dataBaseAccess dbAccess = new dataBaseAccess();
            dbAccess.loadDatabaseTable("SELECT * FROM users","users", new string[]{ "userId"});

            DataSet ds = (DataSet)Cache["dataSet"];
            DataRow row = ds.Tables["users"].Rows.Find(TextBoxuserId.Text.Trim());
          
            if (row!=null)
            {
                if(row["password"].Equals(TextBoxpassword.Text.Trim()))
                {
                    labelErrorMassege.Text = "";
                    Session["currentUser"] = row["userId"];
                    Session["userType"] = row["Type"];
                    if (row["Type"].Equals("Admin"))
                    {
                        Response.Redirect("~/admin.aspx");
                    }
                    else
                    if (row["Type"].Equals("President"))
                    {
                        Response.Redirect("~/president.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/registered.aspx");
                    }
                }
                else
                {
                    labelErrorMassege.Text = "Wrong Password Inputted";
                }
            }
            else
            {
                labelErrorMassege.Text = "Wrong User Name or Password Inputted";
            }
        }

        protected void LinkButtonclickHere_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/registrationPage.aspx");
        }
    }
}
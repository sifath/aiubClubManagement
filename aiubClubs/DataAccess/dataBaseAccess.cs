using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Caching;


namespace aiubClubs.DataAccess
{
    public class dataBaseAccess
    {
        public void loadDatabaseTable(string sql, string table, string[] keys)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds;

            ds = new DataSet();



                adapter.Fill(ds, table);

                int i = 0;
                DataColumn[] keyColumn = new DataColumn[keys.Length];

                foreach (string key in keys)
                {
                    keyColumn[i] = ds.Tables[table].Columns[key];
                    i++;
                }

                ds.Tables[table].PrimaryKey = keyColumn;

                HttpRuntime.Cache.Insert("dataSet", ds, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);

            HttpContext.Current.Session["adapter"+table] = adapter;
            //HttpRuntime.Cache.Insert("ADAPTER", adapter, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
        }




        public void updateDatabase(string table)
        {
            DataSet ds = (DataSet)HttpRuntime.Cache["dataSet"];
            SqlDataAdapter adapter = (SqlDataAdapter)HttpContext.Current.Session["adapter" + table];
            adapter.Update(ds, table);
            ds.Tables[table].AcceptChanges();
        }
    }
}
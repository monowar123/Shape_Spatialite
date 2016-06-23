using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape_Spatialite
{
    public class DbHandler
    {
        string conString = string.Empty;

        public DbHandler()
        {
            conString = @"Data Source=C:\Users\HDSL115\Desktop\SQL Lite\BGTSyncSpLite.sqlite";
        }

        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(conString))
            {
                con.Open();
                con.EnableExtensions(true);
                con.LoadExtension("mod_spatialite.dll");
                using (SQLiteDataAdapter adp = new SQLiteDataAdapter(query, con))
                {
                    adp.Fill(dt);
                }
            }

            return dt;
        }

        public bool ExecuteNonQuery(string query)
        {
            int affectedRows = 0;
            using (SQLiteConnection con = new SQLiteConnection(conString))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    affectedRows = cmd.ExecuteNonQuery();  
                }
            }
            if (affectedRows > 0)
                return true;

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Assignment_4
{
    public class DataAccess
    {

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public string gName;
        public string gDesc;
        public int gStatus;
        public int count = 0;

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public int insert()
        {
            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC AddGroup @name = " + gName + ", @description = " + gDesc + ";";

            cmd.ExecuteNonQuery();

            //CALL A NEW QUERY TO GRAB THE GROUPID OF THE GROUP THAT WAS JUST INSERTED.
            //

            count++;

            con.Close();
            return count;
        }
    }
}
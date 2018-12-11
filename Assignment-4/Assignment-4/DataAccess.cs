using Assignment_4.Models;
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

        public string wName;
        public string wText;
        public string wStatus;

        public string queryStatus;

        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand();

        public int insertGroup()
        {
            int returnedId;
            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC AddGroup @name = " + gName + ", @description = " + gDesc + ";";

            returnedId = cmd.ExecuteNonQuery();     

            con.Close();
            return returnedId;
        }

        public int insertWorkObject(int grID)
        {
            int returnedId;
            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC AddWorkObject  @group = " + grID + " @name = " + wName + ", @text = " + wText + ";";

            returnedId = cmd.ExecuteNonQuery();

            con.Close();
            return returnedId;
        }

        public static ProjectGroup[] getGroups()
        {
            int count = 0;
            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC GetGroups";
            cmd.ExecuteNonQuery();

            // get count of groups
            //cmd.CommandText = "";
            //count = cmd.ExecuteNonQuery();

            con.Close();

            ProjectGroup[] pGroupArray = new ProjectGroup[count];

            return pGroupArray;
        }

        public static WorkObject[] getWorkObjectsByGroup(int grID)
        {
            int count = 0;
            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC GetWorkObjectsByGroup @group=" + grID + "";
            cmd.ExecuteNonQuery();

            // get count of groups
            //cmd.CommandText = "";
            //cmd.ExecuteNonQuery();

            con.Close();

            WorkObject[] wObjArray = new WorkObject[count];

            return wObjArray;
        }

        public static void updateGroup(int grID, string grName, string grDesc)
        {
            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC UpdateGroup @group= " + grID + ", @name= " + grName + ", @description= " + grDesc + "";

            cmd.ExecuteNonQuery();

            con.Close();

            return;
        }

        public static void updateWorkObject(int wObjID, string wObjName, string wObjtext)
        {
            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC UpdateWorkObject @id= " + wObjID + ", @name= " + wObjName + ", @text= " + wObjtext + "";
            cmd.ExecuteNonQuery();
            con.Close();

            return;
        }

    }
}
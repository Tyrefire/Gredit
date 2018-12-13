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
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand();

        public static int insertGroup(string gName, string gDesc, int gStatus)
        {

            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC AddGroup @name = " + gName + ", @description = " + gDesc + ";";

            var returnedId = (Int32)cmd.ExecuteScalar();
            con.Close();
            return returnedId;
        }

        public static int insertWorkObject(int grID, string wName, string wText)
        {
            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC AddWorkObject  @group = " + grID + " @name = " + wName + ", @text = " + wText + ";";
            var returnedId = (Int32)cmd.ExecuteScalar();

            con.Close();
            return returnedId;
        }

        public static ProjectGroup[] getGroups()
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC GetGroups";
            dt.Load(cmd.ExecuteReader());
            ds.Tables.Add(dt);

            //get count of groups
            cmd.CommandText = "EXEC GetProjectCount";
            var count = (Int32)cmd.ExecuteScalar();

            con.Close();

            ProjectGroup[] pGroupArray = new ProjectGroup[count];
            string temp;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables.Count > 0)
                {

                    
                    pGroupArray[i] = new ProjectGroup(i);

                    temp = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    pGroupArray[i].groupID = Convert.ToInt32(temp);
      
                    temp = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    pGroupArray[i].groupName = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                    pGroupArray[i].groupDescription = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                    temp = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    pGroupArray[i].status = Convert.ToInt32(temp);
                }
            }

            return pGroupArray;
        }

        public static WorkObject[] getWorkObjectsByGroup(int grID)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            con.ConnectionString = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID={db_exec};Password={Moroni10:3-5};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC GetWorkObjectsByGroup @group=" + grID + "";
            dt.Load(cmd.ExecuteReader());

            // get count of groups
            cmd.CommandText = "EXEC GetWorkObjCount @groupID = " + grID + "";
            var count = (Int32)cmd.ExecuteScalar();

            con.Close();

            WorkObject[] wObjArray = new WorkObject[count];
            string temp;

            //populate array based on data set
            for (int i=0; i< ds.Tables[0].Rows.Count; i++)
            {
                    if (ds.Tables.Count > 0)
                    {
                        wObjArray[i] = new WorkObject(i,i);

                        temp = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                        wObjArray[i].objectID = Convert.ToInt32(temp);

                        temp = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                        wObjArray[i].groupID = Convert.ToInt32(temp);

                        wObjArray[i].objectTitle = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                        wObjArray[i].objectText = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                }
            }

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
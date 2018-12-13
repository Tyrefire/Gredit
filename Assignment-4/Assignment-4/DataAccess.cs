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

        public static String s = @"Server=tcp:colinhealdtest.database.windows.net,1433;Initial Catalog=CHTest;Persist Security Info=False;User ID=colin.heald;Password=co1inH3a1d;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static int insertGroup(string gName, string gDesc, int gStatus)
        {


            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC AddGroup @name = " + gName + ", @description = " + gDesc + ";";

            int returnedId = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return returnedId;
        }

        public static int insertWorkObject(int grID, string wName, string wText)
        {
            con.ConnectionString = s;
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC AddWorkObject  @group = " + grID + " @name = " + wName + ", @text = " + wText + ";";
            int returnedId = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
            return returnedId;
        }

        public static ProjectGroup[] getGroups()
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            con.ConnectionString = s;
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC GetGroups";
            dt.Load(cmd.ExecuteReader());
            ds.Tables.Add(dt);

            //get count of groups
            cmd.CommandText = "EXEC GetProjectCount";
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            ProjectGroup[] pGroupArray = new ProjectGroup[count];
            string temp;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables.Count > 0)
                {


                    pGroupArray[i] = new ProjectGroup(i);

                    //id
                    temp = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    pGroupArray[i].groupID = Convert.ToInt32(temp);

                    //name
                    pGroupArray[i].groupName = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                    //description
                    pGroupArray[i].groupDescription = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                    temp = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    pGroupArray[i].status = 0;// Convert.ToInt32(temp);
                }
            }

            return pGroupArray;
        }

        public static WorkObject[] getWorkObjectsByGroup(int grID)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            con.ConnectionString = s;
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC GetWorkObjectsByGroup @group=" + grID + "";
            dt.Load(cmd.ExecuteReader());

            // get count of groups
            cmd.CommandText = "EXEC GetWorkObjCount @groupID = " + grID + "";
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            WorkObject[] wObjArray = new WorkObject[count];
            string temp;

            //populate array based on data set
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables.Count > 0)
                {
                    wObjArray[i] = new WorkObject(i, i);

                    //obj ID
                    temp = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    wObjArray[i].objectID = Convert.ToInt32(temp);

                    //Group ID
                    temp = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    wObjArray[i].groupID = Convert.ToInt32(temp);

                    //Object Title
                    wObjArray[i].objectTitle = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                    //Object Text
                    wObjArray[i].objectText = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                }
            }

            return wObjArray;
        }

        public static void updateGroup(int grID, string grName, string grDesc)
        {
            con.ConnectionString = s;
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC UpdateGroup @group= " + grID + ", @name= " + grName + ", @description= " + grDesc + "";

            cmd.ExecuteNonQuery();

            con.Close();

            return;
        }

        public static void updateWorkObject(int wObjID, string wObjName, string wObjtext)
        {
            con.ConnectionString = s;
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "EXEC UpdateWorkObject @id= " + wObjID + ", @name= " + wObjName + ", @text= " + wObjtext + "";
            cmd.ExecuteNonQuery();
            con.Close();

            return;
        }
    }
}
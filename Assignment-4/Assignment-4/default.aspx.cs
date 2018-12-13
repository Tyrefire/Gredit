using Assignment_4.Models;
using Assignment_4.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4
{
    public partial class _default : System.Web.UI.Page
    {
        #region variables

        public static int projectCount;
        public static int cellCount;

        public static List<ProjectGroup> proj;

        #endregion

        #region methods

        protected void Page_Load(object sender, EventArgs e)
        {
            cellCount = Int32.Parse(ddlColCount.SelectedItem.Value);

            //Add all projects to the list of projects
            //This code to be ammended with connection to database to get all projects
            proj = new List<ProjectGroup>();

            //This code to be removed once connection to database is established
            ProjectGroup[] p = DataAccess.getGroups();

            foreach( ProjectGroup P in p)
            {
                proj.Add(P);
            }

            //draw projects
            drawProjectsPage();
        }

        protected void editProject(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            String s = b.ID;
            int id = Int32.Parse(s.Substring(1));

            String gName = callServer1.Value;
            String gDesc = callServer2.Value;

            DataAccess.updateGroup(id, gName, gDesc);

            //pnldynamic.Controls.Add(drawProjectsPage());
        }

        [WebMethod]
        public static void goToNextPage(String s)
        {
            //TextBox c = (TextBox)sender;
            String groupId = s.Substring(4);
            HttpContext.Current.Session["gID"] = groupId;

            HttpContext.Current.Response.Redirect("objects.aspx");
        }

        protected void makeNewGroup(object sender, EventArgs e)
        {
            DataAccess.insertGroup("Title", "Description", 0);
        }

        [WebMethod]
        public static Panel drawProjectsPage()
        {
            Panel pnldynamic = new Panel();

            pnldynamic.Controls.Clear();

            projectCount = proj.Count();
            int rowCount;
            Table t;

            //make the panel visible
            pnldynamic.Visible = true;

            rowCount = projectCount / cellCount;
            if (projectCount % cellCount > 0)
            {
                rowCount += 1;
            }

            //generate the table of Projects
            t = new Table();
            t.Style.Add("width", "100%");

            int nObjCnt = projectCount;
            int jMax = cellCount;

            proj.ToArray();

            for (int i = 0; i < rowCount; ++i)
            {
                TableRow row = new TableRow();
                t.Rows.Add(row);

                if (nObjCnt - cellCount >= 0)
                {
                    nObjCnt -= cellCount;
                }
                else
                {
                    if (nObjCnt % cellCount != 0)
                    {
                        jMax = nObjCnt;
                    }
                }

                for (int j = 0; j < jMax; ++j)
                {
                    TableCell cell = new TableCell();

                    Label Title = new Label();
                    Title.Text = proj[(i * cellCount) + j].getGroupName();
                    Button edit = new Button();
                    edit.ID = "b" + proj[(i * cellCount) + j].getGroupID();
                    edit.Text = "Edit";
                    //edit.Attributes.Add("OnClick", "editProject");
                    edit.Attributes.Add("OnClick", "editGroup()");

                    TextBox tb = new TextBox();
                    tb.ReadOnly = true;
                    tb.TextMode = TextBoxMode.MultiLine;
                    tb.Attributes.Add("style", "resize:none");
                    tb.ID = "proj" + proj[(i * cellCount) + j].getGroupID();
                    tb.Text = "proj" + proj[(i * cellCount) + j].getGroupID();
                    tb.Text += "\n" + proj[(i * cellCount) + j].getGroupDescription();
                    tb.Rows = 20;
                    tb.Columns = 50;
                    tb.Attributes.Add("runat", "server");
                    tb.Attributes.Add("OnClick", "goToNextPage(this.id)");

                    cell.Controls.Add(Title);
                    cell.Controls.Add(edit);
                    cell.Controls.Add(new LiteralControl("<br />"));
                    cell.Controls.Add(tb);

                    cell.ID = "" + proj[(i * cellCount) + j].getGroupID();
                    row.Cells.Add(cell);
                }
            }

            pnldynamic.Controls.Add(t);
            return pnldynamic;
        }

        [WebMethod]
        public static void updateGroups()
        {
            drawProjectsPage();
        }

        #endregion

    }
}
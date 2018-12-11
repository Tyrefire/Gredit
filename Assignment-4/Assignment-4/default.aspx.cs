using Assignment_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4
{
    public partial class _default : System.Web.UI.Page
    {
        public int objectCount;
        public int projectCount;
        public int cellCount;

        public List<ProjectGroup> proj;

        protected void Page_Load(object sender, EventArgs e)
        {
            cellCount = Int32.Parse(ddlColCount.SelectedItem.Value);

            //Add all projects to the list of projects
            //This code to be ammended with connection to database to get all projects
            proj = new List<ProjectGroup>();

            //This code to be removed once connection to database is established
            ProjectGroup p = new ProjectGroup();
            proj.Add(p);

            projectCount = proj.Count();

            //draw projects
            drawProjectsPage();
        }

        private void drawProjectsPage()
        {
            pnldynamic.Dispose();

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
                    Title.Text = proj[0].getGroupName();

                    TextBox tb = new TextBox();
                    tb.ReadOnly = true;
                    tb.TextMode = TextBoxMode.MultiLine;
                    tb.ID = "proj" + proj[0].getGroupID();
                    tb.Text = "proj" + proj[0].getGroupID();
                    tb.Text += "\n" + proj[0].getGroupDescription();
                    tb.Rows = 20;
                    tb.Columns = 50;

                    cell.Controls.Add(Title);
                    cell.Controls.Add(new LiteralControl("<br />"));
                    cell.Controls.Add(tb);
                    cell.Attributes.Add("OnClick", "getObjects()");

                    cell.ID = "Project" + proj[0].getGroupID();
                    row.Cells.Add(cell);
                }
            }

            pnldynamic.Controls.Add(t);
        }

        public void makeNewGroup()
        {
            cellCount = Int32.Parse(ddlColCount.SelectedItem.Value);

            String gName = callServer1.Value;
            String gDesc = callServer2.Value;
            ProjectGroup newGroup = new ProjectGroup();
            newGroup.setGroupName(gName);
            newGroup.setGroupDescription(gDesc);

            proj.Add(newGroup);
            projectCount = proj.Count();

            drawProjectsPage();
        }

        public void updateGroups()
        {
            drawProjectsPage();
        }

    }
}
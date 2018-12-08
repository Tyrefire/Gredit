using Assignment_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4
{
    public partial class objects : System.Web.UI.Page
    {
        public int objectCount;
        public int cellCount;

        public List<WorkObject> obj;
        public List<ProjectGroup> proj;

        protected void Page_Load(object sender, EventArgs e)
        {
            cellCount = Int32.Parse(ddlColCount.SelectedItem.Value);

            checker.Text = "c" + Int32.Parse(loadProjects.Value);
            checker.Text += "\tc" + Int32.Parse(loadObjects.Value);
            checker.Text += "\tc" + Int32.Parse(loadSingleObject.Value);

            //Add all objects from project with a certain groupID to the list of objects
            //This code to be ammended with connection to database to get all objects
            obj = new List<WorkObject>();

            //This code to be removed once connection to database is established
            ProjectGroup p = new ProjectGroup();
            WorkObject w = new WorkObject(p.getGroupID());
            obj.Add(w);

            objectCount = obj.Count();

            //draw objects
            drawObjectsPage();

            /*if (Int32.Parse(loadProjects.Value) == 1)
            {
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

            if (Int32.Parse(loadObjects.Value) == 1)
            {
                //Add all objects from project with a certain groupID to the list of objects
                //This code to be ammended with connection to database to get all objects
                obj = new List<WorkObject>();

                //This code to be removed once connection to database is established
                ProjectGroup p = new ProjectGroup();
                WorkObject w = new WorkObject(p.getGroupID());
                obj.Add(w);

                objectCount = obj.Count();

                //draw objects
                drawObjectsPage();
            }

            if (Int32.Parse(loadSingleObject.Value) == 1)
            {
                //draw single object
                drawSingleObjectPage();
            }*/

        }

        private void drawObjectsPage()
        {
            int rowCount;
            Table t = new Table();

            //make the panel visible
            pnldynamic.Visible = true;

            rowCount = objectCount / cellCount;
            if (objectCount % cellCount > 0)
            {
                rowCount += 1;
            }

            //generate the table of Objects
            t = new Table();
            t.Style.Add("width", "100%");

            int nObjCnt = objectCount;
            int jMax = cellCount;

            obj.ToArray();

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
                    Title.Text = obj[0].getObjectTitle();

                    TextBox tb = new TextBox();
                    tb.TextMode = TextBoxMode.MultiLine;
                    tb.ReadOnly = true;
                    tb.ID = "obj" + obj[0].getObjectID();
                    tb.Text = "obj" + obj[0].getObjectID();
                    tb.Text += obj[0].getObjectText();
                    tb.Rows = 20;
                    tb.Columns = 50;

                    cell.Controls.Add(Title);
                    cell.Controls.Add(new LiteralControl("<br />"));
                    cell.Controls.Add(tb);
                    cell.Attributes.Add("OnClick", "getObject(" + obj[0].getObjectID() + ")");

                    cell.ID = "Object" + obj[0].getObjectID();
                    row.Cells.Add(cell);
                }
            }

            pnldynamic.Controls.Add(t);
        }

    }
}
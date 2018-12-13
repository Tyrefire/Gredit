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

        #region variables

        public int objectCount;
        public int cellCount;
        public int pId;

        public List<WorkObject> obj;

        #endregion

        #region methods

        protected void Page_Load(object sender, EventArgs e)
        {
            cellCount = Int32.Parse(ddlColCount.SelectedItem.Value);
            pId = (int)Session["gID"];

            //Add all objects from project with a certain groupID to the list of objects
            //This code to be ammended with connection to database to get all objects
            obj = new List<WorkObject>();

            //This code to be removed once connection to database is established
            WorkObject[] w = DataAccess.getWorkObjectsByGroup(pId);

            foreach (WorkObject W in w)
            {
                obj.Add(W);
            }

            //draw objects
            drawObjectsPage();
        }

        protected void editObject(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            String s = b.ID;
            int id = Int32.Parse(s.Substring(1));

            String oTitle = callServer.Value;

            WorkObject[] workObjects = DataAccess.getWorkObjectsByGroup(pId);
            WorkObject work = workObjects[id];

            DataAccess.updateWorkObject(id, oTitle, work.getObjectText());

            drawObjectsPage();
        }

        protected void goToNextPage(object sender, EventArgs e)
        {
            TextBox c = (TextBox)sender;
            String objectId = c.ID;
            Session["oID"] = objectId;

            Response.Redirect("object.aspx");
        }

        private void drawObjectsPage()
        {
            pnldynamic.Dispose();

            objectCount = obj.Count();
            int rowCount;
            Table t;

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
                    Title.Text = obj[(i * cellCount) + j].getObjectTitle();
                    Button edit = new Button();
                    edit.ID = "b" + obj[(i * cellCount) + j].getGroupID();
                    edit.Text = "Edit";
                    edit.Attributes.Add("OnClick", "editObject()");
                    edit.Attributes.Add("OnClientClick", "editWork()");

                    TextBox tb = new TextBox();
                    tb.TextMode = TextBoxMode.MultiLine;
                    tb.ReadOnly = true;
                    tb.ID = "obj" + obj[(i * cellCount) + j].getObjectID();
                    tb.Text = "obj" + obj[(i * cellCount) + j].getObjectID();
                    tb.Text += "\n" + obj[(i * cellCount) + j].getObjectText();
                    tb.Rows = 20;
                    tb.Columns = 50;
                    tb.Attributes.Add("OnClick", "goToNextPage()");

                    cell.Controls.Add(Title);
                    cell.Controls.Add(new LiteralControl("<br />"));
                    cell.Controls.Add(tb);

                    cell.ID = "" + obj[(i * cellCount) + j].getObjectID();
                    row.Cells.Add(cell);
                }
            }

            pnldynamic.Controls.Add(t);
        }

        public void makeNewObj()
        {
            DataAccess d = new DataAccess();
            d.insertWorkObject(pId);

            drawObjectsPage();
        }

        public void updateObj()
        {
            drawObjectsPage();
        }

        #endregion

    }
}
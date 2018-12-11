using Assignment_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace Assignment_4
{
    public partial class _object : System.Web.UI.Page
    {

        public WorkObject obj;
        TextBox tb;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectGroup p = new ProjectGroup();
            obj = new WorkObject(p.getGroupID());
            obj.setStatus(1);

            titleField.Text = obj.getObjectTitle();

            drawSingleObjectPage();
        }

        private void drawSingleObjectPage()
        {
            pnldynamic.Dispose();

            //make the panel visible
            pnldynamic.Visible = true;

            tb = new TextBox();
            tb.TextMode = TextBoxMode.MultiLine;
            tb.ID = "obj" + obj.getObjectID();
            tb.Text += obj.getObjectText();
            tb.Rows = 80;
            tb.Columns = 200;

            pnldynamic.Controls.Add(tb);
        }

        [WebMethod]
        public void updateText()
        {
            //send data to database

        }

    }
}
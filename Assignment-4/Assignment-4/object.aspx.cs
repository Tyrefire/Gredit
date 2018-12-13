using Assignment_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace Assignment_4
{
    public partial class _object : System.Web.UI.Page
    {

        #region variables

        public WorkObject obj;
        TextBox tb;
        TextBox checker;
        public int oId;
        System.Timers.Timer timer = new System.Timers.Timer();

        #endregion

        #region methods

        protected void Page_Load(object sender, EventArgs e)
        {
            timer.Interval = 300000;
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(exitingObject);
            timer.Start();

            int pId = (int)Session["gID"];
            oId = (int)Session["oID"];

            WorkObject[] o = DataAccess.getWorkObjectsByGroup(pId);

            obj = o[oId];
            obj.setStatus(oId);

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
            tb.Text = obj.getObjectText();
            checker.Text = obj.getObjectText();
            tb.Rows = 80;
            tb.Columns = 200;

            pnldynamic.Controls.Add(tb);
        }

        [WebMethod]
        public void updateText()
        {
            if (checker.Text != tb.Text)
            {
                checker.Text = tb.Text;

                //send data to database
                DataAccess.updateWorkObject(oId, titleField.Text, tb.Text);
                timer.Stop();
                timer.Start();
            }
        }

        protected void exitingObject(object sender, EventArgs e)
        {
            obj.setStatus(oId);
            Response.Redirect("default.aspx");
        }

        #endregion

    }
}
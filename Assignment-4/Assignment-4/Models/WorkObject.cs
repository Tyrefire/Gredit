using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_4.Models
{
    public class WorkObject
    {
        public int objectID { get; set; }
        public int groupID { get; set; }
        public string objectTitle { get; set; }
        public string objectText { get; set; }
        public int status { get; set; }
        public DateTime modifiedDate;

        public WorkObject(int grID)
        {
            groupID = grID;
            objectTitle = "Title";
            objectText = "Text";
            modifiedDate = DateTime.Now;
            status = 0;
            objectID = DataAccess.insertWorkObject(groupID, objectTitle, objectText);
        }

        public WorkObject(int grID, int objID, string objTtitle, string objText, int sta, DateTime modiDate)
        {
            groupID = grID;
            objectID = objID;
            objectTitle = objTtitle;
            objectText = objText;
            status = sta;
            modifiedDate = modiDate;
        }

        public WorkObject(int useless, int moreUseless)
        {
            groupID = 0;
            objectID = 0;
            objectTitle = "";
            objectText = "";
            status = 0;
            modifiedDate = DateTime.Now;
        }

        //Getters
        public int getGroupID()
        {
            return groupID;
        }

        public int getObjectID()
        {
            return objectID;
        }

        public string getObjectTitle()
        {
            return objectTitle;
        }

        public string getObjectText()
        {
            return objectText;
        }

        //Setters
        public void setObjectTitle(string n)
        {
            objectTitle = n;
        }

        public void setObjectText(string d)
        {
            objectText = d;
        }

        public void setStatus(int s)
        {
            if (this.status == 0)
            {
                this.status = 1;
            }
            else
            {
                this.status = 0;
            }
        }

        public void updateDate()
        {
            modifiedDate = DateTime.Now;
        }
    }
}
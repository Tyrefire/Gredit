using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_4.Models
{
    public class WorkObject
    {
        public int objectID;
        public int groupID;
        public string objectTitle;
        public string objectText;
        public int status;
        public DateTime modifiedDate;

        
        DataAccess work = new DataAccess();

        public WorkObject(int grID)
        {
            groupID = grID;
            objectTitle = "Title";
            objectText = "Text";
            modifiedDate = DateTime.Now;
            status = 0;

            work.wName = objectTitle;
            work.wText = objectText;
            objectID = work.insertWorkObject(groupID);
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
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
            //Set defaults to blank strings and zero
            //objectID = 0;
            groupID = grID;
            objectTitle = "Title";
            objectText = "Text";
            modifiedDate = DateTime.Now;
            status = 0;
            //connect to database, write blank values, then set groupID

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
            //set the status depending on what we want
        }

        public void updateDate()
        {
            modifiedDate = DateTime.Now;
        }


    }
}
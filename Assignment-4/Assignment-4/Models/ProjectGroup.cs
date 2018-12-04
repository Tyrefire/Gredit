using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_4.Models
{
    public class ProjectGroup
    {
        public int groupID;
        public string groupName;
        public string groupDescription;
        public int status;
        DataAccess group = new DataAccess();
        
        public ProjectGroup()
        {
            //Set defaults to blank strings and zero
            groupName = "Title";
            groupDescription = "Description";
            status = 0;
            //connect to database, write blank values, then set groupID
            group.gName = groupName;
            group.gDesc = groupDescription;
            group.gStatus = status;
            groupID = group.insert();

        }

        //Getters
        public int getGroupID()
        {
            return groupID;
        }

        public string getGroupName()
        {
            return groupName;
        }

        public string getGroupDescription()
        {
            return groupDescription;
        }

        //Setters
        public void setGroupName(string n)
        {
            groupName = n;
        }

        public void setGroupDescription(string d)
        {
            groupDescription = d;
        }

        public void setStatus(int s)
        {
            
        }

    }
}
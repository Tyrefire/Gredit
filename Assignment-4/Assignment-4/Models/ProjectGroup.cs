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
            groupName = "Title";
            groupDescription = "Description";
            status = 0;

            group.gName = groupName;
            group.gDesc = groupDescription;
            groupID = group.insertGroup();
        }

        public ProjectGroup(int grID, string grName, int sta, string grDescription)
        {
            groupName = "Title";
            groupDescription = "Description";
            status = 0;
            groupID = group.insertGroup();
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
            if (this.status == 0)
            {
                this.status = 1;
            }
            else
            {
                this.status = 0;
            }
        }

    }
}
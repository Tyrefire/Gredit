using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_4.Models
{
    public class ProjectGroup
    {
        public int groupID { get; set; }
        public string groupName { get; set; }
        public string groupDescription { get; set; }
        public int status { get; set; }
        
        public ProjectGroup()
        {
            groupName = "Title";
            groupDescription = "Description";
            status = 0;
            groupID = DataAccess.insertGroup(groupName, groupDescription, status);
        }

        public ProjectGroup(int grID, string grName, int sta, string grDescription)
        {
            groupName = "Title";
            groupDescription = "Description";
            status = 0;
            groupID = grID;
        }
        public ProjectGroup(int useless)
        {
            groupID = 0;
            groupName = "";
            groupDescription = "";
            status = 0;
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
        public void updateProjectGroup()
        {
            DataAccess.updateGroup(groupID, groupName, groupDescription);
        }
    }
}
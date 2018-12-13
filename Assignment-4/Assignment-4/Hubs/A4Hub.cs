using Assignment_4.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace Assignment_4.Hubs
{
	public class A4Hub : Hub
	{
		
		

		public async Task UpdateWorkObject(WorkObject workObj)
		{
			//update the database and the objects collection
			workObj.updateWorkObject();
			await Clients.All.ClientUpdateWorkObject(workObj);
		}

		public async Task UpdateProjectGroup(ProjectGroup group)
		{
			//update the database and the groups collection

			await Clients.All.ClientUpdateProjectGroup(group);

		}

		public async Task AddProjectGroup(ProjectGroup group)
		{
			//update the database and the groups collection

			await Clients.All.ClientAddProjectGroup(group);
		}

		public async Task AddWorkObject(WorkObject workObj)
		{
			//update the database and the objects collection

			await Clients.All.ClientAddWorkObject(workObj);

		}

		public async Task GetGroups()
		{
			ProjectGroup[] groups = DataAccess.getGroups();

			await Clients.Caller.ClientGetGroups(groups);
		}

		public async Task GetWorkObjects(int groupID)
		{
			WorkObject[] workObjs = DataAccess.getWorkObjectsByGroup(groupID);
			await Clients.Caller.ClientGetWorkObjects(workObjs);
		}
	}
}
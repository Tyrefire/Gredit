using Assignment_4.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace Assignment_4.Hubs
{
	public class MyHub : Hub
	{
		
		

		public async Task UpdateWorkObject(WorkObject workObj)
		{
			//update the database and the objects collection

			await Clients.All.SendAsync(workObj);
		}

		public async Task UpdateProjectGroup(ProjectGroup group)
		{
			//update the database and the groups collection

			await Clients.All.SendAsync(group);

		}

		public async Task AddProjectGroup(ProjectGroup group)
		{
			//update the database and the groups collection

			await Clients.All.SendAsync(group);
		}

		public async Task AddWorkObject(WorkObject workObj)
		{
			//update the database and the objects collection

			await Clients.All.SendAsync(workObj);

		}

		public async Task GetGroups()
		{
			ProjectGroup[] groups = DataAccess.GetGroups();

			await Clients.Caller.SendAsync(groups);
		}

		public async Task GetWorkObjects(int groupID)
		{
			WorkObject[] workObjs = DataAccess.GetWorkObjectsByGroupID(groupID);
			await Clients.Caller.SendAsync(workObjs);
		}
	}
}
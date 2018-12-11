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
		Dictionary<int, ProjectGroup> groups = new Dictionary<int, ProjectGroup>();
		Dictionary<int, WorkObject> objects = new Dictionary<int, WorkObject>();
		

		public async Task UpdateWorkObject(WorkObject workObj)
		{
			//update the database and the objects collection

			await Clients.All.SendAsync(objects);
		}

		public async Task UpdateProjectGroup(ProjectGroup group)
		{
			//update the database and the groups collection

			await Clients.All.SendAsync(groups);

		}

		public async Task AddProjectGroup(ProjectGroup group)
		{
			//update the database and the groups collection

			await Clients.All.SendAsync(groups);
		}

		public async Task AddWorkObject(WorkObject workObj)
		{
			//update the database and the objects collection

			await Clients.All.SendAsync(objects);

		}

		public async Task GetGroups()
		{


			await Clients.Caller.SendAsync(groups);
		}

		public async Task GetWorkObjects()
		{
			await Clients.Caller.SendAsync(objects);
		}
	}
}
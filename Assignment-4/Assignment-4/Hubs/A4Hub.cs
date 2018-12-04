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
		public async Task SendMessage(string rank)
		{
			
			await Clients.All.SendAsync();
		}
	}
}
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace RandonNumberUpdate.Hubs
{
    public class ChatHub: Hub

    {
        /// <summary>
        /// Responsible for emmiting events/messages to client
        /// </summary>
        /// <returns></returns>
        public async Task SendMessage()
        {

            await Clients.All.SendAsync("ReceiveMessage");

            for (int i = 0; i <= 100; i++)
            {
                Random random = new Random();

                int ra = random.Next(i, 100);

                await Clients.All.SendAsync("ReceiveMessage", ra.ToString());

                Random randomInterval = new Random();
                int interval = randomInterval.Next(1, 10);
                await Task.Delay(interval * 1000);


            }
        }
    }
}

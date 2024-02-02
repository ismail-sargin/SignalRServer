using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.App.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //{
        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //{
        //public async Task SendMessageAsync(string message, IEnumerable<string> groups)
        //{
        public async Task SendMessageAsync(string message, string groupName)
        {
            #region Caller 
            //Sadece servera bildrim gönderen client ile iletişim kurar.
            //await Clients.Caller.SendAsync("receiveMessage",message);
            #endregion

            #region All
            //Servere bağlı tüm clientlar'la iletişim kurar.
            // await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Other
            //Servera bağlı kendisi dışındaki tüm clientlarla iletişim kurar
            //    await Clients.Others.SendAsync("receiveMessage", message);
            #endregion


            #region HUB Clients Methodları

            #region AllExcept
            // Belirtilen clientlar hariç servera bağlı olan tüm clientlara bildiride bulunur.
            // await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Client
            // Belirli bir client'a mesaj göndermek için bunu kulllan
            //  await Clients.Client(connectionIds.FirstOrDefault()).SendAsync("receiveMessage", message);
            #endregion

            #region Clients
            // Clientlar arasında sadece belirtilen clientlara bildiride bulunur. AllExcept metodunun tersi
            //  await Clients.Clients(connectionIds).SendAsync("receiveMessage",message);
            #endregion

            #region Group
            // Belirtilen Grouplara mesaj gönderir
            // await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion

            #region GroupExcept
            // Belirtilen Gruptakiler haricine mesaj gönderir
            //  await Clients.GroupExcept(groupName,connectionIds).SendAsync("receiveMessage", message);
            #endregion


            #region Groups
            // Birden fazla gruptaki clientlere bildiride bulunmamızı sağlayan fonksiyondur
            //await Clients.Groups(groups).SendAsync("receiveMessage", message);
            #endregion

            #region OthersInGroup
            // Bildiride bulunan client haricinde gruptaki tüm clientlera bildiride bulunan fonksiyondur
            await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion

            #endregion


        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}

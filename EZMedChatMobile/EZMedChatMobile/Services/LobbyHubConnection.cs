using Microsoft.AspNetCore.SignalR.Client;
using Observables.Specialized.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace EZMedChatMobile.Services
{
    public class LobbyHubConnection : IHubConnection
    {
        public HubConnection lobbyConnection;

        public LobbyHubConnection(Uri uri)
        {
            lobbyConnection = new HubConnectionBuilder()
            .WithUrl($"{uri}/chathub").Build();
        }

        public async Task Connect() 
        {
            await lobbyConnection.StartAsync();
        }

        public async Task Disconnect()
        {
            await lobbyConnection.StopAsync();
        }

        public async Task Join(string groupName)
        {
            await lobbyConnection.InvokeAsync("AddToGroup", groupName);
        }

        public async Task Leave(string groupName)
        {
            await lobbyConnection.InvokeAsync("RemoveFromGroup", groupName);
        }

        public async Task SendMessage(string groupName, string message)
        {
            await lobbyConnection.InvokeAsync("SendMessageToGroup", groupName, message);
        }

        public void ConfigureLobbyOutput(ObservableCollection<string> lobbyMembers)
        {
            // Addtogroup might have to be changed to send
            lobbyConnection.On<string>("AddToGroup", (message) =>
            {
                lobbyMembers.Add(message);
            });
        }
    }
}

using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace EZMedChatMobile.Services
{
    public interface IHubConnection
    {
        // starts HubConnection
        Task Connect();

        // ends HubConnection
        Task Disconnect();

        // joins either a chat or group
        // context can be a user for a chat or a groupName for a group
        Task Join(string context);

        // joins either a chat or group
        // context can be a user for a chat or a groupName for a group
        Task Leave(string context);

        // joins either a chat or group
        // context can be a user for a chat or a groupName for a group
        Task SendMessage(string context, string message);

        void ConfigureLobbyOutput(ObservableCollection<string> lobbyMemebers);
    }
}

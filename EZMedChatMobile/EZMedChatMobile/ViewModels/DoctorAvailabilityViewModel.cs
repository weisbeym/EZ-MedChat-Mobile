using EZMedChatMobile.Models;
using EZMedChatMobile.Services;
using Observables.Specialized.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EZMedChatMobile.ViewModels
{
    public class DoctorAvailabilityViewModel : BaseViewModel
    {
        private IHubConnection _lobbyConnection;

        //TODO: add APIDataService and create method the fetch practitioners
        public DoctorAvailabilityViewModel(IHubConnection lobbyConnection)
        {
            _lobbyConnection = lobbyConnection;
            _lobbyConnection.ConfigureLobbyOutput(LobbyMembers);
            HasJoinedLobby = false;
        }

        private ObservableCollection<Practitioner> _practitioners;
        public ObservableCollection<Practitioner> Practitioners
        {
            get { return _practitioners;  }
            set
            {
                _practitioners = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _lobbyMembers;
        public ObservableCollection<string> LobbyMembers
        { 
            get { return _lobbyMembers;  }
            set
            {
                _lobbyMembers = value;
                OnPropertyChanged();
            }
        }

        private bool _hasJoinedLobby;
        public bool HasJoinedLobby
        {
            get { return _hasJoinedLobby;  }
            set
            {
                _hasJoinedLobby = value;
                OnPropertyChanged();
            }
        }

        private string _chosenLobbyHost;
        public string ChosenLobbyHost
        {
            get { return _chosenLobbyHost; }
            set
            {
                _chosenLobbyHost = value;
                OnPropertyChanged();
            }
        }

        // commands
        public Command JoinLobbyCommand => new Command(() => JoinLobby());
        public Command LeaveLobbyCommand => new Command(() => MockLeaveLobby());

        public void Init()
        {
            MockLoadPractitioners();
        }

        public async void JoinLobby()
        {
            // choose which online practitioners lobby to join.
            var possibleLobbyHosts = Practitioners.Where(p => p.IsOnline == true).Select(p => p.FirstName).ToArray();
            var lobbyHost = await Application.Current.MainPage.DisplayActionSheet(
                "Whose lobby do you want to enter?", "Cancel", null, possibleLobbyHosts);
            
            // if the cancel button is pressed instead of choosing a practitioner
            if (string.IsNullOrEmpty(lobbyHost) || lobbyHost == "Cancel")
                return;

            ChosenLobbyHost = lobbyHost;
            // join and display lobby.
            try
            {
                IsBusy = true;

                MockJoinLobby();
                //await _lobbyConnection.Connect();
                //await _lobbyConnection.Join(ChosenLobbyHost);
                HasJoinedLobby = true;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void LeaveLobby(string groupName)
        {
            try
            {
                IsBusy = true;

                await _lobbyConnection.Leave(groupName);
                await _lobbyConnection.Disconnect();

                ChosenLobbyHost = "";
                LobbyMembers = null;
            }
            finally
            {
                IsBusy = false;
            }
        }



        private void MockLoadPractitioners()
        {
            var practitioners = new MockDataService().GetPractitioners();
            Practitioners = new ObservableCollection<Practitioner>(practitioners);
        }

        // change to have lobby members be key-value pair of name and 
        public async void MockJoinLobby()
        {
            ObservableCollection<string> waitingRoomMemebers = new ObservableCollection<string>();
            waitingRoomMemebers.Add("Joel Vincent has joined the lobby.");
            waitingRoomMemebers.Add("Yisroel Weisberg has joined the lobby.");

            await Task.Delay(1000);
            LobbyMembers = waitingRoomMemebers;
        }

        public async void MockLeaveLobby()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(1000);
                ChosenLobbyHost = "";
                LobbyMembers = new ObservableCollection<string>();
                HasJoinedLobby = false;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

using EZMedChatMobile.Models;
using EZMedChatMobile.Services;
using EZMedChatMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EZMedChatMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoctorAvailabilityPage : ContentPage
    {
        DoctorAvailabilityViewModel vm;
        public DoctorAvailabilityPage()
        {
            InitializeComponent();
            vm = new DoctorAvailabilityViewModel(new LobbyHubConnection(new Uri("https://localhost:44389/")));
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm?.Init();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
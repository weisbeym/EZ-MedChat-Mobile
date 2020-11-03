using System;
using System.Collections.Generic;
using EZMedChatMobile.ViewModels;
using EZMedChatMobile.Views;
using Xamarin.Forms;

namespace EZMedChatMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DoctorAvailabilityPage), typeof(DoctorAvailabilityPage));
            Routing.RegisterRoute(nameof(AppointmentsPage), typeof(AppointmentsPage));
        }

        // change to logout 
        // clear cache, rout to LoginPage
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}

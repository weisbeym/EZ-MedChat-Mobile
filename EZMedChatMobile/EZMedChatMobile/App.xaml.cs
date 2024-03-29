﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EZMedChatMobile.Services;
using EZMedChatMobile.Views;

namespace EZMedChatMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MedChatApiDataService>();
            //MainPage = new AppShell();
            MainPage = new LoginPage();
            Device.SetFlags(new string[] { "Expander_Experimental" });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

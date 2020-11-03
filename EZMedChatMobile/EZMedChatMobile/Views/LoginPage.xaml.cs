using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZMedChatMobile.ViewModels;
using EZMedChatMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EZMedChatMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        //LoginViewModel ViewModel => BindingContext as LoginViewModel;

        public LoginPage()
        {
            InitializeComponent();
            var vm = new LoginViewModel(new MedChatApiDataService(new Uri("https://localhost:44389/api/")));
            BindingContext = vm;
        }
    }
}
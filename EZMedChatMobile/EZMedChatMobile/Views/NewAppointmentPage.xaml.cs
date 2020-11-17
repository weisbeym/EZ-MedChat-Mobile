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
    public partial class NewAppointmentPage : ContentPage
    {
        NewAppointmentViewModel vm;

        public NewAppointmentPage()
        {
            InitializeComponent();
            vm = new NewAppointmentViewModel();
            BindingContext = vm;
        }
    }
}
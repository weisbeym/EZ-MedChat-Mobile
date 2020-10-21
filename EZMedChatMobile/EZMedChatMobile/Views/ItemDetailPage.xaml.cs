using System.ComponentModel;
using Xamarin.Forms;
using EZMedChatMobile.ViewModels;

namespace EZMedChatMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
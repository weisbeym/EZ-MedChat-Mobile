using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using EZMedChatMobile.Models;
using EZMedChatMobile.Services;
using EZMedChatMobile.Views;
using Xamarin.Forms;

namespace EZMedChatMobile.ViewModels
{
    public class AppointmentsViewModel : BaseViewModel
    {
        private IMedChatDataService _medChatDataService;

        private ObservableCollection<Appointment> _pastAppointments;
        public ObservableCollection<Appointment> PastAppointments
        {
            get { return _pastAppointments; }
            set
            {
                _pastAppointments = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Appointment> _futureAppointments;
        public ObservableCollection<Appointment> FutureAppointments
        {
            get { return _futureAppointments; }
            set
            {
                _futureAppointments = value;
                OnPropertyChanged();
            }
        }

        public Command ScheduleNewAppointmentCommand=> new Command(() => AddNewAppointment());

        public async void AddNewAppointment()
        {
            await Shell.Current.GoToAsync("NewAppointmentPage");
        }
        public void Init()
        {
            MockLoadAndSortAppointments();
        }

        // the real version would also be called on refresh
        private void MockLoadAndSortAppointments()
        {
            List<Appointment> appointments = new MockDataService().GetAppointments();
            PastAppointments = new ObservableCollection<Appointment>
                (appointments.Where(a => a.AppointmentDate < DateTime.Now));
            FutureAppointments = new ObservableCollection<Appointment>
                (appointments.Where(a => a.AppointmentDate > DateTime.Now));
        }

        private void LoadAndSortAppointments(string token)
        {
            //TODO: get appointments from data service and sort them into past and future.
            //List<Appointment> appointments = _medChatDataService.GetAppointments(token);
            //PastAppointments = new ObservableCollection<Appointment>
            //    (appointments.Where(a => a.AppointmentDate < DateTime.Now));
            //FutureAppointments = new ObservableCollection<Appointment>
            //    (appointments.Where(a => a.AppointmentDate > DateTime.Now));
        }
    }
}

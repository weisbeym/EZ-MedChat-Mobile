using EZMedChatMobile.Models;
using EZMedChatMobile.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using EZMedChatMobile.Validation;
using Xamarin.Forms;

namespace EZMedChatMobile.ViewModels
{
    public class NewAppointmentViewModel : BaseViewModel
    {
        // ------ Variables ------- //
       private List<Practitioner> _practitioners;
       public List<Practitioner> Practitioners
       {
           get { return _practitioners; }
           set
           {
                _practitioners = value;
                OnPropertyChanged();
           }
       }

        private ValidatableObject<Practitioner> _selectedPractitioner;
        public ValidatableObject<Practitioner> SelectedPractitioner
        {
            get { return _selectedPractitioner; }
            set
            {
                _selectedPractitioner = value;
                OnPropertyChanged();
            }
        }

        private ValidatableObject<DateTime> _selectedDate;
        public ValidatableObject<DateTime> SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        private ValidatableObject<TimeSpan> _selectedTime;
        public ValidatableObject<TimeSpan> SelectedTime
        {
            get { return _selectedTime; }
            set
            {
                _selectedTime = value;
                OnPropertyChanged();
            }
        }

        private ValidatableObject<string> _reason;
        public ValidatableObject<string> Reason
        {
            get { return _reason; }
            set
            {
                _reason = value;
                OnPropertyChanged();
            }
        }

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }

        public async void SaveNewAppointment()
        {
            //TODO: when sending to Db also add it to local cache
            IsValid = ValidateInput();

            if (IsValid)
            {
                Appointment newAppointment = new Appointment()
                {
                    ChosenPractitioner = SelectedPractitioner.Value,
                    AppointmentDate = SelectedDate.Value,
                    StartTime = SelectedTime.Value,
                    AppointmentReason = Reason.Value
                };

                await Shell.Current.GoToAsync("AppointmentsPage");
            }
            else
            {
                return;
            }
        }

        // ----- Commands for validation and saving ----- //
        public Command ValidatePractitionerCommand => new Command(() => ValidatePractitionerPicker());
        public Command ValidateDateCommand => new Command(() => ValidateDatePicker());
        public Command ValidateTimeCommand => new Command(() => ValidateTimePicker());
        public Command ValidateReasonCommand => new Command(() => ValidateReason());
        public Command SaveNewAppointmentCommand => new Command(() => SaveNewAppointment());


        public NewAppointmentViewModel()
        {
            //TODO: when service is implemented get doctor info based on patient token
            Practitioners = new MockDataService().CreateMockPractitioners();
            AddValidationRules();
            IsValid = true;
        }

        // ------- Validation Section -------- //
        private bool ValidateInput()
        {
            bool isSelectedPractitionerValid = ValidatePractitionerPicker();
            bool isSelectedDateValid = ValidateDatePicker();
            bool isSelectedTimeValid = ValidateTimePicker();
            bool isReasonValid = ValidateReason();

            return isSelectedPractitionerValid && isSelectedDateValid
                && isSelectedTimeValid && isReasonValid;
        }

        private bool ValidatePractitionerPicker()
        {
            return SelectedPractitioner.Validate();
        }

        private bool ValidateDatePicker()
        {
            return SelectedDate.Validate();
        }

        private bool ValidateTimePicker()
        {
            return SelectedTime.Validate();
        }

        private bool ValidateReason()
        {
            return Reason.Validate();
        }


        private void AddValidationRules()
        {
            _selectedPractitioner.ValidationRules.Add(new IsNotNullOrEmptyRule<Practitioner>
                { ValidationMessage = "Must choose a Practitioner." });

            _selectedDate.ValidationRules.Add(new IsNotNullOrEmptyRule<DateTime> 
                { ValidationMessage = "Must choose a date." });

            _selectedTime.ValidationRules.Add(new IsNotNullOrEmptyRule<TimeSpan> 
                { ValidationMessage = "Must choose a time." });

            _reason.ValidationRules.Add(new IsNotNullOrEmptyRule<string> 
                { ValidationMessage = "Must supply a reason for appointment." });
        }
    }
}

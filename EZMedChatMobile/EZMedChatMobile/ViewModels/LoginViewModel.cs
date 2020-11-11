using EZMedChatMobile.Services;
using EZMedChatMobile.Validation;
using EZMedChatMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EZMedChatMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        // services
        readonly IMedChatDataService _medChatDataService;

        public LoginViewModel(IMedChatDataService medChatDataService)
        {
            _medChatDataService = medChatDataService;
            _username = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            AddValidationRules();
            IsBusy = false;
        }

        // variables
        private ValidatableObject<string> _username;
        private ValidatableObject<string> _password;
        private bool _isValid;

        public ValidatableObject<string>  Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public bool IsValid
        {
            get { return _isValid;  }
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }

        // ---commands---
        // for view entry validation controls
        public Command ValidateUsernameCommand => new Command(() => ValidateUsername());
        public Command ValidatePasswordCommand => new Command(() => ValidatePassword());

        // login commands
        public Command LoginCommand => new Command(async () => await MockLogin());

        private async Task MockLogin()
        {
            if (IsBusy) return;
            bool isValid = Validate();
            //IsValid = isValid;

            if (isValid)
            {
                IsBusy = true;

                try
                {
                    await Task.Delay(5000);
                    Application.Current.MainPage = new AppShell();
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        private async Task Login()
        {
            if (IsBusy) return;
            bool isValid = Validate();
            //IsValid = isValid;

            if (isValid)
            {
                IsBusy = true;

                try
                {
                    // call to api
                    Application.Current.MainPage = new AppShell();
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        // Code for checking username and password validation.
        private bool Validate()
        {
            bool isValidUsername = ValidateUsername();
            bool isValidPassword = ValidatePassword();
            return isValidUsername && isValidPassword;
        }

        private bool ValidateUsername()
        {
            return _username.Validate();
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }

        private void AddValidationRules()
        {
            _username.ValidationRules.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            //_username.ValidationRules.Add(new UsernameDoesNotExistRule<string>(_medChatDataService) { ValidationMessage = "This username already exists." });
            _password.ValidationRules.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
            //_password.ValidationRules.Add(new PasswordRule<string> { ValidationMessage = "Your password must contain at least" +
              //  "1 special character, 1 numeric character, 1 uppercase character, and 1 lowercase character." });
        }
    }
}

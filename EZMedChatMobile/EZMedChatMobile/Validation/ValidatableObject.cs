using EZMedChatMobile.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EZMedChatMobile.Validation
{
    public class ValidatableObject<T> : BaseViewModel, IValidity
    {
        private readonly List<IValidationRule<T>> _validationRules;
        private List<string> _errors;
        private T _value;
        private bool _isValid;

        public List<IValidationRule<T>> ValidationRules => _validationRules;

        public List<string> Errors
        {
            get { return _errors; }
            set
            {
                _errors = value;
                //TODO: find out the difference between raisepropertychanged and onpropertychanged
                //can I just use onpropertuchangeed?
                OnPropertyChanged();
            }
        }

        public T Value
        {
            get { return _value;  }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            _validationRules = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validationRules.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return IsValid;
        }
    }
}

using System;
using PlantTaggerV1.ViewModels.Base;
using PlantTaggerV1.Validations;
using PlantTaggerV1.Services;
using PlantTaggerV1.Models;
using PlantTaggerV1.Models.User;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PlantTaggerV1.ViewModels
{
    public class LoginPageModel : ViewModelBase
    {
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;
        private bool _isLogin;
        private bool _inputValid;

        private IAuthService _authService;
        private ISettingsService _settingsService;

        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());
        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());
        public ICommand SignInCommand => new Command(async () => await SignInAsync());
        public ICommand SignUpCommand => new Command(async () => await SignUpAsync());

        public LoginPageModel(IAuthService authService, ISettingsService settingsService){
            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            _authService = authService;
            _settingsService = settingsService;

            AddValidations();
        }

        public override Task InitializeAsync(object navigationData){
            if (navigationData is LogoutParameter){
                var logoutParameter = (LogoutParameter)navigationData;

                if (logoutParameter.Logout){
                    Logout();
                }
            }

            return base.InitializeAsync(navigationData);
        }

        public ValidatableObject<string> UserName{
            get { 
                return _userName; 
            }
            set { 
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public ValidatableObject<string> Password{
            get{
                return _password;
            }
            set{
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public bool IsLogin
        {
            get
            {
                return _isLogin;
            }
            set
            {
                _isLogin = value;
                RaisePropertyChanged(() => IsLogin);
            }
        }

        public bool InputValid
        {
            get
            {
                return _inputValid;
            }
            set
            {
                _inputValid = value;
                RaisePropertyChanged(() => InputValid);
            }
        }

        private bool ValidateUserName()
        {
            bool status = _userName.Validate();
            recheckInput();
            return status;
        }

        private bool ValidatePassword()
        {
            bool status = _password.Validate();
            recheckInput();
            return status;
        }

        private void recheckInput(){
            InputValid = _userName.IsValid && _password.IsValid;
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
        }

        private async Task SignInAsync()
        {
            IsBusy = true;

            try
            {
                if( !_userName.IsValid || !_password.IsValid ){
                    throw new Exception("Invalid Input");
                }
                AccessToken token = await _authService.Login(_userName.Value, _password.Value);
                _settingsService.AuthAccessToken = token.ToString();
                System.Diagnostics.Debug.WriteLine("Result: " + _settingsService.AuthAccessToken);
                IsLogin = true;
                await Authenticated();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                await DialogService.ShowAlertAsync(ex.Message, "Login Failed", "Ok");
                IsLogin = false;
            }finally{
                IsBusy = false;    
            }
        }

        private async Task Authenticated(){
            await NavigationService.NavigateToAsync<MainPageModel>();
            await NavigationService.RemoveLastFromBackStackAsync();
        }

        private void Logout()
        {
            var authIdToken = _settingsService.AuthIdToken;

            _authService.Logout();
            _settingsService.AuthAccessToken = string.Empty;
        }

        private async Task SignUpAsync()
        {
            await NavigationService.NavigateToAsync<SignUpPageModel>();
        }
    }
}

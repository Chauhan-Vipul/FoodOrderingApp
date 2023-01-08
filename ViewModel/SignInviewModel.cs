using System;
using System.ComponentModel;
using FoodOrderingApp.Model;
using FoodOrderingApp.Service;
using FoodOrderingApp.View;
using System.Runtime.CompilerServices;

namespace FoodOrderingApp.ViewModel
{
	public class SignInviewModel : INotifyPropertyChanged
	{

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _Email;
        public string Email
        {
            set
            {
                _Email = value; OnPropertyChanged();
            }
            get { return _Email; }
        }

        private string _Password;
        public string Password
        {
            set
            {
                _Password = value; OnPropertyChanged();
            }
            get { return _Password; }
        }

        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }

        public SignInviewModel()
		{
            LoginCommand = new Command(LoginUser);
            SignUpCommand = new Command(SignUp);
        }

        private async void SignUp(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignUpView());
        }

        private async void LoginUser()
        {
            
            if((string.IsNullOrEmpty(Email)) || (string.IsNullOrEmpty(Password)))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Field marked with * Cannot be Blank", "Ok");
            }
            else
            {
                var value = new UserService().Login(Email, Password);
                if (await (value) == true)
                {
                    Preferences.Set("Email", Email);
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePageView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "Ok");
                }
            }
            
        }
    }
}


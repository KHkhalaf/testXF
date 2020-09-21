using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using testXF.Data;
using testXF.Models;
using testXF.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace testXF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private User _user;
        public User user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public LoginViewModel()
        {
            user = new User();
        }
        public Command LoginCommand => new Command(async () => {
            try
            {
                await SecureStorage.SetAsync("user_name", _user.Name);
                await SecureStorage.SetAsync("user_password", _user.Password);
                await SecureStorage.SetAsync("user_email", _user.Email);
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
                DependencyService.Get<ISnackBar>().ShowSnackBar("Error ... Something went wrong");
            }

        });

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

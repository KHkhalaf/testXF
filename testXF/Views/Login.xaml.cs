using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            SecureStorage.RemoveAll();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
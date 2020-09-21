using System;
using testXF.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXF
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[]{ "MediaElement_Experimental" });
            InitializeComponent();
            Device.BeginInvokeOnMainThread(async () => {
                var oauthToken = await SecureStorage.GetAsync("user_name");
                if (oauthToken != null)
                        MainPage = new AppShell();
                    else
                        MainPage = new NavigationPage(new Login());
            });

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

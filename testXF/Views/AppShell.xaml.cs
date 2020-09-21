using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public AppShell()
        {
            InitializeComponent();
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            RegisterRoutes();
            BindingContext = this;
        }
        public ICommand NavigateCommand => new Command(Navigate);
        private async void Navigate(object route)
        {
            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"{state.Location}/{route.ToString()}");
            Shell.Current.FlyoutIsPresented = false;
        }
        private void RegisterRoutes()
        {
            routes.Add("Movies", typeof(Movies));
            routes.Add("Profile", typeof(Profile));
            routes.Add("AboutUs", typeof(AboutUs));
            routes.Add("Login", typeof(Login));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
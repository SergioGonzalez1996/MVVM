using MVVM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Services
{
    public class NavigationService
    {
        public async void Navigate(string pageName)
        {
            App.Master.IsPresented = false;

            switch (pageName)
            {
                case "AlarmsPage":
                    await App.Navigator.PushAsync(new AlarmsPage());
                    break;
                case "ClientsPage":
                    await App.Navigator.PushAsync(new ClientsPage());
                    break;
                case "SettingsPage":
                    await App.Navigator.PushAsync(new SettingsPage());
                    break;
                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
                case "NewOrderPage":
                    await App.Navigator.PushAsync(new NewOrderPage());
                    break;
                default:
                    break;
            }
        }
    }
}

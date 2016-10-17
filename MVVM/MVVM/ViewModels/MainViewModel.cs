using System.Collections.ObjectModel;

namespace MVVM.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public MainViewModel()
        {
            LoadMenu();
        }

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_orders.png",
                PageName = "NewOrderPage",
                Title = "Pedidos",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_customers.png",
                PageName = "ClientsPage",
                Title = "Clientes",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_alarm.png",
                PageName = "AlarmsPage",
                Title = "Alarmas",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_settings.png",
                PageName = "SettingsPage",
                Title = "Ajustes",
            });
        }
    }
}

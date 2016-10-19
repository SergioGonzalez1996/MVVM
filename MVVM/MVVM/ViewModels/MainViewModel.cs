using GalaSoft.MvvmLight.Command;
using MVVM.Pages;
using MVVM.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    public class MainViewModel
    {
        #region Attributes
        private NavigationService navigationService { get; set; }
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            Menu = new ObservableCollection<MenuItemViewModel>();
            navigationService = new NavigationService();
            LoadMenu();
            LoadData();
        }
        #endregion

        #region Commands
        public ICommand GoToCommand { get { return new RelayCommand<string>(GoTo); } }

        private void GoTo(string pageName)
        {
            navigationService.Navigate(pageName);
        }

        public ICommand StartCommand { get { return new RelayCommand(Start); } }

        private void Start()
        {
            navigationService.SetMainPage();
        }
        #endregion

        #region Methods
        private void LoadData()
        {
            for (int i = 0; i < 10; i++)
            {
                Orders.Add(new OrderViewModel
                {
                    Title = "Lorem Ipsum",
                    DeliveryDate = DateTime.Today,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                });
            }
        }

        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_orders.png",
                PageName = "MainPage",
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
        #endregion
    }
}

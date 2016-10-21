using GalaSoft.MvvmLight.Command;
using MVVM.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    public class MainViewModel
    {
        #region Attributes
        private NavigationService navigationService { get; set; }
        private ApiService apiService;
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public OrderViewModel NewOrder { get; private set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            Menu = new ObservableCollection<MenuItemViewModel>();
            navigationService = new NavigationService();
            apiService = new ApiService();
            LoadMenu();
        }
        #endregion

        #region Commands
        public ICommand GoToCommand { get { return new RelayCommand<string>(GoTo); } }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewOrderPage":
                    NewOrder = new OrderViewModel();
                    break;
                default:
                    break;
            }
            navigationService.Navigate(pageName);
        }

        public ICommand StartCommand { get { return new RelayCommand(Start); } }

        private async void Start()
        {
            var orders = await apiService.GetAllOrders();
            Orders.Clear();
            foreach (var order in orders)
            {
                Orders.Add(new OrderViewModel
                {
                    Client = order.Client,
                    CreationDate = order.CreationDate,
                    DeliveryDate = order.DeliveryDate,
                    DeliveryInformation = order.DeliveryInformation,
                    Description = order.Description,
                    Id = order.Id,
                    IsDelivered = order.IsDelivered,
                    Phone = order.Phone,
                    Title = order.Title,
                });
            }
            navigationService.SetMainPage();
        }
        #endregion

        #region Methods

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

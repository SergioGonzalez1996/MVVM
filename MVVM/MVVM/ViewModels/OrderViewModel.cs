using GalaSoft.MvvmLight.Command;
using MVVM.Models;
using MVVM.Services;
using System;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    public class OrderViewModel
    {
        #region Attributes
        private ApiService apiService;
        private DialogService dialogService;
        #endregion

        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string DeliveryInformation { get; set; }

        public string Client { get; set; }

        public string Phone { get; set; }

        public bool IsDelivered { get; set; }
        #endregion

        #region Constructors
        public OrderViewModel()
        {
            dialogService = new DialogService();
            apiService = new ApiService();
            DeliveryDate = DateTime.Today;
        }
        #endregion

        #region Commands
        public ICommand SaveCommand { get { return new RelayCommand(Save);} }

        private async void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(Title))
                {
                    await dialogService.ShowMessage("Error", "Debes ingresar un titulo.");
                }

                var order = new Order
                {
                    Id = Id,
                    Client = this.Client,
                    CreationDate = DateTime.Now,
                    DeliveryDate = this.DeliveryDate,
                    DeliveryInformation = this.DeliveryInformation,
                    Description = this.Description,
                    IsDelivered = false,
                    Title = this.Title,
                };

                await apiService.CreateOrder(order);
                await dialogService.ShowMessage("Información", "El pedido ha sido creado");
            }
            catch
            {
                await dialogService.ShowMessage("Error", "Ha ocurrido un error inesperado");
            }
        }
        #endregion
    }
}

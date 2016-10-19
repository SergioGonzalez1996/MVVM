using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using MVVM.Services;

namespace MVVM.ViewModels
{
    public class MenuItemViewModel
    {
        private NavigationService navigationService { get; set; }

        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
        }

        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        public ICommand NavigateCommand { get { return new RelayCommand(Navigate); } }

        private void Navigate()
        {
            navigationService.Navigate(PageName);
        }       
    }
}

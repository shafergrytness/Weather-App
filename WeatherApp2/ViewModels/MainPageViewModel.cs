using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using static WeatherApp2.Models.WeatherItemModel;
using Plugin.Geolocator;

namespace WeatherApp2.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;

        public DelegateCommand NavToCheckCitiesPageCommand { get; set; }
        public DelegateCommand NavToMapsPageCommand { get; set; }
        public DelegateCommand NavToCheckZipCodePageCommand { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavToCheckCitiesPageCommand = new DelegateCommand(NavToCheckCitiesPage);
            NavToMapsPageCommand = new DelegateCommand(NavToMapsPage);
            NavToCheckZipCodePageCommand = new DelegateCommand(NavToCheckZipCodePage);

            Title = "Weather Application with Prism";
        }

        private async void NavToCheckCitiesPage()
        {
            await _navigationService.NavigateAsync("CheckCitiesPage");
        }

        private async void NavToMapsPage()
        {
            await _navigationService.NavigateAsync("MapsPage");
        }

        private async void NavToCheckZipCodePage()
        {
            await _navigationService.NavigateAsync("CheckZipCodePage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}


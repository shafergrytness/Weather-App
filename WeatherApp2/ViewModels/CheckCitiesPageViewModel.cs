﻿using Prism.Commands;
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
    public class CheckCitiesPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand GetWeatherForLocationCommand { get; set; }
        public DelegateCommand<WeatherItem> NavToMoreInfoPageCommand { get; set; }
        public DelegateCommand<WeatherItem> DeleteItemCellCommand { get; set; }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _locationEnteredByUser;
        public string LocationEnteredByUser
        {
            get { return _locationEnteredByUser; }
            set { SetProperty(ref _locationEnteredByUser, value); }
        }

        private ObservableCollection<WeatherItem> _weatherCollection = new ObservableCollection<WeatherItem>();
        public ObservableCollection<WeatherItem> WeatherCollection
        {
            get { return _weatherCollection; }
            set { SetProperty(ref _weatherCollection, value); }
        }

        INavigationService _navigationService;

        public CheckCitiesPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GetWeatherForLocationCommand = new DelegateCommand(GetWeatherForLocation);
            NavToMoreInfoPageCommand = new DelegateCommand<WeatherItem>(NavToMoreInfoPage);
            DeleteItemCellCommand = new DelegateCommand<WeatherItem>(DeleteItemCell);

            Title = "Search the weather for specific cities";
            ButtonText = "Add Name";
        }

        private async void NavToMoreInfoPage(WeatherItem weatherItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", weatherItem);
            await _navigationService.NavigateAsync("MoreInfoPage", navParams);
        }

        private void DeleteItemCell(WeatherItem weatherItem)
        {
            WeatherCollection.Remove(weatherItem);
        }

        internal async void GetWeatherForLocation()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(
                string.Format(
                    $"http://api.openweathermap.org/data/2.5/weather?q={LocationEnteredByUser}&units=imperial&APPID=" +
                    $"{ApiKey.WeatherAPIKey}"));
            var response = await client.GetAsync(uri);
            WeatherItem weatherData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherData = WeatherItem.FromJson(content);
            }
            WeatherCollection.Add(weatherData);
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


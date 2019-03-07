using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Unity;
using WeatherApp2.Views;
using Xamarin.Forms.Xaml;

namespace WeatherApp2
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync($"MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<MoreInfoPage>();
            Container.RegisterTypeForNavigation<CheckCitiesPage>();
            Container.RegisterTypeForNavigation<MapsPage>();
            Container.RegisterTypeForNavigation<CheckZipCodePage>();
        }
    }
}


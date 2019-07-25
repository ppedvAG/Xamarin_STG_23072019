using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HalloI18n
{
    public partial class App : Application
    {
        public App()
        {
            //var cul = new System.Globalization.CultureInfo("de-DE");
            //var cul = new System.Globalization.CultureInfo("en-US");
            var cul = new System.Globalization.CultureInfo("fr-FR");
            ResX.AppResources.Culture = cul;
            ////Thread.CurrentThread.CurrentCulture = cul;
            //Thread.CurrentThread.CurrentUICulture = cul;

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HalloNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            InitializeComponent();
        }

        private async void ShowMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(), true);
        }

        private async void ShowTabPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedPage1(), true);
        }

        private async void Karussell(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarouselPage1(), true);
        }

        private async void GoHome(object sender, EventArgs e)
        {
            //go Home
            await Navigation.PopToRootAsync(true);
        }

        private async void goBack(object sender, EventArgs e)
        {
            //go Back
            await Navigation.PopAsync(true);
        }
    }
}
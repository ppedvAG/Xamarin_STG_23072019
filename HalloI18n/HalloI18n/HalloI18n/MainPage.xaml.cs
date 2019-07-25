using HalloI18n.ResX;
using System.ComponentModel;
using System.Threading;
using Xamarin.Forms;

namespace HalloI18n
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {


            InitializeComponent();


            myLabel.Text = AppResources.MyText;

        }
    }
}

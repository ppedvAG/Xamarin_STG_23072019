using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HalloEss
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BattPage : ContentPage
    {
        public BattPage()
        {
            InitializeComponent();
            Battery.BatteryInfoChanged += (s, e) => ShowBatteryInfo();
            ShowBatteryInfo();
        }

        private void ShowBatteryInfo()
        {
            batLbl.Text = $"{Battery.ChargeLevel:p} {Battery.State}";
            proBar.Progress = Battery.ChargeLevel ;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Vibration.Vibrate();
        }
    }
}
﻿using HalloHotel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HalloHotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuchungenView : ContentPage
    {
        public BuchungenView()
        {
            InitializeComponent();
            //this.Appearing += (s, e) => ((BuchungenViewModel)BindingContext).Reload();
        }
    }
}
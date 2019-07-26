using HalloHotel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HalloHotel.ViewModel
{
    class BuchungenDetailsViewModel : ViewModelBase
    {
        private Buchung selectedBuchung;

        public Buchung SelectedBuchung
        {
            get => selectedBuchung;
            set
            {
                selectedBuchung = value;
                MeChanged();
            }
        }

    }
}

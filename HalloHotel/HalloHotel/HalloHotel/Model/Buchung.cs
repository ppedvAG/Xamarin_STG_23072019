using System;

namespace HalloHotel.Model
{
    public class Buchung : ViewModel.ViewModelBase
    {
        private int naechte;
        private string gast;
        private string bNummer;
        private DateTime datum;

        public int Id { get; set; }
        public DateTime Datum
        {
            get => datum;
            set
            {
                datum = value;
                MeChanged();
            }
        }
        public int Naechte
        {
            get => naechte;
            set
            {
                naechte = value;
                MeChanged();
            }
        }
        public string Gast
        {
            get => gast;
            set
            {
                gast = value;
                MeChanged();
            }
        }
        public string BNummer
        {
            get => bNummer;
            set
            {
                bNummer = value;
                MeChanged();
            }
        }
        public Hotel Hotel { get; set; }
        public decimal GesamtPreis { get; set; }
    }
}

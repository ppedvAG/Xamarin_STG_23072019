using HalloHotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HalloHotel.ViewModel
{
    class BuchungenViewModel : ViewModelBase
    {
        private Buchung selectedBuchung;


        public List<Buchung> BuchungsListe { get; set; }

        public Buchung SelectedBuchung
        {
            get => selectedBuchung;
            set
            {
                selectedBuchung = value;
                MeChanged();
                OnPropertyChanged(nameof(TageInfo));
            }
        }

        public string TageInfo
        {
            get
            {
                if (SelectedBuchung == null)
                    return "Keine Buchung ausgewählt";

                var delta = SelectedBuchung.Datum.Date - DateTime.Now.Date;

                if (delta.Ticks == 0)
                    return "Die ausgewählte Buchung ist heute";
                else if (delta.Ticks > 0)
                    return $"Die auswählte Buchung ist in {delta.Days} Tagen";
                else
                    return $"Die auswählte Buchung war vor {delta.Days * -1} Tagen";
            }
        }

        public BuchungenViewModel()
        {
            BuchungsListe = new List<Buchung>();
            LadeDemodaten();
        }


        private void LadeDemodaten()
        {
            BuchungsListe.Clear();
            BuchungsListe.Add(new Buchung()
            {
                Datum = DateTime.Now.AddDays(-658),
                Gast = "Fred",
                BNummer = "B00-001",
                Naechte = 3,
                GesamtPreis = 145.22m
            });
            BuchungsListe.Add(new Buchung()
            {
                Datum = DateTime.Now.AddDays(-82),
                Gast = "Fred",
                BNummer = "B00-002",
                Naechte = 2,
                GesamtPreis = 45.22m
            });
            BuchungsListe.Add(new Buchung()
            {
                Datum = DateTime.Now.AddDays(16),
                Gast = "Fred",
                BNummer = "B00-004",
                Naechte = 9,
                GesamtPreis = 645.22m
            });
            BuchungsListe.Add(new Buchung()
            {
                Datum = DateTime.Now,
                Gast = "Fred",
                BNummer = "B00-003",
                Naechte = 2,
                GesamtPreis = 85.22m
            });
        }
    }
}

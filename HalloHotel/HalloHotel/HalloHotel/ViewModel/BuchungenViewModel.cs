using HalloHotel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace HalloHotel.ViewModel
{
    class BuchungenViewModel : ViewModelBase
    {
        private Buchung selectedBuchung;


        public ObservableCollection<Buchung> BuchungsListe { get; set; }

        public Buchung SelectedBuchung
        {
            get => selectedBuchung;
            set
            {
                selectedBuchung = value;
                MeChanged();
                OnPropertyChanged(nameof(TageInfo));
                RemoveSelectedBuchungCommand.ChangeCanExecute();
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


        public ICommand AddNewBuchungCommand { get; set; }
        public Command RemoveSelectedBuchungCommand { get; set; }

        public BuchungenViewModel()
        {
            BuchungsListe = new ObservableCollection<Buchung>();
            LadeDemodaten();

            AddNewBuchungCommand = new Command(UserWantsToAddNewBuchung);
            RemoveSelectedBuchungCommand = new Command(UserWantsToRemoveSelectedBuchung, CanDeleteBuchung);
            //RemoveSelectedBuchungCommand = new Command(UserWantsToRemoveSelectedBuchung, o => SelectedBuchung?.Datum.Date >= DateTime.Now.Date);
        }

        private bool CanDeleteBuchung(object arg)
        {
            if (arg != null && arg is Buchung b)
                return b?.Datum.Date >= DateTime.Now.Date;
            else
                return SelectedBuchung?.Datum.Date >= DateTime.Now.Date;
        }

        private void UserWantsToRemoveSelectedBuchung(object obj)
        {
            if (obj != null && obj is Buchung b)
                BuchungsListe.Remove(b);
            else
                BuchungsListe.Remove(SelectedBuchung);
        }

        private void UserWantsToAddNewBuchung(object obj)
        {
            var b = new Buchung()
            {
                Datum = DateTime.Now,
                Gast = "Fred",
                BNummer = $"B00-00{BuchungsListe.Count + 1}",
                Naechte = 1,
                GesamtPreis = 100m
            };
            BuchungsListe.Add(b);
            SelectedBuchung = b;
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

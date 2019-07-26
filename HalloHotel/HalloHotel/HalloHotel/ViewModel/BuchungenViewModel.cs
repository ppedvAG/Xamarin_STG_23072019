using HalloHotel.Data;
using HalloHotel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Essentials;
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

        internal void Reload()
        {
            Application.Current.MainPage.DisplayAlert("AA", "BB", "kk");
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


        public Command AddNewBuchungCommand { get; set; }
        public Command RemoveSelectedBuchungCommand { get; set; }
        public Command ShowDetailsCommand { get; set; }
        public Command XmlWriteCommand { get; set; }
        public Command XmlReadCommand { get; set; }
        public Command SqlWriteCommand { get; set; }
        public Command SqlReadCommand { get; set; }

        public BuchungenViewModel()
        {
            BuchungsListe = new ObservableCollection<Buchung>();
            LadeDemodaten();

            AddNewBuchungCommand = new Command(UserWantsToAddNewBuchung);
            RemoveSelectedBuchungCommand = new Command(UserWantsToRemoveSelectedBuchung, CanDeleteBuchung);
            ShowDetailsCommand = new Command(UserWantsToSeeDetails);

            XmlWriteCommand = new Command(UserWantsToWriteXML);
            XmlReadCommand = new Command(UserWantsToReadXML);

            SqlWriteCommand = new Command(UserWantsToWriteSQL);
            SqlReadCommand = new Command(UserWantsToReadSQL);
        }

        private async void UserWantsToReadSQL(object obj)
        {
            var filePath = Path.Combine(FileSystem.CacheDirectory, dbFileName);

            Datamanager dm = new Datamanager(filePath);
            BuchungsListe.Clear();
            (await dm.ReadBuchungenAsync()).ForEach(x => BuchungsListe.Add(x));
        }

        private void UserWantsToWriteSQL(object obj)
        {
            var filePath = Path.Combine(FileSystem.CacheDirectory, dbFileName);

            Datamanager dm = new Datamanager(filePath);
            BuchungsListe.ToList().ForEach(x => dm.SaveBuchungAsync(x));
        }

        private void UserWantsToReadXML(object obj)
        {
            var filePath = Path.Combine(FileSystem.CacheDirectory, xmlFileName);
            using (var sr = File.OpenRead(filePath))
            {
                var serial = new XmlSerializer(typeof(List<Buchung>));
                var loaded = (List<Buchung>)serial.Deserialize(sr);
                BuchungsListe.Clear();
                loaded.ForEach(x => BuchungsListe.Add(x));
            }
        }

        string xmlFileName = "buchungen.xml";
        string dbFileName = "hotel.db3";

        private async void UserWantsToWriteXML(object obj)
        {
            var filePath = Path.Combine(FileSystem.CacheDirectory, xmlFileName);
            using (var sw = File.OpenWrite(filePath))
            {
                var serial = new XmlSerializer(typeof(List<Buchung>));
                serial.Serialize(sw, BuchungsListe.ToList());
            }
            if (await Application.Current.MainPage.DisplayAlert("", filePath, "copy", "ok"))
                await Clipboard.SetTextAsync(filePath);
        }

        private async void UserWantsToSeeDetails(object obj)
        {

            var view = new View.BuchungenDetailView();
            ((BuchungenDetailsViewModel)view.BindingContext).SelectedBuchung = (Buchung)obj;
            await Application.Current.MainPage.Navigation.PushModalAsync(view);


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

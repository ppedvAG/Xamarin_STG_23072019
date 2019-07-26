using System;

namespace HalloHotel.Model
{
    public class Buchung
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int Naechte { get; set; }
        public string Gast { get; set; }
        public string BNummer { get; set; }
        public Hotel Hotel { get; set; }
        public decimal GesamtPreis { get; set; }
    }
}

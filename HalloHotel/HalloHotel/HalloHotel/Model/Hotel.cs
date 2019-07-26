using SQLite;
using System.Collections.Generic;
using System.Text;

namespace HalloHotel.Model
{
    public class Hotel
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PreisProNacht { get; set; }
        public string Ort { get; set; }
        public List<Buchung> Buchungen { get; set; } = new List<Buchung>();
    }
}

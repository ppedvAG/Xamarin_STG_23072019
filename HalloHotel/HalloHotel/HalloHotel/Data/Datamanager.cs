using HalloHotel.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HalloHotel.Data
{
    public class Datamanager
    {
        SQLiteAsyncConnection db;

        public Datamanager(string path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Buchung>().Wait();
        }

        public Task<List<Buchung>> ReadBuchungenAsync()
        {
            return db.Table<Buchung>().ToListAsync();
        }
        public Task<int> SaveBuchungAsync(Buchung b)
        {   
            return db.InsertAsync(b);
        }
    }
}

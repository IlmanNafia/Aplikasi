using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aplikasi
{
    public class Processing
    {
        private readonly string dbFilename;

        private readonly string namaTabel = "Kontak";

        public Processing(string dbPath)
        {
            dbFilename = dbPath;
        }

        //Get All Kontak
        public List<Kontak> GetAllKontak()
        {
            using (LiteDatabase db = new LiteDatabase(dbFilename))
            {
                // ambil koleksi
                ILiteCollection<Kontak> col = db.GetCollection<Kontak>(namaTabel);
                return col.FindAll().ToList();
            }
        }

        //Add New Kontak
        public string AddKontak(Kontak kontak)
        {
            using (LiteDatabase db = new LiteDatabase(dbFilename))
            {
                // ambil koleksi
                ILiteCollection<Kontak> col = db.GetCollection<Kontak>(namaTabel);
                // lakukan proses insert
                BsonValue id = col.Insert(kontak);
                return id.ToString();
            }
        }

        //Update Kontak
        public string UpdateKontak(Kontak kontak)
        {
            using (LiteDatabase db = new LiteDatabase(dbFilename))
            {
                // ambil koleksi
                ILiteCollection<Kontak> col = db.GetCollection<Kontak>(namaTabel);

                bool ada = col.Update(kontak);

                return !ada ? "E:Not Found" : kontak.Id.ToString();
            }
        }

        //Get Kontak
        public Kontak GetKontak(int id)
        {
            using (LiteDatabase db = new LiteDatabase(dbFilename))
            {
                // ambil koleksi
                ILiteCollection<Kontak> col = db.GetCollection<Kontak>(namaTabel);
                return col.FindById(id);
            }
        }

        //Delete Kontak
        public string DeleteKontak(int id)
        {
            using (LiteDatabase db = new LiteDatabase(dbFilename))
            {
                // ambil koleksi
                ILiteCollection<Kontak> col = db.GetCollection<Kontak>(namaTabel);

                bool ada = col.Delete(id);

                return !ada ? "E:Not Found" : "S:" + id.ToString();
            }
        }
    }
}
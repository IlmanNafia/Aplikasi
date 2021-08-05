using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplikasi
{
    public partial class App : Application
    {
        private static Processing db;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static Processing LiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new Processing(Path.Combine(FileSystem.AppDataDirectory, "LiteDB.db"));
                }
                return db;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

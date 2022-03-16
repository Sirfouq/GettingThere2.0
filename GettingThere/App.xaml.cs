using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GettingThere.Data;

namespace GettingThere
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserLogin.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new MainPage());
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

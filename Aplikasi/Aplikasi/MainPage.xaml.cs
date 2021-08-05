using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aplikasi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Get All Kontak
            List<Kontak> kontakList = App.LiteDB.GetAllKontak();
            if (kontakList.Count != 0)
            {
                lstPersons.ItemsSource = kontakList;
            }
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) & !string.IsNullOrEmpty(txtPhone.Text) & string.IsNullOrEmpty(txtId.Text))
            {
                Kontak kontak = new Kontak()
                {
                    Name = txtName.Text,
                    Phone = txtPhone.Text
                };
                //Add New Kontak
                App.LiteDB.AddKontak(kontak);
                txtName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                DisplayAlert("Success", "Kontak Added", "OK");

                //Get All Kontak
                var kontakList = App.LiteDB.GetAllKontak();
                if (kontakList.Count != 0)
                {
                    lstPersons.ItemsSource = kontakList;
                }
            }
        }

        private void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                var kontak = App.LiteDB.GetKontak(Convert.ToInt32(txtId.Text));
                if (kontak != null)
                {
                    txtName.Text = kontak.Name;
                    txtPhone.Text = kontak.Phone;
                    DisplayAlert("Success", "Name: " + kontak.Name, "OK");                    
                }
                else
                {
                    DisplayAlert("Failed", "Kontak is not available", "OK");
                }
            }
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                Kontak kontak = new Kontak()
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Name = txtName.Text,
                    Phone = txtPhone.Text
                };

                //Update Kontak
                App.LiteDB.UpdateKontak(kontak);
                txtName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtId.Text = string.Empty;
                DisplayAlert("Success", "Kontak Updated", "OK");

                //Get All Kontak
                var kontakList = App.LiteDB.GetAllKontak();
                if (kontakList.Count != 0)
                {
                    lstPersons.ItemsSource = kontakList;
                }
            }
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                //Delete Kontak
                App.LiteDB.DeleteKontak(Convert.ToInt32(txtId.Text));
                txtId.Text = string.Empty;
                txtPhone.Text = string.Empty;
                DisplayAlert("Warning", "Kontak Deleted!", "OK");

                //Get All Kontak
                var kontakList = App.LiteDB.GetAllKontak();
                if (kontakList.Count != 0)
                {
                    lstPersons.ItemsSource = kontakList;
                }
            }
        }
    }
}
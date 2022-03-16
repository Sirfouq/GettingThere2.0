using System;
using System.Collections.Generic;
using GettingThere.Models;

using Xamarin.Forms;

namespace GettingThere
{
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage()
        {
            InitializeComponent();
            btnSubmit.Clicked += OnSubmitButtonClicked;
        }

        public async void OnSubmitButtonClicked(object sender , EventArgs e)
        {
            if (!string.IsNullOrEmpty(Reference.Text)){

                await App.Database.SaveProductAsync(new Product
                {
                    ID = Convert.ToInt32(Reference.Text),
                    Price = Convert.ToDouble(Price.Text),
                    Description = Description.Text,
                    Rating=Convert.ToInt32(Rating.Text)
                });

                Reference.Text = Price.Text = Description.Text =Rating.Text= string.Empty;

            }

        }



        
    }
}

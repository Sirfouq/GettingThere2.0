using System;
using System.Collections.Generic;
using GettingThere.Models;

using Xamarin.Forms;

namespace GettingThere
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public async void btnRegister_Clicked(System.Object sender, System.EventArgs e)
        {



            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();

            if (!string.IsNullOrWhiteSpace(Username.Text))
            {
                await App.Database.SaveUserAsync(new User
                {
                    UserName = (Username.Text).ToString(),
                    Pass = (Password.Text).ToString(),
                    Email = (Email.Text).ToString(),

                });
                Username.Text = Password.Text = Email.Text = Company.Text = FirstName.Text = LastName.Text = AFM.Text = string.Empty;
                
            }


        }
    }
}

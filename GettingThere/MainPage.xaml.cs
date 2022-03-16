using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using GettingThere.Models;

namespace GettingThere
{
    public partial class MainPage : ContentPage
    {

        List<User> list { get; set; }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            onLoad();
        }
        public MainPage()
        {
            InitializeComponent();


        }

        public async void onLoad()
        {
            list = new List<User>(await App.Database.GetUserAsync());
            var preloadedValue =
                list.OrderByDescending(value => value.ID).Select(value => value.UserName).Take(1);
            //                    select i.UserName).Take(1)).ToString();
            foreach (var i in preloadedValue)
            {
                User.Text = i;
            }
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User();
            user.UserName = User.Text;
            user.Pass = Pass.Text;
            if (user.UserName == Constants.Username && user.Pass == Constants.Password)
            {

                Navigation.InsertPageBefore(new MyTabbedPage(), this);
                await Navigation.PopAsync();

                if (!string.IsNullOrWhiteSpace(User.Text) && !string.IsNullOrWhiteSpace(Pass.Text))
                {

                    await App.Database.SaveUserAsync(new User
                    {
                        UserName = User.Text,
                        Pass = Pass.Text
                    });
                    User.Text = Pass.Text = string.Empty;

                    



                }
            }
            else
            {
                Validation.Text = "Wrong Username or Password. Please try again.";
            }


        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }         /*async void OnRegisterButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
         
        }*/
    }
 }



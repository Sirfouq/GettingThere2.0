using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GettingThere
{
    public partial class InventoryPage : ContentPage
    {
        public InventoryPage()
        {
            InitializeComponent();
            btnAdd.Clicked += onAddButtonClicked;
            btnDelete.Clicked += onDeleteButtonClicked;
            
        }


        public async void onAddButtonClicked(object sender,EventArgs e)
        {
            Navigation.PushAsync(new AddProductPage());
        }
        
        public async void onDeleteButtonClicked(object sender,EventArgs e)
        {
            Navigation.PushAsync(new DeleteProductPage());
        }
                            
    }

}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GettingThere.Models;
using System.Linq;
using GettingThere.Data;


using Xamarin.Forms;

namespace GettingThere
{
    public partial class DeleteProductPage : ContentPage
    {
        List<object> Soon_to_be_Deleted{ get; set; } 
        List<Product> list { get; set; }
        ObservableCollection<Product> SelectedItems { get; set; } 
        protected override void OnAppearing()
        {
            
            base.OnAppearing();
            onLoad();
        }
        public DeleteProductPage()
        {   
            InitializeComponent();
            BindingContext = this;
            btnDelete.Clicked += OnDeleteButton;
        }
        public async void onLoad()
        {
           
            list = new List<Product>(await App.Database.GetProductAsync());
            SelectedItems = new ObservableCollection<Product>(list);
            DeleteProductListView.ItemsSource = SelectedItems;
        }


        public void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var SearchTerm = e.NewTextValue;
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                SearchTerm = string.Empty;
            }
            SearchTerm = SearchTerm.ToLowerInvariant();
            var FilteredItems = list.Where(value => value.Description.ToLowerInvariant().Contains(SearchTerm)
            || value.ID.ToString().ToLowerInvariant().Contains(SearchTerm)
            || value.Price.ToString().ToLowerInvariant().Contains(SearchTerm)).ToList(); //|| value.Price == Convert.ToDouble(SearchTerm
                                                                                         //) || value.Description == Convert.ToString(SearchTerm));

            foreach (var value in list)
            {
                if (!FilteredItems.Contains(value))
                {
                   
                    SelectedItems.Remove(value);
                }
                else if (!SelectedItems.Contains(value))
                {
                    SelectedItems.Add(value);
                }
            }
        }

        public async void OnDeleteButton(object sender,EventArgs e)
        {
          
            Soon_to_be_Deleted = new List<object>(DeleteProductListView.SelectedItems);
            if(Soon_to_be_Deleted.FirstOrDefault() != null)
            {

                foreach(var value in Soon_to_be_Deleted)
                {
                    SelectedItems.Remove((Product)value);
                    _ = await App.Database.DeleteProductAsync((Product)value);
                }
            }
        }


    }
}

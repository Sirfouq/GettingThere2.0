using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using GettingThere.Models;

namespace GettingThere
{
    public partial class StorePage : ContentPage
    {
         List<Product> list { get; set; }
         ObservableCollection<Product> prod { get; set; }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            onLoad();
        }
        public StorePage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        public async void onLoad()
        {
            list = new List<Product>(await App.Database.GetProductAsync());
            prod = new ObservableCollection<Product>(list);
            CollectionView.ItemsSource = prod;
            
            
        }

        private bool isListVisible;
        public void OnTapped(object sender, EventArgs e)
        {

            isListVisible = !isListVisible;
            ListSection.IsVisible = isListVisible;
            if (ShowTable.Text == "Show Store")
            {
                ShowTable.Text = "Hide Store";
            }
            else
            {
                ShowTable.Text = "Show Store";
                
            }

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
                    prod.Remove(value);
                }
                else if (!prod.Contains(value))
                {
                    prod.Add(value);
                }
            }
        }


            

            


        

    }
}

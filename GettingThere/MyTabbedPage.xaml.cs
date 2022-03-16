using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GettingThere
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : TabbedPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            onLoad();
        }
        public MyTabbedPage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(this,false);

        }

        public async void onLoad()
        {
            

        }
    }
}

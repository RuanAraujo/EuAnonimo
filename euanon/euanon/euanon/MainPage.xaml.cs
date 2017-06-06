using euanon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace euanon
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();

            //Master = new MasterPage();
            Detail = new NavigationPage(new DetailPage());

            masterPage.ListView.ItemSelected += OnItemSelected;
            masterPage.ListViewOpcoes.ItemSelected += OnItemSelected;
        }

        

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = true;
            }
        }
    }
}

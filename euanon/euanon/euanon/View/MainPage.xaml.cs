using euanon.View;
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
            masterPage.ListViewOpcoes.ItemSelected += OnOpcaoSelected;
        }

        void OnOpcaoSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListViewOpcoes.SelectedItem = null;
                IsPresented = false;
            }
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
           
            if (item != null)
            {
                var categoria = item.Title;
                Detail = new NavigationPage(new CategoriaPage(categoria));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}

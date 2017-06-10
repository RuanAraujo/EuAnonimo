using euanon.Model;
using euanon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace euanon.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaPage : ContentPage
    {
        //private DescubraViewModel ViewModel => BindingContext as DescubraViewModel;
        //DescubraViewModel ViewModel = new DescubraViewModel();
        public CategoriaPage(string categoria)
        {
           InitializeComponent();
           BindingContext = new CategoriaViewModel(categoria);
        }

        private void listFeed_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                // ViewModel.ItemCommand.Execute(e.SelectedItem);
                Item((Post)e.SelectedItem);
                listFeed.SelectedItem = null;
            }
        }
        public async void Item(Post post)
        {
            await DisplayAlert(post.Titulo, post.Texto, "OK");
        }
    }
}
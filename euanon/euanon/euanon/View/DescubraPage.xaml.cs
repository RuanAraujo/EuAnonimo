using euanon.Model;
using euanon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace euanon
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescubraPage : ContentPage
    {
       private DescubraViewModel ViewModel = new  DescubraViewModel();
        public DescubraPage()
        {
            InitializeComponent();
            BindingContext = new DescubraViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.ItemCommand.Execute(e.SelectedItem);
                listFeed.SelectedItem = null;
            }
        }
    }
}
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

            Master = new  MasterPage();
            Detail = new NavigationPage(new DetailPage());

        }
    }
}

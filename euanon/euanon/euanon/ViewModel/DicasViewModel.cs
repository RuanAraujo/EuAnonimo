using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace euanon.ViewModel
{
    public class DicasViewModel : BaseViewModel
    {
        public Command ComecarCommand { get; set; }
        INavigation navigation;
        public DicasViewModel(INavigation nav)
        {
            navigation = nav;
            ComecarCommand = new Command(() => Comecar());
        }
        async void Comecar()
        {
            Application.Current.MainPage = new MainPage();
            var mainPage = new MainPage();
            await navigation.PushAsync(mainPage);
        }
    }
}

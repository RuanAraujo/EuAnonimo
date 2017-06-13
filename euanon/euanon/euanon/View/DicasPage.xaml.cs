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
    public partial class DicasPage : CarouselPage
    {
        public DicasPage()
        {
            InitializeComponent();
            BindingContext = new DicasViewModel(Navigation);
        }
    }
}
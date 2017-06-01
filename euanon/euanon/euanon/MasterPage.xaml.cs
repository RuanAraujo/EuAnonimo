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
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public MasterPage()
        {
            InitializeComponent();

            BindingContext = new MasterViewModel(Navigation);

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Amor",
                IconSource = "heart.png",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Reflexão",
                IconSource = "reflexao.png",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Amizade",
                IconSource = "amizade.png",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Carinho",
                IconSource = "afeicao.png",
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
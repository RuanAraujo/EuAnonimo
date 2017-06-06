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
        public ListView ListViewOpcoes { get { return listViewOpcoes; } }
        public MasterPage()
        {
            InitializeComponent();

            BindingContext = new MasterViewModel(Navigation);

            var opcoes = new List<MasterPageItem>();
            opcoes.Add(new MasterPageItem
            {
                Title = "About",
                IconSource = "info.png",
                TargetType = typeof(AboutPage)
            });

            //Categorias da page master
            var categorias = new List<MasterPageItem>();
            categorias.Add(new MasterPageItem
            {
                Title = "Amor",
                IconSource = "heart.png",
            });
            categorias.Add(new MasterPageItem
            {
                Title = "Reflexão",
                IconSource = "reflexao.png",
            });
            categorias.Add(new MasterPageItem
            {
                Title = "Amizade",
                IconSource = "amizade.png",
            });
            categorias.Add(new MasterPageItem
            {
                Title = "Carinho",
                IconSource = "afeicao.png",
            });

            listView.ItemsSource = categorias;
            listViewOpcoes.ItemsSource = opcoes;
        }
    }
}
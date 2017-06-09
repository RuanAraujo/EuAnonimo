using euanon.View;
using euanon.ViewModel;
using System.Collections.Generic;
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
                Title = "Sobre",
                IconSource = "info.png",
                TargetType = typeof(AboutPage)
            });
            opcoes.Add(new MasterPageItem
            {
                Title = "Configurações",
                IconSource = "config.png",
                TargetType = typeof(ConfiguracaoPage)
            });

            //Categorias da page master
            var categorias = new List<MasterPageItem>();
            categorias.Add(new MasterPageItem
            {
                Title = "Amor",
                IconSource = "heart.png",
                TargetType = typeof(CategoriaPage)
            });
            categorias.Add(new MasterPageItem
            {
                Title = "Reflexão",
                IconSource = "reflexao.png",
                TargetType = typeof(CategoriaPage)
            });
            categorias.Add(new MasterPageItem
            {
                Title = "Amizade",
                IconSource = "amizade.png",
                TargetType = typeof(CategoriaPage)
            });
            categorias.Add(new MasterPageItem
            {
                Title = "Carinho",
                IconSource = "afeicao.png",
                TargetType = typeof(CategoriaPage)
            });

            listView.ItemsSource = categorias;
            listViewOpcoes.ItemsSource = opcoes;
        }
    }
}
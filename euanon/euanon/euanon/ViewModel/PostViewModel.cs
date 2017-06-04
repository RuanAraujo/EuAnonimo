using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace euanon.ViewModel
{
    public class PostViewModel : BaseViewModel
    {
        public List<string> Categorias { get; set; }
        public Command CategoriasCommand;
        public PostViewModel()
        {
            listarCategorias();
        }
       
        public void listarCategorias()
        {
            Categorias = new List<string>();
            Categorias.Add("Amor");
            Categorias.Add("Reflexao");
            Categorias.Add("Amizade");
            Categorias.Add("Afeição");
        }
       
        

    }
}

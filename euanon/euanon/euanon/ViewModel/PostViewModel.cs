using euanon.Model;
using euanon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace euanon.ViewModel
{
    public class PostViewModel : BaseViewModel
    {
        public List<string> Categorias { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Categoria { get; set; }
        //public Command PostCommand;
        ICommand postCommand;
        public ICommand PostCommand => postCommand ?? (postCommand = new Command(async () => await ExecutePostCommand()));
        Azure azure;
        Post post;

        public PostViewModel()
        {
            listarCategorias();
            //postCommand = new Command(() => ExecutePostCommand());
            azure = new Azure();
        }

        async Task ExecutePostCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            post = new Post();
            post.Categoria = this.Categoria;
            post.Titulo = this.Titulo;
            post.Texto = this.Texto;

            //await DisplayAlert("Postando..", "Estamos postando " + this.Titulo + " Aguarde", "Ok");
            azure.AddPost(post);
            
            IsBusy = false;
            /*await DisplayAlert("Postando..", this.Titulo + " Postado", "Ok");
            this.Titulo = string.Empty;
            this.Texto = string.Empty;
            this.Categoria = null;*/
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

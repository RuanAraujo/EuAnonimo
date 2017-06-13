using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euanon.Model
{
    [DataTable("Post")]
    public class Post
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [Version]
        public string Version { get; set; }

        [JsonProperty("Categoria")]
        public string Categoria { get; set; }

        [JsonProperty("Titulo")]
        public string Titulo { get; set; }

        [JsonProperty("Texto")]
        public string Texto { get; set; }


        Util util;
        private string imagem;

        public string Imagem
        {
            get { return imagem; }
            set {
                    util = new Util();
                    imagem = util.selecionaImagem(this.Categoria);
                }
        }

    }
}

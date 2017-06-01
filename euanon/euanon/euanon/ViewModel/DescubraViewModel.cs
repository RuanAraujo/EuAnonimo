using euanon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euanon.ViewModel
{
    public class DescubraViewModel : BaseViewModel
    {
        public string Token { get; set; }
        public string UserId { get; set; }

        public DescubraViewModel()
        {
            Token = Settings.AuthToken;
            UserId = Settings.UserId;
        }
    }
}

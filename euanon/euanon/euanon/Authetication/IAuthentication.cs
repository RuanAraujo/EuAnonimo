using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euanon.Authetication
{
    public interface IAuthentication
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
                                MobileServiceAuthenticationProvider provider,
                                IDictionary<string, string> paramameters = null);

        Task LogoutAsync(MobileServiceClient client, IDictionary<string, string> parameters = null);
    }
}

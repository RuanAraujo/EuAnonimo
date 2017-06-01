using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euanon.Model
{
    public class User
    {
        [JsonProperty(PropertyName = "id_token")]
        public string IdToken { get; set; }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "user_claims")]
        public List<UserClaim> UserClaims { get; set; }
    }

    public class UserClaim
    {
        [JsonProperty(PropertyName = "typ")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "val")]
        public string Value { get; set; }
    }
}

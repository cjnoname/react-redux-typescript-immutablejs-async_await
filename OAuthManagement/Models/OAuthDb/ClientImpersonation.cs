using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class ClientImpersonation
    {
        public ClientImpersonation()
        {
            AccessToken = new HashSet<AccessToken>();
        }

        public int ClientImpersonationId { get; set; }
        public string ClientId { get; set; }
        public string ImpersonateClientId { get; set; }
        public string Scope { get; set; }

        public Client Client { get; set; }
        public Client ImpersonateClient { get; set; }
        public ICollection<AccessToken> AccessToken { get; set; }
    }
}

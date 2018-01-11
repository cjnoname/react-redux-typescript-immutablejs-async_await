using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class Client
    {
        public Client()
        {
            AccessToken = new HashSet<AccessToken>();
            ClientAccessParameter = new HashSet<ClientAccessParameter>();
            ClientImpersonationClient = new HashSet<ClientImpersonation>();
            ClientImpersonationImpersonateClient = new HashSet<ClientImpersonation>();
            ClientParameter = new HashSet<ClientParameter>();
            ClientResourceAccess = new HashSet<ClientResourceAccess>();
        }

        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; }

        public ICollection<AccessToken> AccessToken { get; set; }
        public ICollection<ClientAccessParameter> ClientAccessParameter { get; set; }
        public ICollection<ClientImpersonation> ClientImpersonationClient { get; set; }
        public ICollection<ClientImpersonation> ClientImpersonationImpersonateClient { get; set; }
        public ICollection<ClientParameter> ClientParameter { get; set; }
        public ICollection<ClientResourceAccess> ClientResourceAccess { get; set; }
    }
}

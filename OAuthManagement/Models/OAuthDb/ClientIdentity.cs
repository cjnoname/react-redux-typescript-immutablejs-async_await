using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class ClientIdentity
    {
        public int ClientIdentityId { get; set; }
        public string ClientId { get; set; }
        public string IdentityClientId { get; set; }
        public string IdentityProviderId { get; set; }
    }
}

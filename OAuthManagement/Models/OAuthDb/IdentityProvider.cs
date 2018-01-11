using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class IdentityProvider
    {
        public string IdentityProviderId { get; set; }
        public int? IdentityProviderTypeId { get; set; }
        public string Configuration { get; set; }
    }
}

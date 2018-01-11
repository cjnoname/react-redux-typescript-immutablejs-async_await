using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class AccessProvider
    {
        public AccessProvider()
        {
            ClientAccessParameter = new HashSet<ClientAccessParameter>();
        }

        public string AccessProviderId { get; set; }
        public int? AccessProviderTypeId { get; set; }
        public string Configuration { get; set; }

        public ICollection<ClientAccessParameter> ClientAccessParameter { get; set; }
    }
}

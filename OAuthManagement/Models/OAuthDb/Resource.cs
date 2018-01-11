using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class Resource
    {
        public Resource()
        {
            ClientAccessParameter = new HashSet<ClientAccessParameter>();
            ClientParameter = new HashSet<ClientParameter>();
            ClientResourceAccess = new HashSet<ClientResourceAccess>();
        }

        public string ResourceId { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
        public string Access { get; set; }

        public ICollection<ClientAccessParameter> ClientAccessParameter { get; set; }
        public ICollection<ClientParameter> ClientParameter { get; set; }
        public ICollection<ClientResourceAccess> ClientResourceAccess { get; set; }
    }
}

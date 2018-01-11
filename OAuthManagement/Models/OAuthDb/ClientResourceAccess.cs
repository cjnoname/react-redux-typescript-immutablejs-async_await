using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class ClientResourceAccess
    {
        public int ClientResourceAccessId { get; set; }
        public string ClientId { get; set; }
        public string ResourceId { get; set; }
        public string Access { get; set; }

        public Client Client { get; set; }
        public Resource Resource { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class ClientAccessParameter
    {
        public int ClientAccessParameterId { get; set; }
        public string ResourceId { get; set; }
        public string ClientId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string AccessProviderId { get; set; }
        public bool IncludeInResponse { get; set; }

        public AccessProvider AccessProvider { get; set; }
        public Client Client { get; set; }
        public Resource Resource { get; set; }
    }
}

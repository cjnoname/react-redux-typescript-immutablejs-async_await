using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class ClientConfig
    {
        public string ClientId { get; set; }
        public int? MaxActiveAccessTokens { get; set; }
        public int MaxTokenExpirySeconds { get; set; }
        public int? MaxTokenUses { get; set; }
        public bool ExpireOldestTokenOnExceedMax { get; set; }
    }
}

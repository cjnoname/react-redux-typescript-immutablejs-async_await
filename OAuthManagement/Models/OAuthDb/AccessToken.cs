using System;
using System.Collections.Generic;

namespace OAuthManagement.Models.OAuthDb
{
    public partial class AccessToken
    {
        public AccessToken()
        {
            RefreshToken = new HashSet<RefreshToken>();
        }

        public string Token { get; set; }
        public string ClientId { get; set; }
        public DateTime Expires { get; set; }
        public int Uses { get; set; }
        public int? MaxUses { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime? LastConsumed { get; set; }
        public string Scope { get; set; }
        public int? ClientImpersonationId { get; set; }

        public Client Client { get; set; }
        public ClientImpersonation ClientImpersonation { get; set; }
        public ICollection<RefreshToken> RefreshToken { get; set; }
    }
}

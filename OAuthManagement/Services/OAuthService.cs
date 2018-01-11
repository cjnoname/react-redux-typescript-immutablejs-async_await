using System.Collections.Generic;
using System.Threading.Tasks;
using OAuthManagement.Interfaces;
using OAuthManagement.Models.OAuthDb;
using OAuthManagement.Models.Requests;

namespace OAuthManagement.Services
{
    public class OAuthService : IOAuthService
    {
        private readonly OAuthContext oAuthContext;

        public OAuthService(OAuthContext oAuthContext)
        {
            this.oAuthContext = oAuthContext;
        }

        public async Task UpdateOAuthDb(OAuthDbUpdateRequest request)
        {
            // Create client basic information
            await oAuthContext.Client.AddAsync(new Client
            {
                ClientId = request.ClientId,
                Secret = request.ClientSecret,
                Name = request.ClientName
            });

            // Configure standard token expiry 
            await oAuthContext.ClientConfig.AddAsync(new ClientConfig
            {
                ClientId = request.ClientId,
                MaxActiveAccessTokens = 50,
                MaxTokenExpirySeconds = 8000,
                ExpireOldestTokenOnExceedMax = true
            });

            // Configure the NewClient to be able access the resources of the defined seller
            await oAuthContext.ClientAccessParameter.AddRangeAsync(new List<ClientAccessParameter>
            {
                new ClientAccessParameter
                {
                    ResourceId = "product_content",
                    ClientId = request.ClientId,
                    Key = "organisation_ids",
                    Value = "[0]",
                    IncludeInResponse = true
                },

                new ClientAccessParameter
                {
                    ClientId = request.ClientId,
                    Key = "permission_level",
                    Value = "4",
                    IncludeInResponse = true
                },

                new ClientAccessParameter
                {
                    ClientId = request.ClientId,
                    Key = "place_code",
                    Value = request.PlaceCode,
                    IncludeInResponse = true
                },

                new ClientAccessParameter
                {
                    ClientId = request.ClientId,
                    Key = "place_code",
                    Value = request.PlaceCode,
                    IncludeInResponse = true
                },

                new ClientAccessParameter
                {
                    ClientId = request.ClientId,
                    Key = "chain_code",
                    Value = request.ChainCode,
                    IncludeInResponse = true
                },

                new ClientAccessParameter
                {
                    ClientId = request.ClientId,
                    Key = "performance_code",
                    Value = request.PlaceCode,
                    AccessProviderId = "OriginPromMatch",
                    IncludeInResponse = false
                }
            });

            await oAuthContext.ClientParameter.AddAsync(new ClientParameter
            {
                ClientId = request.ClientId,
                Key = "username",
                Value = request.ClientId
            });

            // Allow MobileAppServices to impersonate the new client
            await oAuthContext.ClientImpersonation.AddAsync(new ClientImpersonation
            {
                ClientId = "MobileAppServices",
                ImpersonateClientId = request.ClientId,
                Scope = "product_content.read customers.read prices.read"
            });

            // Confiugre the resources the client has access
            await oAuthContext.ClientResourceAccess.AddRangeAsync(
                new List<ClientResourceAccess>
                {
                    new ClientResourceAccess
                    {
                        ClientId = request.ClientId,
                        ResourceId = "mobile_app_services",
                        Access = "*"
                    }
                }
            );

            await oAuthContext.SaveChangesAsync();
        }
    }
}

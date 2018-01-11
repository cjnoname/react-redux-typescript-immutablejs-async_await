using Microsoft.EntityFrameworkCore;
using OAuthManagement.Interfaces;
using OAuthManagement.Models.OAuthDb;
using System.Linq;
using System.Threading.Tasks;

namespace OAuthManagement.Services
{
    public class SampleService : ISampleService
    {
        private readonly OAuthContext oAuthContext;

        public SampleService(OAuthContext oAuthContext)
        {
            this.oAuthContext = oAuthContext;
        }

        public async Task<AccessToken> GetAnItem()
        {
            var aa = await oAuthContext.AccessToken.FirstAsync();
            return aa;
        }
    }
}

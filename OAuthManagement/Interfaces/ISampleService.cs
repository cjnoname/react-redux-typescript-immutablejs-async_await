using OAuthManagement.Models.OAuthDb;
using System.Threading.Tasks;

namespace OAuthManagement.Interfaces
{
    public interface ISampleService
    {
        Task<AccessToken> GetAnItem();
    }
}

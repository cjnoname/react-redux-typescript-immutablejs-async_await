using OAuthManagement.Models.Requests;
using System.Threading.Tasks;

namespace OAuthManagement.Interfaces
{
    public interface IOAuthService
    {
        Task UpdateOAuthDb(OAuthDbUpdateRequest request);
    }
}

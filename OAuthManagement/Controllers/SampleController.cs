using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OAuthManagement.Interfaces;
using OAuthManagement.Models.OAuthDb;

namespace OAuthManagement.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        private readonly ISampleService sampleService;

        public SampleController(ISampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        [HttpGet("[action]")]
        public async Task<AccessToken> GetItem()
        {
            return new AccessToken
            {
                Client = new Client
                {
                    ClientId = "123456"
                },
                Token = "123"
            };
            //return await sampleService.GetAnItem();
        }
    }
}

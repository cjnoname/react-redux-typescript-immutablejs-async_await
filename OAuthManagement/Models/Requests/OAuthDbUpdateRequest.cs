
using System.ComponentModel.DataAnnotations;

namespace OAuthManagement.Models.Requests
{
    public class OAuthDbUpdateRequest
    {
        [Required]
        public string ClientId { get; set; }

        [Required]
        public string ClientSecret { get; set; }

        public string ClientName { get; set; }

        [Required]
        public string PlaceCode { get; set; }

        public string ChainCode { get; set; }
    }
}

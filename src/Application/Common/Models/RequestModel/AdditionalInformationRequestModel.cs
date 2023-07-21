using Excallibur.Domain.Entites;

namespace Excallibur.Application.Common.Models.RequestModel
{
    public class AdditionalInformationRequestModel
    {
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }
        public string? NationalId { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? YoutubeUrl { get; set; }
        public ICollection<Device> Devices { get; set; } = new List<Device>();
        public ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    }
}

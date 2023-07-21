using Microsoft.AspNetCore.Identity;

namespace Excallibur.Domain.Entites
{
    public class Tester : IdentityUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool hasPassedQuiz { get; set; }
        public bool hasPassedSampleTest { get; set; }
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

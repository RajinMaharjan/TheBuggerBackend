using Excallibur.Application.Common.Models.RequestModel;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Excallibur.Application.Common.Validator
{
    public class AdditionalInformationValidator : AbstractValidator<AdditionalInformationRequestModel>
    {
        public AdditionalInformationValidator()
        {
            RuleFor(x => x.FacebookUrl)
                .Must(facebookUrl => ValidFacebookUrl(facebookUrl)).WithMessage("Enter a valid facebook url");

            RuleFor(x => x.InstagramUrl)
                .Must(instagramUrl => ValidInstagramUrl(instagramUrl)).WithMessage("Enter a valid facebook url");

            RuleFor(x => x.LinkedInUrl)
                .Must(linkedInUrl => ValidLinkedInUrl(linkedInUrl)).WithMessage("Enter a valid facebook url");

            RuleFor(x => x.GitHubUrl)
                .Must(gitHubUrl => ValidGitHubUrl(gitHubUrl)).WithMessage("Enter a valid facebook url");

            RuleFor(x => x.TwitterUrl)
                .Must(twitterUrl => ValidTwitterUrl(twitterUrl)).WithMessage("Enter a valid facebook url");

            RuleFor(x => x.YoutubeUrl)
                .Must(youtubeUrl => ValidYoutubeUrl(youtubeUrl)).WithMessage("Enter a valid facebook url");

        }

        public static bool ValidFacebookUrl(string facebookUrl)
        {
            const string facebookUrlRegex = @"^((?:https?\:\/\/|www\.)(?:facebook)(?:.com\/)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*?)$";

            return new Regex(facebookUrlRegex).IsMatch(facebookUrl);
        }
        public static bool ValidInstagramUrl(string instagramUrl)
        {
            const string instagramUrlRegex = @"^((?:https?\:\/\/|www\.)(?:instagram)(?:.com\/)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*?)$";

            return new Regex(instagramUrlRegex).IsMatch(instagramUrl);
        }
        public static bool ValidLinkedInUrl(string linkedinUrl)
        {
            const string linkedinUrlRegex = @"^((?:https?\:\/\/|www\.)(?:linkedin)(?:.com\/)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*?)$";

            return new Regex(linkedinUrlRegex).IsMatch(linkedinUrl);
        }
        public static bool ValidGitHubUrl(string githubUrl)
        {
            const string githubUrlRegex = @"^((?:https?\:\/\/|www\.)(?:github)(?:.com\/)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*?)$";

            return new Regex(githubUrlRegex).IsMatch(githubUrl);
        }
        public static bool ValidTwitterUrl(string facebookUrl)
        {
            const string facebookUrlRegex = @"^((?:https?\:\/\/|www\.)(?:twitter)(?:.com\/)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*?)$";

            return new Regex(facebookUrlRegex).IsMatch(facebookUrl);
        }
        public static bool ValidYoutubeUrl(string facebookUrl)
        {
            const string facebookUrlRegex = @"^((?:https?\:\/\/|www\.)(?:youtube)(?:.com\/)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*?)$";

            return new Regex(facebookUrlRegex).IsMatch(facebookUrl);
        }
    }

}


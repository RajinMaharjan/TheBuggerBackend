namespace Excallibur.Application.Common.Models.RequestModel
{
    public class ResetPasswordRequestModel
    {
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
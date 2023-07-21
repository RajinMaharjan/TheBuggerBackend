using Excallibur.Application.Common.Models.RequestModel;

namespace Excallibur.Application.Common.Interfaces
{
    public interface ITesterAuthenticationService
    {
        Task<bool> RegisterTesterAsync(TesterRegisterRequestModel model);
        Task<(string, DateTime)> LoginTesterAsyc(TesterLoginRequestModel model);
        Task<bool> ConfirmEmail(ConfirmEmailRequestModel model);
        Task<bool> ForgotPassword(ForgotPasswordRequestModel model);
        Task<bool> ResetPassword(ResetPasswordRequestModel model);
    }
}

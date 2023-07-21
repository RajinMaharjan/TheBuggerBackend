using Excallibur.Application.Common.Interfaces;
using Excallibur.Application.Common.Models.RequestModel;
using Excallibur.Application.Common.Models.ResponseModel;
using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Excallibur.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    [EnableCors]
    public class TesterAuthenticationController : ControllerBase
    {
        private readonly ILogger<TesterAuthenticationController> _logger;
        private readonly ITesterAuthenticationService _testerAuthenticationService;
        private readonly IValidator<TesterRegisterRequestModel> _registerValidator;
        private readonly IValidator<TesterLoginRequestModel> _loginValidator;
        private readonly IValidator<ForgotPasswordRequestModel> _forgetPasswordValidator;
        private readonly IValidator<ResetPasswordRequestModel> _resetPasswordValidator;
        public TesterAuthenticationController(
            ILogger<TesterAuthenticationController> logger,
            ITesterAuthenticationService testerAuthenticationService,
            IValidator<TesterRegisterRequestModel> registerValidator,
            IValidator<TesterLoginRequestModel> loginValidator,
            IValidator<ForgotPasswordRequestModel> forgetPasswordValidator,
            IValidator<ResetPasswordRequestModel> resetPasswordValidator
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _testerAuthenticationService = testerAuthenticationService ?? throw new ArgumentNullException(nameof(testerAuthenticationService));
            _registerValidator = registerValidator ?? throw new ArgumentNullException(nameof(registerValidator));
            _loginValidator = loginValidator ?? throw new ArgumentNullException(nameof(loginValidator));
            _forgetPasswordValidator = forgetPasswordValidator ?? throw new ArgumentNullException(nameof(forgetPasswordValidator));
            _resetPasswordValidator = resetPasswordValidator ?? throw new ArgumentNullException(nameof(resetPasswordValidator));
        }


        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(TesterRegisterRequestModel model)
        {
            _logger.LogInformation("\nRegistering User \n ");

            await _registerValidator.ValidateAsync(model, options => options.ThrowOnFailures()).ConfigureAwait(false);

            await _testerAuthenticationService.RegisterTesterAsync(model);

            return StatusCode(
                200,
                new Response
                {
                    Status = "Success",
                    Message = $"User Created and verification link sent to {model.Email} successfully"
                });



        }

        [HttpPost("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailRequestModel model)
        {

            await _testerAuthenticationService.ConfirmEmail(model);

            return StatusCode(200,
                new Response
                {
                    Message = "Email Verified Successfully",
                    Status = "Success"
                });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(TesterLoginRequestModel model)
        {
            _logger.LogInformation("Logging in");
            await _loginValidator.ValidateAsync(model, options => options.ThrowOnFailures()).ConfigureAwait(false);

            var result = await _testerAuthenticationService.LoginTesterAsyc(model);
            return Ok(
                new
                {
                    token = result.Item1,
                    ExpiresOn = result.Item2,
                    Message = "Login successful",
                    Status = "Success"
                });
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequestModel model)
        {
            await _forgetPasswordValidator.ValidateAsync(model, options => options.ThrowOnFailures()).ConfigureAwait(false);
            await _testerAuthenticationService.ForgotPassword(model);


            return StatusCode(
                200,
                new Response
                {
                    Message = $"Password change request sent on email {model.Email}. Please Open Your email & click the link",
                    Status = "Success"
                }
                );

        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestModel model)
        {
            await _resetPasswordValidator.ValidateAsync(model, options => options.ThrowOnFailures()).ConfigureAwait(false);
            await _testerAuthenticationService.ResetPassword(model);


            return StatusCode(200,
                   new Response
                   {
                       Message = "Password has been changed successfully",
                       Status = "Success"
                   });




        }

    }
}

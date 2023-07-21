using Excallibur.Application.Common.Exceptions;
using Excallibur.Application.Common.Interfaces;
using Excallibur.Application.Common.Models.RequestModel;
using Excallibur.Domain.Entites;
using Infrastructure.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Excallibur.Infrastructure.Services
{
    public class TesterAuthenticationService : ITesterAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly UserManager<Tester> _userManager;
        private readonly SignInManager<Tester> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private Tester? _tester;
        private string? _url;

        public TesterAuthenticationService(
            IUnitOfWork unitOfWork,
            IConfiguration configuration,
            UserManager<Tester> userManager,
            SignInManager<Tester> signInManager,
            RoleManager<IdentityRole> roleManager,
            IEmailService emailService
            )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            var x = configuration.GetSection("Website");
            _url = x["Url"];

        }

        /// <summary>
        /// Registration of tester
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="PersistenceException">Throws exception if user already exists or failed to create user</exception>
        public async Task<bool> RegisterTesterAsync(TesterRegisterRequestModel model)
        {
            var role = "Tester";
            try
            {
                // Check user exists or not
                var userExists = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);

                if (userExists != null)
                {
                    throw new PersistenceException("User Already exist.");
                }
                var tester = new Tester
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    hasPassedQuiz = false,
                    hasPassedSampleTest = false,
                };

                //var roleExist = await _roleManager.RoleExistsAsync(model.role).ConfigureAwait(false);
                //if (!roleExist)
                //{
                //    throw new Exception($"Role {model.role} not found");
                //}
                var result = await _userManager.CreateAsync(tester, model.Password).ConfigureAwait(false);

                if (!result.Succeeded)
                {
                    throw new PersistenceException("Failed to create user");
                }
                //qa-lint-web.vercel.app
                await _userManager.AddToRoleAsync(tester, role).ConfigureAwait(false);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(tester).ConfigureAwait(false);
                var confirmationLink = $@"{_url}/emailVerification?token={token}&email={model.Email}";
                var message = new Message(new string[] { model.Email! }, "Confirmation email link", confirmationLink);
                _emailService.SendEmail(message);

                return true;
            }
            catch (PersistenceException ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }


        /// <summary>
        /// Verification of the email after the verification link of email is clicked by the user.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException">Throws exception if email doesnot exist.</exception>
        public async Task<bool> ConfirmEmail(ConfirmEmailRequestModel model)
        {
            try
            {
                var tester = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);

                var result = await _userManager.ConfirmEmailAsync(tester, model.Token).ConfigureAwait(false);
                if (!result.Succeeded)
                {
                    throw new ForbiddenException("Invalid token.");
                }

                return true;
            }
            catch (ForbiddenException ex)
            {
                throw new ForbiddenException(ex.Message);
            }
        }


        /// <summary>
        /// Login tester with email and password.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException">Throws exception if user does not exist</exception>
        /// <exception cref="ForbiddenException">Throws exception if email is not verified</exception>
        /// <exception cref="PersistenceException">Throws exception if login credentials doesnot match</exception>
        public async Task<(string, DateTime)> LoginTesterAsyc(TesterLoginRequestModel model)
        {
            try
            {
                _tester = await _userManager.FindByEmailAsync(model.Email).ConfigureAwait(false);
                if (_tester == null)
                {
                    throw new EntityNotFoundException("User does not Exist");
                }
                var emailConfirmed = await _userManager.IsEmailConfirmedAsync(_tester).ConfigureAwait(false);
                if (!emailConfirmed)
                {
                    throw new ForbiddenException("Email is not confirmed, Please confirm your email");
                }
                var result = await _signInManager.PasswordSignInAsync(_tester, model.Password, false, lockoutOnFailure: false);
                if (!result.Succeeded)
                {
                    throw new PersistenceException($"Failed to login {model.Email}, Invalid email or password");
                }
                var jwtToken = await CreateTokenAsync().ConfigureAwait(false);

                return jwtToken;
            }
            catch (EntityNotFoundException ex)
            {
                throw new EntityNotFoundException(ex.Message);
            }
            catch (ForbiddenException ex)
            {
                throw new ForbiddenException(ex.Message);
            }
            catch (PersistenceException ex)
            {
                throw new PersistenceException(ex.Message);
            }

        }


        /// <summary>
        /// Generates token for reset password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException">Throws exception if email does not exist</exception>
        public async Task<bool> ForgotPassword(ForgotPasswordRequestModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    throw new EntityNotFoundException($"{model.Email} is not registered.");
                }
                var token = await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false);
                var forgotPasswordLink = $@"{_url}/resetPassword?token={token}&email={model.Email}";
                var message = new Message(new string[] { model.Email }, "Forgot password link", forgotPasswordLink!);
                _emailService.SendEmail(message);
                return true;
            }
            catch (EntityNotFoundException ex)
            {
                throw new EntityNotFoundException(ex.Message);
            }
        }


        /// <summary>
        /// Reset password of the user.
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException">Throws exception if user does not exist</exception>
        /// <exception cref="PersistenceException">Throws exception if Failed to upload data</exception>
        public async Task<bool> ResetPassword(ResetPasswordRequestModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    throw new EntityNotFoundException("User does not exist.");
                }
                var resetPasswordResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (!resetPasswordResult.Succeeded)
                {
                    throw new PersistenceException("Failed to reset password");
                    //foreach (var error in resetPasswordResult.Errors)
                    //{
                    //    ModelState.AddModelError(error.Code, error.Description);
                    //}

                }
                return true;
            }
            catch (EntityNotFoundException ex)
            {
                throw new EntityNotFoundException(ex.Message);
            }
            catch (PersistenceException ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }


        /// <summary>
        /// Create token
        /// </summary>
        /// <returns></returns>
        private async Task<(string, DateTime)> CreateTokenAsync()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims().ConfigureAwait(false);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return (new JwtSecurityTokenHandler().WriteToken(tokenOptions), tokenOptions.ValidTo);
        }

        /// <summary>
        /// Get signing credentials to create token
        /// </summary>
        /// <returns></returns>
        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("JwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Get claim to add to token
        /// </summary>
        /// <returns></returns>
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _tester.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("hasPassedQuiz",$"{_tester.hasPassedQuiz}"),
            new Claim("hasPassedSampleTest",$"{_tester.hasPassedSampleTest}")
        };
            var roles = await _userManager.GetRolesAsync(_tester);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        /// <summary>
        /// Gnerate Jwt Token
        /// </summary>
        /// <param name="signingCredentials"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["ValidIssuer"],
            audience: jwtSettings["ValidAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresIn"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
        //public async Task<Tester> AddTesterAsync(TesterRegisterRequestModel model)
        //{
        //    Guid id = Guid.NewGuid();
        //    var tester = new Tester
        //    {
        //        Id = id,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        Email = model.Email,
        //        PhoneNumber = model.PhoneNumber,
        //        Password = model.Password,
        //        CreatedAt = DateTime.UtcNow,
        //        CreatedBy = id.ToString(),
        //        LastModifiedAt = DateTime.UtcNow,
        //        LastModifiedBy = id.ToString(),
        //        hasPassedQuiz = false,
        //        hasPassedSampleTest = false,
        //    };
        //    await _unitOfWork.GetRepository<Tester>().InsertAsync(tester).ConfigureAwait(false);
        //    await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        //    return tester;
        //}

    }
}

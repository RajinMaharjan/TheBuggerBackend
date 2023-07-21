using Excallibur.Application.Common.Interfaces;
using Excallibur.Application.Common.Models.RequestModel;
using Excallibur.Application.Common.Validator;
using Excallibur.Domain.Entites;
using Excallibur.Infrastructure.Persistence;
using Excallibur.Infrastructure.Services;
using FluentValidation;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Excallibur.Infrastructure.Configurations
{
    public static class Configurations
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Adding database connection
            var connectionString = configuration.GetConnectionString("DbConnection");

            services.AddDbContext<QaLintDbContext>(options =>
            options.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion), ServiceLifetime.Scoped);

            //Add Email Configuration
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<Email>();

            services.AddSingleton(emailConfig);

            //Adding unit of work
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Adding services
            ///Authentication services
            services.AddScoped<ITesterAuthenticationService, TesterAuthenticationService>();

            ///Quiz services
            services.AddScoped<IQuizService, QuizService>();

            ///Email services
            services.AddScoped<IEmailService, EmailService>();

            ////Adding exception handling mdidleware
            //services.AddTransient<ExceptionHandlingMiddleware>();

            //Adding validators
            services.AddScoped<IValidator<TesterRegisterRequestModel>, TesterRegisterValidator>();
            services.AddScoped<IValidator<TesterLoginRequestModel>, TesterLoginValidator>();
            services.AddScoped<IValidator<ForgotPasswordRequestModel>, ForgotPasswordValidator>();
            services.AddScoped<IValidator<ResetPasswordRequestModel>, ResetPasswordValidator>();

            return services;
        }
    }
}

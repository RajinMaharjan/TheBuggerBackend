using Excallibur.Infrastructure.Configurations;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("MySpecificOrigin",
        policy =>
        {
            policy
            .WithOrigins(
                "http://localhost:3000",
                "http://localhost:8080"
                )
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

//Adding logger (Serilog)
var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/tester.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        options.ReturnHttpNotAcceptable = true;
        options.CacheProfiles.Add("30SecondsCaching", new CacheProfile
        {
            Duration = 30
        });
    }
    ).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
builder.Services.AddResponseCaching();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJWTConfigurationServices(builder.Configuration);

builder.Services.AddIdentityConfigurationService();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHealthChecks();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();
app.UseRouting();

app.UseCors("MySpecificOrigin");

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseResponseCaching();

app.UseAuthentication();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();


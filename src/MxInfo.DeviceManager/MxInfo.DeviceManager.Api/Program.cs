using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using MxInfo.DeviceManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var secureConfiguration = builder.Configuration.GetSection("SecureConfiguration").Get<SecureConfiguration>();
if(secureConfiguration == null)
{
    throw new InvalidOperationException("SecureConfiguration is required");
}
secureConfiguration.ThrowIfInvalid();

if (secureConfiguration.UseKeyVault)
{
    var secretClient = new SecretClient(
        new Uri(secureConfiguration.KeyVaultUrl),
        new DefaultAzureCredential(
            new DefaultAzureCredentialOptions
            {
                ExcludeVisualStudioCodeCredential = true,
                ExcludeVisualStudioCredential = true,
                ExcludeEnvironmentCredential = secureConfiguration.ExcludeEnvironmentCredential
            }
        ));

    builder.Configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());    
}

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/healthz");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
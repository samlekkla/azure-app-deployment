using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using GameStore.Services;

var builder = WebApplication.CreateBuilder(args);

var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri")!);
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["ApplicationInsights:InstrumentationKey"]);

// Lägg till tjänster för MVC och GameService
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<GameService>();

// Konfigurera Key Vault
builder.Services.AddSingleton<SecretClient>(sp =>
{
    var keyVaultUrl = builder.Configuration["KeyVault:VaultUrl"];
    return new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
});

var app = builder.Build();

// Konfigurera HTTP-anrop
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Games}/{action=Index}/{id?}");

app.Run();

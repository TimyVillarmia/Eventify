using Eventify.Components;
using Eventify.Components.Account;
using Eventify.Data;
using Eventify.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("Azure"));


builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
    options.TokenLifespan = TimeSpan.FromHours(3));

builder.Services.ConfigureApplicationCookie(options => {
    options.ExpireTimeSpan = TimeSpan.FromDays(5);
    options.SlidingExpiration = true;
});

services.Configure<CookiePolicyOptions>(options =>
{
    options.Secure = CookieSecurePolicy.Always;
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;

    })
    .AddGoogle(googleoptions =>
    {
        googleoptions.ClientId = configuration["Google:client_id"];
        googleoptions.ClientSecret = configuration["Google:client_secret"];
    })
    .AddIdentityCookies();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddQuickGridEntityFrameworkAdapter();;
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, EmailSender>();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
    
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

using (var scope = app.Services.CreateScope())
{
    string[] roles = ["Organizer", "Judge"];
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var UserStore = scope.ServiceProvider.GetRequiredService<IUserStore<ApplicationUser>>();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    context.Database.EnsureCreated();

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            IdentityRole roleRole = new IdentityRole(role);
            await roleManager.CreateAsync(roleRole);
        }
    }


    // This part of the code is only for development
    // Will Remove Aftre Deployment
    // Ensure a user named Admin@eventify.com is an Administrator
    var user = await userManager.FindByEmailAsync("Admin@eventify.com");
    if (user == null)
    {
        var organizer = Activator.CreateInstance<ApplicationUser>();
        // organizer account
        await UserStore.SetUserNameAsync(organizer, "Admin@eventify.com", CancellationToken.None);
        var emailStore = (IUserEmailStore<ApplicationUser>)UserStore;
        await emailStore.SetEmailAsync(organizer, "Admin@eventify.com", CancellationToken.None);
        var identityResult = await userManager.CreateAsync(organizer, "Admin123!");

        if (identityResult.Succeeded)
        {
            // Put Admin@eventify.com in Organizer role
            await userManager.AddToRoleAsync(organizer, "Organizer");
        }
        
    }

    //DbInitializer.Initialize(context);

}

app.Run();

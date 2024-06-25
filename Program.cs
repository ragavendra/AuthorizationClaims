#define DEFAULT // SECOND
#if NEVER
#elif DEFAULT
#region snippet
using System.Security.Claims;
using AuthorizationClaims.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using AuthorizationClaims;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

if(builder.Environment.IsDevelopment()){
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        // options.UseSqlServer(connectionString)
        options.UseSqlite(connectionString)
        // options.UseInMemoryDatabase("StopList")
        );
    builder.Services.AddSwaggerGen();
}

builder.Services.AddAuthorization(options =>
{
   options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    options.AddPolicy("AtLeast21", policy =>
         policy.Requirements.Add(new MinimumAgeRequirement(21)));
});

// authe only
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

// custom handler for age21 claim
builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

// authe only
// app.MapGet("/", () => "Hello, World!");
app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret")
    .RequireAuthorization();

app.MapGet("/helloworld", () => "Hello World!")
.RequireAuthorization("AtLeast21");
/*
app.MapGet("/secret2", () => "This is a different secret!")
.RequireAuthorization(p => p.RequireClaim("scope", "myapi:secrets"));*/

app.Run();
#endregion
#elif SECOND
#region snippet2
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Founders", policy =>
                      policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
#endregion
#endif

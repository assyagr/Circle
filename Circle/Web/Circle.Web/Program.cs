using Circle.Data;
using Circle.Data.Models;
using Circle.Data.Repositories;
using Circle.Service;
using Circle.Service.Cloudinary;
using Circle.Service.Post;
using Gettit.Web.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<CircleDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Application Repositories
builder.Services.AddTransient<AttachmentRepository>();
builder.Services.AddTransient<CirclePostRepository>();
builder.Services.AddTransient<CommentRepository>();
builder.Services.AddTransient<ReactionRepository>();
builder.Services.AddTransient<HashtagRepository>();
builder.Services.AddTransient<CircleUserRepository>();

// Application Services
builder.Services.AddTransient<ICirclePostService, CirclePostService>();
builder.Services.AddTransient<ICircleUserService, CircleUserService>();
builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();

builder.Services.AddDefaultIdentity<CircleUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CircleDbContext>();

//builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDatabaseSeed();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();

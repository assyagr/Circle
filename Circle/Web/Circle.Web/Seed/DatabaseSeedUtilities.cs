using Circle.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gettit.Web.Seed
{
	public static class DatabaseSeedUtilities
	{
		public static void UseDatabaseSeed(this WebApplication app)
		{
			SeedRoles(app);
		}

		public static void SeedRoles(WebApplication app)
		{
			using (var serviceScope = app.Services.CreateScope())
			{
				using (var circleDbContext = serviceScope.ServiceProvider.GetRequiredService<CircleDbContext>())
				{
					circleDbContext.Database.Migrate();

					if (circleDbContext.Roles.Count() == 0)
					{
						IdentityRole adminRole = new IdentityRole();
						adminRole.Name = "Administrator";
						adminRole.NormalizedName = adminRole.Name.ToUpper();

						IdentityRole userRole = new IdentityRole();
						userRole.Name = "User";
						userRole.NormalizedName = userRole.Name.ToUpper();

						circleDbContext.Add(adminRole);
						circleDbContext.Add(userRole);

						circleDbContext.SaveChanges();
					}
				}
			}
		}
	}
}

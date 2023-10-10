using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using APPR6312POEPart1DAF.Data.Enums;
using APPR6312POEPart1DAF.Models;
using System.Drawing;

namespace APPR6312POEPart1DAF.Data
{
    public class Seed
    {

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Disasters.Any())
                {
                    context.Disasters.AddRange(new List<Disaster>()
                    {
                        new Disaster()
                        {
                            //DistaterId = 1,
                            StartDate = new DateTime(2021, 8, 4),
                            EndDate = new DateTime(2022, 11, 4),
                            Location = "Chile",
                            Description = "Famine in Chile"

                         },
                        new Disaster()
                        {
                            //DistaterId = 2,
                            StartDate = new DateTime(2023, 6, 9),
                            EndDate = new DateTime(2023, 6, 29),
                            Location = "Turkey",
                            Description = "Earthquake in Istanbul"
                        },
                        new Disaster()
                        {
                            //DistaterId = 3,
                            StartDate = new DateTime(2020, 1, 1),
                            EndDate = new DateTime(2023, 12, 29),
                            Location = "Iraq",
                            Description = "War in Iraq"
                        },
                        new Disaster()
                        {
                            //DistaterId = 4,
                            StartDate = new DateTime(2022, 10, 1),
                            EndDate = new DateTime(2022, 11, 5),
                            Location = "France",
                            Description = "Flood in Lorraine"
                        }
                    });
                    context.SaveChanges();
                }
                //Money
                if (!context.DonationsMoney.Any())
                {
                    context.DonationsMoney.AddRange(new List<DonationMoney>()
                    {
                        new DonationMoney()
                        {
                            //Id = 1,
                            Date = new DateTime(2023, 8, 1),
                            Amount = 1000
                        },
                        new DonationMoney()
                        {
                            //Id = 2,
                            Date = new DateTime(2023, 7, 9),
                            Amount = 1000
                        }
                    });
                    context.SaveChanges();
                }
                //Items
                if (!context.DonationsItems.Any())
                {
                    context.DonationsItems.AddRange(new List<DonationItem>()
                    {
                        new DonationItem()
                        {
                            //ItemDonationId = 1,
                            DonationDate = new DateTime(2023, 8, 1),
                            numItems = 20,
                            Catagory = new Catagory(),
                            Description = "Warm clothes and Jackets",
                            Donor = "Anonymous"
                        },
                        new DonationItem()
                        {
                            //ItemDonationId = 2,
                            DonationDate = new DateTime(2022, 2, 3),
                            numItems = 3200,
                            Catagory = new Catagory(),
                            Description = "Canned Food and Water",
                            Donor = "Red Cross"
                        }
                    }); ;
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "teddysmithdev",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}

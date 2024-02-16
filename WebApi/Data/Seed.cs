using DataLibrary.Models;
using System.Data;

namespace WebApi.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context?.Database.EnsureCreated();


                if (context?.Authors != null && !context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author
                        {
                            FirstName = "Johnson_NEW",
                            LastName = "White",
                            City = "Menlo Park",
                            EmailAddress = "Johnson@gmail.com",
                            Salary = 40852,
                            PhoneNumber = "12345678",
                        },
                        new Author
                        {
                            FirstName = "Marjorie",
                            LastName = "Green",
                            City = "Oakland",
                            EmailAddress = "Marjorie@gmail.com",
                            Salary = 41455,
                            PhoneNumber = "34576234",
                        },
                        new Author
                        {
                            FirstName = "Cheryl",
                            LastName = "Carson",
                            City = "Berkeley",
                            EmailAddress = "Cheryl@gmail.com",
                            Salary = 53453,
                            PhoneNumber = "4574376",
                        }
                    });
                    context.SaveChanges();
                }

                //if (!context.Roles.Any())
                //{
                //    context.Roles.AddRange(new List<Role>()
                //    {
                //        new Role
                //        {
                //            RoleDescription="User"
                //        },
                //        new Role
                //        {
                //            RoleDescription="Admin"
                //        },
                //        new Role
                //        {
                //            RoleDescription="Publisher"
                //        }
                //    });
                //    context.SaveChanges();
                //}

                //if (!context.Users.Any())
                //{
                //    context.Roles.AddRange(new List<User>()
                //    {
                //        new User
                //        {
                //            EmailAddress="user@gmail.com",
                //            PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                //            PasswordSalt = 44,

                //        },

                //    });
                //    context.SaveChanges();
                //}


            }
        }
    }
}

using CapstoneFinalProject.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneFinalProject.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        FirstName = "Isabelle",
                        LastName = "Winters",
                        Email = "iwinters@gmail.com",
                        Phone = "555-555-5555"
                    },
                    new User
                    {
                        FirstName = "Taran",
                        LastName = "Copeland",
                        Email = "tcopeland@gmail.com",
                        Phone = "555-555-5554"
                    },
                    new User
                    {
                        FirstName = "Joe",
                        LastName = "Sanders",
                        Email = "js@gmail.com",
                        Phone = "555-555-5355"
                    },
                    new User
                    {
                        FirstName = "Lia",
                        LastName = "Meyer",
                        Email = "liameyer@gmail.com",
                        Phone = "555-555-1555"
                    },
                    new User
                    {
                        FirstName = "Bob",
                        LastName = "Barnett",
                        Email = "bb@gmail.com",
                        Phone = "555-535-5555"
                    },
                    new User
                    {
                        FirstName = "Elisa",
                        LastName = "Hensley",
                        Email = "ehensley@gmail.com",
                        Phone = "555-595-5555"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

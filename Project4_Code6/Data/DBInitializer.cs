using Project4_Code6.Models;
using Project4_Code6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project4_Code6.Data
{
    public class DBInitializer
        {
            public static void Initialize(ProjectContext context)
            {
                context.Database.EnsureCreated();
                context.SaveChanges();

                // Look for any albums.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User { 
                        Username = "admin", Password = "admin", Email = "admin@admin.com"
                    }
                );
            context.SaveChanges();
            

            }
        }
    }

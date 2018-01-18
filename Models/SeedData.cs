using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookingSystem.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider ServiceProvider)
        {
            using (var context = new BookingSystemContext(ServiceProvider.GetRequiredService<DbContextOptions<BookingSystemContext>>()))
            {
                // Look for any students.
                if(context.Student.Any())
                {
                    return;  //  DB has been seeded
                }

                context.Student.AddRange(
                    new Student
                    {
                        Name = "John Doe",
                        Course = "Jumping Jacks",
                        Paid = true,
                        PaidDate = DateTime.Parse("14-08-2016"),
                        Email = "johndoe@anonymous.org",
                        Comment = "Blah blah blah"
                    
                    },

                    new Student
                    {
                        Name = "Jane Doe",
                        Course = "Goat Herding",
                        Paid = false,
                        PaidDate = DateTime.Parse("11-04-2087"),
                        Email = "jandoe@notsoanonymous.org",
                        Comment = "sgsfsfafafafsafs"
                    
                    },

                    new Student
                    {
                        Name = "Justin Boehm",
                        Course = "Boot scooting",
                        Paid = true,
                        PaidDate = DateTime.Parse("05-10-2033"),
                        Email = "boehm@razzledazzle.net",
                        Comment = "Some latin crap"
                    
                    },

                    new Student
                    {
                        Name = "Falcor",
                        Course = "Transorbital flight",
                        Paid = false,
                        PaidDate = DateTime.Parse("24-04-2399"),
                        Email = "falcor@thestorythatneverends.com",
                        Comment = "Some more latin crap"
                    
                    },

                     new Student
                    {
                        Name = "Rick James",
                        Course = "Couch dirtying",
                        Paid = false,
                        PaidDate = DateTime.Parse("12-07-2466"),
                        Email = "imrick@jamesbitch.edu",
                        Comment = "Fuck yo couch nigga!"
                    
                    },

                     new Student
                    {
                        Name = "Dusty Balls",
                        Course = "Ball dusting",
                        Paid = true,
                        PaidDate = DateTime.Parse("12-06-2144"),
                        Email = "dustthemballs@howdydo.com",
                        Comment = "ehhhhhhhhh bruz"
                    
                    },

                     new Student
                    {
                        Name = "James Bond",
                        Course = "Ball dusting",
                        Paid = false,
                        PaidDate = DateTime.Parse("18-02-2199"),
                        Email = "james@howdydo.com",
                        Comment = "Shaken, not stirred"
                    
                    },

                     new Student
                    {
                        Name = "Nick James",
                        Course = "Monkey Bizz",
                        Paid = false,
                        PaidDate = DateTime.Parse("28-08-2277"),
                        Email = "nickjames@monkeysarse.ocm",
                        Comment = "Lazy dude"
                    
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
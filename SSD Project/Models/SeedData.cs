using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SSD_Project.Data;

namespace SSD_Project.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SSD_ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SSD_ProjectContext>>()))

            {
                // Look for any movies.
                if (context.Facility.Any())
                {
                    System.Diagnostics.Debug.WriteLine("Hello");
                    return;   // DB has been seeded
                }
                System.Diagnostics.Debug.WriteLine("Hello");

                context.Facility.AddRange(
                    new Facility
                    {
                        Name = "Lap Pool 1",
                        Status = "Available",
                        MaxNumOfPeople = 20,
                        BlockNum = "1",
                        LocationName = "Swimming Complex",
                        LevelNo = "1",
                        RommNo = "04-04",
                        Description = "Lap pool at block 1, for all your aquatic needs.",
                        FilePath = "/images/swimming.jpg"


                    },
                    new Facility
                    {
                        Name = "Lap Pool 2",
                        Status = "Unavailable",
                        MaxNumOfPeople = 20,
                        BlockNum = "1",
                        LocationName = "Swimming Complex",
                        LevelNo = "1",
                        RommNo = "04-04",
                        Description = "Lap pool at block 1, for all your aquatic needs.",
                        FilePath = "/images/swimming.jpg"

                    });
                context.Booking.AddRange(
                    new Booking
                    {
                        Time = DateTime.Parse("2012-2-12 8:30:00 AM"),
                        Facilitys = new Facility
                        {
                            Name = "Lap Pool 1",
                            Status = "Available",
                            MaxNumOfPeople = 20,
                            BlockNum = "1",
                            LocationName = "Swimming Complex",
                            LevelNo = "1",
                            RommNo = "04-04",
                            Description = "Lap pool at block 1, for all your aquatic needs.",
                            


                        },
                        StatusOfBooking = "Approved",
                        CheckInStatus = true,
                        StartTime=DateTime.Parse("2012-2-12 8:30:00 AM"),
                        EndTime=DateTime.Parse("2012-2-12 9:00:00 AM"),
                        NumOfPeople = 1


                    });
                context.SaveChanges();
                }

            }
        }
    }

                
                  



using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Models;

namespace WebApi.DB
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //var options = new DbContextOptionsBuilder<dbContext>()
            //    .UseInMemoryDatabase(databaseName: "Haandvaerker")
            //    .Options;

            using (var context = new dbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<dbContext>>()))
            {
                // Look for any movies.
                if (context.Haandvaerkers.Any())
                {
                    return;   // DB has been seeded
                }


                var logresult = context.Database.EnsureCreated();
                Console.WriteLine("DB result: " + logresult);
                context.Database.ExecuteSqlRaw("USE Haandvaerker");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Haandvaerker ON;");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Vaerktoej ON;");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Vaerktoejskasse ON;");
                //context.Database.CommitTransactionAsync();

                context.Haandvaerkers.AddRange(

                    new Haandvaerker
                    {
                        HVAnsaettelsedato = DateTime.Now,
                        HVEfternavn = "Lund",
                        HVFagomraade = "VVS",
                        HVFornavn = "Mads"
                    },
                    new Haandvaerker
                    {
                        HVAnsaettelsedato = DateTime.Today,
                        HVEfternavn = "Seb",
                        HVFagomraade = "Tømrer",
                        HVFornavn = "Emil"
                    },
                    new Haandvaerker
                    {
                        HVAnsaettelsedato = DateTime.Today,
                        HVEfternavn = "Knullerup",
                        HVFagomraade = "VVS",
                        HVFornavn = "Sebastian"
                    });
                
                context.SaveChanges();

                context.Vaerktoejs.AddRange(

                    new Vaerktoej
                    {
                        LiggerIvtk = 1,
                        VTAnskaffet = DateTime.Now,
                        VTFabrikat = "Bahco",
                        VTModel = "Veliro",
                        VTSerienr = "123541",
                        VTType = "Hammer"
                    },
                    new Vaerktoej
                    {
                        LiggerIvtk = 2,
                        VTAnskaffet = DateTime.Today,
                        VTFabrikat = "Makita",
                        VTModel = "Bold",
                        VTSerienr = "101011",
                        VTType = "Skruetrækker"
                    },
                    new Vaerktoej
                    {
                        LiggerIvtk = 3,
                        VTAnskaffet = DateTime.Today,
                        VTFabrikat = "DeWalt",
                        VTModel = "Tough",
                        VTSerienr = "166211",
                        VTType = "Boremaskine"
                    });

                context.SaveChanges();

                context.Vaerktoejskasses.AddRange(
                    new Vaerktoejskasse
                    {
                        VTKAnskaffet = DateTime.Today,
                        VTKEjesAf = 1,
                        VTKFabrikat = "Bahco",
                        VTKFarve = "Gul",
                        VTKModel = "Large",
                        VTKSerienummer = "412121"
                    },
                    new Vaerktoejskasse
                    {
                        VTKAnskaffet = DateTime.Now,
                        VTKEjesAf = 2,
                        VTKFabrikat = "Makita",
                        VTKFarve = "Rød",
                        VTKModel = "Medium",
                        VTKSerienummer = "555121"
                    },
                    new Vaerktoejskasse
                    {
                        VTKAnskaffet = DateTime.Today,
                        VTKEjesAf = 3,
                        VTKFabrikat = "Milwaukee",
                        VTKFarve = "Rød",
                        VTKModel = "Small",
                        VTKSerienummer = "81900"
                    }
                );

                context.SaveChanges();

                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Haandvaerker.Haandvaerker OFF;");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Haandvaerker.Vaerktoej OFF;");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Haandvaerker.Vaerktoejskasse OFF;");
                //context.Database.CommitTransaction();

            }
        }
    }
}

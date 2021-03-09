using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using WebApi.Models;

namespace WebApi.DB
{
    public static class DbInitializer
    {
        public static void Initialize(dbContext context)
        {
            if (context == null)
            {
                Console.WriteLine("No context available: ", context);
            }

            context.Database.EnsureCreated();


            var handvaerker = new Haandvaerker[]
            {
                new Haandvaerker{HVAnsaettelsedato = DateTime.Now, HVEfternavn = "Lund", HVFagomraade = "VVS", HVFornavn = "Mads", HaandvaerkerId = 1, Vaerktoejskasse = new HashSet<Vaerktoejskasse>()},
                new Haandvaerker{HVAnsaettelsedato = DateTime.Today, HVEfternavn = "Seb", HVFagomraade = "Tømrer", HVFornavn = "Emil", HaandvaerkerId = 2, Vaerktoejskasse = new HashSet<Vaerktoejskasse>()},
                new Haandvaerker{HVAnsaettelsedato = DateTime.Today, HVEfternavn = "Knullerup", HVFagomraade = "VVS", HVFornavn = "Sebastian", HaandvaerkerId = 3, Vaerktoejskasse = new HashSet<Vaerktoejskasse>()}
            };
            foreach (var haandvaerker in handvaerker)
            {
                context.Haandvaerkers.Add(haandvaerker);
            }

            context.SaveChanges();

            var varktoej = new Vaerktoej[]
            {
                new Vaerktoej{LiggerIvtk = 1, LiggerIvtkNavigation = new Vaerktoejskasse(), VTAnskaffet = DateTime.Now, VTFabrikat = "Bahco", VTId = 1,
                    VTModel = "Veliro", VTSerienr = "123541", VTType = "Hammer"},
                new Vaerktoej{LiggerIvtk = 2, LiggerIvtkNavigation = new Vaerktoejskasse(), VTAnskaffet = DateTime.Today, VTFabrikat = "Makita", VTId = 1,
                VTModel = "Bold", VTSerienr = "101011", VTType = "Skruetrækker"},
                new Vaerktoej{LiggerIvtk = 3, LiggerIvtkNavigation = new Vaerktoejskasse(), VTAnskaffet = DateTime.Today, VTFabrikat = "DeWalt", VTId = 1,
                    VTModel = "Tough", VTSerienr = "166211", VTType = "Boremaskine"}
            };
            foreach (var v in varktoej)
            {
                context.Vaerktoejs.Add(v);
            }

            context.SaveChanges();

            var kasse = new Vaerktoejskasse[]
            {
                new Vaerktoejskasse
                {
                    EjesAfNavigation = new Haandvaerker(), Vaerktoej = new HashSet<Vaerktoej>(), VTKAnskaffet = DateTime.Today, VTKEjesAf = 1,
                    VTKFabrikat = "Bahco", VTKFarve = "Gul", VTKId = 1, VTKModel = "Large", VTKSerienummer = "412121"
                },
                new Vaerktoejskasse
                {
                    EjesAfNavigation = new Haandvaerker(), Vaerktoej = new HashSet<Vaerktoej>(), VTKAnskaffet = DateTime.Now, VTKEjesAf = 2,
                    VTKFabrikat = "Makita", VTKFarve = "Rød", VTKId = 1, VTKModel = "Medium", VTKSerienummer = "555121"
                },
                new Vaerktoejskasse
                {
                    EjesAfNavigation = new Haandvaerker(), Vaerktoej = new HashSet<Vaerktoej>(), VTKAnskaffet = DateTime.Today, VTKEjesAf = 3,
                    VTKFabrikat = "Milwaukee", VTKFarve = "Rød", VTKId = 1, VTKModel = "Small", VTKSerienummer = "81900"
                }
            };
            foreach (var k in kasse)
            {
                context.Vaerktoejskasses.Add(k);
            }

            context.SaveChanges();
        }
    }
}

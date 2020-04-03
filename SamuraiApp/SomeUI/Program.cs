using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiApp.Domain;
using SamuraiApp.Data;

namespace SomeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleSamurais();
            //InsertMultipleDifferentObjects();
            SimpleSamuraiQuery();
        }

        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
                //var query = context.Samurais;
                //var samuraisAgain = query.ToList();
                foreach (var samurai in context.Samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "Nick" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Julie" };
            var samuraiSammy = new Samurai { Name = "Sampson" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samurai, samuraiSammy);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleDifferentObjects()
        {
            //EF Core 2.1 added a minimum batch size which defaults to 4
            //this 4 object insert WILL be batched
            var samurai = new Samurai { Name = "Samurai1" };
            var battle = new Battle
            {
                Name = "Battle of Nagashino",
                StartDate = new DateTime(1575, 06, 16),
                EndDate = new DateTime(1575, 06, 28)
            };
            using (var context = new SamuraiContext())
            {
                context.AddRange(samurai, battle); //AddRange figures out which entities to add for you.
                context.SaveChanges();
            }
        }
    }
}

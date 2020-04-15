using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using SamuraiApp.Data;

namespace SomeUI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleSamurais();
            //InsertMultipleDifferentObjects();
            //SimpleSamuraiQuery();
            //MoreQueries();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //MultipleDatabaseOperations();
            //QueryAndUpdateSamurai_Disconnected();
            //InsertBattle();
            //QueryAndUpdateBattle_Disconnected();
            DeleteWhileTracked();
            //DeleteWhileNotTracked();
            //DeleteMany();
            //DeleteUsingId(3);
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }

        private static void MultipleDatabaseOperations()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "Hiro";
            _context.Samurais.Add(new Samurai { Name = "Kikuchiyo" });
            _context.SaveChanges();
        }

        private static void InsertBattle()
        {
            _context.Battles.Add(new Battle
            {
                Name = "Battle of Okehazama",
                StartDate = new DateTime(1560, 05, 01),
                EndDate = new DateTime(1560, 06, 15)
            });
            _context.SaveChanges();
        }

        private static void QueryAndUpdateBattle_Disconnected()
        {
            var battle = _context.Battles.FirstOrDefault();
            battle.EndDate = new DateTime(1560, 06, 30);
            using (var newContextInstance = new SamuraiContext())
            {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }

        private static void MoreQueries()
        {
            var samurais_NonParameterizedQuery = _context.Samurais.Where(s => s.Name == "Sampson").ToList();
            var name = "Sampson";
            var samurais_ParameterizedQuery = _context.Samurais.Where(s => s.Name == name).ToList();
            var samurai_Object = _context.Samurais.FirstOrDefault(s => s.Name == name);
            var samurais_ObjectFindByKeyValue = _context.Samurais.Find(2);
            var samuraisJ = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();
            var search = "J%";
            var samuraisJParameter = _context.Samurais.Where(s => EF.Functions.Like(s.Name, search)).ToList();

        }

        private static void QueryAndUpdateSamurai_Disconnected()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Kikuchiyo");
            samurai.Name += "San";
            using (var newContextInstance = new SamuraiContext())
            {
                newContextInstance.Samurais.Update(samurai);
                newContextInstance.SaveChanges();
            }
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

        private static void DeleteWhileTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Samurai1San");
            _context.Samurais.Remove(samurai);
            //some alternates:
            // _context.Remove(samurai);
            // _context.Samurais.Remove(_context.Samurais.Find(1));
            _context.SaveChanges();
        }

        private static void DeleteMany()
        {
            var samurais = _context.Samurais.Where(s => s.Name.Contains("ō"));
            _context.Samurais.RemoveRange(samurais);
            //alternate: _context.RemoveRange(samurais);
            _context.SaveChanges();
        }
        private static void DeleteUsingId(int samuraiId)
        {
            var samurai = _context.Samurais.Find(samuraiId);
            _context.Remove(samurai);
            _context.SaveChanges();
            //alternate: call a stored procedure!
            //_context.Database.ExecuteSqlCommand("exec DeleteById {0}", samuraiId);
        }

        private static void DeleteWhileNotTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Heihachi Hayashida");
            using (var contextNewAppInstance = new SamuraiContext())
            {
                contextNewAppInstance.Samurais.Remove(samurai);
                //contextNewAppInstance.Entry(samurai).State=EntityState.Deleted;
                contextNewAppInstance.SaveChanges();
            }
        }
    }
}

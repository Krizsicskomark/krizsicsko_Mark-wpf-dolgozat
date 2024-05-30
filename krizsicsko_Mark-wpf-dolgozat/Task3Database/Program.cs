using System;
using Task3Database.Data;
using Task3Database.Models;

namespace Run
{
    public class Program
    {

       
        static void Main(string[] args)
        {
            Context db = new Context();
            if (!db.People.Any())
            {
                var sorok = File.ReadAllLines("7.csv").Skip(1);
                foreach (var line in sorok)
                {
                    db.People.Add(new People(line));

                }
                db.SaveChanges();
            }

            /* akkor is betölti a .csv-t ha nem üres az adatbázis
            var sorok = File.ReadAllLines("7.csv").Skip(1);
            foreach (var line in sorok)
            {
                db.People.Add(new People(line));

            }
            db.SaveChanges();
            */


        }
    }
}
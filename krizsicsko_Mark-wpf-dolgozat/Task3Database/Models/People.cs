using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task3Database.Models
{
    public class People
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Occupation { get; set; }
        public string Hobbies { get; set; }


        public People()
        {
        }

        public People(string sor)
        {
            string[] t = sor.Split(';');
            Name = t[0];
            Age = Convert.ToInt32(t[1]);
            City = t[2];
            Occupation = t[3];
            Hobbies = t[4];
        }

        public override string? ToString()
        {
            return $"Név: {Name}";
        }
    }
}

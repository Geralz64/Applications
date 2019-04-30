using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    class PlayerCharacter
    {

        private readonly SpecialDefense _specialDefense;

        public PlayerCharacter(SpecialDefense specialDefense)
        {
            _specialDefense = specialDefense;
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public void Hit(int damage)
        {

            //int damageReduction = 0;

            //damageReduction = _specialDefense.CalculateDamageReduction(damage);

            //int totalDamageTaken = damage - damageReduction;


            int totalDamageTaken = damage - _specialDefense.CalculateDamageReduction(damage);

            Health -= totalDamageTaken;

            Console.WriteLine($"{Name}'s health has been reduced by {totalDamageTaken} to {Health}");


        }


        //public string Name { get; set; }

        //public int? DaysSinceLastLogin { get; set; }

        //public DateTime? DateOfBirth { get; set; }

        //public bool? IsNoob { get; set; }

        //public PlayerCharacter()
        //{

        //    DateOfBirth = null;

        //    DaysSinceLastLogin = null;

        //}

    }
}

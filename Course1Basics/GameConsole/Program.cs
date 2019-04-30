using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            PlayerCharacter sarah = new PlayerCharacter(new DiamondSkinDefense())
            {

                Name = "Sarah"

            };


            PlayerCharacter amrit = new PlayerCharacter(new IronBonesDefense())
            {

                Name = "Amrit"

            };

            PlayerCharacter gentry = new PlayerCharacter(SpecialDefense.Null)
            {

                Name = "Gentry"

            };




















            //PlayerCharacter player = new PlayerCharacter();

            ////player.DaysSinceLastLogin = 42;

            ////PlayerDisplayer.Write(player);

            //int days = player?.DaysSinceLastLogin ?? -1;

            //Console.WriteLine(days);


            //Console.ReadLine();


            //PlayerCharacter[] players = new PlayerCharacter[3]
            //{

            //    new PlayerCharacter { Name = "Sarah"},
            //    new PlayerCharacter(),
            //    null


            //};


            //string p1 = players?[0]?.Name;
            //string p2 = players?[1]?.Name;
            //string p3 = players?[2]?.Name;



        }
    }
}

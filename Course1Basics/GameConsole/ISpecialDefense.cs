using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole
{
    public abstract class SpecialDefense
    {
        public abstract int CalculateDamageReduction(int totalDamage);

        public static SpecialDefense Null { get; } = new NullDefense();

        private class NullDefense : SpecialDefense
        {
            public override int CalculateDamageReduction(int totalDamage)
            {

                return 0;
            }

        }

    }
}

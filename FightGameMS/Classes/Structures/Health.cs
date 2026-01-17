using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Structures
{
    public struct Health
    {
        public int CurrentHealth;
        public int MaxHeath;

        public Health(int currentHealth, int maxHeath)
        {
            if (maxHeath == 0) throw new Exception("Max Health cannot be zero");
            CurrentHealth = currentHealth;
                MaxHeath = maxHeath;

        }

        public static Health operator -(Health hp ,int Damage){
            
            return new Health(hp.CurrentHealth - Damage, hp.MaxHeath);

        }




}
}

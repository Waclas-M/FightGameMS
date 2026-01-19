using FightGameMS.Classes.Interfaces;
using FightGameMS.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes
{
    public class HeroTemplate 
    {
        public string ClassName { get; set; }
        public string Name { get; set; }

        public int MaxHealth { get; set; }

        public int AttackDamage { get; set; }
        public int AttackRange { get; set; }

        public int HitBoxWidth { get; set; }
        public int HitBoxHeight { get; set; }

        public int SpeedMs { get; set; }

       

        public HeroTemplate(string className, string name, int maxHealth, int attackDamage,int attackRange,int hitBoxWidth,int hitBoxHeight, int speedMs) {
        
            ClassName = className;
            Name = name;
            MaxHealth = maxHealth;
            AttackDamage = attackDamage;
            AttackRange = attackRange;
            HitBoxWidth = hitBoxWidth;
            HitBoxHeight = hitBoxHeight;
            SpeedMs = speedMs;
            
                
    
        }

    }
}

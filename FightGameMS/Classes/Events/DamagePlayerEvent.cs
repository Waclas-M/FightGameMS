using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Events
{
    public class DamagePlayerEvent : EventArgs
    {
        public int AttackerID { get; }
        public int TargetID { get; }

        public int Damage {get; }

        public DamagePlayerEvent(int attackerID , int targetID, int damage)
        {
            AttackerID = attackerID;
            TargetID = targetID;
            Damage = damage;
        }

    }
}

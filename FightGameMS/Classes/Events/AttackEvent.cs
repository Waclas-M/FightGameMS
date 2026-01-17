using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Events
{
    public class AttackEvent : EventArgs
    {
        public int AttackerId { get; }
        public double DtMs { get; }

        public AttackEvent(int attackerId, double dtMs)
        {
            AttackerId = attackerId;
            DtMs = dtMs;
        }
    }
}

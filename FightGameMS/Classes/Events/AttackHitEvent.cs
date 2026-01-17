using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Events
{
    public class AttackHitEvent : EventArgs
    {
        public int AttackerId { get; }

        public int TargetId { get; }
        public double DtMs { get; }

        public AttackHitEvent(int attackerId ,int targetId, double dtMs) 
        {
            AttackerId = attackerId;
            TargetId = targetId;
            DtMs = dtMs;
        }

    }
}

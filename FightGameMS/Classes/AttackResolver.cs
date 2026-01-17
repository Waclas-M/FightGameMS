using FightGameMS.Classes.Abstracts;
using FightGameMS.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes
{
    public class AttackResolver
    {
        public const int HIT_START_MS = 480;
        public const int HIT_END_MS = 600;

        // Parametry hitboxa ataku
        private const int ATTACK_BOX_W = 70;
        private const int ATTACK_BOX_H = 40;
        private const int ATTACK_RANGE = 55; // dystans "przed" graczem

        public bool CheackHit(Hero attacker,Hero target) {
            
            if (!attacker.IsAttacking) return false;
            if (attacker.AttackDamageApplied) return false;

            Debug.WriteLine("W Cheack Hit" + attacker.AttackAnimation.AttackElapsedMs);
            if (attacker.AttackAnimation.AttackElapsedMs < HIT_START_MS || attacker.AttackAnimation.AttackElapsedMs > HIT_END_MS) return false;

            attacker.AttackDamageApplied = true;
            Rectangle atk = HtiBoxHelper.GetAttackBox(attacker);
            Rectangle def = HtiBoxHelper.GetBodyBox(target);

            return atk.IntersectsWith(def);

        }
    }
}

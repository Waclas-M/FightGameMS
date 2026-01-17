using FightGameMS.Classes.Abstracts;
using FightGameMS.Classes.Enums;
using FightGameMS.Classes.Helpers;
using FightGameMS.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Animations
{
    public class CloseAttackAnimation : IAnimation
    {
        private List<Image> HeroAttackRight;
        private List<Image> HeroAttackLeft;
        private const int ATTACK_DURATION_MS = 600;
        public double AttackElapsedMs { get; set; } = 0;
        public int AttackFrameIndex { get; set; } = -1;

        public CloseAttackAnimation(string className)
        {
            HeroAttackRight = ActionImageHelper.LoadFrames(ActionImageHelper.AnimPath(className, "ATTACK", "ATTACK_RIGHT"));
            HeroAttackLeft = ActionImageHelper.LoadFrames(ActionImageHelper.AnimPath(className, "ATTACK", "ATTACK_LEFT"));
        }

        public void Animate(Hero hero,double dtMS)
        {
            Debug.WriteLine("Wejście do animacji Atatku " + AttackElapsedMs);
            AttackElapsedMs += dtMS;
           
            if (!hero.IsAttacking) return;

            var frames = GetFrames(hero.Facing);

            double frameMs = (double)ATTACK_DURATION_MS / frames.Count;
            int index = (int)(AttackElapsedMs / frameMs);

            if (index >= frames.Count)
            {
                hero.IsAttacking = false;
                AttackFrameIndex = frames.Count -1 ;
                hero.HeroCurrentImage = frames.Last();
                return;
            }
            if (index != AttackFrameIndex)
            {
                AttackFrameIndex = index;
                hero.HeroCurrentImage = frames[index];
                //Debug.WriteLine("Ustawiono Attack HeroCurrentImage");
            }


        }

        public List<Image> GetFrames(Direction direction)
        {
           return direction == Direction.Right ? HeroAttackRight : HeroAttackLeft;
            
        }

        public void RestFrames()
        {
            AttackElapsedMs = 0;
            AttackFrameIndex = 0;
        }



    }
}

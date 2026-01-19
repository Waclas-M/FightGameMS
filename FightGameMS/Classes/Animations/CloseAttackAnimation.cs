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
    public class CloseAttackAnimation : Animation
    {

        public CloseAttackAnimation(string className, AnimationsType type, int animationTimeMS) : base(className, type, animationTimeMS)
        {}

        public override void Animate(Hero hero,double dtMS)
        {
            //Debug.WriteLine("Wejście do animacji Atatku " + ElapsedMs);
            ElapsedMs += dtMS;
           
            if (!hero.IsAttacking) return;

            var frames = GetFrames(hero.Facing);

            double frameMs = (double)AnimationTimeMS / frames.Count;
            int index = (int)(ElapsedMs / frameMs);

            if (index >= frames.Count)
            {
                hero.IsAttacking = false;
                FrameIndex = frames.Count -1 ;
                hero.HeroCurrentImage = frames.Last();
                return;
            }
            if (index != FrameIndex)
            {
                FrameIndex = index;
                hero.HeroCurrentImage = frames[index];
                //Debug.WriteLine("Ustawiono Attack HeroCurrentImage");
            }


        }



    }
}

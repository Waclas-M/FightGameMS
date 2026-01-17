using FightGameMS.Classes.Abstracts;
using FightGameMS.Classes.Enums;
using FightGameMS.Classes.Helpers;
using FightGameMS.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Animations
{
    public class MoveAnimation : Animation
    {
        
     

        public MoveAnimation(string className, AnimationsType type, int animationTimeMS): base(className, type, animationTimeMS) 
        {}

        public override void Animate(Hero hero, double dtMs)
        {
            if(hero.IsWalking && !hero.IsAttacking)
            {
                double dtSec = dtMs / 1000;
                int dir = (int)hero.Facing;
                hero.X += (int)(dir * hero.SpeedMs * dtSec);
            }

            if (hero.IsAttacking) return;

            
            
            var frames = GetFrames(hero.Facing);

            ElapsedMs += dtMs;

            double frameMs = (double)(AnimationTimeMS / frames.Count);

            int index = (int)(ElapsedMs / frameMs) % frames.Count;

            if (index != FrameIndex)
            {
                FrameIndex = index;
                hero.HeroCurrentImage = frames[index];
            }


        }

     

     
    }
}

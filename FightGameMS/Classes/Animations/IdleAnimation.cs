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
    public class IdleAnimation : Animation
    {
        //private const int Idle_CYCLE_MS = 1000;
        //private List<Image> IdleRight;
        //public List<Image> IdleLeft;
        //public double IdleElapsedMs { get; set; } = 0;
        //public int IdleFrameIndex { get; set; } = -1;


        public IdleAnimation(string className, AnimationsType type, int animationTimeMS) : base(className, type, animationTimeMS) { }

        public override void Animate(Hero hero, double dtMs)
        {
            if (!hero.IsStaying) return;

           

            if (hero.IsAttacking) return;
            var frames = GetFrames(hero.Facing);

            ElapsedMs += dtMs;
            double frameMs = (double)(AnimationTimeMS / frames.Count);

            int index = (int)(ElapsedMs / frameMs)% frames.Count;

            if (index >= frames.Count)
            {
                hero.IsStaying = false;
                FrameIndex = 0;
                hero.HeroCurrentImage = frames.Last();
                return;

            }
            if (index != FrameIndex)
            {
                FrameIndex = index;
                hero.HeroCurrentImage = frames[index];
                //Debug.WriteLine("Ustawiono Idle HeroCurrentImage");
            }

        }

        //public List<Image> GetFrames(Direction direction)
        //{
        //    return direction == Direction.Right ? IdleRight : IdleLeft;
        //}

        //public void RestFrames()
        //{
        //    IdleElapsedMs = 0;
        //    IdleFrameIndex = 0;
        //}
    }
}

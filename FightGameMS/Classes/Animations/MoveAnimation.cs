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
    public class MoveAnimation : IAnimation
    {
        private const int WALK_CYCLE_MS = 600;
        private List<Image> WalkRight;
        private List<Image> WalkLeft;

        public double WalkElapsedMs { get; set; } = 0;
        public int WalkFrameIndex { get; set; } = -1;
        public double AttackElapsedMs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AttackFrameIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MoveAnimation(string className)
        {
            WalkRight = ActionImageHelper.LoadFrames(ActionImageHelper.AnimPath(className, "WALK", "WALK_RIGHT"));
            WalkLeft = ActionImageHelper.LoadFrames(ActionImageHelper.AnimPath(className, "WALK", "WALK_LEFT"));

            


        }

        public void Animate(Hero hero, double dtMs)
        {
            if(hero.IsWalking && !hero.IsAttacking)
            {
                double dtSec = dtMs / 1000;
                int dir = (int)hero.Facing;
                hero.X += (int)(dir * hero.SpeedMs * dtSec);
            }

            if (hero.IsAttacking) return;

            
            
            var frames = GetFrames(hero.Facing);

            WalkElapsedMs += dtMs;

            double frameMs = (double)(WALK_CYCLE_MS / frames.Count);

            int index = (int)(WalkElapsedMs / frameMs) % frames.Count;

            if (index != WalkFrameIndex)
            {
                WalkFrameIndex = index;
                hero.HeroCurrentImage = frames[index];
            }


        }

        public List<Image> GetFrames(Direction direction)
        {
            return direction == Direction.Right ? WalkRight : WalkLeft;
        }

        public void RestFrames()
        {
            WalkElapsedMs = 0;
            WalkFrameIndex = 0;
        }

     
    }
}

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
    public class IdleAnimation : IAnimation
    {
        private const int Idle_CYCLE_MS = 1000;
        private List<Image> IdleRight;
        public List<Image> IdleLeft;
        public double IdleElapsedMs { get; set; } = 0;
        public int IdleFrameIndex { get; set; } = -1;
        public double AttackElapsedMs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AttackFrameIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IdleAnimation(string className) {
            IdleRight = ActionImageHelper.LoadFrames(ActionImageHelper.AnimPath(className, "IDLE", "IDLE_RIGHT"));
            IdleLeft = ActionImageHelper.LoadFrames(ActionImageHelper.AnimPath(className, "IDLE", "IDLE_LEFT"));
        }

        public void Animate(Hero hero, double dtMs)
        {
            if (!hero.IsStaying) return;

           

            if (hero.IsAttacking) return;
            var frames = GetFrames(hero.Facing);

            IdleElapsedMs += dtMs;
            double frameMs = (double)(Idle_CYCLE_MS / frames.Count);

            int index = (int)(IdleElapsedMs/frameMs)% frames.Count;

            if (index >= frames.Count)
            {
                hero.IsStaying = false;
                IdleFrameIndex = 0;
                hero.HeroCurrentImage = frames.Last();
                return;

            }
            if (index != IdleFrameIndex)
            {
                IdleFrameIndex = index;
                hero.HeroCurrentImage = frames[index];
                //Debug.WriteLine("Ustawiono Idle HeroCurrentImage");
            }

        }

        public List<Image> GetFrames(Direction direction)
        {
            return direction == Direction.Right ? IdleRight : IdleLeft;
        }

        public void RestFrames()
        {
            IdleElapsedMs = 0;
            IdleFrameIndex = 0;
        }
    }
}

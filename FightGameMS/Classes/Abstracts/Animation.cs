using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightGameMS.Classes.Enums;
using FightGameMS.Classes.Helpers;
using FightGameMS.Classes.Interfaces;

namespace FightGameMS.Classes.Abstracts
{
    public abstract class Animation : IAnimation
    {
        private List<Image> LeftSiteAnimations { get; set; }
        private List<Image> RightSiteAnimations { get; set; }

        AnimationsType animationType { get; set; }

        public int AnimationTimeMS {get;set;}

        public double ElapsedMs { get; set; } = 0;
        public int FrameIndex { get; set; } = -1;

        public Animation(string className,AnimationsType type,int animationTimeMS)
        {
            LeftSiteAnimations = ActionImageHelper.LoadFrames(ActionImageHelper.AnimPath(className,type.ToString(),type.ToString()+"_LEFT"));
            RightSiteAnimations = ActionImageHelper.LoadFrames(ActionImageHelper.AnimPath(className, type.ToString(), type.ToString() + "_RIGHT"));
            AnimationTimeMS = animationTimeMS;
            animationType = type;
        }

        public virtual void Animate(Hero hero, double dtMs)
        {
         
            

        }

        public List<Image> GetFrames(Direction direction)
        {
            return direction == Direction.Right ? RightSiteAnimations: LeftSiteAnimations;
        }

        public void RestFrames()
        {
            ElapsedMs = 0;
            FrameIndex = 0;
        }
    }
}

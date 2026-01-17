using FightGameMS.Classes.Abstracts;
using FightGameMS.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes
{
    public class Warrior : Hero
    {
        
        public HeroTemplate Template { get; set; }
        public bool IsAlive { get; set; }

        public Warrior(HeroTemplate template) : base(template.Name,template.ClassName,template.MaxHealth,template.HitBoxWidth,template.HitBoxHeight,
            template.AttackDamage,template.AttackRange,template.SpeedMs,template.PlayerMovmentsFolder)
        {
            Template = template;
            IsAlive = true;
            AttackAnimation = new CloseAttackAnimation(Template.ClassName);
            MoveAnimation = new MoveAnimation(Template.ClassName);
            IdleAnimation = new IdleAnimation(Template.ClassName);
            
        }

        


    }
}

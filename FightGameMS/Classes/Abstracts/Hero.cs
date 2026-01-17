using FightGameMS.Classes.Enums;
using FightGameMS.Classes.Events;
using FightGameMS.Classes.Interfaces;
using FightGameMS.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Abstracts
{
    public class Hero : IHero
    {
        public int HeroID { get; set; }
        public string ClassName { get; set; }
        public string Name { get; set; }

        public Health Hp { get; set; }

        public int AttackDamage { get; set; }
        public int AttackRange { get; set; }

        public int HitBoxWidth { get; set; }
        public int HitBoxHeight { get; set; }

        public int SpeedMs { get; set; } = 200;

        public int X { get; set; }
        public int Y { get; set; }

        public string PlayerMovmentsFolder { get; set; }


        // statets
        public bool IsAttacking { get; set; } = false;
        public Direction Facing {  get; set; }

        public bool IsWalking { get; set; } = false;

        public bool IsStaying { get; set; } = true;

        public bool AttackDamageApplied { get; set; }

        // animations

        public IAnimation AttackAnimation { get; set; }
        public IAnimation MoveAnimation { get; set; }
        public IAnimation IdleAnimation { get; set; }


        public Image HeroCurrentImage { get; set; }

        public Hero(string name,string className,int maxHealth,int hitBoxWidth,int hitBoxHeight,int attackDamage,int attackRange,int speedMS,string playerMovmentsFolder) { 
            
            Name = name;
            ClassName = className;
            Hp = new Health(maxHealth,maxHealth);
            HitBoxWidth = hitBoxWidth;
            HitBoxHeight = hitBoxHeight;
            AttackDamage = attackDamage;
            AttackRange = attackRange;
            SpeedMs = speedMS;
            PlayerMovmentsFolder = playerMovmentsFolder;
        }
        
        public void TakeDamage(object? sender, DamagePlayerEvent e)
        {
            if (e.TargetID == HeroID)
            {
                Hp -= e.Damage;
            }
        }

        public void MakeMove(object? sender, MoveEvent e)
        {
            if (e.HeroId == HeroID)
            {
                MoveAnimation.Animate(this, e.DtMs);
                //Debug.WriteLine("Ruch odebrany w Hero.Attack");
            }
        }
        public void StopMoving(object? sender, StopMoveEvent e)
        {
            if (e.HeroId == HeroID)
            {
                IsWalking = false;
                IdleAnimation.Animate(this, e.DtMs);
                //Debug.WriteLine("Stop odebrany w Hero.Attack");
            }
        }

        public void Attack(object? sender, AttackEvent e)
        {
            if (e.AttackerId == HeroID)
            {
                AttackAnimation.Animate(this, e.DtMs);
                Debug.WriteLine("Atak odebrany w Hero.Attack");
            }
        }

    }
}

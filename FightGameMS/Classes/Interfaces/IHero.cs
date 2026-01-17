using FightGameMS.Classes.Events;
using FightGameMS.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Interfaces
{
    public interface IHero
    {
        
        public void TakeDamage(object? sender, DamagePlayerEvent e);
        public void MakeMove(object? sender, MoveEvent e);
        public void Attack(object? sender, AttackEvent e);


    }
}

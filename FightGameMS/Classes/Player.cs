
using FightGameMS.Classes.Abstracts;
using FightGameMS.Classes.Events;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes
{
    public class Player 
    {

        public string Name { get; }

        public int PlayerID { get; set; }

        public HeroTemplate SelectedHeroTemplate { get; set; }

        public Hero hero { get; private set; }


        public Player(string name) {
            Name = name;
        }

        public void AddHero(Hero hero_x)
        {
            hero = hero_x;
            hero.HeroID = PlayerID;
           

        }

        public void SubscribeToGameEvents(GameSession game)
        {
            game.DamagePlayer += hero.TakeDamage;
            game.AttackPlayer += hero.Attack;
            game.MovePlayer += hero.MakeMove;
            game.StopMovePlayer += hero.StopMoving;


        }

   


    }
}

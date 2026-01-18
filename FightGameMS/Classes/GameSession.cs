using FightGameMS.Classes.Abstracts;
using FightGameMS.Classes.Enums;
using FightGameMS.Classes.Events;
using FightGameMS.Classes.Interfaces;
using FightGameMS.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes
{
    public class GameSession
    {


        public bool Debug { get; } = true;

        public Guid Id { get; set; }
        private Player Player1 { get; }
        private Player Player2 { get; }

        public Hero Hero_P1 { get; set; }
        public Hero Hero_P2 { get; set; }
        public Status GameStatus { get; set; }
        public int Winner {get; private set;}

        private BattleLog GameLog { get; set; }

        private AttackResolver AttackHitResolver { get; set; } = new AttackResolver();


        public event EventHandler<DamagePlayerEvent>? DamagePlayer;
        public event EventHandler<AttackEvent>? AttackPlayer;
        public event EventHandler<MoveEvent>? MovePlayer;
        public event EventHandler<StopMoveEvent>? StopMovePlayer;

        // Onxxx pattern
        public virtual void OnDamagePlayer(int attackerId, int targetId, int dmg)
            => DamagePlayer?.Invoke(this, new DamagePlayerEvent(attackerId, targetId, dmg));

        public virtual void OnAttackPlayer(int HeroId, double dtMs)
            => AttackPlayer?.Invoke(this, new AttackEvent(HeroId, dtMs));

        public virtual void OnMovePlayer(int HeroId, double dtMs) 
            => MovePlayer?.Invoke(this, new MoveEvent(HeroId, dtMs));

        public virtual void OnStopMovePlayer(int HeroId,double dtMs) 
            => StopMovePlayer?.Invoke(this,new StopMoveEvent(HeroId,dtMs));



        public GameSession(Player player1, Player player2)
        {
            Id = new Guid();
            Player1 = player1;
            Player2 = player2;
            Player1.PlayerID = 1;
            Player2.PlayerID = 2;
        }

        private void AddHeroToPlayer(Player player)
        {
            switch (player.SelectedHeroTemplate.ClassName)
            {
                case "Warrior":
                    var test = new Warrior(player.SelectedHeroTemplate);
                    //Debug.WriteLine(test.ClassName);
                    player.AddHero(test);
                    break;
                case "Archer":
                    player.AddHero(new Warrior(player.SelectedHeroTemplate));
                    break;
            }
        }

        public void SetUp()
        {
            GameLog = new BattleLog(this);
            AddHeroToPlayer(Player1);
            AddHeroToPlayer(Player2);
            Hero_P1 = Player1.hero;
            Hero_P2 = Player2.hero;
            Player1.SubscribeToGameEvents(this);
            Player2.SubscribeToGameEvents(this);
            Hero_P2.X = 800;
            
            Update(16);
            

            

        }

        public void Initialize(GameSession gameSession) {
            Application.Run(new GameWindow(gameSession));
        }

        public void Update(double dtMs)
        {
            // Animacje // StateUpdate

            if (Hero_P1.IsAttacking) OnAttackPlayer(Hero_P1.HeroID, dtMs);
            if (Hero_P2.IsAttacking) OnAttackPlayer(Hero_P2.HeroID, dtMs);

            if (AttackHitResolver.CheackHit(Hero_P1, Hero_P2)) OnDamagePlayer(Hero_P1.HeroID, Hero_P2.HeroID, Hero_P1.AttackDamage);
            if (AttackHitResolver.CheackHit(Hero_P2, Hero_P1)) OnDamagePlayer(Hero_P2.HeroID, Hero_P1.HeroID, Hero_P2.AttackDamage);
            
            if (Hero_P1.IsWalking) OnMovePlayer(Hero_P1.HeroID, dtMs);
            if (Hero_P2.IsWalking) OnMovePlayer(Hero_P2.HeroID, dtMs);

            if (Hero_P1.IsStaying) OnStopMovePlayer(Hero_P1.HeroID, dtMs);
            if (Hero_P2.IsStaying) OnStopMovePlayer(Hero_P2.HeroID, dtMs);

            EndGame();

            // Sprawdzenie czy udrzenie trafiło

            //OnDamagePlayer()



        }

        public void Action(ActionType action, int heroID, int? directionX)
        {
            Hero hero;
            if (heroID == Hero_P1.HeroID)
            {
                hero = Hero_P1;
            }
            else
            {
                hero = Hero_P2 ;
            }


            switch (action)
            {
                case ActionType.Attack:
                    if (hero.IsAttacking == true) return;
                    hero.IsAttacking = true;
                    hero.AttackAnimation.RestFrames();
                    hero.AttackDamageApplied = false;
                    if (heroID == Hero_P1.HeroID)
                    {
                        GameLog.p1_attacked = false;
                    }
                    else
                    {
                        GameLog.p2_attacked = false;
                    }


                    //Debug.WriteLine("Atak odebrany w Action");
                    break;
                case ActionType.Move:
                    if (directionX != 0)
                    {
                        hero.IsWalking = true;
                        hero.IsStaying = false;
                        hero.IdleAnimation.RestFrames();

                    }
                    else
                    {
                        hero.IsWalking = false;
                        hero.IsStaying = true;
                        hero.MoveAnimation.RestFrames();
                    }
                    if (directionX < 0) hero.Facing = Direction.Left;
                    if (directionX > 0) hero.Facing = Direction.Right;


                    //Debug.WriteLine("Chodzenie odebrane w Action");

                    break;

            }

        }

        private void EndGame()
        {
            if (Hero_P1.Hp.CurrentHealth == 0 && Hero_P2.Hp.CurrentHealth == 0)
            { Winner = 0; GameStatus = Status.Ended; new EndGameWindow(this).ShowDialog(); }

            if (Hero_P1.Hp.CurrentHealth == 0) { Winner = 2; GameStatus = Status.Ended;  new EndGameWindow(this).ShowDialog(); }

            if (Hero_P2.Hp.CurrentHealth == 0) 
            {
                Winner = 1;
                GameStatus = Status.Ended;

                new EndGameWindow(this).ShowDialog();
            }
            

        }
    }
}

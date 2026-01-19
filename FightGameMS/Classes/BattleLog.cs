using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightGameMS.Classes.Events;

namespace FightGameMS.Classes
{
    public class BattleLog
    {
     
        private readonly string _logFilePath = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\infrastructure\Logs\"));
        
        private  string _gamefile {  get; set; }

        public bool p1_attacked { get; set; } = false;
        public bool p2_attacked { get; set; } = false;

        public BattleLog(GameSession game)
        {
            _gamefile = game.Id + ".txt";
            game.DamagePlayer += LogDamage;
            game.AttackPlayer += LogAttack;
            game.GameEnd += LogEndGame;

        }
        public void LogToFile(string message)
        {
            using (var writer = new StreamWriter(_logFilePath+_gamefile, true))
            {
                writer.WriteLine(message);
            }
        }

        private void LogAttack(object? sender, AttackEvent e) {

            if (e.AttackerId == 1 && !p1_attacked) { LogToFile($"[Attack] Gracz player1 wykonał atak."); p1_attacked = true; }
            if (e.AttackerId == 2 && !p2_attacked) { LogToFile($"[Attack] Gracz player2 wykonał atak."); p2_attacked = true; }


        }
        private void LogDamage(object? sender, DamagePlayerEvent e) {

            if (e.AttackerID == 1) LogToFile($"[Damage/Hit] Gracz player1 trafił gracza player2 za {e.Damage} Hp.");
            if (e.AttackerID == 2) LogToFile($"[Damage/Hit] Gracz player2 trafił gracza player1 za {e.Damage}.Hp.");
        
        }
        private void LogEndGame(object? sender, GameEndEvent e)
        {
            if (e.WinnerId == 0) LogToFile("[End Game] Gra zkończyła się remisem!");
            if (e.WinnerId != 0) LogToFile($"[End Game] Wygrywa gracz {e.Winner}");
        }
    }
}

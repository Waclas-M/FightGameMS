using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Events
{
    public class GameEndEvent : EventArgs
    {
        public string Winner {  get; set; }
        public int WinnerId { get; set; }
        public GameEndEvent(string winner,int winnerId) {
            Winner = winner;
            WinnerId = winnerId;
        }
    }
}

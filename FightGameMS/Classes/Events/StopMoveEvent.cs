using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Events
{
    public class StopMoveEvent: EventArgs
    {
        public int HeroId { get; }
        public double DtMs { get; }

        public StopMoveEvent(int heroId, double dtMs)
        {
            HeroId = heroId;
            DtMs = dtMs;
        }

    }
}

using FightGameMS.Classes.Abstracts;
using FightGameMS.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Interfaces
{
    public interface IAnimation
    {
      
        void Animate(Hero hero, double dtMs);
        List<Image> GetFrames(Direction direction);
        void RestFrames();
    }

}

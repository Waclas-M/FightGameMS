using FightGameMS.Classes.Abstracts;
using FightGameMS.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGameMS.Classes.Helpers
{
    public class HtiBoxHelper
    {

        public static Rectangle GetBodyBox(Hero hero) {
            int x = hero.X + (420 / 2) - (hero.HitBoxWidth / 2);
            int y = hero.Y + 420 - hero.HitBoxHeight - 100;
            return new Rectangle(x, y, hero.HitBoxWidth, hero.HitBoxHeight);
        }
        public static Rectangle GetAttackBox(Hero hero) {
            var body = GetBodyBox(hero);
            int y = body.Y + body.Height / 2 - 20;
            int x = hero.Facing == Direction.Right
                ? body.Right
                : body.Left -hero.AttackRange;
            return new Rectangle(x, y, hero.AttackRange, 40);
        }
    }
}

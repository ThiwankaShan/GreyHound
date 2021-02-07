using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    class EnemyShip : Ship
    {
        public override void attack()
        {
            Player.getInstance().getHit(this.getWeapon().fireWeapon());
        }
    }
}

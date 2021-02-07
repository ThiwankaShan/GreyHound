using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    class EnemyShip : Ship
    {
        public EnemyShip()
        {
            AttackSubject.getInstance().register(this);
        }

        public override void attack(int x = 0 , int y = 0)
        {
            x = Player.getInstance().getLocationX();
            y = Player.getInstance().getLocationY();
            int damage = this.getWeapon().getDamage();
            int range = this.getWeapon().getRange();
            AttackSubject.getInstance().Attack(damage,x,y,range);
        }
    }
}

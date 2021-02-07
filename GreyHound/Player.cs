using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    class Player : Ship
    {
        
        private static Player _instance = null;

        private Player() {
            AttackSubject.getInstance().register(this);
        }

        public static Player getInstance()
        {
            if (_instance == null)
            {
                _instance = new Player();
            }

            return _instance;
        }

       
        public override void attack(int x, int y)
        {
            int damage = this.getWeapon().getDamage();
            int range = this.getWeapon().getRange();
            AttackSubject.getInstance().Attack(damage,x,y,range);
        }
    }
}

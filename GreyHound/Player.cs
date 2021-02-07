using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    class Player : Ship
    {
        
        private static Player _instance = null;

        private int _health = 200;

        private Player() { }

        public static Player getInstance()
        {
            if (_instance == null)
            {
                _instance = new Player();
            }

            return _instance;
        }

        public string getHealth()
        {
            return _health.ToString();
        }

        public void getHit(int points)
        {
            _health -= points;  
        }

        public void heal(int points)
        {
            _health += points;
        }

        public override void attack()
        {
            getHit(this.getWeapon().fireWeapon());
        }
    }
}

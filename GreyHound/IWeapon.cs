using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    interface IWeapon
    {
        public string getWeapon();

        public int getDamage();

        public int getRange();
    }

    class RailGun : IWeapon
    {
        public string getWeapon()
        {
            return "get rail gun";
        }

        public int getDamage()
        {
            return 100;
        }

        public int getRange()
        {
           return 5;
        }
    }

    class MotarGun : IWeapon
    {
        public string getWeapon()
        {
            return "get motar gun";
        }

        public int getDamage()
        {
            return 10;
        }

        public int getRange()
        {
            return 10;
        }
    }
}

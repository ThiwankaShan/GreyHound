using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundLibrary
{
    public interface IWeapon
    {
        public string getWeapon();

        public int getDamage();

        public int getRange();
    }

    public class RailGun : IWeapon
    {
        public string getWeapon()
        {
            return "get rail gun";
        }

        public int getDamage()
        {
            return 2;
        }

        public int getRange()
        {
           return 2;
        }
    }

    public class MotarGun : IWeapon
    {
        public string getWeapon()
        {
            return "get motar gun";
        }

        public int getDamage()
        {
            return 5;
        }

        public int getRange()
        {
            return 3;
        }
    }
}

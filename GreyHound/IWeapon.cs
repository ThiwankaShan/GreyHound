using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    interface IWeapon
    {
        public string getWeapon();
        public int fireWeapon();
    }

    class RailGun : IWeapon
    {
        public string getWeapon()
        {
            return "get rail gun";
        }

        public int fireWeapon()
        {
            return 10;
        }
    }

    class MotarGun : IWeapon
    {
        public string getWeapon()
        {
            return "get motar gun";
        }

        public int fireWeapon()
        {
            return 100;
        }
    }
}

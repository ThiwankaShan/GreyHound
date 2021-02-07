using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    class HCShipFactory : ShipFactory
    {
        private IWeapon _weapon = new RailGun();

        private IEngine _engine = new SpeedEngine();

        private Ship _ship; 

        public override Ship buildShip()
        {
            _ship = new EnemyShip();

            _ship.setWeapon(_weapon);
            _ship.setEngine(_engine);

            return _ship;
        }

        public override void changeWeaponType(IWeapon weapon)
        {
            _weapon = weapon;
        }
    }
}

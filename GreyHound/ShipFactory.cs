using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    abstract class ShipFactory
    {
        abstract public Ship buildShip();
        abstract public void changeWeaponType(IWeapon weapon);
    }
}

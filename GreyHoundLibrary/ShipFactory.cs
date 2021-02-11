using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundLibrary
{
    public abstract class ShipFactory
    {
        abstract public Ship buildShip();
        abstract public void changeWeaponType(IWeapon weapon);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundLibrary
{
    public class ShipBuilder 
    {
        private static ShipBuilder _instance = null;

        private ShipBuilder() { }

        public static ShipBuilder getInstance()
        {
            if(_instance == null)
            {
                _instance = new ShipBuilder();
            }

            return _instance;
        }

        public Ship buildShip(ShipFactory factory)
        {
            return factory.buildShip();
        }
    }
}

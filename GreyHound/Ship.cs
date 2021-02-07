using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    abstract class Ship
    {
        private IWeapon _weapon;

        private IEngine _engine;

        private List<int> _location ;

        public void setWeapon(IWeapon weapon)
        {
            _weapon = weapon; 
        }

        public void setEngine(IEngine engine)
        {
            _engine = engine;
        }

        public IWeapon getWeapon()
        {
            return _weapon;
        }

        public IEngine Engine()
        {
            return _engine;
        }

        abstract public void attack();
        
    }
}

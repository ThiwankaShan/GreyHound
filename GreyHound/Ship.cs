using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    abstract class Ship
    {
        private IWeapon _weapon;

        private IEngine _engine;

        private int _health = 1000;

        private int _locationX = 0;
        private int _locationY = 0;

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

        public IEngine getEngine()
        {
            return _engine;
        }

        public IEngine Engine()
        {
            return _engine;
        }

        public void getHit(int points)
        {
            _health -= points;
        }

        public int getHealth()
        {
            return _health;
        }

        public void heal(int points)
        {
            _health += points;
        }


        public void setLocation(int x = 0 , int y = 0 )
        {
            _locationX = x;
            _locationY = y;
        }

        public int getLocationX()
        {
            return _locationX;
        }

        public int getLocationY()
        {
            return _locationY;
        }

        public string showLocation()
        {
            return $"({_locationX.ToString("000")},{_locationY.ToString("000")})";
        }

        abstract public void attack(int x = 0 , int y = 0 );

        abstract public void move(int x = 0, int y = 0); 

    }
}

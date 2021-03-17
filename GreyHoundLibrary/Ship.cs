using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundLibrary
{
    public abstract class Ship
    {
        private IWeapon _weapon;

        private IEngine _engine;

        public int health { get; set; } = 100;
        public int locationX { get; set; }
        public int locationY { get; set; }

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
            health -= points;
        }

        public int getHealth()
        {
            return health;
        }

        public void heal(int points)
        {
            health += points;
        }

        public void setLocation(int x = 0 , int y = 0 )
        {
            locationX = x;
            locationY = y;
        }

        public int getLocationX()
        {
            return locationX;
        }

        public int getLocationY()
        {
            return locationY;
        }

        public string showLocation()
        {
            return $"({locationX.ToString("000")},{locationY.ToString("000")})";
        }

        abstract public void attack(int x = 0 , int y = 0 );

        abstract public void move(int x = 0, int y = 0); 

    }
}

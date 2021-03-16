using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundLibrary
{
    public class Player : Ship
    {
        
        private static Player _instance = null;

        private Player() {
            AttackSubject.getInstance().register(this);
            this.setWeapon(new MotarGun());
            this.setEngine(new LightEngine());
        }

        public static Player getInstance()
        {
            if (_instance == null)
            {
                _instance = new Player();
            }

            return _instance;
        }

       
        public override void attack(int x, int y)
        {
            int damage = this.getWeapon().getDamage();
            int range = this.getWeapon().getRange();
            AttackSubject.getInstance().Attack(damage,x,y,range);
            //MoveSubject.getInstance().Move();
        }

        public override void move(int directionX , int directionY)
        {
            int locationX = this.getLocationX() + this.getEngine().getspeed() * directionX;
            int locationY = this.getLocationY() + this.getEngine().getspeed() * directionY;

            this.setLocation(locationX,locationY);
        }
    }
}

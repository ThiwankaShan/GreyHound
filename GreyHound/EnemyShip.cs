using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    class EnemyShip : Ship
    {
        public EnemyShip()
        {
            AttackSubject.getInstance().register(this);
            MoveSubject.getInstance().register(this);
        }

        public override void attack(int x = 0 , int y = 0)
        {
            x = Player.getInstance().getLocationX();
            y = Player.getInstance().getLocationY();
            int damage = this.getWeapon().getDamage();
            int range = this.getWeapon().getRange();
            AttackSubject.getInstance().Attack(damage,x,y,range);
        }

        public override void move(int locationX = 0 , int locationY = 0)
        {

            int playerLocationX = Player.getInstance().getLocationX();
            int playerLocationY = Player.getInstance().getLocationY();
            int delta = this.getEngine().getspeed();
            locationX = this.getLocationX();
            locationY = this.getLocationY();
            
            if (Math.Abs((playerLocationX - locationX)) > delta)
            {
                if (playerLocationX > locationX)
                {
                    locationX += delta;
                }
                else
                {
                    locationX -= delta;
                }
            }
            

            if (Math.Abs((playerLocationY - locationY)) > delta)
            {
                if (playerLocationY > locationY)
                {
                    locationY += delta;
                }
                else
                {
                    locationY -= delta;
                }
            }

            this.setLocation(locationX,locationY);
        }
    }
}

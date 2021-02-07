using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    class AttackSubject
    {
        private List<Ship> _observers = new List<Ship>();

        private static AttackSubject _instance = null;

        private AttackSubject() { }

        public static AttackSubject getInstance()
        {
            if (_instance == null)
            {
                _instance = new AttackSubject();
            }

            return _instance;
        }

        public void register(Ship ship)
        {
            _observers.Add(ship);       
        }

        public void Attack(int points, int attackX, int attackY,int range)
        {
           

            foreach (Ship ship in _observers)
            {
                int locationX = ship.getLocationX();
                int locationY = ship.getLocationY();
                int Xdiff = Math.Abs(locationX - attackX);
                int Ydiff = Math.Abs(locationY - attackY);
                Console.WriteLine($"difference {Xdiff.ToString()}, {Ydiff.ToString()}");
                if(Xdiff < range || Ydiff < range){
                    ship.getHit(points);
                }
                
            }
        }
    }
}

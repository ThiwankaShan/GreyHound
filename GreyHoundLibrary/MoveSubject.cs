using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundLibrary
{
    public class MoveSubject
    {
        private List<Ship> _observers = new List<Ship>();

        private static MoveSubject _instance = null;

        private MoveSubject() { }

        public static MoveSubject getInstance()
        {
            if (_instance == null)
            {
                _instance = new MoveSubject();
            }

            return _instance;
        }

        public void register(Ship ship)
        {
            _observers.Add(ship);
        }

        public void Move()
        {
            foreach (Ship ship in _observers)
            {          
                ship.move();
            }
        }
    }
}

using System;
using System.Threading;
using System.ComponentModel;
using GreyHoundLibrary;
using System.Collections.Generic;

namespace GreyHoundWPF
{
    public class Program : INotifyPropertyChanged
    {
        public Ship ship1 { get; set; }
        public Ship ship2 { get; set; }
        public Ship ship3 { get; set; }
        public Ship player { get; set; }
        public int ship1LocationX { get; set; }
        public int ship1LocationY { get; set; }
        public int ship2LocationX { get; set; }
        public int ship2LocationY { get; set; }
        public int ship3LocationX { get; set; }
        public int ship3LocationY { get; set; }
        public int playerLocationX { get; set; }
        public int playerLocationY { get; set; }
        public int playerHealth { get; set; }
        public int ship1Health { get; set; }
        public int ship2Health { get; set; }
        public int ship3Health { get; set; }
        public Thread t { set; get; }

        public bool isPlaying { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void onPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }

        public Program()
        {
            ShipBuilder builder = ShipBuilder.getInstance();
            ShipFactory factory = new HCShipFactory();
            player = Player.getInstance();
            ship1 = builder.buildShip(factory);
            ship2 = builder.buildShip(factory);
            ship3 = builder.buildShip(factory);

            player.setLocation(10, 10);
            ship1.setLocation(1, 4);
            ship2.setLocation(0, 2);
            ship3.setLocation(2, 1);
            update();
            isPlaying = true;
            t = new Thread(Game);
            t.Start();
        }

        public void Game()
        {  
            while (isPlaying)
            { 
                Thread.Sleep(1000);
                gamePlay();
            }            
        }

        void gamePlay()
        {
            enemyAttack();
            MoveSubject.getInstance().Move();
            update();
        }

        void status()
        {

            Console.WriteLine("==================================================================");
            Console.WriteLine("SHIP\t\t HEALTH\t\t LOCATION\t\t SPEED");
            Console.WriteLine("==================================================================\n");

            Console.WriteLine($"Enemy ship 1\t {ship1.getHealth().ToString("0000")}\t\t {ship1.showLocation()}\t\t {ship1.getEngine().getspeed().ToString("000")}\n");
            Console.WriteLine($"Enemy ship 2\t {ship2.getHealth().ToString("0000")}\t\t {ship2.showLocation()}\t\t {ship2.getEngine().getspeed().ToString("000")}\n");
            Console.WriteLine($"Enemy ship 3\t {ship3.getHealth().ToString("0000")}\t\t {ship3.showLocation()}\t\t {ship3.getEngine().getspeed().ToString("000")}\n");

            Console.WriteLine($"player\t\t {player.getHealth().ToString("0000")}\t\t {player.showLocation()}\t\t {player.getEngine().getspeed().ToString("000")}");

            Console.WriteLine("==================================================================\n");

        }

        void enemyAttack()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nEnemies are attacking\n");
            Console.ResetColor();

            ship1.attack();
            ship2.attack();
            ship3.attack();
        }

        public void playerAttack(int x, int y)
        {
            player.attack(x,y);
            update();
        }

        public void playerMove(int xDirection, int yDirection)
        { 
            player.move(xDirection,yDirection);
            update();
        }

        private void update()
        {
            ship1LocationX = ship1.getLocationX();
            ship1LocationY = ship1.getLocationY();
            ship2LocationX = ship2.getLocationX();
            ship2LocationY = ship2.getLocationY();
            ship3LocationX = ship3.getLocationX();
            ship3LocationY = ship3.getLocationY();
            playerLocationX = player.getLocationX();
            playerLocationY = player.getLocationY();
            playerHealth = player.getHealth();
            ship1Health = ship1.getHealth();
            ship2Health = ship2.getHealth();
            ship3Health = ship3.getHealth();
            onPropertyChanged(string.Empty);

        }
    }
}

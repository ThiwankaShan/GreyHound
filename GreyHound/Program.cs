using System;
using System.Threading;

namespace GreyHound
{
    class Program
    {
        static void Main(string[] args)
        {

            ShipBuilder builder = ShipBuilder.getInstance();
            ShipFactory factory = new HCShipFactory();
            Player player = Player.getInstance();
            Ship ship1 = builder.buildShip(factory);
            Ship ship2 = builder.buildShip(factory);
            Ship ship3 = builder.buildShip(factory);

            player.setLocation(10, 20);
            ship1.setLocation(100, 300);
            ship2.setLocation(140, 235);
            ship3.setLocation(-200, -10);

            Thread Tstatus = new Thread(status);
            Tstatus.Start();

            while (true)
            {
                Thread.Sleep(1000);
                if (player.getHealth() < 0)
                {
                    break;
                }

                Thread TgamePlay = new Thread(gamePlay);
                TgamePlay.Start();
                Thread.Sleep(28500);

                try
                {
                    TgamePlay.Abort();
                }
                catch
                {
                    Console.WriteLine("Time finished");
                }
                
            }

            Console.WriteLine("Game over");

            void gamePlay()
            {                                           
                    Console.WriteLine($"Attack damage radius {player.getWeapon().getRange()}\n");
                    Console.WriteLine("Enter x coordinates for the attack ");
                    int locationX = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter y coordinates for the attack ");
                    int locationY = Convert.ToInt32(Console.ReadLine());

                    player.attack(locationX, locationY);

                    Console.WriteLine("Enter x axis direction to move (1 to right, -1 to left): ");
                    int directionX = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter y axis direction to move (1 to up, -1 to down): ");
                    int directionY = Convert.ToInt32(Console.ReadLine());
                    player.move(directionX, directionY);

                
            
            }
            
            

            
            void status()
            {
                while (true)
                {
                    if (player.getHealth() < 0)
                    {
                        break;
                    }

                    Console.WriteLine("==================================================================");
                    Console.WriteLine("SHIP\t\t HEALTH\t\t LOCATION\t\t SPEED");
                    Console.WriteLine("==================================================================\n");

                    Console.WriteLine($"Enemy ship 1\t {ship1.getHealth().ToString("0000")}\t\t {ship1.showLocation()}\t\t {ship1.getEngine().getspeed().ToString("000")}\n");
                    Console.WriteLine($"Enemy ship 2\t {ship2.getHealth().ToString("0000")}\t\t {ship2.showLocation()}\t\t {ship2.getEngine().getspeed().ToString("000")}\n");
                    Console.WriteLine($"Enemy ship 3\t {ship3.getHealth().ToString("0000")}\t\t {ship3.showLocation()}\t\t {ship3.getEngine().getspeed().ToString("000")}\n");

                    Console.WriteLine($"player\t\t {player.getHealth().ToString("0000")}\t\t {player.showLocation()}\t\t {player.getEngine().getspeed().ToString("000")}");

                    Console.WriteLine("==================================================================\n");

                    Thread.Sleep(30000);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEnemies are attacking\n");
                    Console.ResetColor();

                    ship1.attack();
                    ship2.attack();
                    ship3.attack();
                }

            }
        }
    }
}

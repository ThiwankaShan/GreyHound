using System;

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

            player.setLocation(10,20);
            ship1.setLocation(100, 300);
            ship2.setLocation(200,100);
            ship3.setLocation(-200,-10);

            int i = 0;

            while (true)
            {
                if (i%3 == 0)
                {
                    Console.WriteLine("Enemies attacking");
                    ship1.attack();
                    ship2.attack();
                    ship3.attack();
                }

                if (player.getHealth()<0)
                {
                    break;
                }

                status();

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

                
                i++;
            }

            Console.WriteLine("Game over");

            void status()
            {
                Console.WriteLine("==================================================================");
                Console.WriteLine("SHIP\t\t HEALTH\t\t LOCATION\t\t SPEED");
                Console.WriteLine("==================================================================\n");
                              
                Console.WriteLine($"Enemy ship 1\t {ship1.getHealth().ToString()}\t\t {ship1.showLocation()}\t\t {ship1.getEngine().getspeed()}\n");
                Console.WriteLine($"Enemy ship 2\t {ship2.getHealth().ToString()}\t\t {ship2.showLocation()}\t\t {ship2.getEngine().getspeed()}\n");
                Console.WriteLine($"Enemy ship 3\t {ship3.getHealth().ToString()}\t\t {ship3.showLocation()}\t\t {ship3.getEngine().getspeed()}\n");

                Console.WriteLine($"player\t\t {player.getHealth().ToString()}\t\t {player.showLocation()}\t\t {player.getEngine().getspeed()}");

                Console.WriteLine("==================================================================\n");
            }
        }
    }
}

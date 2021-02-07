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

            factory.changeWeaponType(new MotarGun());
            Ship ship2 = builder.buildShip(factory);

            player.setLocation(0, 0);
            ship1.setLocation(105, 45);
            ship2.setLocation(4, 1);

            Console.WriteLine("======   START   =======================\n");

            ship1.attack();
            status();
           
            ship2.attack();         
            status();

            IWeapon weapon = new MotarGun();
            player.setWeapon(weapon);

            Console.WriteLine("Enter x location to attack : ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter y location to attack : ");
            int y = Convert.ToInt32(Console.ReadLine());

            player.attack(x, y);
            status();
            
                       

            void status()
            {
                Console.WriteLine("==============================================\n");
                Console.WriteLine($"player health : {player.getHealth()} / location {player.showLocation()}");
                Console.WriteLine($"Enemy ship 1 : health {ship1.getHealth()} / location {ship1.showLocation()}");
                Console.WriteLine($"Enemy ship 2 : health {ship2.getHealth()} / location {ship2.showLocation()}");
                Console.WriteLine("==============================================\n");
            }
        }
    }
}

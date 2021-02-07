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

            Console.WriteLine($"player health : {player.getHealth()}");

            Ship ship1 = builder.buildShip(factory);
            ship1.attack();
            Console.WriteLine($"player health : {player.getHealth()}");

            factory.changeWeaponType(new MotarGun());

            Ship ship2 = builder.buildShip(factory);
            ship2.attack();
            Console.WriteLine($"player health : {player.getHealth()}");


            player.setWeapon(new MotarGun());
            player.attack();
            Console.WriteLine($"player health : {player.getHealth()}");

        }
    }
}

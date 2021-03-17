using System;
using System.Threading;
using System.ComponentModel;
using GreyHoundLibrary;
using System.Collections.Generic;
using System.Diagnostics;

namespace GreyHoundWPF
{
    public class GamePlay : ObservableObject
    {
        public Ship ship1 { get; set; }
        public Ship ship2 { get; set; }
        public Ship ship3 { get; set; }
        public Ship player { get; set; }
        public Thread t { set; get; }
        public bool isPlaying { get; set; }
        public int damageRange { get; set; }

        public GamePlay()
        {
            ShipBuilder builder = ShipBuilder.getInstance();
            ShipFactory factory = new HCShipFactory();
            ship1 = builder.buildShip(factory);
            ship2 = builder.buildShip(factory);
            ship3 = builder.buildShip(factory);
            player = Player.getInstance();
            damageRange = player.getWeapon().getRange()*10 + 30;

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
                Thread.Sleep(12000);
                gamePlay();
            }            
        }

        void gamePlay()
        {
            enemyAttack();
            MoveSubject.getInstance().Move();
            update();
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
            Thread.Sleep(1000);
            player.move(xDirection,yDirection);
            update();
        }

        private void update()
        {
            onPropertyChanged(string.Empty);
        }
    }
}

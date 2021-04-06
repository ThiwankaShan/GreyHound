using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace GreyHoundLibrary
{

    public class GamePlay : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Ship ship1 { get; set; }
        public Ship ship2 { get; set; }
        public Ship ship3 { get; set; }
        public Ship player { get; set; }
        public Thread thread { set; get; }
        public bool isPlaying { get; set; }
        public int damageRange { get; set; }

        public IGamePlayState playState;
        public IGamePlayState stopedState;
        public IGamePlayState pausedState;
        public IGamePlayState gameState;

        public GamePlay()
        {
            playState = new PlayState(this);
            stopedState = new StopedState(this);
            pausedState = new PausedState(this);
            gameState = stopedState;
        }  
        
        public void setState(IGamePlayState state)
        {
            gameState = state;
        }

        public void setInitStatus()
        {
            ShipBuilder builder = ShipBuilder.getInstance();
            ShipFactory factory = new HCShipFactory();
            ship1 = builder.buildShip(factory);
            ship2 = builder.buildShip(factory);
            ship3 = builder.buildShip(factory);
            player = Player.getInstance();
            player.health = 100;
            damageRange = player.getWeapon().getRange() * 10 + 30;

            player.setLocation(10, 10);
            ship1.setLocation(1, 4);
            ship2.setLocation(0, 2);
            ship3.setLocation(2, 1);
            onPropertyChanged(string.Empty);
        }

        protected virtual void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public void start()
        {
            while (true)
            {
                if (isPlaying)
                {
                    Debug.WriteLine("Playing");
                    Thread.Sleep(12000);
                    gamePlay();
                }
                
            }
        }

        private void gamePlay()
        {
            ship1.attack();
            ship2.attack();
            ship3.attack();

            MoveSubject.getInstance().Move();
            onPropertyChanged(string.Empty);
        }

        public void playerAttack(int x, int y)
        {
            player.attack(x, y);
            onPropertyChanged(string.Empty);
        }

        public void playerMove(int xDirection, int yDirection)
        {
            Thread.Sleep(1000);
            player.move(xDirection, yDirection);
            onPropertyChanged(string.Empty);
        }

    }
}


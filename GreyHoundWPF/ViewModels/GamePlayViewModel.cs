using System;
using System.Threading;
using GreyHoundLibrary;
using System.Diagnostics;
using System.Windows.Input;
using GreyHoundWPF.Commands;

namespace GreyHoundWPF.ViewModels
{
    public class GamePlayViewModel : BaseViewModel
    {
        public ICommand updateViewcommand { get; set; }
        public GamePlay gamePlay { get; set; }

        public static GamePlayViewModel instaince = null;
        
        private GamePlayViewModel()
        {
            gamePlay = new GamePlay();
        }

        public static GamePlayViewModel getInstaince()
        {
            if (instaince == null)
            {
                instaince = new GamePlayViewModel();
            }
            return instaince;
        }

    }
}

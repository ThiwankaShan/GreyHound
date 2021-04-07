using GreyHoundWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace GreyHoundWPF.Commands
{
    class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public event EventHandler CanExecuteChanged;

        public static UpdateViewCommand instaince = null;

        private UpdateViewCommand(MainViewModel viewModel) {
            this.viewModel = viewModel;
        }

        public static UpdateViewCommand getInstaince(MainViewModel viewModel)
        {
            if (instaince == null)
            {
                instaince = new UpdateViewCommand(viewModel);
            }
            return instaince;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "gamePlay")
            {
                Debug.WriteLine("View update to gameplay view command fired");
                GamePlayViewModel.getInstaince().gamePlay.gameState.play();
                this.viewModel.selectedViewModel = GamePlayViewModel.getInstaince();
  
            }else if (parameter.ToString() == "mainMenue")
            {
                Debug.WriteLine("View update to main menue view command fired");
                this.viewModel.selectedViewModel = MainMenueViewModel.getInstaince();
            }
            else if (parameter.ToString() == "controls")
            {
                Debug.WriteLine("View update to controls menue view command fired");
                this.viewModel.selectedViewModel = ControlsViewModel.getInstaince();
            }
        }
    }
}

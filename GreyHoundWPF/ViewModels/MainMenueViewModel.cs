using GreyHoundWPF.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GreyHoundWPF.ViewModels
{
    class MainMenueViewModel : BaseViewModel
    {
        public ICommand updateViewcommand { get; set; }

        public static MainMenueViewModel instaince = null;

        private MainMenueViewModel()
        {
            this.updateViewcommand = UpdateViewCommand.getInstaince(MainViewModel.getInstaince());
        }

        public static MainMenueViewModel getInstaince()
        {
            if(instaince == null)
            {
                instaince = new MainMenueViewModel();
            }
            return instaince;
        }
       
    }
}

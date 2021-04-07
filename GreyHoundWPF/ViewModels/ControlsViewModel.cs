using GreyHoundWPF.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GreyHoundWPF.ViewModels
{
    class ControlsViewModel : BaseViewModel
    {
        public static ControlsViewModel instaince = null;

        public ICommand updateViewcommand { get; set; }

        private ControlsViewModel()
        {
            updateViewcommand = UpdateViewCommand.getInstaince(MainViewModel.getInstaince());
        }

        public static ControlsViewModel getInstaince()
        {
            if (instaince == null)
            {
                instaince = new ControlsViewModel();
            }
            return instaince;
        }

        
    }
}

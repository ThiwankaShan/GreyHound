using GreyHoundWPF.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GreyHoundWPF.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        public static MainViewModel instaince = null;

        public BaseViewModel selectedViewModel { 
            get { 
                return _selectedViewModel; 
            }
            set {
                _selectedViewModel = value;
                onPropertyChanged(nameof(this._selectedViewModel));
            } 
        }

        public ICommand updateViewcommand { get; set; }

        private MainViewModel()
        {
            _selectedViewModel = MainMenueViewModel.getInstaince();
            this.updateViewcommand = UpdateViewCommand.getInstaince(); 
        }

        public static MainViewModel getInstaince()
        {
            if(instaince == null)
            {
                instaince = new MainViewModel();
            }
            return instaince;
        }

        public override void start()
        {
            throw new NotImplementedException();
        }

        public override void stop()
        {
            throw new NotImplementedException();
        }
    }
}

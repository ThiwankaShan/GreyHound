
using System.Windows;
using GreyHoundLibrary;
using System.Threading;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Media;
using System.Threading.Tasks;
using GreyHoundWPF.ViewModels;

namespace GreyHoundWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();

            MainViewModel mainViewModel = MainViewModel.getInstaince();
            mainViewModel.selectedViewModel = MainMenueViewModel.getInstaince();
            DataContext = mainViewModel;

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            GamePlayViewModel data = GamePlayViewModel.getInstaince();

            data.gamePlay.gameState.stop();

            base.OnClosing(e);
            Application.Current.Shutdown();
        }
    }
}

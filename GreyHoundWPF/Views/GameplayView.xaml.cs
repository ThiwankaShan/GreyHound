using GreyHoundWPF.Commands;
using GreyHoundWPF.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace GreyHoundWPF.Views
{
    /// <summary>
    /// Interaction logic for GameplayView.xaml
    /// </summary>
    public partial class GameplayView : UserControl
    {
        public GamePlayViewModel data { set; get; }
        public bool available = true;

        public GameplayView()
        {
            InitializeComponent();

            data = GamePlayViewModel.getInstaince();

            for (int i = 0; i < 20; i++)
            {
                RadarGrid.RowDefinitions.Add(new RowDefinition());
                RadarGrid.ColumnDefinitions.Add(new ColumnDefinition());
                Button button = new Button();
                button.SetValue(Grid.RowProperty, i);
                button.SetValue(Grid.ColumnProperty, i);
            }

            for (int j = 0; j < 20; j++)
            {
                TextBlock txtBox = new TextBlock();
                txtBox.Text = j.ToString();
                txtBox.Foreground = Brushes.WhiteSmoke;
                Grid.SetColumn(txtBox, 0);
                Grid.SetRow(txtBox, j);

                RadarGrid.Children.Add(txtBox);

            }

            for (int j = 1; j < 20; j++)
            {
                TextBlock txtBox = new TextBlock();
                txtBox.Text = j.ToString();
                txtBox.Foreground = Brushes.WhiteSmoke;
                Grid.SetColumn(txtBox, j);
                Grid.SetRow(txtBox, 20);

                RadarGrid.Children.Add(txtBox);
            }
        }

        private async void fire_Click(object sender, RoutedEventArgs e)
        {
            if (xCoordinate.Text != "" && yCoordinate.Text != "")
            {
                bombLocation.Visibility = Visibility.Visible;

                int xcoordinate = Convert.ToInt32(xCoordinate.Text);
                int ycoordinate = Convert.ToInt32(yCoordinate.Text);

                data.playerAttack(xcoordinate, ycoordinate);
                fire.IsEnabled = false;
                gunLoading.Visibility = Visibility.Visible;

                await Task.Delay(6000);
                gunLoading.Visibility = Visibility.Hidden;
                fire.IsEnabled = true;
            }
        }

        private void GamePlayUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += OnKeyDownHandler;
        }

        private async void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && available)
            {
                available = false;
                data.playerMove(-1, 0);
                await Task.Delay(6000);
                available = true;
            }
            else if (e.Key == Key.Left && available)
            {
                available = false;
                data.playerMove(0, -1);
                await Task.Delay(6000);
                available = true;
            }
            else if (e.Key == Key.Down && available)
            {
                available = false;
                data.playerMove(1, 0);
                await Task.Delay(6000);
                available = true;
            }
            else if (e.Key == Key.Right && available)
            {
                available = false;
                data.playerMove(0, 1);
                await Task.Delay(6000);
                available = true;
            }
            else if (e.Key == Key.Escape)
            {
                
                data.isPlaying = false;
                try
                {
                    data.thread.Abort();
                }
                catch
                {
                    Debug.WriteLine("Thread closed");
                }

                UpdateViewCommand.getInstaince(MainViewModel.getInstaince()).Execute("mainMenue");
            }
        }

        
    }
}

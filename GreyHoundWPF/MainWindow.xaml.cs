
using System.Windows;
using GreyHoundLibrary;
using System.Threading;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.ComponentModel;

namespace GreyHoundWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Program data { set; get; }
        public MainWindow()
        {
            
            InitializeComponent();

            data = new Program();
            DataContext = data;

            for(int i= 0; i<21; i++)
            {
                RadarGrid.RowDefinitions.Add(new RowDefinition());
                RadarGrid.ColumnDefinitions.Add(new ColumnDefinition());
                Button button = new Button();
                button.SetValue(Grid.RowProperty,i);
                button.SetValue(Grid.ColumnProperty,i);

            }
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            data.isPlaying = false;
            try
            {
                data.t.Abort();
            }
            catch
            {
                Debug.WriteLine("Thread closed");
            }
            
            base.OnClosing(e);

            Application.Current.Shutdown();
        }

        private void fire_Click(object sender, RoutedEventArgs e)
        {
            int xcoordinate = Convert.ToInt32(xCoordinate.Text);
            int ycoordinate = Convert.ToInt32(yCoordinate.Text);

            data.playerAttack(xcoordinate,ycoordinate);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                data.playerMove(-1, 0);

            }
            else if((e.Key == Key.Left))
            {
                data.playerMove(0, -1);
            }
            else if ((e.Key == Key.Down))
            {
                data.playerMove(1, 0);
            }
            else if ((e.Key == Key.Right))
            {
                data.playerMove(0, 1);
            }
           
        }
    }
}

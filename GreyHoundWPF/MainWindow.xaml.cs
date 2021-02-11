
using System.Windows;
using GreyHoundLibrary;
using System.Threading;
using System;
using System.Windows.Controls;

namespace GreyHoundWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Program data;
        public MainWindow()
        {
            
            InitializeComponent();

            data = new Program();      
            DataContext = data;
            
            for(int i= 0; i<21; i++)
            {
                RadarGrid.RowDefinitions.Add(new RowDefinition());
                RadarGrid.ColumnDefinitions.Add(new ColumnDefinition());
                TextBlock text = new TextBlock();
                text.Text = i.ToString();
                text.SetValue(Grid.RowProperty,i);
                text.SetValue(Grid.ColumnProperty,i);
                
            }
            
        }

        private void OnWindowclose(object sender, EventArgs e)
        {
            data.t.Join();
            Environment.Exit(Environment.ExitCode); 
        }

    }
}

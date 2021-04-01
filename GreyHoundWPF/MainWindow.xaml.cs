﻿
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

            DataContext = MainViewModel.getInstaince();

        }
    }
}

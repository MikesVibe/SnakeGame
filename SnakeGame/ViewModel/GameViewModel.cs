﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SnakeGame.ViewModel
{
    public class GameViewModel : ObservableObject
    {

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString());

            //if (ViewModel == null) return;
            ///* ... */
            //ViewModel.HandleKeyDown(e);

            //SnakeGame.Views.GameView.Window_PreviewKeyDown(sender, e)
            //MessageBox.Show(e.Key.ToString());

        }
    }
}

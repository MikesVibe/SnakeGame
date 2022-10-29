using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SnakeGame.ViewModel
{
    class MainViewModel : ObservableObject
    {
        //public RelayCommand MainMenuViewCommand{ get; set; }
        public RelayCommand GameViewCommand{ get; set; }

        public MainMenuViewModel MainMenuVM { get; set; }
        public GameViewModel GameVM { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private object _keyDownPressed ;

        public object KeyDownPressed
        {
            get { return _keyDownPressed; }
            set 
            {
                _keyDownPressed = value;
                OnPropertyChanged();
            }
        }

        public void MainView_KeyDown(object sender, KeyEventArgs e)
        {
           string name =  e.Key.ToString();
           string name1 =  e.Key.ToString();
        }



        //public ICommand MyProperty
        //{
        //    get { return (ICommand)GetValue(MyPropertyProperty); }
        //    set { SetValue(MyPropertyProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MyPropertyProperty =
        //    DependencyProperty.Register("MyProperty", typeof(int), typeof(MainViewModel), new PropertyMetadata(null));




        public MainViewModel()
        {
            MainMenuVM = new MainMenuViewModel();
            GameVM = new GameViewModel();
            CurrentView = MainMenuVM;
            //CurrentView = GameVM;
            //MainMenuViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = MainMenuVM;
            //});

            //GameViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = GameVM;
            //});
        }


    }
}

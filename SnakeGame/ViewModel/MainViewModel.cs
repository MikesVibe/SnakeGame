using SnakeGame.Stores;
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
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }



        //public MainViewModel()
        //{
        //    MainMenuVM = new MainMenuViewModel();
        //    GameVM = new GameViewModel();
        //    CurrentView = MainMenuVM;
        //    CurrentView = GameVM;
        //    MainMenuViewCommand = new RelayCommand(o =>
        //    {
        //        CurrentView = MainMenuVM;
        //    });

        //    GameViewCommand = new RelayCommand(o =>
        //    {
        //        CurrentView = GameVM;
        //    });
        //}

        ////public RelayCommand MainMenuViewCommand{ get; set; }

        //public RelayCommand GameViewCommand { get; set; }

        //public MainMenuViewModel MainMenuVM { get; set; }
        //public GameViewModel GameVM { get; set; }

        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        private readonly NavigationStore _navigationStore;



        private object _currentView;



    }
}

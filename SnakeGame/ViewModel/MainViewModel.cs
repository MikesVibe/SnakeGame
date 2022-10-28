using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public MainViewModel()
        {
            MainMenuVM = new MainMenuViewModel();
            GameVM = new GameViewModel();
            //CurrentView = MainMenuVM;
            CurrentView = GameVM;

            //MainMenuViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = MainMenuVM;
            //});

            GameViewCommand = new RelayCommand(o =>
            {
                CurrentView = GameVM;
            });
        }


    }
}

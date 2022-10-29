using SnakeGame.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnakeGame.ViewModel
{
    class MainMenuViewModel : ObservableObject
    {
        //private readonly ObservableCollection<Reser>
    
    
    public ICommand StartGame { get; }
    public ICommand Options { get; }
    public ICommand Exit { get; }

        public MainMenuViewModel()
        {
            StartGame = new StartGameCommand();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnakeGame.ViewModel
{
    class MainMenuViewModel : ObservableObject
    {
    
    
    
    public ICommand StartGame { get; }
    public ICommand Options { get; }
    public ICommand Exit { get; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace SnakeGame.Views
{
    /// <summary>
    /// Logika interakcji dla klasy GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {


        public ICommand KeyPressedCommand
        {
            get { return (ICommand)GetValue(KeyPressedCommandProperty); }
            set { SetValue(KeyPressedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KeyPressedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyPressedCommandProperty =
            DependencyProperty.Register("KeyPressedCommand", typeof(ICommand), typeof(GameView), new PropertyMetadata(null));



        //public GameView()
        //{
        //    InitializeComponent();
        //}
        public GameView()
        {
            InitializeComponent();
            gridImages = SetupGrid();
            gameState = new GameState(rows, cols);
            //Overlay.Visibility = Visibility.Hidden;


        }

        private async Task RunGame()
        {
            Draw();
            Overlay.Visibility = Visibility.Hidden;
            await GameLoop();
        }
        public async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString());

            if (Overlay.Visibility == Visibility.Visible)
            {
                e.Handled = true;
            }
            if (!gameRunning)
            {
                gameRunning = true;
                await RunGame();
                gameRunning = false;
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyPressedCommand == null)
                return;
            KeyPressedCommand.Execute(null);

            MessageBox.Show(e.Key.ToString());


            if (gameState.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    gameState.ChangeDirection(Direction.Left);
                    break;
                case Key.Right:
                    gameState.ChangeDirection(Direction.Right);
                    break;
                case Key.Up:
                    gameState.ChangeDirection(Direction.Up);
                    break;
                case Key.Down:
                    gameState.ChangeDirection(Direction.Down);
                    break;
            }
        }

        private async Task GameLoop()
        {
            while (!gameState.GameOver)
            {
                await Task.Delay(100);
                gameState.Move();
                Draw();
            }
        }


        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[rows, cols];
            //GameGrid.Rows = rows;
            //GameGrid.Columns = cols;

            //for (int r = 0; r < rows; r++)
            //{
            //    for (int c = 0; c < cols; c++)
            //    {
            //        Image img = new Image()
            //        {
            //            Source = Images.Empty
            //        };
            //        images[r, c] = img;
            //        GameGrid.Children.Add(img);
            //    }
            //}

            return images;
        }
        private void Draw()
        {
            DrawGrid();
            ScoreText.Text = $"SCORE: {gameState.Score}";
        }

        private void DrawGrid()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    GridValue gridVal = gameState.Grid[r, c];
                    gridImages[r, c].Source = gridValToImage[gridVal];
                }
            }
        }


        private readonly Dictionary<GridValue, ImageSource> gridValToImage = new()
        {
            { GridValue.Empty, Images.Empty },
            { GridValue.Food, Images.Food },
            { GridValue.Snake, Images.Body }
        };

        private readonly int rows = 15, cols = 15;
        private readonly Image[,] gridImages;
        private GameState gameState;
        private bool gameRunning;

    }
}

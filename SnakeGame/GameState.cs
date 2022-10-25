using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class GameState
    {
        public int Rows { get; }
        public int Cols { get; }
        public GridValue[,] Grid { get; }
        public Direction Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }

        private readonly LinkedList<Direction> dirChanges = new LinkedList<Direction>();
        private readonly LinkedList<Position> snakePositions = new LinkedList<Position>();
        private readonly Random random = new Random();

        public GameState(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new GridValue[rows, cols];
            Dir = Direction.Right;
            Score = 0;

            AddSnake();
            AddFood();
        }
        private void AddSnake()
        {
            int r = Rows / 2;

            for (int c = 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
                snakePositions.AddFirst(new Position(r, c));
            }
        }

        private IEnumerable<Position> EmptyPositions()
        {
            /*
            Itterate through the whole Grid and return all empty spots
            */
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c] == GridValue.Empty)
                    {
                        yield return new Position(r, c);
                    }
                }
            }

        }
        private void AddFood()
        {
            List<Position> empty = new List<Position>(EmptyPositions());
            if (empty.Count == 0)
            {
                return;
            }

            Position pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Col] = GridValue.Food;
        }
        public Position HeadPosition()
        {
            return snakePositions.First.Value;
        }
        public Position TailPosition()
        {
            return snakePositions.Last.Value;
        }

        public IEnumerable<Position> SnakePositions()
        {
            return snakePositions;
        }
        private void AddHead(Position pos)
        {
            /*
             This function adds first part of snail and sets gridValue to snake.
             */
            snakePositions.AddFirst(pos);
            Grid[pos.Row, pos.Col] = GridValue.Snake;
        }

        private void RemoveTail()
        {
            /*
             This function removes last part of snail and sets gridValue to empty.
             */
            Position tail = snakePositions.Last.Value;
            Grid[tail.Row, tail.Col] = GridValue.Empty;
            snakePositions.RemoveLast();
        }

        private Direction GetLastDirection()
        {
            if(dirChanges.Count == 0)
            {
                return Dir;
            }

            return dirChanges.Last.Value;
        }

        private bool CanChangeDirection(Direction newDir)
        {
            /*
            Function returns true if number of direction changes in bufer is less than 2.
            Function also checks if new direction is difrent than previous one and 
            new direction should not be opposite to last one.
             */
            if(dirChanges.Count >= 2)
            {
                return false;
            }

            Direction lastDir = GetLastDirection();
            return newDir != lastDir && newDir != lastDir.Opposite();
        }

        public void ChangeDirection(Direction dir)
        {
            /*
             Function adds directon to buffer
             */
            if(CanChangeDirection(dir))
            {
                dirChanges.AddLast(dir);
            }
        }


        private bool OutsideGrid(Position pos)
        {
            /*
             This function returns true if position is outside a grid.
             */
            return pos.Row < 0 || pos.Row >= Rows || pos.Col < 0 || pos.Col >= Cols; 
        }
        private GridValue WillHit(Position newHeadPos)
        {
            /*
             This function checks for collison with other objects like wall, food and snake itself.
             */
            if(OutsideGrid(newHeadPos))
            {
                return GridValue.Outside;
            }
            if(newHeadPos == TailPosition())
            {
                return GridValue.Empty;
            }

            //It will return Empty, Snake or Food
            return Grid[newHeadPos.Row, newHeadPos.Col];
        }

        public void Move()
        {
            /*
             Function responsible for "Moving" snake
             */
            if(dirChanges.Count > 0)
            {
                Dir = dirChanges.First.Value;
                dirChanges.RemoveFirst();
            }

            Position newHeadPos = HeadPosition().Translate(Dir);
            GridValue hit = WillHit(newHeadPos);

            if(hit == GridValue.Outside || hit == GridValue.Snake)
            {
                GameOver = true;
            }
            else if(hit == GridValue.Empty)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if(hit == GridValue.Food)
            {
                AddHead(newHeadPos);
                Score++;
                AddFood();
            }

        }
    }
}

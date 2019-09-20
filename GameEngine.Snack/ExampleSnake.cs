using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 5;
        private Point _myHeadPosition;
        private List<Point> tail ;

        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection, int foodX, int foodY)
        {
          
                if (_myHeadPosition.X > foodX)
                {
                    if (tail.Contains(new Point(_myHeadPosition.X - 1, _myHeadPosition.Y)))
                    {
                        return SnakeDirection.Down;
                    }
                    else
                        return SnakeDirection.Left;
                }
                else if (_myHeadPosition.X < foodX)
                {
                    if (tail.Contains(new Point(_myHeadPosition.X + 1, _myHeadPosition.Y)))
                    {
                        return SnakeDirection.Down;
                    }
                    else
                    return SnakeDirection.Right;
                }
                if (_myHeadPosition.Y > foodY)
                {
                    if (tail.Contains(new Point(_myHeadPosition.X , _myHeadPosition.Y - 1)))
                    {
                        return SnakeDirection.Right;
                    }
                    else
                    return SnakeDirection.Up;
                }
                else if (_myHeadPosition.Y < foodY)
                {
                    if (tail.Contains(new Point(_myHeadPosition.X, _myHeadPosition.Y + 1)))
                    {
                        return SnakeDirection.Left;
                    }
                    else
                    return SnakeDirection.Down;
                }

            return currentDirection;
        }
        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            //Get All tail point so that the snake does not eat itself
            tail = new List<Point>();
            for (int index = map.IndexOf('1'); index > -1; index = map.IndexOf('1', index + 1))
            {
               tail.Add(new Point(index % _width, index / _width));
            }

            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }
      
    }
}

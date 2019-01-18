using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fit_xna_framework_lab.Objects
{
    class Player
    {
        public Vector2 coordinates;
        public Vector2 start;
        public double speed;
        public int score;
        public Texture2D texture;
        public int width;
        public int height;

        public Player(Vector2 _coordinates, double _speed, Texture2D _texture, int _width, int _height)
        {
            coordinates = _coordinates;
            start = _coordinates;
            speed = _speed;
            texture = _texture;
            width = _width;
            height = _height;
        }

        public void CheckCollision(Ball ball)
        {
            if (ball.currentVector == 0 || ball.currentVector == 3)
            {
                if (ball.coordinates.X <= coordinates.X + width
                    && ball.coordinates.X > coordinates.X
                    && ball.coordinates.Y >= coordinates.Y
                    && ball.coordinates.Y <= coordinates.Y + height)
                    ball.currentVector = ball.currentVector == 0 ? 1 : 2;
            }
            else
            {
                if (ball.coordinates.X >= coordinates.X + width
                    && ball.coordinates.X < coordinates.X
                    && ball.coordinates.Y >= coordinates.Y
                    && ball.coordinates.Y <= coordinates.Y + height)
                    ball.currentVector = ball.currentVector == 1 ? 0 : 3;
            }
        }


        public void move(int distance)
        {

        }
    }
}

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
        public float speed;
        public int score;
        public Texture2D texture;
        public int width;
        public int height;

        public Player(Vector2 _coordinates, float _speed, Texture2D _texture)
        {
            coordinates = _coordinates;
            start = _coordinates;
            speed = _speed;
            texture = _texture;
            width = texture.Width;
            height = texture.Height;
            score = 0;
        }

        public void CheckCollision(Ball ball)
        {
            if (ball.currentVector == 0 || ball.currentVector == 3)
            {
                if (ball.coordinates.X <= coordinates.X + width
                    && ball.coordinates.X > coordinates.X
                    &&(ball.coordinates.Y >= coordinates.Y || ball.coordinates.Y + ball.height >= coordinates.Y)
                    && (ball.coordinates.Y <= coordinates.Y + height || ball.coordinates.Y + ball.height <= coordinates.Y + height))
                    ball.currentVector = ball.currentVector == 0 ? 1 : 2;
            }
            else
            {
                if (ball.coordinates.X + ball.width >= coordinates.X
                    && ball.coordinates.X + ball.width < coordinates.X + width
                    && (ball.coordinates.Y >= coordinates.Y || ball.coordinates.Y + ball.height >= coordinates.Y)
                    && (ball.coordinates.Y <= coordinates.Y + height || ball.coordinates.Y + ball.height <= coordinates.Y + height))
                    ball.currentVector = ball.currentVector == 1 ? 0 : 3;
            }
        }


        public void Move(int distance, int uperBoundY, int bottomBoundY)
        {
            if (coordinates.Y + speed * distance >= uperBoundY && coordinates.Y + speed * distance + height <= bottomBoundY)
                coordinates.Y = coordinates.Y + speed * distance;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle((int)coordinates.X, (int)coordinates.Y, width, height), Color.White);
            spriteBatch.End();
        }
    }
}

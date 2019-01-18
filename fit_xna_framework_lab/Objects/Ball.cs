using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fit_xna_framework_lab.Objects
{
    class Ball
    {
        public Vector2 coordinates;
        Vector2 start;
        public float speed;
        public Texture2D texture;
        public int width;
        public int height;
        public Vector2[]vectors = new Vector2[4];
        public Vector2 center;
        public int currentVector;

        public Vector2 countUnitVector(Vector2 point, Vector2 coordinates)
        {
            Vector2 vector;
            Vector2 result;
            vector.X = point.X - coordinates.X;
            vector.Y = point.Y - coordinates.Y;
            result.X = vector.X / (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            result.Y = vector.Y / (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            return result;
        }

        public Ball(Vector2 _coordinates, float _speed, Texture2D _texture)
        {
            coordinates = _coordinates;
            start = _coordinates;
            speed = _speed;
            texture = _texture;
            width = texture.Width;
            height = texture.Height;

            center.X = width / 2;
            center.Y = height / 2;

            vectors[0] = countUnitVector(new Vector2(0, 0), center);
            vectors[1] = countUnitVector(new Vector2(width, 0), center);
            vectors[2] = countUnitVector(new Vector2(width, height), center);
            vectors[3] = countUnitVector(new Vector2(0, height), center);

            currentVector = GetRandomVector();
        }

        int GetRandomVector()
        {
            Random rnd = new Random();
            return rnd.Next(1, 4);
        }

        public void CheckCollision(int upperBoundY, int bottomBoundY, int leftGoalY, int RightGoalY,
            Player player1, Player player2)
        {
            if (upperBoundY >= coordinates.Y || bottomBoundY <= coordinates.Y + height)
            {
                if (currentVector == 0 || currentVector == 1)
                    currentVector = currentVector == 0 ? 3 : 2;
                else
                    currentVector = currentVector == 2 ? 1 : 0;
            }

            if (coordinates.X <= leftGoalY)
            {
                player1.score++;
                currentVector = GetRandomVector();
                coordinates = start;
                player1.coordinates = player1.start;
                player2.coordinates = player2.start;
            }
            else if (coordinates.X + width >= RightGoalY)
            {
                player2.score++;
                currentVector = GetRandomVector();
                coordinates = start;
                player1.coordinates = player1.start;
                player2.coordinates = player2.start;
            }
                
        }

        public void Move()
        {
            coordinates.X = coordinates.X + (vectors[currentVector].X * speed);
            coordinates.Y = coordinates.Y + (vectors[currentVector].Y * speed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle((int)coordinates.X, (int)coordinates.Y, width, height), Color.White);
            spriteBatch.End();
        }


    }
}

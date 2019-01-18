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
        Vector2 coordinates;
        double speed;
        Texture2D texture;
        int width;
        int height;
        Vector2 []vectors = new Vector2[4];
        Vector2 center;
        int currentVector;

        public Vector2 GetStartVector()
        {
            Random rnd = new Random();
            currentVector = rnd.Next(1, 4);
        }

        public Ball(Vector2 _coordinates, double _speed, Texture2D _texture, int _width, int _height)
        {
            coordinates = _coordinates;
            speed = _speed;
            texture = _texture;
            width = _width;
            height = _height;

            center.X = width / 2;
            center.Y = height / 2;

            vectors[0].X = 0 - center.X;
            vectors[0].Y = 0 - center.Y;

            vectors[1].X = width - center.X;
            vectors[1].Y = 0 - center.Y;

            vectors[2].X = width - center.X;
            vectors[2].Y = height - center.Y;

            vectors[3].X = 0 - center.X;
            vectors[3].Y = height - center.Y;
        }
    }
}

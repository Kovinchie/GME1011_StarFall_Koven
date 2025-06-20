using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Net.Mime;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace GME1011_StarFall_Koven
{
    internal class Clouds
    {
        private Texture2D _texture;
        private Vector2 _location;
        private Color _color;
        private Random _rng = new Random();
        private float _scale;
        private float _transparency;
        private float _speed;

        public Clouds(Texture2D clouds) 
        {
            _texture = clouds;
            _location = new Vector2(_rng.Next(0, 800), _rng.Next(0, 500)); // Randomly position clouds within the screen bounds
            _color = new Color(210 + _rng.Next(0, 41), 170 + _rng.Next(0, 21), 120 + _rng.Next(0, 21));
            _scale = _rng.Next(50, 150) / 200f;
            _transparency = _rng.Next(1, 61) / 100f;
            _speed = _rng.Next(1, 4) / 10f; // Random speed for cloud movement
        }
        public void Update()
        {
            _location.X -= _speed; // Move clouds to the left
            if (_location.X < -(_texture.Width/2))
            {
                // make clouds feel special
                _location.X = 800+(_texture.Width/2);
                _location.Y = _rng.Next(0, 480);
                _color = new Color(210 + _rng.Next(0, 41), 170 + _rng.Next(0, 21), 120 + _rng.Next(0, 21));
                _scale = _rng.Next(50, 150) / 200f;
                _transparency = _rng.Next(1, 61) / 100f;
                _speed = _rng.Next(1, 4) / 10f;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the clouds at the specified position
            spriteBatch.Draw(_texture, _location, null, _color * _transparency, 0,
                new Vector2(_texture.Width / 2, _texture.Height / 2), new Vector2(_scale, _scale), SpriteEffects.None, 0f);
        }
    }
}

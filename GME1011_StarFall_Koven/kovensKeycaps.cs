using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GME1011_StarFall_Koven
{
    internal class kovensKeycaps
    {
        protected Vector2 _Location;
        protected int _spot;
        protected Random _rng = new Random();
        private Texture2D _texture;
        protected int _rngMax = 27; // should be 27

        protected kovensKeys _playingKey;
        public kovensKeycaps(Texture2D texture, kovensKeys playingKey) 
        {
            _spot = _rng.Next(1, _rngMax); // Randomly select a key spot between 1 and 26
            _Location = playingKey.GetLocation(_spot);
            _playingKey = playingKey;
            _texture = texture;
        }

        public Vector2 GetLocation()  {  return _Location; }
        public int GetSpot() { return _spot; }

        public virtual Rectangle GetRectangle()
        {
            // Return a rectangle representing the key cap's hitbox
            return new Rectangle((int)_Location.X, (int)_Location.Y, _texture.Width, _texture.Height);
        }

        public virtual void ChangeLocation()
        {
            int position = _rng.Next(1, _rngMax);
            while (position == _playingKey.GetKeyPressed())
            {
                position = _rng.Next(1, _rngMax); // Ensure the new position is not the same as the pressed key
            }
            _spot = position;
            _Location = _playingKey.GetLocation(_spot);
        }

        public virtual void Update()
        {
            if (_playingKey.GetKeyPressed() == _spot)
            {
                Vector2 tempLocation;
                Vector2 currentLocation;
                _spot = _rng.Next(1, _rngMax);

                currentLocation = _Location;
                tempLocation = _playingKey.GetLocation(_spot);
                if (_playingKey.GetLocation() != tempLocation)
                {
                    currentLocation = tempLocation;
                }
                _Location = currentLocation;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Draw the key cap at its current location
            Vector2 location = GetLocation();
            spriteBatch.Draw(_texture, _Location, Color.White);
        }

    }
}

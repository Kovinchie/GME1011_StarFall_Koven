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
    internal class spikeyKeycap : kovensKeycaps
    {
        private Texture2D _texture;
        private Rectangle _spikeyHitbox;
        public spikeyKeycap(Texture2D textureSpikey, kovensKeys playingKey) : base(textureSpikey, playingKey)
        {
            _texture = textureSpikey;
            _Location.X -= 4;
            _Location.Y -= 4;
        }

        public override void ChangeLocation()
        {
            int position = _rng.Next(1, _rngMax);
            while (position == _playingKey.GetKeyPressed())
            {
                position = _rng.Next(1, _rngMax); // Ensure the new position is not the same as the pressed key
            }
            _spot = position;
            _Location = _playingKey.GetLocation(_spot);
            _Location.X -= 4; // Adjust the X position
            _Location.Y -= 4; // Adjust the Y position
        }

        public override void Update()
        {
            if (_playingKey.GetKeyPressed() == _spot)
            {
                Vector2 tempLocation;
            int position = _rng.Next(1, _rngMax);

            while (_spot == _playingKey.GetKeyPressed()) // make sure all stacked keycaps are moved
            {
                position = _rng.Next(1, _rngMax);
                tempLocation = _playingKey.GetLocation(position);
                if (_playingKey.GetLocation() != tempLocation)
                {
                    _Location = tempLocation;
                    _spot = position;
                }
            }

                _Location.X -= 4; // Adjust the X position
                _Location.Y -= 4; // Adjust the Y position
                Debug.WriteLine("Lost health");
            }
        }
    }
    
}

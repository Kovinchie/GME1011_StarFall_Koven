using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel.Design;


namespace GME1011_StarFall_Koven
{
    internal class spikeyKeycap : kovensKeycaps
    {
        private Texture2D _texture;
        private Vector2 _ajustedLocation;
        public spikeyKeycap(Texture2D textureSpikey, kovensKeys playingKey, SpriteFont gameFont) : base(textureSpikey, playingKey, gameFont)
        {
            _texture = textureSpikey;
            _description = "\nAvoid   Spikey   Keys!";
            _ajustedLocation = new Vector2(_Location.X - 4, _Location.Y - 4); // Adjust the initial location
        }

        public override void ChangeLocation()
        {
            base.ChangeLocation();
            if (_ajustedLocation != _Location)
            {
                _ajustedLocation = new Vector2(_Location.X - 4, _Location.Y - 4);
                _Location = _ajustedLocation; // Update the location with the adjusted position
            }
        }
        public override void Update()
        {
            if (_playingKey.GetKeyPressed() == _spot)
                _playingKey.TakeDamage();

            base.Update();

            if (_ajustedLocation != _Location)
            {
                _ajustedLocation = new Vector2(_Location.X - 4, _Location.Y - 4);
                _Location = _ajustedLocation; // Update the location with the adjusted position
            }
        }
    }
    
}

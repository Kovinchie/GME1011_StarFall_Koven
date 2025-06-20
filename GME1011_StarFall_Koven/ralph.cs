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
    internal class ralph : kovensKeycaps 
    {
        private Texture2D _texture;
        private bool _toggle;

        public ralph(Texture2D ralphTexture,kovensKeys playingKey, SpriteFont gameFont) : base(ralphTexture, playingKey, gameFont)
        {
            _texture = ralphTexture;
            _description = "Not you again...";
            _toggle = true;
            _timer = 5 * 60;
        }
        public override void Timer()
        {
            if (_timer > 0)
            {
                _timer--;
                _toggle = true;
            }
            else if (_toggle)
            {
                _timer = _rng.Next(1, 6) * 60; // Reset the timer to 4 seconds
                _visable = (false == _visable);
                _toggle = false;
            }
        }

        public override void Update()
        {
            if (_playingKey.GetKeyPressed() == _spot)
                _playingKey.AddPoint();
            base.Update();
        }

    }
}

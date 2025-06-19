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

        public ralph(Texture2D ralphTexture,kovensKeys playingKey, SpriteFont gameFont) : base(ralphTexture, playingKey, gameFont)
        {
            _texture = ralphTexture;
            _description = "Not you again...";
        }

        public override void ChangeLocation()
        {
            base.ChangeLocation();
            _Location = _playingKey.GetLocation(_spot);
        }

        public override void Update()
        {
            base.Update();
        }

    }
}

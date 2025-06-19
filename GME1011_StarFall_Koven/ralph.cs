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
        private Rectangle _ralphHitbox;

        public ralph(Texture2D ralphTexture,kovensKeys playingKey) : base(ralphTexture, playingKey)
        {
            _texture = ralphTexture;
        }


        public override void Update()
        {
            base.Update();
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace GME1011_StarFall_Koven
{
    internal class ralph : kovensKeycaps 
    {
        private Texture2D _texture;
        private bool _toggle;
        private string[] _ralphalog; // GET IT LOL!!! ITS LIKE ralph + dialog SO FUNNY RIGHT XD

        public ralph(Texture2D ralphTexture,kovensKeys playingKey, SpriteFont gameFont, List<SoundEffect> hitsounds)
            : base(ralphTexture, playingKey, gameFont, hitsounds)
        {
            _texture = ralphTexture;
            _description = "Not you again...";
            _toggle = true;
            _timer = 5 * 60;
            _ralphalog = new string[]
            {
                "Leave me alone!",
                "please leave...",
                "stop following me!!!",
                "um... over here?",
                "whats your problem.",
                "*  Sobs  *",
                "what ever i guess."
            };
            _hitSounds[4].Play();
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
            _timer = _rng.Next(3, 7) * 60; // Reset the timer rng
            _visable = (false == _visable);
                if (_visable && _toggle)
                {
                    _hitSounds[4].Play(); // Play the yap sound when the keycap reappears
                }
            _toggle = false;
                
            if (_playingKey.Gethealth() != 0)
                {
                    _description = _ralphalog[_rng.Next(0, _ralphalog.Length)];

                }
                else
                {
                    _description = "Some Peace and Quiet.";
                }
            }
        
        }

        public override void Update()
        {
            if (_playingKey.GetKeyPressed() == _spot)
            {
                _playingKey.AddPoint();
                _hitSounds[_rng.Next(0, 2)].Play();
            }
            base.Update();
        }

    }
}

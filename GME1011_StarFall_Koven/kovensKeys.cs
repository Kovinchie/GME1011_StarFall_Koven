using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GME1011_StarFall_Koven
{
    internal class kovensKeys
    {
        private int _keypressed;
        private Vector2 _location;
        private int _x;
        private int _y;
        private int _points;
        private int _health;

        public kovensKeys()
        {
            _keypressed = 15;
            _location = new Vector2(400, 240);
            _x = 24;
            _y = 96;
            _points = 0;
            _health = 3; // Starting health
        }
        public void AddPoint()
        {
            _points ++;
        }
        public void TakeDamage(int damage)
        {
            _health += damage;
        }
        public int Gethealth()
        {
            return _health;
        }
        public int GetPoints()
        {
            return _points;
        }

        public int GetKeyPressed()
        {
            return _keypressed;
        }
        public Vector2 GetLocation()
        {
            return GetLocation(_keypressed); // changed it so i can grab the location of the key pressed inside keycaps
        }
        public Vector2 GetLocation(int keypressed)
        {
             int spot = keypressed;
            // Calculate the x and y position based on the key pressed
            if (spot <= 10)
            {
                _x = 20 + (80 * (spot - 1)); // Top row
                _y = 92;
            }
            if (spot <= 19 && 10 < spot)
            {
                _x = 60 + (80 * (spot - 11)); // Middle row
                _y = 212;
            }
            if (spot <= 27 && spot > 19)
            {
                _x = 100 + (80 * (spot - 20)); // Bottom row
                _y = 332;
            }

            Vector2 location = new Vector2(_x, _y);
            return location;
        }

        public void Update()
        {
            if (_health <= 0)
            {
                _health = 0; // Prevent health from going below 0
                return; // Stop processing if health is 0
            }
            KeyboardState keystate = Keyboard.GetState();
            // TOP ROW
            if (keystate.IsKeyDown(Keys.Q))
            {
                _keypressed = 1;
            }
            if (keystate.IsKeyDown(Keys.W))
            {
                _keypressed = 2;
            }
            if (keystate.IsKeyDown(Keys.E))
            {
                _keypressed = 3;
            }
            if (keystate.IsKeyDown(Keys.R))
            {
                _keypressed = 4;
            }
            if (keystate.IsKeyDown(Keys.T))
            {
                _keypressed = 5;
            }
            if (keystate.IsKeyDown(Keys.Y))
            {
                _keypressed = 6;
            }
            if (keystate.IsKeyDown(Keys.U))
            {
                _keypressed = 7;
            }
            if (keystate.IsKeyDown(Keys.I))
            {
                _keypressed = 8;
            }
            if (keystate.IsKeyDown(Keys.O))
            {
                _keypressed = 9;
            }
            if (keystate.IsKeyDown(Keys.P))
            {
                _keypressed = 10;
            }

            // MIDDLE ROW
            if (keystate.IsKeyDown(Keys.A))
            {
                _keypressed = 11;
            }
            if (keystate.IsKeyDown(Keys.S))
            {
                _keypressed = 12;
            }
            if (keystate.IsKeyDown(Keys.D))
            {
                _keypressed = 13;
            }
            if (keystate.IsKeyDown(Keys.F))
            {
                _keypressed = 14;
            }
            if (keystate.IsKeyDown(Keys.G))
            {
                _keypressed = 15;
            }
            if (keystate.IsKeyDown(Keys.H))
            {
                _keypressed = 16;
            }
            if (keystate.IsKeyDown(Keys.J))
            {
                _keypressed = 17;
            }
            if (keystate.IsKeyDown(Keys.K))
            {
                _keypressed = 18;
            }
            if (keystate.IsKeyDown(Keys.L))
            {
                _keypressed = 19;
            }

            // BOTTOM ROW
            if (keystate.IsKeyDown(Keys.Z))
            {
                _keypressed = 20;
            }
            if (keystate.IsKeyDown(Keys.X))
            {
                _keypressed = 21;
            }
            if (keystate.IsKeyDown(Keys.C))
            {
                _keypressed = 22;
            }
            if (keystate.IsKeyDown(Keys.V))
            {
                _keypressed = 23;
            }
            if (keystate.IsKeyDown(Keys.B))
            {
                _keypressed = 24;
            }
            if (keystate.IsKeyDown(Keys.N))
            {
                _keypressed = 25;
            }
            if (keystate.IsKeyDown(Keys.M))
            {
                _keypressed = 26;
            }
            if (keystate.IsKeyDown(Keys.OemComma))
            {
                _keypressed = 27;
            }

        }
    }
}

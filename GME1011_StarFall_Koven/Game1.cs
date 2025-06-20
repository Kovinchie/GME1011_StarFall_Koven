using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GME1011_StarFall_Koven
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _background;
        private SpriteFont gameFont;
        private kovensKeys _kovensKeys;
        private List<kovensKeycaps> _kovensKeycaps;
        private int _gameTime;
        private int _gameTime2;
        private int _timer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _kovensKeys = new kovensKeys();
            _gameTime = 0;
            _gameTime2 = 0;
            _timer = 0; // Initialize timeAdd to 0

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _kovensKeycaps = new List<kovensKeycaps>();
            _kovensKeycaps.Add(new ralph(Content.Load<Texture2D>("Ralph"),_kovensKeys, Content.Load<SpriteFont>("RalphText")));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background = Content.Load<Texture2D>("Keyboard");
            gameFont = Content.Load<SpriteFont>("infoText");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _kovensKeys.Update();
            _kovensKeycaps.ForEach(keyCap => keyCap.Update());
            _kovensKeycaps.ForEach(Key => Key.Timer()); // Font stuff

            for (int i = 1; i < _kovensKeycaps.Count; i++)
            {
                if (_kovensKeycaps[0].GetRectangle().Intersects(_kovensKeycaps[i].GetRectangle()))
                {
                    _kovensKeycaps.ForEach(key => key.ChangeLocation());
                    // Handle collision logic here, e.g., reset position or change state
                }
            }
            if (_kovensKeys.GetPoints() % 10 == 0)
            {
                _kovensKeycaps.Add(new spikeyKeycap(Content.Load<Texture2D>("Spikey"), _kovensKeys, Content.Load<SpriteFont>("infoText")));
                _kovensKeys.AddPoint();
            }

            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.Space))
            {
                Debug.WriteLine("Spot "+(_kovensKeycaps[0].GetSpot()) + " Texture loaded at " + (_kovensKeycaps[0].GetLocation()) +
                    " \n Player Spot "+(_kovensKeys.GetKeyPressed()) + " location of player at " + (_kovensKeys.GetLocation()));
            }

            _timer++;
            if (_timer >= 60)
            {
                _gameTime++;
                _timer = 0;
            }
            if (_gameTime >= 60)
            {
                _gameTime2++;
                _gameTime = 0;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();

            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _spriteBatch.Draw(Content.Load<Texture2D>("CurrentKeycap"), _kovensKeys.GetLocation(), Color.White);
            _kovensKeycaps.ForEach(keyCap => keyCap.Draw(_spriteBatch)); // copilot helped
            _spriteBatch.DrawString(gameFont, "Health : "+_kovensKeys.Gethealth() + "\nPoints : "+_kovensKeys.GetPoints(), new Vector2(10, 10), Color.Red);
            _spriteBatch.DrawString(gameFont, "Time"+ _gameTime2 +" : "+_gameTime, new Vector2(700, 460), Color.Red);


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

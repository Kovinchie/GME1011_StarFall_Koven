using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading.Tasks;
using System.Net.Mime;
using System.Threading;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;


namespace GME1011_StarFall_Koven
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Song _music;
        private List<SoundEffect> _hitSounds;


        private Texture2D _background;
        private SpriteFont gameFont;
        private kovensKeys _kovensKeys;
        private List<kovensKeycaps> _kovensKeycaps;
        private List<Clouds> _clouds;
        private Random _rng = new Random();
        private int _digitCount1;
        private int _digitCoun2;
        private int _timer;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _kovensKeys = new kovensKeys();
            _digitCount1 = 0;
            _digitCoun2 = 0;
            _timer = 0; // Initialize timeAdd to 0

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _kovensKeycaps = new List<kovensKeycaps>();

            _clouds = new List<Clouds>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _music = Content.Load<Song>("Plaint");
            _hitSounds = new List<SoundEffect>
            {
                Content.Load<SoundEffect>("Wood"),
                Content.Load<SoundEffect>("Clicky"),
                Content.Load<SoundEffect>("String"),
                Content.Load<SoundEffect>("Shuffle"),
                Content.Load<SoundEffect>("Yap")
            };
            MediaPlayer.Play(_music);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background = Content.Load<Texture2D>("Keyboard");
            gameFont = Content.Load<SpriteFont>("infoText");


            _kovensKeycaps.Add(new ralph(Content.Load<Texture2D>("Ralph"), _kovensKeys, Content.Load<SpriteFont>("RalphText"), _hitSounds));

            for (int i = 0; i < _rng.Next(10, 20); i++)
            {
                _clouds.Add(new Clouds(Content.Load<Texture2D>("Cloud")));
            }

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
                _kovensKeycaps.Add(new spikeyKeycap(Content.Load<Texture2D>("Spikey"), _kovensKeys, Content.Load<SpriteFont>("infoText"), _hitSounds));
                _kovensKeys.AddPoint();
            }

            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.Space) && _kovensKeys.Gethealth() == 0)
            {
                _kovensKeys.TakeDamage(3);
                _kovensKeys.ResetPoints();
                _kovensKeycaps.Clear(); // Clear the keycaps when space is pressed
                _kovensKeycaps.Add(new ralph(Content.Load<Texture2D>("Ralph"), _kovensKeys, Content.Load<SpriteFont>("RalphText"), _hitSounds)); // Add a new keycap
            }

            _timer++;
            if (_timer >= 60)
            {
                _digitCount1++;
                _timer = 0;
            }
            if (_digitCount1 >= 60)
            {
                _digitCoun2++;
                _digitCount1 = 0;
            }
            _clouds.ForEach(cloud => cloud.Update()); // Update clouds if you have a Clouds class
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();

            _clouds.ForEach(cloud => cloud.Draw(_spriteBatch)); // Draw clouds
            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _spriteBatch.Draw(Content.Load<Texture2D>("CurrentKeycap"), _kovensKeys.GetLocation(), Color.White);
            _kovensKeycaps.ForEach(keyCap => keyCap.Draw(_spriteBatch));
            _spriteBatch.DrawString(gameFont, "Health : "+_kovensKeys.Gethealth() + "\nPoints : "+_kovensKeys.GetPoints(), new Vector2(10, 10), Color.Red);
            _spriteBatch.DrawString(gameFont, "Time"+ _digitCoun2 +" : "+_digitCount1, new Vector2(700, 460), Color.Red);

            if (_kovensKeys.Gethealth() <= 0)
            {
                _spriteBatch.DrawString(Content.Load<SpriteFont>("RalphText"), "Game Over!\nPress   Space   to   Restart...", new Vector2(300, 10), Color.Red);
            }

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

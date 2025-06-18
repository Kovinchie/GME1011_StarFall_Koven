using System.Diagnostics;
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
        private kovensKeys kovensKeys;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            kovensKeys = new kovensKeys();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background = Content.Load<Texture2D>("Keyboard");
            gameFont = Content.Load<SpriteFont>("GameFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            kovensKeys.Update();

            Debug.WriteLine("Key Location: " + kovensKeys.GetLocation());

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _spriteBatch.DrawString(gameFont, ""+kovensKeys.GetKeyPressed(), kovensKeys.GetLocation(), Color.Black);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

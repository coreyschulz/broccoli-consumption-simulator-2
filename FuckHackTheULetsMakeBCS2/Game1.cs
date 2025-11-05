using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

using State;
using Assets;

namespace FuckHackTheULetsMakeBCS2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private StateManager stateManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720,
                IsFullScreen = true
            };

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            stateManager = StateManager.GetInstance();
            stateManager.Push(new OriginalBCS());

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Assets.Assets.Textures["zak/original/bcman"] = Content.Load<Texture2D>("zak/original/bcman");
            Assets.Assets.Textures["zak/original/bcman_left"] = Content.Load<Texture2D>("zak/original/bcman_left");
            Assets.Assets.Textures["zak/original/bcman_right"] = Content.Load<Texture2D>("zak/original/bcman_right");
            Assets.Assets.Textures["zak/original/bcman_new"] = Content.Load<Texture2D>("zak/original/bcman_new");

            Assets.Assets.Textures["zak/original/brocolli"] = Content.Load<Texture2D>("zak/original/brocolli");

            Assets.Assets.Songs["zak/original/sakura_ost"] = Content.Load<Song>("zak/original/sakura_ost");
            Assets.Assets.Songs["zak/original/epic"] = Content.Load<Song>("zak/original/epic");

            Assets.Assets.SpriteFonts["zak/original/bcsfont"] = Content.Load<SpriteFont>("zak/original/bcsfont");



            Assets.Assets.Textures["zak/bullet/samsung"] = Content.Load<Texture2D>("zak/bullet/samsung");
            Assets.Assets.Textures["zak/bullet/bcman"] = Content.Load<Texture2D>("zak/bullet/bcman");
            Assets.Assets.Textures["zak/bullet/bullet"] = Content.Load<Texture2D>("zak/bullet/bullet");

            Assets.Assets.SoundEffects["zak/bullet/yell"] = Content.Load<SoundEffect>("zak/bullet/yell");

            Assets.Assets.Songs["zak/bullet/undertale"] = Content.Load<Song>("zak/bullet/undertale");



            Assets.Assets.Textures["mason_assets/demo_image"] = Content.Load<Texture2D>("mason_assets/demo_image");
            Assets.Assets.Textures["mason_assets/boy"] = Content.Load<Texture2D>("mason_assets/boy");
            Assets.Assets.Textures["mason_assets/girl"] = Content.Load<Texture2D>("mason_assets/girl");
            Assets.Assets.Textures["mason_assets/bcs_man"] = Content.Load<Texture2D>("mason_assets/bcs_man");
            Assets.Assets.Textures["mason_assets/drug_needle"] = Content.Load<Texture2D>("mason_assets/drug_needle");
            Assets.Assets.Textures["mason_assets/pill"] = Content.Load<Texture2D>("mason_assets/pill");
            Assets.Assets.Textures["mason_assets/cocaine"] = Content.Load<Texture2D>("mason_assets/cocaine");
            Assets.Assets.SpriteFonts["mason_assets/arial_font"] = Content.Load<SpriteFont>("mason_assets/arial_font");
            Assets.Assets.SoundEffects["mason_assets/BC_theme"] = Content.Load<SoundEffect>("mason_assets/BC_theme");


            Assets.Assets.Textures["corey/bcman"] = Content.Load<Texture2D>("corey/bcman");
            Assets.Assets.Textures["corey/bcman_done"] = Content.Load<Texture2D>("corey/bcman_done");
            Assets.Assets.Textures["corey/samsung"] = Content.Load<Texture2D>("corey/samsung");
            Assets.Assets.Textures["corey/broccoli"] = Content.Load<Texture2D>("corey/broccoli");
            Assets.Assets.Textures["corey/ruinedWorld"] = Content.Load<Texture2D>("corey/ruinedWorld");
            Assets.Assets.Textures["corey/home"] = Content.Load<Texture2D>("corey/home");
            Assets.Assets.Textures["corey/rectangleBase"] = Content.Load<Texture2D>("corey/rectangleBase");
            Assets.Assets.SpriteFonts["corey/bcsFont"] = Content.Load<SpriteFont>("corey/bcsFont");
            Assets.Assets.SpriteFonts["corey/bcsFont2"] = Content.Load<SpriteFont>("corey/bcsFont2");
            Assets.Assets.Songs["corey/default"] = Content.Load<Song>("corey/default");
            Assets.Assets.Songs["corey/notFight"] = Content.Load<Song>("corey/notFight");
            Assets.Assets.Songs["corey/fight"] = Content.Load<Song>("corey/fight");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            stateManager.Update(gameTime);

            if(stateManager.Empty())
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            stateManager.Draw(spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }
}

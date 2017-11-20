using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjetWorms
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;
        Worms worms1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1250;
            graphics.PreferredBackBufferHeight = 750;
            Content.RootDirectory = "Content";
            map = new Map(this);
            worms1 = new Worms(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            map.Generate(new int[,]{
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,2 ,2, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,2 ,2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0,0 ,0 ,0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {2 ,2 ,2 ,2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
                {1 ,1 ,1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1 ,1 ,1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            }, 50);
       
            worms1.Initialise();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            map.LoadContent(spriteBatch);
            worms1.LoadContent(spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            worms1.Update(gameTime);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            this.spriteBatch.Begin();

            map.Draw(gameTime);
            //Dessine la hitbox du worms1
            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 60, 60);
            Color[] data = new Color[60 * 60];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            rect.SetData(data);
            Vector2 coor = new Vector2(worms1.Position.X, worms1.Position.Y);
            spriteBatch.Draw(rect, coor, Color.White);

            //Dessine le worms1
            worms1.Draw(gameTime);

            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

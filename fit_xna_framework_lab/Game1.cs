using fit_xna_framework_lab.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace fit_xna_framework_lab
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player1;
        Player player2;
        Ball ball;
        Texture2D playerTexture;
        Texture2D ballTexture;

        int uperBoundY;
        int bottomBoundY;
        int leftGoal;
        int rightGoal;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
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
            uperBoundY = 0;
            bottomBoundY = 1080;
            leftGoal = 0;
            rightGoal = 1920;
            
            
           
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            player1 = new Player(new Vector2(100, 100), 6, Content.Load<Texture2D>("block"));
            player2 = new Player(new Vector2(1820, 100), 6, Content.Load<Texture2D>("block"));
            ball = new Ball(new Vector2(910, 540), 4, Content.Load<Texture2D>("ball"));
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
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
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.W))
                player1.Move(-1);
            else if (state.IsKeyDown(Keys.S))
                player1.Move(1);

            if (state.IsKeyDown(Keys.Up))
                player2.Move(-1);
            else if (state.IsKeyDown(Keys.Down))
                player2.Move(1);

            ball.Move();
            

            ball.CheckCollision(uperBoundY, bottomBoundY, leftGoal, rightGoal, player1, player2);
            player1.CheckCollision(ball);
            player2.CheckCollision(ball);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

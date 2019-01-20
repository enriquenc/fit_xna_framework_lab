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
        SpriteFont font;

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
            bottomBoundY = graphics.PreferredBackBufferHeight;
            leftGoal = 0;
            rightGoal = graphics.PreferredBackBufferWidth;
            
            
           
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Texture2D blockTexture = Content.Load<Texture2D>("block");
            Texture2D ballTexture = Content.Load<Texture2D>("ball");

            player1 = new Player(new Vector2(100, (bottomBoundY - blockTexture.Height) / 2), 6, blockTexture);
            player2 = new Player(new Vector2(rightGoal - 200, (bottomBoundY - blockTexture.Height) / 2), 6, blockTexture);
            ball = new Ball(new Vector2(rightGoal / 2, bottomBoundY / 2), 7, ballTexture);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("file");
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
                player1.Move(-1, uperBoundY, bottomBoundY);
            else if (state.IsKeyDown(Keys.S))
                player1.Move(1, uperBoundY, bottomBoundY);

            if (state.IsKeyDown(Keys.Up))
                player2.Move(-1, uperBoundY, bottomBoundY);
            else if (state.IsKeyDown(Keys.Down))
                player2.Move(1, uperBoundY, bottomBoundY);

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

            ball.Draw(spriteBatch);
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            

            spriteBatch.Begin();
            spriteBatch.DrawString(font, player1.score.ToString(), new Vector2(400, 100), Color.Black);
            spriteBatch.DrawString(font, player2.score.ToString(), new Vector2(rightGoal - 400, 100), Color.Black);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

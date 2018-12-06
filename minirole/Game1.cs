using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Image screenImage;
        GameObject Screen;
        Animator animator;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.


            //**************************************************************************************************************************************************************************
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ComponentManager.Instance.graphicsDevice = GraphicsDevice;
            ComponentManager.Instance.Content = Content;

            //screenImage = new Image();
            //screenImage.LoadContent(Content);

            //ContentLoader<Image> ImageLoader = new ContentLoader<Image>();
            //screenImage = ImageLoader.Load("Load/SplashScreen01.xml");
            //Screen = new GameObject("Image");
            //Screen = new GameObject(screenImage);

            Screen = new GameObject();
            screenImage = Screen.AddCompnent<Image>();
            animator = Screen.AddCompnent<Animator>();
            animator.Initialize(1920, 1080, Vector2.Zero);
            //animator = new Animator(screenImage.gameObject, 1920, 1080, Vector2.Zero);
            animator.gameObject.LoadContent();
            //animator.gameObject.Image.LoadContent();
            animator.gameObject.Scale = .10f;
            //animator.gameObject.Transform.Rotate(180f);
            animator.gameObject.Transform.Translate(new Vector2(400, 240));

            //screenImage.gameObject.LoadContent();

            //screenImage.gameObject.Scale = .11f;
            //screenImage.gameObject.Transform.Rotate(180f);
            //screenImage.gameObject.Transform.Translate(new Vector2(400, 240));

            //Screen.Scale = .11f;
            //Screen.Transform.Rotate(180f);
            //Screen.Transform.Translate(new Vector2(400, 240));

            //Screen = new GameObject(new Image());
            //Screen.LoadContent();

            //**************************************************************************************************************************************************************************

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

            // TODO: Add your update logic here

            //**************************************************************************************************************************************************************************

            animator.gameObject.Update(gameTime);

            //if (screenImage.gameObject.Position.X > 800 && screenImage.gameObject.Position.Y > 480)
            //    screenImage.gameObject.Position = Vector2.Zero;
            //screenImage.gameObject.Transform.Translate(new Vector2(1, 1));
            //screenImage.gameObject.Transform.Rotate(1.0f);
            //screenImage.gameObject.Transform.Scale(0.001f);

            //if (Screen.Position.X > 800 && Screen.Position.Y > 480)
            //    Screen.Position = Vector2.Zero;
            //Screen.Transform.Translate(new Vector2(1, 1));
            //Screen.Transform.Rotate(1.0f);
            //Screen.Transform.Scale(0.001f);

            //**************************************************************************************************************************************************************************

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            animator.gameObject.Draw(spriteBatch);
            //screenImage.gameObject.Draw(spriteBatch);
            //Screen.Draw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

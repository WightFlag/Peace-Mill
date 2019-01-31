using System.Collections.Generic;
using System;

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
        GameObject Player;
        GameObject thisObject;
        Scene aScene;

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

            ComponentManager.Instance.graphicsDeviceManager = graphics;
            ComponentManager.Instance.graphicsDevice = GraphicsDevice;
            ComponentManager.Instance.Content = Content;

            //var gameObjectLoader = new ContentLoader<GameObject>();
            ////var thisObject = new GameObject();
            ////thisObject.AddCompnent<Image>();
            ////thisObject.AddCompnent<Animator>();
            ////thisObject.AddCompnent<Collider>();

            ////thisObject = new GameObject();
            ////thisObject.AddCompnent<Animator>();


            //thisObject = gameObjectLoader.Load("Load/gameObjectTemplate01.xml");



            //var aScene = new Scene();
            //aScene.Add(thisObject);
            //var sceneLoader = new ContentLoader<Scene>();
            //sceneLoader.Save("sceneTemplate.xml", aScene);

            //thisObject.Initialize();
            ////thisObject.GetComponent<Animator>().Initialize();


            ////thisObject.AddCompnent <InputController<ScreenInputController>>();

            ////gameObjectLoader.Save("Load/gameObjectTemplate.xml", thisObject);

            //thisObject.LoadContent();
            ////thisObject.Scale = (float)graphics.PreferredBackBufferWidth/thisObject.SourceRect.Width;
            ////thisObject.SourceRect = new Rectangle(0, 0, 48, 48);

            ////var imageLoader = new ContentLoader<Image>();
            ////imageLoader.Save("Load/image.xml", thisObject.GetComponent<Image>());

            ////var animatorLoader = new ContentLoader<Animator>();
            ////animatorLoader.Save("Load/animator.xml",thisObject.GetComponent<Animator>());

            ////Screen = new GameObject();
            ////screenImage = Screen.AddCompnent<Image>();
            ////animator = Screen.AddCompnent<Animator>();
            ////Screen.AddCompnent<InputController<ScreenInputController>>();

            ////animator.Initialize();
            ////animator.Initialize(1920, 1080, Vector2.Zero);

            ////animator.gameObject.LoadContent();
            ////animator.gameObject.Scale = .20f;
            ////Player = new GameObject();



            ////animator.gameObject.Transform.Translate(new Vector2(240, 240));


            var sceneLoader = new ContentLoader<Scene>();
            aScene = sceneLoader.Load("sceneTemplate.xml");
            aScene.Initialize();

            aScene.LoadContent();


            var animLoader = new ContentLoader<Animation>();
            //Texture2D[,] set = AnimationManager.Instance.GenerateFrames(aScene.GameObjects[1].GetComponent<Animator>().Spritesheet, aScene.GameObjects[1].GetComponent<Animator>().FrameSize);
            //var row = new Texture2D[(int)aScene.GameObjects[1].GetComponent<Animator>().FrameSet.X];
            //for(var i = 0; i < row.Length; i++)
            //{
            //    row[i] = set[0, i];
            //}
            var frameSet = aScene.GameObjects[1].GetComponent<Animator>().FrameSet;
            var animator = aScene.GameObjects[1].GetComponent<Animator>();

            var anim1 = AnimationManager.Instance.Generate(animator, frameSet);
            animLoader.Save("animation01.anim", anim1);

            var gameObjectLoader = new ContentLoader<GameObject>();

           for(var i = 0; i < aScene.GameObjects.Count; i++)
            {
                gameObjectLoader.Save($@"Load/gameObjectTemplateReRevised{i}.xml", aScene.GameObjects[i]);
            }


            //this line of code below is a temp fix to remove the laser beams from the sprite's feet. for some reason, the sourcerect is getting set to  (0,0,144,192) following the block above from "var animLoader".
            //UPDATE: The gameobject sourcerect was being reset to the original texture size due to a call from AnimationManager.GenerateFrames() to spriteSheet.LoadContent(). This affected the aScene sprite gameObject
            //because that is the spritesheet that was passed to AnimationManger.GenerateFrames() and as an object it was passed by reference by default.
            //aScene.GameObjects[1].SourceRect = new Rectangle(0, 0, 48, 48);


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

            InputHandler.Instance().Update(gameTime);

            // TODO: Add your update logic here

            //**************************************************************************************************************************************************************************

            ////animator.gameObject.Update(gameTime);
            //thisObject.Update(gameTime);

            aScene.Update(gameTime);

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

            ////animator.gameObject.Draw(spriteBatch);
            //thisObject.Draw(spriteBatch);

            aScene.Draw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

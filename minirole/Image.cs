using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    public class Image : Component, IRenderable
    {
        [XmlIgnore]
        public ContentManager Content;
        [XmlIgnore]
        public GraphicsDevice graphicsDevice;
        public string Path;
        [XmlIgnore]
        public Texture2D Texture;
        [XmlIgnore]
        public Texture2D RenderTarget;

        public Color Tint;
        public float Alpha;

        private Animator _animator;
        private Vector2 _origin;

        public Animator Animator { get => _animator; }

        public Image() :base()
        {
            Name = "Image";
            graphicsDevice = ComponentManager.Instance.graphicsDevice;
            Path = String.Empty;
            Tint = Color.White;
            Alpha = 1.0f;
            gameObject = new GameObject(this)
            {
                Image = this
            };
        }

        public Image(GameObject gameObject) : base()
        {
            Name = "Image";
            graphicsDevice = ComponentManager.Instance.graphicsDevice;
            Path = String.Empty;
            Tint = Color.White;
            Alpha = 1.0f;
            this.gameObject = gameObject;
            gameObject.Image = this;
            GameObjectManager.Instance.AddComponent(gameObject, this);
        }

        public override void LoadContent()
        {
            Content = new ContentManager(ComponentManager.Instance.Content.ServiceProvider, "Content");
            Texture = Content.Load<Texture2D>(Path);
            gameObject.SourceRect = new Rectangle(0, 0, Texture.Width, Texture.Height);
            _origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            RenderTarget = new Texture2D(graphicsDevice, gameObject.SourceRect.Width, gameObject.SourceRect.Height);
            Color[] pixelarray = new Color[gameObject.SourceRect.Width * gameObject.SourceRect.Height];
            Texture.GetData(0, gameObject.SourceRect, pixelarray, 0, pixelarray.Length);
            RenderTarget.SetData(pixelarray);
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(
               RenderTarget, 
               gameObject.Position, 
               gameObject.SourceRect, 
               Tint*Alpha, 
               gameObject.Rotation, 
               _origin, 
               gameObject.Scale, 
               SpriteEffects.None, 
               0.0f);
        }
    }
}

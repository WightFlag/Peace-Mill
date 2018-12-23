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
    public class Image : Component//, IRenderable
    {
        [XmlIgnore]
        public ContentManager Content;
        [XmlIgnore]
        public GraphicsDevice graphicsDevice;
        public string Path;
        [XmlIgnore]
        public Texture2D Texture;
        //public Texture2D RenderTarget;

        //private Animator _animator;
        private Vector2 _origin;

        
        public Color Tint;
        public float Alpha;
        public Vector2 Origin { get => _origin; set => _origin = value; }
        
        //public Animator Animator { get => _animator; }

        public Image(GameObject gameObject) : base()
        {
            Name = "Image";
            graphicsDevice = ComponentManager.Instance.graphicsDevice;
            Path = String.Empty;
            Tint = Color.White;
            Alpha = 1.0f;
            this.gameObject = gameObject;

            //Path = "bclog";
        }

        public Image() : base()
        {
            Name = "Image";
            graphicsDevice = ComponentManager.Instance.graphicsDevice;
            Path = String.Empty;
            Tint = Color.White;
            Alpha = 1.0f;

           //Path = "bclog";
        }

        public override void LoadContent()
        {
            Content = new ContentManager(ComponentManager.Instance.Content.ServiceProvider, "Content");
            Texture = Content.Load<Texture2D>(Path);
            gameObject.SourceRect = new Rectangle(0, 0, Texture.Width, Texture.Height);
            _origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}

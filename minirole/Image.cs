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
        public string Path;
        [XmlIgnore]
        public Texture2D Texture;
        [XmlIgnore]
        public ContentManager Content;
        [XmlIgnore]
        public GraphicsDevice graphicsDevice;
        public Rectangle sourceRect;
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
        }

        public override void LoadContent()
        {
            Content = new ContentManager(ComponentManager.Instance.Content.ServiceProvider, "Content");
            Texture = Content.Load<Texture2D>(Path);
            sourceRect = new Rectangle(0, 0, Texture.Width, Texture.Height);
            _origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
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
                Texture, 
                gameObject.Position, 
                sourceRect, 
                Tint*Alpha, 
                gameObject.Rotation, 
                _origin, 
                gameObject.Scale, 
                SpriteEffects.None, 
                0.0f);
        }
    }
}

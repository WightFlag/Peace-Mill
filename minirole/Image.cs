using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace minirole
{
    public class Image : Component, IRenderable
    {
        public string Path;
        public Texture2D Texture;
        public ContentManager Content;
        public GraphicsDevice graphicsDevice;
        public Rectangle sourceRect;

        public Image() :base()
        {
            Name = "Image";
            graphicsDevice = ComponentManager.Instance.graphicsDevice;
            //Path = String.Empty;
            Path = "bclog";
        }

        public override void LoadContent()
        {
            Content = new ContentManager(ComponentManager.Instance.Content.ServiceProvider, "Content");
            Texture = Content.Load<Texture2D>(Path);
            sourceRect = new Rectangle(0, 0, Texture.Width, Texture.Height);
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, gameObject.Transform.Position, sourceRect, Color.White, 0.0f, Vector2.Zero, 0.22f, SpriteEffects.None, 0.0f);
        }
    }
}

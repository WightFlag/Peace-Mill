using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Peace_Mill
{
    public class Renderer : Component
    {
        private Image _image;
        private GraphicsDevice _graphicsDevice;
        private GraphicsDeviceManager _graphicsDeviceManager;

        private Vector2 _originCenter;

        public Renderer(GameObject gameObject)
        {
            _graphicsDevice = ComponentManager.Instance.graphicsDevice;
            _graphicsDeviceManager = ComponentManager.Instance.graphicsDeviceManager;
            this.gameObject = gameObject;
            _image = gameObject.GetComponent<Image>();
            _originCenter = Vector2.Zero;
        }

        public Texture2D DrawFrame(Rectangle sourceRect, Image image)
        {

            var RenderTarget = new Texture2D(_graphicsDevice, sourceRect.Width, sourceRect.Height);
            Color[] pixelarray = new Color[sourceRect.Width * sourceRect.Height];
            image.Texture.GetData(0, sourceRect, pixelarray, 0, pixelarray.Length);
            RenderTarget.SetData(pixelarray);

            return RenderTarget;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 localOffset)
        {
            spriteBatch.Draw(
                texture,
                CenterOrigin() + localOffset,
                gameObject.SourceRect,
                _image.Tint * _image.Alpha,
                gameObject.Rotation,
                Vector2.Zero,
                gameObject.Scale,
                SpriteEffects.None,
                0.0f);
        }

        public Vector2 CenterOrigin()
        {
            //_originCenter.X = gameObject.Position.X * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2 + GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2;
            //_originCenter.Y = gameObject.Position.Y * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2 + GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2;
            _originCenter.X = gameObject.Position.X + _graphicsDeviceManager.PreferredBackBufferWidth / 2;
            _originCenter.Y = gameObject.Position.Y + _graphicsDeviceManager.PreferredBackBufferHeight / 2;

            return _originCenter;
        }
    }
}

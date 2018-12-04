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
        private GraphicsDevice _graphicsDevice;

        public Renderer()
        {
            _graphicsDevice = ComponentManager.Instance.graphicsDevice;
        }

         public Texture2D Draw(Rectangle sourceRect, Image image)
        {

            var RenderTarget = new Texture2D(_graphicsDevice, sourceRect.Width, sourceRect.Height);
            Color[] pixelarray = new Color[sourceRect.Width * sourceRect.Height];
            image.Texture.GetData(0, sourceRect, pixelarray, 0, pixelarray.Length);
            RenderTarget.SetData(pixelarray);

            return RenderTarget;
        }
    }
}

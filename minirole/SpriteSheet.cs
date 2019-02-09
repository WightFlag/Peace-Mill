using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    public class SpriteSheet : Component
    {
        private Image _image;
        private Vector2 _frameSize;
        private Vector2 _frameSet;

        public Image Image;
        public Vector2 FrameSize;
        public Vector2 FrameSet;

        public SpriteSheet()
        {
        }

        public SpriteSheet(Image image, Vector2 frameSize)
        {
            _image = image;
            _frameSize = frameSize;

            var width = image.Texture.Width / frameSize.X;
            var height = image.Texture.Height / frameSize.Y;
            _frameSet = new Vector2(width, height);
        }

        
    }
}

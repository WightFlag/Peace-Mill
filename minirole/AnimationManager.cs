using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    public class AnimationManager
    {
        private Texture2D[,] _currentSpriteSheetFrameSet;
        private static AnimationManager _instance;

        public static AnimationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AnimationManager();
                }

                return _instance;
            }
        }

        public Texture2D[,] GenerateFrames(Image spriteSheet, Vector2 frameSize)
        {
            spriteSheet.LoadContent();
            var frameSet = new Vector2(spriteSheet.Texture.Width / frameSize.X, spriteSheet.Texture.Height / frameSize.Y);
            _currentSpriteSheetFrameSet = new Texture2D[(int)frameSet.X, (int)frameSet.Y];
            var tempIndex = Vector2.Zero;

            spriteSheet.gameObject.SourceRect = new Rectangle((int)(tempIndex.X * frameSize.X), (int)(tempIndex.Y * frameSize.Y), (int)frameSize.X, (int)frameSize.Y);

            //var SourceRect = new Rectangle((int)(tempIndex.X * frameSize.X), (int)(tempIndex.Y * frameSize.Y), (int)frameSize.X, (int)frameSize.Y);

            var renderer = new Renderer();
            for (tempIndex.Y = 0; tempIndex.Y < frameSet.Y; tempIndex.Y++)
            {
                //_frames.Add(new List<Texture2D>());
                for (tempIndex.X = 0; tempIndex.X < frameSet.X; tempIndex.X++)
                {
                    var image = renderer.DrawFrame(new Rectangle((int)(tempIndex.X * frameSize.X), (int)(tempIndex.Y * frameSize.Y), (int)frameSize.X, (int)frameSize.Y), spriteSheet);

                    //_frames[(int)tempIndex.X].Add(image);
                    _currentSpriteSheetFrameSet[(int)tempIndex.X, (int)tempIndex.Y] = image;
                }
            }
            //_frameOrigin = new Vector2(frameSize.X / 2, frameSize.Y / 2);

            return _currentSpriteSheetFrameSet;
        }

        public Animation Generate(Texture2D[] frameSet)
        {
            return new Animation(frameSet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    public class Animator :Component
    {
        //private List<Texture2D> _frames;
        private Image _spriteSheet;
        private Vector2 _frameSize;
        private Vector2 _frameSet;
        private Vector2 _currentFrameIndex;

        //public List<Texture2D> Frames { get => _frames; private set => _frames = value; }
        public Image Spritesheet { get => _spriteSheet; }
        public Vector2 FrameSize { get => _frameSize; }
        public Vector2 FrameSet { get => _frameSet; }
        public Vector2 CurrentFrameIndex { get => _currentFrameIndex; }

        int i = 0;

        public Animator(GameObject gameObject, int tileWidth, int tileHeight, Vector2 initialFrameIndex):base()
        {
            this.Name = "Animator";
            this.gameObject = gameObject;            

            _spriteSheet = gameObject.HasCompnent("Image")? (Image)gameObject.Components["Image"]: new Image(gameObject);
            _frameSize = new Vector2(tileWidth, tileHeight);
            _frameSet = Vector2.Zero;
            _currentFrameIndex = initialFrameIndex;
            GameObjectManager.Instance.AddComponent(gameObject, this);
        }

        public void AdvanceFrame()
        {
            _currentFrameIndex.X = _currentFrameIndex.X == FrameSet.X ? 0 : _currentFrameIndex.X + 1;
        }

        public void SetFrameSequence(int row)
        {
            _currentFrameIndex.Y = row;
        }

        public override void LoadContent()
        {//establishes the frameset and sourceRect for render once the image has been loaded
            _frameSet = new Vector2(gameObject.Image.Texture.Width / FrameSize.X, gameObject.Image.Texture.Width / FrameSize.Y);
            gameObject.SourceRect = new Rectangle((int)(_currentFrameIndex.X * FrameSize.X), (int)(_currentFrameIndex.Y * FrameSize.Y), (int)FrameSize.X, (int)FrameSize.Y);
        }

        public override void Update(GameTime gameTime)
        {
            //current problem is the need to render the section of the image that I am drawing as sourcerect to a texture and then draw that texture to the sourcerect, then move the sourcerect
            //delete exploratory garbage and fix up.

            //AdvanceFrame();
            if(gameTime.TotalGameTime.TotalSeconds >2)
            {
                switch (i)
                {
                    case 0:
                        _currentFrameIndex = new Vector2(0, 0);
                        break;
                    case 1:
                        _currentFrameIndex = new Vector2(1, 0);
                        break;
                    case 2:
                        _currentFrameIndex = new Vector2(1, 1);
                        break;
                    case 3:
                        _currentFrameIndex = new Vector2(0, 1);
                        break;

                }
                gameObject.SourceRect = new Rectangle((int)(_currentFrameIndex.X * FrameSize.X), (int)(_currentFrameIndex.Y * FrameSize.Y), (int)FrameSize.X, (int)FrameSize.Y);
                switch (i)
                {
                    case 0:
                        gameObject.Position = new Vector2(406, 224);
                        break;
                    case 1:
                        gameObject.Position = new Vector2(406 + 384 / 2, 224);
                        break;
                    case 2:
                        gameObject.Position = new Vector2(406 + 384 / 2, 224 + 216 / 2);
                        break;
                    case 3:
                        gameObject.Position = new Vector2(406, 224 + 216 / 2);
                        break;
                }
                i = i > 2 ? 0 : i + 1;
            }

        }
    }
}

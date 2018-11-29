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
        //public bool HasAnimator { get; } = false;

        public Animator(GameObject gameObject, int tileWidth, int tileHeight):base()
        {
            this.Name = "Animator";
            this.gameObject = gameObject;

            Image image = (Image)gameObject.Components["Image"];
            if (image != null)
            {
                this._spriteSheet = image; // consider how to point to a GameObject's image when it may or may not have been set yet
                                           //also, items below in this constructor may need to move to LoadContent and same should be considered for other classes/constructors
                                           //also, implement a mechanism for preventing GameObjectManager from calling draw on images associated with Animators.
                //this._spriteSheet.ToggleAnimator(this);

                this._frameSize = new Vector2(tileWidth, tileHeight);
                this._frameSet = new Vector2(image.sourceRect.Width / tileWidth, image.sourceRect.Height / tileHeight);
            }
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
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}

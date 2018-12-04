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
    public class Animator :Component, IRenderable
    {
        private List<List<Texture2D>> _frames;
        private Image _spriteSheet;
        private Vector2 _frameSize;
        private Vector2 _frameSet;
        private Vector2 _currentFrameIndex;        

        public List<List<Texture2D>> Frames { get => _frames; private set => _frames = value; }
        public Image Spritesheet { get => _spriteSheet; }
        public Vector2 FrameSize { get => _frameSize; }
        public Vector2 FrameSet { get => _frameSet; }
        public Vector2 CurrentFrameIndex { get => _currentFrameIndex; }

        

        public Animator(GameObject gameObject, int tileWidth, int tileHeight, Vector2 initialFrameIndex):base()
        {
            this.Name = "Animator";
            this.gameObject = gameObject;

            _frames = new List<List<Texture2D>>();
            _spriteSheet = gameObject.HasCompnent("Image")? (Image)gameObject.Components["Image"]: new Image(gameObject);
            _frameSize = new Vector2(tileWidth, tileHeight);
            _frameSet = Vector2.Zero;
            _currentFrameIndex = initialFrameIndex;
            _currentFrameIndex = new Vector2(0, 0);
            GameObjectManager.Instance.AddComponent(gameObject, this);
        }

        public void AdvanceFrame()
        {
            //_currentFrameIndex.X = _currentFrameIndex.X < FrameSet.X ? _currentFrameIndex.X + 1 : 0;
            if (_currentFrameIndex.X < _frameSet.X)
                _currentFrameIndex.X++;
            else
            {
                _currentFrameIndex.X = 0;
                SetFrameSequence(_currentFrameIndex.Y + 1);
            }
        }

        public void SetFrameSequence(float row)
        {
            _currentFrameIndex.Y = row > _frameSet.Y ? 0 : row;
        }

        public override void LoadContent()
        {//establishes the frameset and sourceRect for render once the image has been loaded
            _frameSet = new Vector2(gameObject.Image.Texture.Width / FrameSize.X-1, gameObject.Image.Texture.Height / FrameSize.Y-1);
            gameObject.SourceRect = new Rectangle((int)(_currentFrameIndex.X * FrameSize.X), (int)(_currentFrameIndex.Y * FrameSize.Y), (int)FrameSize.X, (int)FrameSize.Y);

            var renderer = new Renderer();
            for (_currentFrameIndex.X = 0; _currentFrameIndex.X <= _frameSet.X; _currentFrameIndex.X++)
            {
                _frames.Add(new List<Texture2D>());
                for (_currentFrameIndex.Y = 0; _currentFrameIndex.Y <= _frameSet.Y; _currentFrameIndex.Y++)
                {
                    var image = renderer.Draw(new Rectangle((int)(_currentFrameIndex.X * _frameSize.X), (int)(_currentFrameIndex.Y * _frameSize.Y),(int)_frameSize.X,(int)_frameSize.Y), gameObject.Image);
                    _frames[(int)_currentFrameIndex.X].Add(image);
                }
            }
            _currentFrameIndex.X = 0;
            _currentFrameIndex.Y = 0;

        }

        public override void Update(GameTime gameTime)
        {
            AdvanceFrame();
            //gameObject.SourceRect = new Rectangle((int)(_currentFrameIndex.X * FrameSize.X), (int)(_currentFrameIndex.Y * FrameSize.Y), (int)FrameSize.X, (int)FrameSize.Y);
            gameObject.Position = new Vector2(_currentFrameIndex.X * _frameSize.X * gameObject.Scale + 406, _currentFrameIndex.Y * _frameSize.Y * gameObject.Scale + 224); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw( 
                _frames[(int)_currentFrameIndex.X][(int)_currentFrameIndex.Y],
                gameObject.Position,
                gameObject.SourceRect,
                gameObject.Image.Tint * gameObject.Image.Alpha,
                gameObject.Rotation,
                gameObject.Image.Origin,
                gameObject.Scale,
                SpriteEffects.None,
                0.0f);
        }
    }
}

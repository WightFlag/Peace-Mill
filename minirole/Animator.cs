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
    public class Animator : Component, IRenderable
    {
        private List<List<Texture2D>> _frames;
        private Image _spriteSheet;
        private Vector2 _frameSize;
        private Vector2 _frameSet;
        private Vector2 _currentFrameIndex;
        private Renderer _renderer;
        private Vector2 _localOffset;

        public List<List<Texture2D>> Frames { get => _frames; private set => _frames = value; }
        public Image Spritesheet { get => _spriteSheet; }
        public Vector2 FrameSize { get => _frameSize; }
        public Vector2 FrameSet { get => _frameSet; }
        public Vector2 CurrentFrameIndex { get => _currentFrameIndex; }
        public Vector2 LocalOffset { get => _localOffset; }

        public Animator (GameObject gameObject)
        {
            this.Name = "Animator";
            this.gameObject = gameObject;
        }

        public void Initialize(int tileWidth, int tileHeight, Vector2 initialFrameIndex)
        {
            _frames = new List<List<Texture2D>>();

            _spriteSheet = gameObject.HasComponent<Image>() ? gameObject.GetComponent<Image>() : gameObject.AddCompnent<Image>();
            _spriteSheet.LoadContent();

            _frameSize = new Vector2(tileWidth, tileHeight);
            _frameSet = Vector2.Zero;
            _currentFrameIndex = initialFrameIndex;
            _currentFrameIndex = new Vector2(0, 0);
        }

        public void AdvanceFrame()
        {
            _currentFrameIndex.X = _currentFrameIndex.X < FrameSet.X ? _currentFrameIndex.X + 1 : 0;
        }

        public void SetFrameSequence(float row)
        {
            _currentFrameIndex.Y = row > _frameSet.Y ? 0 : row;
        }

        public override void LoadContent()
        {//establishes the frameset and sourceRect for render once the image has been loaded

            var texture = gameObject.GetComponent<Image>().Texture;
            _frameSet = new Vector2(_spriteSheet.Texture.Width / _frameSize.X - 1, Spritesheet.Texture.Height / _frameSize.Y - 1);
            gameObject.SourceRect = new Rectangle((int)(_currentFrameIndex.X * FrameSize.X), (int)(_currentFrameIndex.Y * FrameSize.Y), (int)FrameSize.X, (int)FrameSize.Y);

            _renderer = new Renderer(gameObject);
            for (_currentFrameIndex.X = 0; _currentFrameIndex.X <= _frameSet.X; _currentFrameIndex.X++)
            {
                _frames.Add(new List<Texture2D>());
                for (_currentFrameIndex.Y = 0; _currentFrameIndex.Y <= _frameSet.Y; _currentFrameIndex.Y++)
                {
                    var image = _renderer.DrawFrame(new Rectangle((int)(_currentFrameIndex.X * _frameSize.X), (int)(_currentFrameIndex.Y * _frameSize.Y),(int)_frameSize.X,(int)_frameSize.Y), _spriteSheet);
                    _frames[(int)_currentFrameIndex.X].Add(image);
                }
            }
            _currentFrameIndex.X = 0;
            _currentFrameIndex.Y = 0;
        }

        public override void Update(GameTime gameTime)
        {
           AdvanceFrame();
           _localOffset = new Vector2(_currentFrameIndex.X * _frameSize.X * gameObject.Scale, _currentFrameIndex.Y * _frameSize.Y * gameObject.Scale); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _renderer.Draw(spriteBatch, _frames[(int)_currentFrameIndex.X][(int)_currentFrameIndex.Y], _localOffset);
        }
    }
}

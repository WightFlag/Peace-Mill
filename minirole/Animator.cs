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
    public class Animator : Component, IRenderable
    {
        private List<List<Texture2D>> _frames;
        private Image _spriteSheet;
        private Vector2 _frameSize;
        private Vector2 _frameSet;
        private Vector2 _currentFrameIndex;
        private Vector2 _defaultFrameIndex;
        private Renderer _renderer;
        private Vector2 _frameOrigin;
        private int _frameUpdateInterval;
        private int _elapsedTime;
        private List<Animation> _animations;

        [XmlIgnore]
        public List<List<Texture2D>> Frames { get => _frames; private set => _frames = value; }

        public Image Spritesheet { get => _spriteSheet; set => _spriteSheet = value; }
        public Vector2 FrameSize { get => _frameSize; set => _frameSize = value; }
        public Vector2 FrameSet { get => _frameSet; set => _frameSet = value; }
        public Vector2 CurrentFrameIndex { get => _currentFrameIndex; set => _currentFrameIndex = value; }
        public Vector2 DefaultFrameIndex { get => _defaultFrameIndex; set => _defaultFrameIndex = value; }
        public Renderer Renderer { get => _renderer; set => _renderer = value; }
        public Vector2 FrameOrigin { get => _frameOrigin; }
        public List<Animation> Animations { get => _animations; set => _animations = value; }

        public Animator (GameObject gameObject)
        {

            this.gameObject = gameObject;
            this.Name = nameof(this.gameObject) + "Animator";
            Frames = new List<List<Texture2D>>();
            _frameUpdateInterval = 100;
            _elapsedTime = 0;
            _defaultFrameIndex = new Vector2(1, 0);

        }
        public Animator()
        {
            this.Name = "Animator";
            Frames = new List<List<Texture2D>>();
            _frameUpdateInterval = 100;
            _elapsedTime = 0;
            _defaultFrameIndex = new Vector2(1, 0);
        }

        public void AdvanceFrame()
        {
            if(_elapsedTime > _frameUpdateInterval)
            {
                _currentFrameIndex.X = _currentFrameIndex.X < FrameSet.X ? _currentFrameIndex.X + 1 : 0;
                _elapsedTime -= _frameUpdateInterval;
            }
        }

        public void SetFrameSequence(float row)
        {
            _currentFrameIndex.Y = row > _frameSet.Y ? 0 : row;
        }

        public override void LoadContent()
        {//establishes the frameset and sourceRect for render once the image has been loaded

            IsActive = true;
            var tempIndex = Vector2.Zero;
            _spriteSheet = gameObject.GetComponent<Image>();
            _spriteSheet.LoadContent();

            gameObject.SourceRect = new Rectangle((int)(tempIndex.X * FrameSize.X), (int)(tempIndex.Y * FrameSize.Y), (int)FrameSize.X, (int)FrameSize.Y);

            _renderer = new Renderer(gameObject);

            _frameOrigin = new Vector2(FrameSize.X / 2, FrameSize.Y / 2);
        }

        public override void Update(GameTime gameTime)
        {
            _elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (gameObject.Velocity == Vector2.Zero)
                _currentFrameIndex.X = _defaultFrameIndex.X;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _renderer.Draw(spriteBatch, _spriteSheet.Texture, _frameOrigin, _animations[(int)_currentFrameIndex.Y].Frames[(int)_currentFrameIndex.X]);
        }
    }
}

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
        //private T animationType;
        private List<List<Texture2D>> _frames;
        private Image _spriteSheet;
        private Vector2 _frameSize;
        private Vector2 _frameSet;
        private Vector2 _currentFrameIndex;
        private Renderer _renderer;
        //private Vector2 _localOffset;
        private Vector2 _frameOrigin;
        [XmlIgnore]
        public List<List<Texture2D>> Frames { get => _frames; private set => _frames = value; }

        public Image Spritesheet { get => _spriteSheet; set => _spriteSheet = value; }
        public Vector2 FrameSize { get => _frameSize; set => _frameSize = value; }
        public Vector2 FrameSet { get => _frameSet; set => _frameSet = value; }
        public Vector2 CurrentFrameIndex { get => _currentFrameIndex; set => _currentFrameIndex = value; }
        public Renderer Renderer { get => _renderer; set => _renderer = value; }
        //public Vector2 LocalOffset { get => _localOffset; }
        public Vector2 FrameOrigin { get => _frameOrigin; }

        public Animator (GameObject gameObject)
        {

            this.gameObject = gameObject;
            this.Name = nameof(this.gameObject) + "Animator";

            //var type = typeof(T);
            //var constructor = type.GetConstructors();
            //animationType = (T)constructor[0].Invoke(new object[] { gameObject});
        }
        public Animator()
        {
            this.Name = "Animator";
            Frames = new List<List<Texture2D>>();
 
        }

        public void Initialize()
        {
            _frames = new List<List<Texture2D>>();
            _spriteSheet = gameObject.HasComponent<Image>() ? gameObject.GetComponent<Image>() : gameObject.AddCompnent<Image>();
            _spriteSheet.LoadContent();

            _frameSize = new Vector2(_spriteSheet.Texture.Width,_spriteSheet.Texture.Height);
            _frameSet = Vector2.Zero;
            _currentFrameIndex = Vector2.Zero;
            _frameOrigin = new Vector2(_spriteSheet.Texture.Width/2, _spriteSheet.Texture.Height/2);
        }

        public void Initialize(int tileWidth, int tileHeight, Vector2 initialFrameIndex)
        {
            _frames = new List<List<Texture2D>>();

            _spriteSheet = gameObject.HasComponent<Image>() ? gameObject.GetComponent<Image>() : gameObject.AddCompnent<Image>();
            _spriteSheet.LoadContent();

            _frameSize = new Vector2(tileWidth, tileHeight);
            _frameSet = Vector2.Zero;
            _currentFrameIndex = initialFrameIndex;
            _frameOrigin = new Vector2(tileWidth / 2, tileHeight / 2);
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

            var tempIndex = Vector2.Zero;

            _spriteSheet.gameObject = this.gameObject;
            _spriteSheet.LoadContent();

            gameObject.SourceRect = new Rectangle((int)(tempIndex.X * FrameSize.X), (int)(tempIndex.Y * FrameSize.Y), (int)FrameSize.X, (int)FrameSize.Y);

            _renderer = new Renderer(gameObject);
            for (tempIndex.X = 0; tempIndex.X <= _frameSet.X; tempIndex.X++)
            {
                _frames.Add(new List<Texture2D>());
                for (tempIndex.Y = 0; tempIndex.Y <= _frameSet.Y; tempIndex.Y++)
                {
                    var image = _renderer.DrawFrame(new Rectangle((int)(tempIndex.X * _frameSize.X), (int)(tempIndex.Y * _frameSize.Y),(int)_frameSize.X,(int)_frameSize.Y), _spriteSheet);
                    
                    _frames[(int)tempIndex.X].Add(image);
                }
            }
            _frameOrigin = new Vector2(FrameSize.X/2, FrameSize.Y/2);
        }

        public override void Update(GameTime gameTime)
        {
           //AdvanceFrame();
           //_localOffset = new Vector2((_currentFrameIndex.X * _frameSize.X - (_frameSize.X * (_frameSet.X + 1)/2)) * gameObject.Scale , (_currentFrameIndex.Y * _frameSize.Y - (_frameSize.Y * (_frameSet.Y+1)/2)) * gameObject.Scale); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_spriteSheet.Texture, gameObject.Position + _frameOrigin, gameObject.SourceRect, Color.White * _spriteSheet.Alpha, 0.0f, _frameOrigin, new Vector2(gameObject.Scale, gameObject.Scale), SpriteEffects.None, 0.0f);
            _renderer.Draw(spriteBatch, _frames[(int)_currentFrameIndex.X][(int)_currentFrameIndex.Y], _frameOrigin);
        }
    }
}

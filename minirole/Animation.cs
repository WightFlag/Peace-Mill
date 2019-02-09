using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Peace_Mill
{
    public class Animation : Component
    {
        private int _frameUpdateInterval;
        private List<Vector2> _frameCoordinates;
        private List<Rectangle> _frames;
        private SpriteSheet _spriteSheet; //this implementation will only support animation of frames from a single spritesheets. additional work will be required to implement support for animation from multiple files.

        public int FrameUpdateInterval { get => _frameUpdateInterval; set => _frameUpdateInterval = value; }
        public List<Vector2> FrameCoordinates { get => _frameCoordinates; set => _frameCoordinates = value; }
        public List<Rectangle> Frames { get => _frames; set => _frames = value; }
       
        public Animation()
        {
            _frameUpdateInterval = 100;
        }

        public Animation(Component parent) : base(parent)
        {
            _parent = parent;
        }

        public Animation (Animator animator, Vector2 frames)
        {
            animator.AddChild(this);
            AddChild(animator.Spritesheet);
            //_frames = frames;
        }

        public Animation(List<Vector2> frameCoordinateList, int frameUpdateInterval, Image image, Vector2 frameSize)
        {
            _frames = new List<Rectangle>();
            _spriteSheet = new SpriteSheet(image, frameSize);
            _frameUpdateInterval = frameUpdateInterval;
            _frameCoordinates = frameCoordinateList;
            for(var i = 0; i < _frameCoordinates.Count; i++)
            {
                _frames.Add(new Rectangle((int)frameSize.X * (int)_frameCoordinates[i].X, (int)frameSize.Y * (int)_frameCoordinates[i].Y, (int)frameSize.X, (int)frameSize.Y));
            }

            //var animationLoader = new ContentLoader<Animation>();
            //animationLoader.Save($@"Load/animation-Row{frameCoordinateList[0].Y}-Frames{_frameCoordinates.Count}.xml", this);
        }
    }
}
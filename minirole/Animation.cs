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
        //private Texture2D[] _frames;
        //public Texture2D[] Frames { get => _frames; set => _frames = value; }
        private Vector2 _frames;
        public Vector2 Frames { get => _frames; set => _frames = value; }

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
            _frames = frames;
        }

        public Animation(Vector2 frames, int frameUpdateInterval)
        {
            _frameUpdateInterval = frameUpdateInterval;
            _frames = frames;
        }
    }
}
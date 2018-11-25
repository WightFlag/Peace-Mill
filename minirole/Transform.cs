using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace minirole
{
    public class Transform : Component
    {
        private Vector2 _position;
        private Vector2 _velocity;

        public Vector2 Position { get { return _position; } set { _position = value; } }
        public Vector2 Velocity { get { return _velocity; } set { _velocity = value; } }

        public Transform()
        {
            this._position = Vector2.Zero;
            this._velocity = Vector2.Zero;            
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }

        public void Scale()
        {
            throw new NotImplementedException();
        }

        public void Translate()
        {
            throw new NotImplementedException();
        }
    }
}

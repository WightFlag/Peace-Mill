using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public class Transform : Component
    {
        private float _rotation;
        private float _scale;
        private Vector2 _velocity;

        public float GetRotation { get { return _rotation; } private set { _rotation = value; } }
        public float GetScale {  get { return _scale; } private set { _scale = value; } }
        public Vector2 Velocity { get { return _velocity; } set { _velocity = value; } }

        public Transform()
        {
            this.Name = "Transform";
            this._rotation = 0.0f;
            this._scale = 1f;
            this._velocity = Vector2.Zero;            
        }

        public Transform(GameObject gameObject)
        {
            this.Name = "Transform";
            this.gameObject = gameObject;
            this._rotation = 0.0f;
            this._scale = 1f;
            this._velocity = Vector2.Zero;
        }

        public void Rotate(float rotation)
        {
            _rotation += rotation * 3.14159f/180;
        }

        public void Scale(float scale)
        {
            this._scale = scale;
        }

        public void Translate(Vector2 distance)
        {
            this.gameObject.Position.Set(this.gameObject.Position.Get() + distance);
        }
    }
}

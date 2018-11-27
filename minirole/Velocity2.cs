using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Peace_Mill
{
    public class Velocity2 : Component, IVelocity<Vector2, Vector2>
    {
        private Vector2 _velocity;

        public Vector2 Velocity { get => _velocity; private set => _velocity = value; }
        public float X { get => _velocity.X; set => _velocity.X = value; }
        public float Y { get => _velocity.Y; set => _velocity.Y = value; }
        
        public Velocity2(GameObject gameObject):base()
        {
            this.Name = "Velocity";
            this.gameObject = gameObject;
            _velocity = Vector2.Zero;
        }

        public Vector2 Get()
        {
            return _velocity;
        }

        public void Set(Vector2 velocityIn)
        {
            _velocity = velocityIn;
        }
    }
}

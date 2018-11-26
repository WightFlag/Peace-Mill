using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Peace_Mill
{
    class Position2 : Component, IPosition<Vector2,Vector2>
    {
        private Vector2 _value;
        
        public Vector2 Position { get => _value; set => _value = value; }

        public Position2(GameObject gameObject)
        {
            this.gameObject = gameObject;
            _value = Vector2.Zero;
        }

        public float X { get => _value.X; set => _value.X = value; }
        public float Y { get => _value.Y; set => _value.Y = value; }

        public Vector2 Get()
        {
            return _value;
        }

        public void Set(Vector2 value)
        {
            _value = value;
        }
    }
}

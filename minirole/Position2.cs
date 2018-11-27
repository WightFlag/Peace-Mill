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
        private Vector2 _position;
        
        public Vector2 Position { get => _position; private set => _position = value; }

        public float X { get => _position.X; set => _position.X = value; }
        public float Y { get => _position.Y; set => _position.Y = value; }

        public Position2(GameObject gameObject):base()
        {
            this.Name = "Position";
            this.gameObject = gameObject;
            _position = Vector2.Zero;
        }


        public Vector2 Get()
        {
            return _position;
        }

        public void Set(Vector2 positionIn)
        {
            _position = positionIn;
        }
    }
}

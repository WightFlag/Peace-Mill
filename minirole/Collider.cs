using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Peace_Mill
{
    class Collider : Component
    {
        private Rectangle _collisionBox;

        public Rectangle CollisionBox { get => _collisionBox; set => _collisionBox = value; }

        //public Collider()
        //{
        //    _collisionBox = new Rectangle(0, 0, 0, 0);
        //}

        public Collider (GameObject gameObject)
        {
            this.gameObject = gameObject;
            _collisionBox = new Rectangle(0, 0, 0, 0);
        }        
    }
}

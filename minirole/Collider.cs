using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Peace_Mill
{
    public class Collider : Component
    {
        private Rectangle _collisionBox;

        public Rectangle CollisionBox { get => _collisionBox; set => _collisionBox = value; }

        //public Collider()
        //{
        //    _collisionBox = new Rectangle(0, 0, 0, 0);
        //}

        public Collider (GameObject gameObject):base()
        {
            this.Name = "Collider";
            this.gameObject = gameObject;
            //_collisionBox = gameObject.Dimensions;
            //_collisionBox = gameObject.SourceRect;
        }

        public Collider()
        {
            this.Name = "Collider";
            //_collisionBox = gameObject.SourceRect;
        }

        public override void LoadContent()
        {
            //_collisionBox = gameObject.SourceRect;
            CollisionManager.Instance.AddCollider(this);
        }
        
        public override void Update(GameTime gameTime)
        {
            //_collisionBox = gameObject.SourceRect;
            Console.WriteLine(CollisionBox.Height + " " + CollisionBox.Width); //this line is just for debugging and ensuring that the collision box is appropriately sized and not changing.
        }
    }
}

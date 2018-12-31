using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    public class RotateCommand : Command
    {
        private float _rotation;

        public RotateCommand (float rotation)
        {
            _rotation = rotation;
        }

        public RotateCommand()
        {
        }

        public override void Execute(GameObject gameObject)
        {

        }

        public override void Continue(GameObject gameObject)
        {
            if(gameObject.Velocity == Vector2.Zero)
                gameObject.Rotation += _rotation * 3.14159f / 180;
        }

        public override void Terminate(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}

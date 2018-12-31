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
    public class AdvanceFrame_Command : Command
    {
        private Vector2 _acceleration;


        public AdvanceFrame_Command(Vector2 acceleration)
        {
            _acceleration = acceleration;
        }
        public override void Execute(GameObject gameObject)
        {

        }

        public override void Continue(GameObject gameObject)
        {

        }

        public override void Terminate(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}

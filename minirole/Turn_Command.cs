using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Peace_Mill
{
    public class Turn_Command : Command
    {
        private float _spin;

        public Turn_Command(string name, float spin)
        {
            Name = name;
            _spin = spin;
        }

        public Turn_Command()
        {
        }

        public override void Execute(GameObject gameObject)
        {
           
        }

        public override void Continue(GameObject gameObject)
        {
            if (gameObject.Velocity.X == 0)
                gameObject.Continue(new RotateCommand(_spin));
        }

        public override void Terminate(GameObject gameObject)
        {
        }
    }
}

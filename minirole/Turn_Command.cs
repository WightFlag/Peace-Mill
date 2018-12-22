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

        public override void Execute(GameObject gameObject)
        {
            if(gameObject.Velocity.X == 0)
                gameObject.Execute(new RotateCommand(_spin));
        }

        public override void Terminate(GameObject gameObject)
        {
            gameObject.Velocity = Vector2.Zero;
        }
    }
}

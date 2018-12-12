using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            gameObject.Execute(new RotateCommand(_spin));
        }

        public override void Terminate(GameObject gameObject)
        {
        }
    }
}

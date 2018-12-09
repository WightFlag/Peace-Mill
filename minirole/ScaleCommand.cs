using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace_Mill
{
    class ScaleCommand :ICommand
    {
        private float _scale;

        public ScaleCommand(float scale)
        {
            _scale = scale;
        }

        public override void Execute(GameObject gameObject)
        {
            gameObject.Scale += _scale;
        }
    }
}

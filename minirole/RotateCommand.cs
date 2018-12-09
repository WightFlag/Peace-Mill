using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace_Mill
{
    class RotateCommand : ICommand
    {
        private float _rotation;

        public RotateCommand (float rotation)
        {
            _rotation = rotation;
        }

        public override void Execute(GameObject gameObject)
        {
           gameObject.Rotation += _rotation * 3.14159f / 180;
        }
    }
}

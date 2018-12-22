using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Peace_Mill
{
    class TranslateCommand : Command
    {
        private Vector2 _movement;

        public TranslateCommand(Vector2 movement) { _movement = movement; }

        public override void Execute(GameObject gameObject)
        {
            gameObject.Position += _movement;
            Console.WriteLine($"Game Object Position.X: {gameObject.Position.X}");
        }

        public override void Terminate(GameObject gameObject)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class Move_Command : ICommand
    {
        private Vector2 _acceleration;


        public Move_Command(string name, Vector2 acceleration)
        {
            Name = name;
            _acceleration = acceleration;
        }

        public override void Execute(GameObject gameObject)
        {
            gameObject.Execute(new TranslateCommand(_acceleration));
            gameObject.Velocity = _acceleration;
        }
    }
}

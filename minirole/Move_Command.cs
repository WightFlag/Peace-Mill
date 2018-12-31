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
    public class Move_Command : Command
    {
        private TranslateCommand _translateCommand;
        private Vector2 _direction;

        public Vector2 Acceleration { get => _direction; set => _direction = value; }

        public Move_Command(string name, Vector2 direction)
        {
            Name = name;
            _direction = direction;
            _translateCommand = new TranslateCommand(_direction);
        }

        public Move_Command()
        {
        }

        public override void Execute(GameObject gameObject)
        {
            if(gameObject.Velocity == Vector2.Zero)
            {
                gameObject.Velocity = _direction;
                if (_translateCommand == null)
                    _translateCommand = new TranslateCommand(_direction);
                _translateCommand.Movement = _direction;
                gameObject.Execute(new Set_Frame_Sequence_Command(_direction));
               // gameObject.Execute(_translateCommand);
            }
        }

        public override void Continue(GameObject gameObject)
        {
            if(gameObject.Velocity == _direction || gameObject.Velocity == Vector2.Zero)
            {
                gameObject.Velocity = _direction;
                _translateCommand.Movement = _direction;
                gameObject.Continue(_translateCommand);
                gameObject.GetComponent<Animator>().AdvanceFrame();
            }
        }

        public override void Terminate(GameObject gameObject)
        {
            gameObject.Velocity = Vector2.Zero;
        }
    }
}

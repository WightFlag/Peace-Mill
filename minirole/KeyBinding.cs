using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public class KeyBinding
    {
        private ICommand _command;
        private Keys[] _key;

        public ICommand Command { get => _command; set => _command = value; }
        public Keys[] Key { get => _key; set => _key = value; }

        public KeyBinding()
        {
        }  

        public KeyBinding(ICommand command, params Keys[] key)
        {
            _key = key;
            _command = command;
        }
    }
}

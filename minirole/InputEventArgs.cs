using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public class InputEventArgs : EventArgs
    {
        private List<Keys> _keys;

        public List<Keys> Keys { get => _keys; set => _keys = value; }

    }
}

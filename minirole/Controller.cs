using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace_Mill
{
    public abstract class Controller
    {
        private List<string> _actions;
        public List<string> Actions { get => _actions; set => _actions = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace_Mill
{
    public abstract class ICommand
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        public abstract void Execute(GameObject gameObject);
    }
}

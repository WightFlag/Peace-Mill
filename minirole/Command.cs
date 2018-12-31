using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Peace_Mill
{
    [XmlInclude(typeof(Move_Command))]
    [XmlInclude(typeof(RotateCommand))]
    [XmlInclude(typeof(ScaleCommand))]
    [XmlInclude(typeof(TranslateCommand))]
    public abstract class Command
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }

        public abstract void Execute(GameObject gameObject);
        public abstract void Continue(GameObject gameObject);
        public abstract void Terminate(GameObject gameObject);

        public Command()
        {

        }
    }
}

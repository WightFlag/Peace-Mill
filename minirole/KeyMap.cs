using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    class KeyMap 
    {
        private List<KeyBinding> _bindings;
        //[XmlElement("Binding")]
        public List<KeyBinding> Bindings { get => _bindings; set => _bindings = value; }

        private static KeyMap _instance;

        public static KeyMap Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KeyMap()
                    {

                        Bindings = new List<KeyBinding>()
                        {
                            new KeyBinding(new Move_Command("Move_Down_Command", new Vector2(0,1)),Keys.Down),
                            new KeyBinding(new Move_Command("Move_Up_Command", new Vector2(0,-1)), Keys.Up),
                            new KeyBinding(new Move_Command("Move_Right_Command", new Vector2(1,0)), Keys.Right),
                            new KeyBinding(new Move_Command("Move_Left_Command", new Vector2(-1,0)), Keys.Left)
                        }
                    };
                    var bindingLoader = new ContentLoader<List<KeyBinding>>();
                    //Instance.Bindings = bindingLoader.Load("KeyMap.xml");
                    //bindingLoader.Save("KeyMap.xml", Instance.Bindings);
                };
                return _instance;
            }
        }

        public KeyBinding GetKeyBinding (string name)
        {
            for(var i  = 0; i < Bindings.Count(); i++)
            {
                if (_bindings[i].Command.Name == name)
                    return _bindings[i];
            }
            return null;
        }
    }
}

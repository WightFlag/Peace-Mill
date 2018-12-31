using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    class KeyMap 
    {
        private List<KeyBinding> _bindings;
        private List<KeyBinding> _bindingDefaults;

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
                        _bindingDefaults = new List<KeyBinding>()
                        {//Below are defaults in the event that KeyMap.xml does not exist or is corrupted
                            new KeyBinding(new Move_Command("Move_Down_Command", new Vector2(0, 1)), Keys.Down),
                            new KeyBinding(new Move_Command("Move_Up_Command", new Vector2(0, -1)), Keys.Up),
                            new KeyBinding(new Move_Command("Move_Right_Command", new Vector2(1, 0)), Keys.Right),
                            new KeyBinding(new Move_Command("Move_Left_Command", new Vector2(-1, 0)), Keys.Left)
                        }
                    };
                    _instance.Bindings = _instance._bindingDefaults;

                    var bindingLoader = new ContentLoader<List<KeyBinding>>();
                    if (File.Exists("KeyMap.xml"))
                        Instance.Bindings = bindingLoader.Load("KeyMap.xml");
                    else
                        bindingLoader.Save("KeyMap.xml", Instance.Bindings);
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

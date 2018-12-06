using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Peace_Mill
{
    class ComponentManager
    {
        public GraphicsDevice graphicsDevice;
        public ContentManager Content;
        public List<Component> AvailableComponents { get; private set; } // available component types
        public Dictionary<int, Component> GameComoponents;

        private static ComponentManager _instance;

        public static ComponentManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ComponentManager();
                    _instance.AvailableComponents = new List<Component>();
                    _instance.GameComoponents = new Dictionary<int, Component>();
                }
                return _instance;
            }
        }

        public int AddGameComponent(Component component)
        {
            int id = this.GameComoponents.Count;
            this.GameComoponents.Add(id, component);
            return id;
        }

        public Type GetComponentType(string component)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().First(t => t.Name == component);

            return type;
        }

        public object Instantiate(Type type)
        {
            return Activator.CreateInstance(type);
        }


    }
}

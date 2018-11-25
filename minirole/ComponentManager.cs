using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace minirole
{
    class ComponentManager
    {
        public GraphicsDevice graphicsDevice;
        public ContentManager Content;
        public List<Component> Components { get; private set; }
        public Dictionary<int, Component> GameComoponents;

        private static ComponentManager _instance;

        public static ComponentManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ComponentManager();
                    _instance.Components = new List<Component>();
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

        //public Type GetComponentType (Component component)
        //{
        //    var assembly = Assembly.GetExecutingAssembly();
        //    var type = assembly.GetTypes().First(t => t.Name == component.Name);

        //    return type;
        //}

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

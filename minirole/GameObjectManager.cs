using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    class GameObjectManager
    {
        public Dictionary<GameObject, List<Component>> GameObjects { get; private set; }

        private static GameObjectManager _instance;

        public static GameObjectManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObjectManager();
                    _instance.GameObjects = new Dictionary<GameObject, List<Component>>();                    
                }
                return _instance;
            }
        }
        
        public void AddComponent(GameObject gameObject, Component component)
        {
            component.gameObject = gameObject;
            gameObject.Components.Add(component.Name,component);
            //var T = ComponentManager.Instance.GetComponentType(component);
            //gameObject.Components[component.Name] = (Component)ComponentManager.Instance.Instantiate(T);
        }

        public void AddComponent(GameObject gameObject, string componentName)
        {
            var T = ComponentManager.Instance.GetComponentType(componentName);
            Component component = (Component)ComponentManager.Instance.Instantiate(T);
            component.gameObject = gameObject;
            gameObject.Components.Add(component.Name, component);

            //gameObject.Components[component.Name] = (Component)ComponentManager.Instance.Instantiate(T);
        }

        public void RemoveComponent(GameObject gameObject, Component component)
        {

        }
    }
}

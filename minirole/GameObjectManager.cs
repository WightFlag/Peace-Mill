using System.Collections.Generic;

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
        }

        public void AddComponent(GameObject gameObject, string componentName)
        {
            var T = ComponentManager.Instance.GetComponentType(componentName);
            Component component = (Component)ComponentManager.Instance.Instantiate(T);
            component.gameObject = gameObject;
            gameObject.Components.Add(component.Name, component);
        }

        public void RemoveComponent(GameObject gameObject, Component component)
        {

        }
    }
}

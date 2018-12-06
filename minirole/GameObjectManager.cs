using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Peace_Mill
{
    class GameObjectManager
    {
        private Dictionary<GameObject, List<Component>> _gameObjects;

        public Dictionary<GameObject, List<Component>> GameObjects { get => _gameObjects; private set => _gameObjects = value; }

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

        //public void AddComponent(GameObject gameObject, Component component)
        //{
        //    component.gameObject = gameObject;
        //    gameObject.Components.Add(component.Name, component);
        //}

        //public void AddComponent(GameObject gameObject, string componentName)
        //{
        //    var T = ComponentManager.Instance.GetComponentType(componentName);
        //    Component component = (Component)ComponentManager.Instance.Instantiate(T);
        //    component.gameObject = gameObject;
        //    gameObject.Components.Add(component.Name, component);
        //}

        public void RemoveComponent(GameObject gameObject, Component component)
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach (GameObject g in _gameObjects.Keys)
            {
                if (g.IsActive)
                    g.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void ToggleActiveObjects()
        {

        }
    }
}

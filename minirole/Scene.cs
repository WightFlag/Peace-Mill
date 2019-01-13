using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    public class Scene
    {
        private int _id;
        private string _name;
        private List<string> _paths;
        private List<GameObject> _gameObjects;
        private int _iterator;
        private Camera _camera;

        public string Name { get => _name; set => _name = value; }
        //[XmlIgnore]
        public List<string> Paths { get => _paths; set => _paths = value; }
        [XmlIgnore]
        public List<GameObject> GameObjects { get => _gameObjects; set => _gameObjects = value; }

        public Scene()
        {
            _paths = new List<string>();
            _gameObjects = new List<GameObject>();
        }

        public void Add(GameObject gameObject)
        {
        }

        public void Initialize()
        {
            var gameObjectLoader = new ContentLoader<GameObject>();
            for(_iterator = 0; _iterator < _paths.Count; _iterator++)
            {
                var gameObject = gameObjectLoader.Load(_paths[_iterator]);
                gameObject.Initialize();
                _gameObjects.Add(gameObject);
                //gameObjectLoader.Save(@"Load\gameObjectTemplateRevised" + _iterator.ToString() +".xml", gameObject);
            }
        }

        public void LoadContent()
        {
            for(_iterator = 0; _iterator < _gameObjects.Count; _iterator++)
            {
                _gameObjects[_iterator].LoadContent();
                _gameObjects[_iterator].IsActive = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            for (_iterator = 0; _iterator < _gameObjects.Count; _iterator++)
            {
                if (_gameObjects[_iterator].IsActive)
                    _gameObjects[_iterator].Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(_iterator = 0; _iterator < _gameObjects.Count; _iterator++)
            {
                _gameObjects[_iterator].Draw(spriteBatch);
            }

        }
    }
}

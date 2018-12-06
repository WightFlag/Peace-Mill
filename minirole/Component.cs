using System.Xml.Serialization;

using Microsoft.Xna.Framework;

namespace Peace_Mill
{
    public abstract class Component
    {
        private string _name;
        private int _id;
        [XmlIgnore]
        private GameObject _gameObject;
        private bool _isActive;

        public string Name { get => _name; set => _name = value; }
        [XmlIgnore]
        public int ID { get => _id; private set => _id = value; }
        [XmlIgnore]
        public GameObject gameObject { get => _gameObject; set => _gameObject = value; }


        public Component ()
        {
        }

        public virtual void LoadContent()
        {            
        }

        public virtual void UnloadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}

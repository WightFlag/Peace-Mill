using System;
using System.Reflection;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public abstract class Component
    {
        private string _name;
        private int _id;
        [XmlIgnore]
        public GameObject gameObject;
        private bool _isActive;

        public string Name { get => _name; set => _name = value; }
        [XmlIgnore]
        public int ID { get => _id; private set => _id = value; }

        public Component ()
        {
            _isActive = true;
            _name = "Name";
            _id = ComponentManager.Instance.AddGameComponent(this);
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

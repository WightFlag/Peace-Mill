using System;
using System.Reflection;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace minirole
{
    public abstract class Component
    {
        private string _name;
        private int _id;
        public GameObject gameObject;
        private bool _isActive;

        public string Name { get => _name; set => _name = value; }
        public int ID { get => _id; private set => _id = value; }

        public Component ()
        {
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

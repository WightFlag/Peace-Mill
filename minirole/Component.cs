using System.Xml.Serialization;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using System;

namespace Peace_Mill
{
    [XmlInclude(typeof(Animator))]
    //[XmlInclude(typeof(Collider))]
    [XmlInclude(typeof(Image))]
    [XmlInclude(typeof(InputController<ScreenInputController>))]
    public abstract class Component
    {
        private string _name;
        private int _id;
        [XmlIgnore]
        private GameObject _gameObject;
        protected Component _parent;
        protected Component[] _children;
        protected int _countOfChildren;
        private bool _isActive;

        public string Name { get => _name; set => _name = value; }
        [XmlIgnore]
        public int ID { get => _id; private set => _id = value; }
        [XmlIgnore]
        public GameObject gameObject { get => _gameObject; set => _gameObject = value; }
        public bool IsActive;
        public Component[] Children { get => _children; set => _children = value; }

        public Component ()
        {
            _countOfChildren = 0;
            _isActive = true;

            _children = new Component[1];
        }

        public void AddChild(Component component)
        {
            _countOfChildren += 1;
            if (_countOfChildren > _children.Length / 2)
                Array.Resize(ref _children, _countOfChildren * 2);
            component._parent = this;
            component._gameObject = this._gameObject;
            _children[_countOfChildren-1] = component;

        }

        public virtual void LoadContent()
        {
            for(var i = 0; _children[i] != null; i++)
            {
                _children[i].LoadContent();
            }
        }

        public virtual void UnloadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            for (var i = 0; _children[i] != null; i++)
            {
                _children[i].Update(gameTime);
            }
        }
    }
}

using System.Xml.Serialization;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using System;

namespace Peace_Mill
{
    [XmlInclude(typeof(Animator))]
    //[XmlInclude(typeof(Collider))]
    [XmlInclude(typeof(Animation))]
    [XmlInclude(typeof(Image))]
    [XmlInclude(typeof(InputController<ScreenInputController>))]
    [XmlInclude(typeof(Collider))]
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
        //public Component Parent { get => _parent; set => _parent = value; }
        public Component[] Children { get => _children; set => _children = value; }

        public Component ()
        {
            _countOfChildren = 0;
            _isActive = true;
            _children = new Component[1];
        }

        public Component(Component parent)
        {
            _countOfChildren = 0;
            _isActive = true;
            _children = new Component[1];
            parent.AddChild(this);
        }

        public void AddChild(Component component)
        {
            _countOfChildren += 1;
            if (_countOfChildren > _children.Length / 2)
                Array.Resize(ref _children, _countOfChildren * 2);
            if (component._parent != null)
                component._parent.RemoveChild(component);
            component._parent = this;
            component._gameObject = this._gameObject;
            _children[_countOfChildren-1] = component;

        }

        public void RemoveChild(Component component)
        {
            for(var i = 0; i < _children.Length; i++)
            {
                if(_children[i] == component)
                {
                    for(var j = i + 1; j < _children.Length; j++)
                    {
                        if(j+1 == _children.Length)
                        {
                            Array.Resize(ref _children, _children.Length - 1);
                            return;
                        }
                        _children[j] = _children[j + 1];
                    }
                }
            }
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

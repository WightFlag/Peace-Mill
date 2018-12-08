using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    public class GameObject
    {
        [XmlElement("Component")]
        public List<Component> Renderables;

        private Rectangle _dimensions;
        private Vector2 _position;
        private float _rotation;
        private float _scale;
        private Vector2 _velocity;
        private Transform _transform;

        private bool _isActive;
        private Rectangle _sourceRect;
        private Dictionary<Type,object> _components;

        public Rectangle Dimensions { get => _dimensions; set => _dimensions = value; }
        public Vector2 Position { get => _position; set => _position = value; }
        public float Rotation { get => _rotation; set => _rotation = value; }
        public float Scale { get => _scale; set => _scale = value; }
        public Vector2 Velocity { get => _velocity; set => _velocity = value; }
        public Transform Transform { get => _transform; set => _transform = value; }

        public bool IsActive { get => _isActive; set => _isActive = value; }
        public Rectangle SourceRect { get => _sourceRect; set => _sourceRect = value; }
        public Dictionary<Type, object> Components { get => _components; set => _components = value; }

               
        #region Constructors

        public GameObject()
        {
            InitializePreDefinedComponents();
        }

        private void InitializePreDefinedComponents()
        {
            _components = new Dictionary<Type, object>();
            Components = new Dictionary<Type, object>();
            Renderables = new List<Component>();

            Dimensions = Rectangle.Empty;
            Position = Vector2.Zero;
            Rotation = 0.0f;
            Scale = 1.0f;
            Velocity = Vector2.Zero;
            IsActive = false;
   
            Transform = new Transform(this);          
        }

        #endregion Constructors

        public void Execute(ICommand command)
        {
            command.Execute(this);
        }

        public bool HasComponent<T>()
        {
            return _components.Keys.Contains(typeof(T)) ? true : false;
        }

        public T GetComponent<T>() where T: Component 
        {
            Type type = typeof(T);
            return _components.ContainsKey(type) ? (T)Convert.ChangeType(_components[type], type) : default(T);
        }

        public T AddCompnent<T>() where T: Component
        {
            Type type = typeof(T);
            T component = (T)ComponentManager.Instance.Instantiate(type, this);
            component.gameObject = this;
            _components.Add(type, component);
            return (T)component;
        }

        public void LoadContent()
        {
            foreach (Component c in Components.Values)
            {
                c.LoadContent();
                if (c is IRenderable)
                    Renderables.Add(c);
            }
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            foreach (Component c in Components.Values)
                c.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IRenderable ir in Renderables)
            {
                ir.Draw(spriteBatch);
            }
        }
    }
}

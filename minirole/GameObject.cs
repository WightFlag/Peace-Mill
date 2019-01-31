using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    public class GameObject : Component
    {
        [XmlElement("Component")]
        public List<Component> Renderables;

        //private Rectangle _dimensions;
        //private Vector2 _position;
        private float _rotation;
        private float _scale;
        private Vector2 _velocity;
        private Transform _transform;

        //private Layer _layer;
        private bool _isActive;
        private Rectangle _sourceRect;

        

        public Rectangle Dimensions;
        //public Rectangle Dimensions { get => _dimensions; set => _dimensions = value; }
        public Vector2 Position;
        //public Vector2 Position { get => _position; set => _position = value; }
        public float Rotation { get => _rotation; set => _rotation = value; }
        public float Scale { get => _scale; set => _scale = value; }
        public Vector2 Velocity { get => _velocity; set => _velocity = value; }
        public Transform Transform { get => _transform; set => _transform = value; }

        //public Layer Layer { get => _layer; set => _layer = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public Rectangle SourceRect { get => _sourceRect; set => _sourceRect = value; }

               
        #region Constructors

        public GameObject()
        {            
            Renderables = new List<Component>();

            Dimensions = Rectangle.Empty;
            Position = Vector2.Zero;
            Rotation = 0.0f;
            Scale = 1.0f;
            Velocity = Vector2.Zero;
            IsActive = false;

            Transform = new Transform(this);

            //InitializePreDefinedComponents();
        }

        private void InitializePreDefinedComponents()
        {
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

        public void Execute(Command command)
        {
            command.Execute(this);
        }

        public void Continue(Command command)
        {
            command.Continue(this);
        }

        public void Termiante(Command command)
        {
            command.Terminate(this);
        }



        public T GetComponent<T>() where T: Component 
        {
            Type type = typeof(T);
            for(var i = 0; _children[i] != null; i++)
            {
                if (_children[i].GetType() == type)
                    return (T)Convert.ChangeType(_children[i], type);
            }
            return default(T);
        }

        //public T AddCompnent<T>() where T : Component
        //{
        //    Type type = typeof(T);
        //    T component = (T)ComponentManager.Instance.Instantiate(type, this);
        //    component.gameObject = this;
        //    AddChild(component);

        //    return (T)component;
        //}

        //Moved this function to component manager becaues functionality should be reserved to editor and not needed at runtime within game. Refactoring required based on revised _children Component/GameObject structure.
        //public bool HasComponent<T>()
        //{
        //    return _components.Keys.Contains(typeof(T)) ? true : false;
        //}

        public void Initialize()
        {
            for (var i = 0; _children[i] != null; i++)
            {
                _children[i].gameObject = this;
            }
        }

        public void LoadContent()
        {
            for(var i = 0; _children[i] != null; i++)
            {
                _children[i].LoadContent();
                if (_children[i] is IRenderable)
                    Renderables.Add(_children[i]);
            }
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            for (var i = 0; _children[i] != null; i++)
                _children[i].Update(gameTime);
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

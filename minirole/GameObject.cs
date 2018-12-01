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
        public Dictionary<string, Component> Components;
        public List<Component> Renderables;
        public Transform Transform;

        //Consider adding default values and method for preserving them. 
        //Also consider changing from ordinary "get" assignment "=" to a plus-get assignment "+=" in the transform commands.

        private Rectangle _dimensions;
        private Vector2 _position;
        private float _rotation;
        private float _scale;
        private Vector2 _velocity;
        private bool _isActive;
        private Image _image;
        private Rectangle _sourceRect;

        public Rectangle Destination = new Rectangle();

        public Rectangle Dimensions { get => _dimensions; set => _dimensions = value; }
        public Vector2 Position { get => _position; set => _position = value; }
        public float Rotation { get => _rotation; set => _rotation = value; }
        public float Scale { get => _scale; set => _scale = value; }
        public Vector2 Velocity { get => _velocity; set => _velocity = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public Image Image { get => _image; set => _image = value; }
        public Rectangle SourceRect { get => _sourceRect; set => _sourceRect = value; }
               
        #region Constructors

        public GameObject()
        {
            InitializePreDefinedComponents();
        }

        public GameObject(params Component[] components)
        {
            InitializePreDefinedComponents();

            foreach (Component component in components)
            {
                GameObjectManager.Instance.AddComponent(this, component);
            }
        }

        public GameObject (params string[] components)
        {
            InitializePreDefinedComponents();

            foreach (string component in components)
            {
                GameObjectManager.Instance.AddComponent(this, component);
            }
        }

        private void InitializePreDefinedComponents()
        {
            Components = new Dictionary<string, Component>();
            Renderables = new List<Component>();

            Dimensions = Rectangle.Empty;
            Position = Vector2.Zero;
            Rotation = 0.0f;
            Scale = 1.0f;
            Velocity = Vector2.Zero;
            IsActive = false;
   
            Transform = new Transform(this);
            //GameObjectManager.Instance.AddComponent(this, Transform);
        }

        #endregion Constructors

        public void Execute(ICommand command)
        {
            command.Execute(this);
        }

        public bool HasCompnent(string componentName)
        {
            if (Components.Keys.Contains(componentName))
                return true;
            return false;
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

        //consider revising/modifying this to exclude images assocaited with animators
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IRenderable ir in Renderables)
            {
                ir.Draw(spriteBatch);
            }
        }
    }
}

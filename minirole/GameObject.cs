using System.Collections.Generic;
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
        //public Properties Properties;
        //public IPosition<Vector2,Vector2> Position;
        //public IVelocity<Vector2, Vector2> Velocity;
        //public ISize<Rectangle, Rectangle> Size;
        private Vector2 _position;
        private Vector2 _velocity;
        private Rectangle _size;

        public Vector2 Position { get => _position; set => _position = value; }
        public Vector2 Velocity { get => _velocity; set => _velocity = value; }
        public Rectangle Size { get => _size; set => _size = value; }

        
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

            Position = Vector2.Zero;
            Velocity = Vector2.Zero;
            Size = Rectangle.Empty;
            //Position = new Position2(this);
            //Velocity = new Velocity2(this);
            Transform = new Transform(this);
            //GameObjectManager.Instance.AddComponent(this, (Component)Position);
            //GameObjectManager.Instance.AddComponent(this, (Component)Velocity);
            GameObjectManager.Instance.AddComponent(this, Transform);
        }

        #endregion Constructors

        public void Execute(ICommand command)
        {
            command.Execute(this);
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

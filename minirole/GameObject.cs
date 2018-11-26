using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Peace_Mill
{
    public class GameObject
    {
        [XmlElement("Component")]
        public Dictionary<string, Component> Components;
        public List<Component> Renderables;
        public Transform Transform;
        public IPosition<Vector2,Vector2> Position;


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

            Transform = new Transform(this);
            Position = new Position2(this);
            GameObjectManager.Instance.AddComponent(this, (Component)Position);
            GameObjectManager.Instance.AddComponent(this, Transform);
        }

        #endregion Constructors

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

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IRenderable ir in Renderables)
            {
                ir.Draw(spriteBatch);
            }
        }
    }
}

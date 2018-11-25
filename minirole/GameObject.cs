﻿using System; using System.Collections.Generic; using System.Text; using System.IO; using System.Linq; using System.Xml.Serialization;  using Microsoft.Xna.Framework; using Microsoft.Xna.Framework.Graphics; using Microsoft.Xna.Framework.Content;  namespace minirole {     public class GameObject     {         [XmlElement("Component")]         public Dictionary<string, Component> Components;         public List<Component> Renderables;         public Transform Transform;           #region Constructors          public GameObject()         {             Components = new Dictionary<string, Component>();             Renderables = new List<Component>();             Transform = new Transform();         }          public GameObject(params Component[] components)         {             Components = new Dictionary<string, Component>();             Renderables = new List<Component>();             Transform = new Transform();              foreach (Component component in components)             {                 GameObjectManager.Instance.AddComponent(this, component);             }         }          public GameObject (params string[] components)
        {
            Components = new Dictionary<string, Component>();
            Renderables = new List<Component>();
            Transform = new Transform();

            foreach(string component in components)
            {
                GameObjectManager.Instance.AddComponent(this, component);
            }
        }          #endregion Constructors          public void LoadContent()         {             foreach (Component c in Components.Values)             {                 c.LoadContent();                 if (c is IRenderable)                     Renderables.Add(c);             }         }          public void UnloadContent()         {         }          public void Update(GameTime gameTime)         {         }          public void Draw(SpriteBatch spriteBatch)         {             foreach(IRenderable ir in Renderables)             {                 ir.Draw(spriteBatch);             }         }     } } 
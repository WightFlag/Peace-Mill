﻿using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    class CollisionManager
    {
        private List<Collider> _colliders;
        private List<Collider> _activeColliders;

        public List<Collider> Colliders { get => _colliders; }
        public List<Collider> ActiveColliders { get => _activeColliders; }

        private static CollisionManager _instance;

        public static CollisionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CollisionManager();
                    _instance._colliders = new List<Collider>();
                    _instance._activeColliders = new List<Collider>();
                }

                return _instance;
            }
        }

        public void AddCollider(Collider collider)
        {
            _colliders.Add(collider);
            //will need to change this line below so that active collider list is managed dynamically rather than just making everything active all the time like the line below currently does
            _activeColliders.Add(collider);
        }

        public void Update(GameTime gameTime)
        {
            for(var i = 0; i < _activeColliders.Count; i++)
            {
                if(_activeColliders[i].gameObject.Velocity != null)
                {
                    for(var j = 0; j < _activeColliders.Count; j++)
                    {
                        if (i != j && IsColliding(_activeColliders[i], _activeColliders[j]))
                        {
                            if (_activeColliders[j].gameObject.Velocity != null)
                                PositionCorrect(_activeColliders[i], _activeColliders[j], false);
                            else
                                PositionCorrect(_activeColliders[i], _activeColliders[j], true);
                        }      
                    }
                }
            }
        }

        public bool IsColliding(Collider collider1, Collider collider2)
        {
            return Rectangle.Intersect(collider1.CollisionBox, collider2.CollisionBox) != null ? true : false;
        }

        public void PositionCorrect(Collider collider1, Collider collider2, bool bothMoving)
        {
            if (bothMoving)
            {
                //this code is duplicate of single moving object solution. evaluate behavior at runtime and modify as necessary, or reduce method to single solution (remove bool
                //as well as else clause in update method above.
                var collider1pos = collider1.gameObject.Position;
                var collider2pos = collider2.gameObject.Position;
                var offset = new Vector2((collider1.CollisionBox.Width + collider2.CollisionBox.Width) / 2, (collider1.CollisionBox.Height + collider2.CollisionBox.Height) / 2);

                if (collider1pos.X > 0)
                    collider1.gameObject.Position = (new Vector2(collider2pos.X + offset.X, collider1pos.Y));
                if (collider1pos.X < 0)
                    collider1.gameObject.Position = (new Vector2(collider2pos.X - offset.X, collider1pos.Y));
                if (collider1pos.Y > 0)
                    collider1.gameObject.Position = (new Vector2(collider1pos.X, collider2pos.Y + offset.Y));
                if (collider1pos.Y < 0)
                    collider1.gameObject.Position = (new Vector2(collider1pos.X, collider2pos.Y - offset.Y));
            }
            else
            {
                var collider1pos = collider1.gameObject.Position;
                var collider2pos = collider2.gameObject.Position;
                var offset = new Vector2((collider1.CollisionBox.Width + collider2.CollisionBox.Width)/2, (collider1.CollisionBox.Height + collider2.CollisionBox.Height)/2);

                if (collider1pos.X > 0)
                    collider1.gameObject.Position = (new Vector2(collider2pos.X + offset.X, collider1pos.Y));
                if (collider1pos.X < 0)
                    collider1.gameObject.Position = (new Vector2(collider2pos.X - offset.X, collider1pos.Y));
                if (collider1pos.Y > 0)
                    collider1.gameObject.Position = (new Vector2(collider1pos.X, collider2pos.Y + offset.Y));
                if (collider1pos.Y < 0)
                    collider1.gameObject.Position = (new Vector2(collider1pos.X, collider2pos.Y - offset.Y));
            }
        }
    }
}

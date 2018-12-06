using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public class Transform : Component
    {
        public Transform() 
        {
            this.Name = "Transform";        
        }

        public Transform(GameObject gameObject)
        {
            this.Name = "Transform";
            this.gameObject = gameObject;
        }

        public void Rotate(float rotation)
        {
            gameObject.Execute(new RotateCommand(rotation));
        }

        public void Scale(float scale)
        {
            gameObject.Execute(new ScaleCommand(scale));
        }

        public void Translate(Vector2 distance)
        {
            gameObject.Execute(new TranslateCommand(distance));  
        }
    }
}

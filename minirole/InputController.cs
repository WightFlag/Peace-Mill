using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace_Mill
{
    public abstract class InputController :Component
    {   
        public InputController(GameObject gameObject)
        {
            this.Name = "InputController";
            this.gameObject = gameObject;

            //InputHandler.Instance().KeyPressedEvent += OnKeyPressed;
            //InputHandler.Instance().KeyDownEvent += OnKeyDown;
            //InputHandler.Instance().KeyReleasedEvent += OnKeyReleased;
            //InputHandler.Instance().KeyStateChange += OnKeyPressed;
            InputHandler.Instance().KeyStateChanged += OnKeyStateChanged;
        }

        public virtual void OnKeyStateChanged(object sender, EventArgs eventArgs)
        {
        }

        //public virtual void OnKeyPressed(object sender, InputEventArgs inputEventArgs)
        //{
        //}


        //public virtual void OnKeyPressed(object sender, EventArgs eventArgs)
        //{

        //}

        //public virtual void OnKeyDown(object sender, EventArgs eventArgs)
        //{
        //}

        //public virtual void OnKeyReleased(object sender, EventArgs eventArgs)
        //{
        //}
    }
}

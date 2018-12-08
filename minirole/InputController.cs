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
        }

        public virtual void OnKeyPressed(object sender, EventArgs eventArgs)
        {
        }

        public virtual void OnKeyDown(object sender, EventArgs eventArgs)
        {
        }

        public virtual void OnKeyReleased(object sender, EventArgs eventArgs)
        {
        }
    }
}

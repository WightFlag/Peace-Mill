using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Peace_Mill
{
    public class ScreenInputController :InputController
    {
        public ScreenInputController(GameObject gameObject) : base(gameObject)
        {
            InputHandler.Instance().KeyPressedEvent += OnKeyPressed;
            InputHandler.Instance().KeyDownEvent += OnKeyDown;
            InputHandler.Instance().KeyReleasedEvent += OnKeyReleased;
        }

        public override void OnKeyPressed(object sender, EventArgs eventArgs)
        {
            gameObject.Transform.Translate(new Vector2(1, 1));
        }
        public override void OnKeyDown(object sender, EventArgs eventArgs)
        {
            base.OnKeyDown(sender, eventArgs);
        }

        public override void OnKeyReleased(object sender, EventArgs eventArgs)
        {
            base.OnKeyReleased(sender, eventArgs);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public class ScreenInputController :InputController
    {
        private List<string> _actions;
        public List<string> Actions { get => _actions; set => _actions = value; }

        public ScreenInputController(GameObject gameObject) : base(gameObject)
        {
            Actions = new List<string>()
            {
                "Move_Down_Command",
                "Move_Up_Command",
                "Move_Right_Command",
                "Move_Left_Command"
            };
        }

        public override void OnKeyStateChanged(object sender, EventArgs eventArgs)
        {
            for(var i = 0; i < Actions.Count(); i++)
            {
                if (InputHandler.Instance().WasPressed(Actions[i]))
                    gameObject.Execute(KeyMap.Instance.GetKeyBinding(Actions[i]).Command);
            }

        }


        //public override void OnKeyPressed(object sender, InputEventArgs inputEventArgs)
        //{
        //    if (inputEventArgs.Keys.Contains(Keys.Down))
        //        gameObject.Transform.Translate(new Vector2(0, 1));
        //    if (inputEventArgs.Keys.Contains(Keys.Right))
        //        gameObject.Transform.Translate(new Vector2(1, 0));
        //}

        //public override void OnKeyPressed(object sender, EventArgs eventArgs)
        //{
        //    base.OnKeyPressed(sender, eventArgs);
        //}


        //public override void OnKeyDown(object sender, EventArgs eventArgs)
        //{
        //    base.OnKeyDown(sender, eventArgs);
        //}

        //public override void OnKeyReleased(object sender, EventArgs eventArgs)
        //{
        //    base.OnKeyReleased(sender, eventArgs);
        //}
    }
}

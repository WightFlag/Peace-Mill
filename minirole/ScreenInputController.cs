using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public class ScreenInputController :Controller
    {
        public ScreenInputController(GameObject gameObject) 
        {
            Actions = new List<string>()
            {
                "Move_Down_Command",
                "Move_Up_Command",
                "Move_Right_Command",
                "Move_Left_Command",
                "Turn_Right_Command",
                "Turn_Left_Command"
            };
        }
    }
}

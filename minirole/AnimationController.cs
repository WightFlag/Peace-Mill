using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public class AnimationController : Controller
    {
        public AnimationController()
        {
            Actions = new List<string>()
            {
                "Set_Frame_Squence"
            };
        }
    }
}

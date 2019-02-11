using System.Collections.Generic;
using System.Xml.Serialization;

namespace Peace_Mill
{
    [XmlInclude(typeof(Controller))]
    public class ScreenInputController :Controller
    {
        public ScreenInputController(GameObject gameObject) 
        {
            //Actions = new List<string>()
            //{
            //    "Move_Down_Command",
            //    "Move_Up_Command",
            //    "Move_Right_Command",
            //    "Move_Left_Command",
            //    "Turn_Right_Command",
            //    "Turn_Left_Command"
            //};
        }

        public ScreenInputController()
        {
            //Actions = new List<string>()
            //{
            //    "Move_Down_Command",
            //    "Move_Up_Command",
            //    "Move_Right_Command",
            //    "Move_Left_Command",
            //    "Turn_Right_Command",
            //    "Turn_Left_Command"
            //};
        }
    }
}

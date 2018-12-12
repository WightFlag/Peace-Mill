using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace_Mill
{
    public class InputController <T> :Component where T:Controller
    {
        public T ObjectType;
        
        public InputController(GameObject gameObject)
        {
            var type = typeof(T);
            var constructors = type.GetConstructors();
            ObjectType = (T)constructors[0].Invoke(new object[] {gameObject });

            this.Name = "InputController";
            this.gameObject = gameObject;

            InputHandler.Instance().KeyStateChanged += OnKeyStateChanged;
            InputHandler.Instance().KeysDownUpdate += OnKeysDownUpdate;
        }

        //When KeyboardState changes, this method is called via the KeyStateChanged event. This event does three things:
        //1. checks if any of the keys associated with the command names in the list of the InputController type (T at instantiation) have been pressed and calls execute from associated commands.
        //2. checks if any of the keys are have been held down since last update and calls execute from commands.
        //3. checks if any of those keys have been released and calls terminate from associated commands.
        public void OnKeyStateChanged(object sender, EventArgs eventArgs)
        {
            for (var i = 0; i < ObjectType.Actions.Count(); i++)
            {
                if (InputHandler.Instance().WasPressed(ObjectType.Actions[i]))
                    gameObject.Execute(KeyMap.Instance.GetKeyBinding(ObjectType.Actions[i]).Command);
            }
            for (var i = 0; i < ObjectType.Actions.Count(); i++)
            {
                if (InputHandler.Instance().IsDown(ObjectType.Actions[i]))
                    gameObject.Execute(KeyMap.Instance.GetKeyBinding(ObjectType.Actions[i]).Command);
            }
            for (var i = 0; i < ObjectType.Actions.Count(); i++)
            {
                if (InputHandler.Instance().IsReleased(ObjectType.Actions[i]))
                    gameObject.Termiante(KeyMap.Instance.GetKeyBinding(ObjectType.Actions[i]).Command);
            }
        }

        //This method is only called when any keys are down and KeyboardState has not changed. These two methods reduce unnecessary update calls when nothing has changed.
        public void OnKeysDownUpdate(object sender, EventArgs args)
        {

            for (var i = 0; i < ObjectType.Actions.Count(); i++)
            {
                if (InputHandler.Instance().IsDown(ObjectType.Actions[i]))
                    gameObject.Execute(KeyMap.Instance.GetKeyBinding(ObjectType.Actions[i]).Command);
            }
        }

    }
}

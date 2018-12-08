using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Peace_Mill
{
    public class InputHandler
    {

        private KeyboardState _previousKeyState;
        private KeyboardState _currentKeyState;

        //public EventHandler OnKeyPressedHandler;
        //public EventHandler OnKeyDownHandler;
        //public EventHandler OnKeyReleasedHandler;

        public delegate void KeyPressedEventHandler(object sender, EventArgs args);
        public delegate void KeyDownEventHandler(object sender, EventArgs args);
        public delegate void KeyReleasedEventHandler(object sender, EventArgs args);

        public event KeyPressedEventHandler KeyPressedEvent;
        public event KeyDownEventHandler KeyDownEvent;
        public event KeyReleasedEventHandler KeyReleasedEvent;

        private static InputHandler _instance;
               
        public static InputHandler Instance()
        {
            if(_instance == null)
            {
                _instance = new InputHandler();
            }

            return _instance;
        }

        public void Update (GameTime gameTime)
        {
            _previousKeyState = _currentKeyState;
            _currentKeyState = Keyboard.GetState();
            KeysPressed(Keys.Space);
        }

        public bool KeyPressed(Keys key)
        {            
            return _currentKeyState.IsKeyDown(key) && _previousKeyState.IsKeyUp(key) ? true : false;
        }

        public bool KeyDown(Keys key)
        {
            return _currentKeyState.IsKeyDown(key) && _previousKeyState.IsKeyDown(key) ? true : false;
        }

        public bool KeyReleased(Keys key)
        {
            return _currentKeyState.IsKeyUp(key) && _previousKeyState.IsKeyDown(key) ? true : false;
        }

        public bool KeysPressed(params Keys[] keys)
        {
            for(var i = 0; i < keys.Length; i++)
            {
                if (!(_currentKeyState.IsKeyDown(keys[i]) && _previousKeyState.IsKeyUp(keys[i])))
                    return false;
            }
            OnKeyPressed();
            return true;
        }

        public bool KeysDown(params Keys[] keys)
        {
            for(var i = 0; i < keys.Length; i++)
            {
                if (!(_currentKeyState.IsKeyDown(keys[i]) && _previousKeyState.IsKeyDown(keys[i])))
                    return false;
            }
            return true;

        }

        public bool KeysReleased(params Keys[] keys)
        {
            for(var i = 0; i < keys.Length; i++) //possibly consider inverting the logic here so that releasing one key will break an action instead of requiring release of all
            {
                if (!(_currentKeyState.IsKeyUp(keys[i]) && _previousKeyState.IsKeyDown(keys[i])))
                    return false;
            }
            return true;
        }

        protected virtual void OnKeyPressed()
        {
            if(KeyPressedEvent != null)
                KeyPressedEvent(this, EventArgs.Empty);
        }

        protected virtual void OnKeyDown()
        {
            KeyDownEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnKeyReleased()
        {
            KeyReleasedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}

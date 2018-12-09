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

        public delegate void KeyPressedEventHandler(object sender, InputEventArgs args);
        public delegate void KeyDownEventHandler(object sender, EventArgs args);
        public delegate void KeyReleasedEventHandler(object sender, EventArgs args);

        public event KeyPressedEventHandler KeyPressedEvent;
        public event KeyDownEventHandler KeyDownEvent;
        public event KeyReleasedEventHandler KeyReleasedEvent;

        public delegate void KeyStateChangeHanlder(object sender, InputEventArgs args);
        public delegate void KeyStateChangedHandler (object sender, EventArgs args);

        public event KeyStateChangeHanlder KeyStateChange;
        public event KeyStateChangedHandler KeyStateChanged;

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
            if (IsKeyStateChanged())
                OnKeyStateChanged();
        }

        private bool KeyPressed(Keys key)
        {            
            return _currentKeyState.IsKeyDown(key) && _previousKeyState.IsKeyUp(key) ? true : false;
        }

        private bool KeyDown(Keys key)
        {
            return _currentKeyState.IsKeyDown(key) && _previousKeyState.IsKeyDown(key) ? true : false;
        }

        private bool KeyReleased(Keys key)
        {
            return _currentKeyState.IsKeyUp(key) && _previousKeyState.IsKeyDown(key) ? true : false;
        }

        //public bool KeysPressed(params Keys[] keys)
        //{
        //    var keysPressed = new List<Keys>();
        //    for(var i = 0; i < keys.Length; i++)
        //    {
        //        if ((_currentKeyState.IsKeyDown(keys[i]) && _previousKeyState.IsKeyUp(keys[i])))
        //            keysPressed.Add(keys[i]);
        //        else
        //            return false;
        //    }
        //    OnKeyPressed(keysPressed);
        //    return true;
        //}

        public bool IsKeyStateChanged()
        {
            if (_currentKeyState != _previousKeyState)
                return true;
            return false;
        }

        //public void OnKeyStateChange()
        //{
        //    var keysPressed = _currentKeyState.GetPressedKeys().ToList<Keys>();
        //    KeyStateChange(this, new InputEventArgs() { Keys = keysPressed });
        //}

        public void OnKeyStateChanged()
        {
            KeyStateChanged(this, EventArgs.Empty);
        }

        //public bool KeysPressed(params Keys[] keys)
        //{
        //    for (var i = 0; i < keys.Length; i++)
        //    {
        //        if (!(_currentKeyState.IsKeyDown(keys[i]) && _previousKeyState.IsKeyUp(keys[i])))
        //            return false;
        //    }
        //    return true;
        //}


        //public bool KeysDown(params Keys[] keys)
        //{
        //    for(var i = 0; i < keys.Length; i++)
        //    {
        //        if (!(_currentKeyState.IsKeyDown(keys[i]) && _previousKeyState.IsKeyDown(keys[i])))
        //            return false;
        //    }
        //    return true;

        //}

        //public bool KeysReleased(params Keys[] keys)
        //{
        //    for(var i = 0; i < keys.Length; i++) //possibly consider inverting the logic here so that releasing one key will break an action instead of requiring release of all
        //    {
        //        if (!(_currentKeyState.IsKeyUp(keys[i]) && _previousKeyState.IsKeyDown(keys[i])))
        //            return false;
        //    }
        //    return true;
        //}



        //protected virtual void OnKeyPressed(List<Keys> keysPressed)
        //{
        //    KeyPressedEvent?.Invoke(this, new InputEventArgs() { Keys = keysPressed });
        //}

        //protected virtual void OnKeyDown()
        //{
        //    KeyDownEvent?.Invoke(this, EventArgs.Empty);
        //}

        //protected virtual void OnKeyReleased()
        //{
        //    KeyReleasedEvent?.Invoke(this, EventArgs.Empty);
        //}

        //public bool WasPressed(Type type)
        //{
        //    var bindings = KeyMap.Instance.Bindings;
        //    for(var i = 0; i < bindings.Count; i++)
        //    {
        //        if(bindings[i].Command.GetType() == type)
        //        {
        //            for (var j = 0; j < bindings[i].Key.Count(); j++)
        //            {
        //                if (!KeyPressed(bindings[i].Key[j]))
        //                    return false;
        //            }
        //            return true;
        //        }               
        //    }
        //    return false;
        //}

        public bool WasPressed(string type)
        {
            var bindings = KeyMap.Instance.Bindings;
            for (var i = 0; i < bindings.Count; i++)
            {
                if (bindings[i].Command.Name == type)
                {
                    for (var j = 0; j < bindings[i].Key.Count(); j++)
                    {
                        if (!KeyPressed(bindings[i].Key[j]))
                            return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}

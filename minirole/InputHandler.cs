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
        private List<Keys> _keysDown;

        public delegate void KeyStateChangedHandler (object sender, EventArgs args);
        public delegate void KeysDownUpdateHandler (object sender, EventArgs args);

        public event KeyStateChangedHandler KeyStateChanged;
        public event KeysDownUpdateHandler KeysDownUpdate;

        private static InputHandler _instance;
               
        public static InputHandler Instance()
        {
            if(_instance == null)
            {
                _instance = new InputHandler();
                _instance._keysDown = new List<Keys>();
            }

            return _instance;
        }

        public void Update (GameTime gameTime)
        {
            _previousKeyState = _currentKeyState;
            _currentKeyState = Keyboard.GetState();
            if (IsKeyStateChanged())
                OnKeyStateChanged();
            if (_keysDown.Count != 0)
                OnKeysDownUpdate();
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

        public bool IsKeyStateChanged()
        {
            if (_currentKeyState != _previousKeyState)
                return true;
            return false;
        }

        public void OnKeyStateChanged()
        {
            KeyStateChanged(this, EventArgs.Empty);
        }

        public void OnKeysDownUpdate()
        {
            KeysDownUpdate(this, EventArgs.Empty);
        }

        public bool WasPressed(string type)
        {
            var bindings = KeyMap.Instance.Bindings;
            for (var i = 0; i < bindings.Count; i++)
            {
                if (bindings[i].Command.Name == type)
                {
                    for (var j = 0; j < bindings[i].Key.Count(); j++)
                    {
                        if (!KeyPressed(bindings[i].Key[j]) && !KeyDown(bindings[i].Key[j]))
                            return false;
                        _keysDown.Add(bindings[i].Key[j]);
                    }
                    return true;
                }
            }
            return false;
        }


        public bool IsReleased(string type)
        {
            var bindings = KeyMap.Instance.Bindings;
            for (var i = 0; i < bindings.Count; i++)
            {
                if (bindings[i].Command.Name == type)
                {
                    for (var j = 0; j < bindings[i].Key.Count(); j++)
                    {
                        if (KeyReleased(bindings[i].Key[j]))
                            return true;
                        //_keysDown.Remove(bindings[i].Key[j]);
                    }
                    return false;
                }
            }
            return false;
        }

        public bool IsDown(string type)
        {
            var bindings = KeyMap.Instance.Bindings;
            for (var i = 0; i < bindings.Count; i++)
            {
                if (bindings[i].Command.Name == type)
                {
                    for (var j = 0; j < bindings[i].Key.Count(); j++)
                    {
                        if (!KeyDown(bindings[i].Key[j]))
                            return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}

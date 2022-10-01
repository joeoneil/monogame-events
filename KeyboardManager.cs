using System;
using System.Collections;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MonoGameCross_PlatformDesktopApplication1;

public class KeyboardManager
{
    private readonly KeyboardState[] _prevState;
    private readonly int _debounce;
    private int _ptr;
    private readonly ArrayList _handles;

    private struct ButtonEvent
    {
        public Keys key;
        public PressType pressType;
        public Action callback;

        public ButtonEvent(Keys key, Action callback, PressType pressType)
        {
            this.key = key;
            this.callback = callback;
            this.pressType = pressType;
        }
    }

    private enum PressType
    {
        Pressed,
        Held,
        Released,
    }

    public KeyboardManager(int debounce = 6)
    {
        this._debounce = debounce;
        this._prevState = new KeyboardState[debounce];
        this._handles = new ArrayList();
    }
    
    public void Update(KeyboardState newState)
    {
        ++_ptr;
        _ptr %= _debounce;
        _prevState[_ptr] = newState;
        
        foreach(ButtonEvent handle in _handles)
        {
            switch (handle.pressType)
            {
                case PressType.Pressed:
                    if (IsPressed(handle.key))
                    {
                        handle.callback();
                    }
                    break;
                case PressType.Held:
                    if (IsHeld(handle.key))
                    {
                        handle.callback();
                    }
                    break;
                case PressType.Released:
                    if (IsReleased(handle.key))
                    {
                        handle.callback();
                    }
                    break;
            }
        }
    }

    private int FramesPressed(Keys key)
    {
        var acc = 0;
        for (var i = 0; i < _debounce; i++)
        {
            if (_prevState[i].IsKeyDown(key))
            {
                acc++;
            }
        }

        return acc;
    }

    private KeyboardState GetState(int prev)
    {
        // Console.Write(_ptr);
        // Console.Write(", ");
        // Console.Write(prev);
        // Console.Write(", ");
        // Console.Write((_ptr - prev + _debounce) % _debounce);
        // Console.WriteLine();
        return _prevState[(_ptr - prev + _debounce) % _debounce];
    }

    private KeyboardState GetState()
    {
        return GetState(0);
    }

    private bool IsPressed(Keys key)
    {
        return GetState().IsKeyDown(key) && FramesPressed(key) == 1;
    }

    private bool IsHeld(Keys key, int threshold = 2)
    {
        if (GetState().IsKeyUp(key)) return false;
        for (var i = 1; i < _debounce; i++)
        {
            if (i >= threshold) { return true; }
            if (GetState(i).IsKeyUp(key)) { return false; }
        }
        return false;
    }

    private bool IsReleased(Keys key)
    {
        return GetState().IsKeyUp(key) && GetState(1).IsKeyDown(key);
    }

    public void OnPressed(Keys key, Action callback)
    {
        AddCallback(key, callback, PressType.Pressed);
    }

    public void OnHeld(Keys key, Action callback)
    {
        AddCallback(key, callback, PressType.Held);
    }

    public void OnReleased(Keys key, Action callback)
    {
        AddCallback(key, callback, PressType.Released);
    }

    private void AddCallback(Keys key, Action callback, PressType pressType)
    {
        _handles.Insert(0, new ButtonEvent(key, callback, pressType));
    }

    public String StateString(Keys key)
    {
        var s = new StringBuilder();
        for (var i = 0; i < _debounce; i++)
        {
            s.Append(GetState(i).IsKeyDown(key) ? "|" : "_");
        }
        return s.ToString();
    }
}
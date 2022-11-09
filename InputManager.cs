using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEvents; 

public class InputManager {
    private readonly CompoundState[] _compoundStates;
    private readonly int debounce;
    private int ptr;
    private readonly List<InputEvent> _events;

    private struct InputEvent {
        public readonly CompoundButton button;
        public readonly PressType type;
        public readonly Action callback;
        
        public InputEvent(CompoundButton button, PressType type, Action callback) {
            this.button = button;
            this.type = type;
            this.callback = callback;
        }
    }

    private enum PressType {
        Pressed,
        Released,
        Held,
    }
    
    public InputManager(int debounce = 5) {
        this.debounce = debounce;
        _compoundStates = new CompoundState[debounce];
        _events = new List<InputEvent>();
    }
    
    private void update(CompoundState state) {
        ptr = (ptr + 1) % debounce;
        _compoundStates[ptr] = state;
        
        foreach (InputEvent e in _events) {
            switch (e.type) {
                // compiler wouldn't let me name them all _ :(
                // non-rust moment
                // 
                // it also yells at be for unused variables when clearly
                // they are short circuit evaluations with side effects
                // that FOR SOME REASON I have to assign to a variable.
                case PressType.Pressed:
                    bool _a = isPressed(e.button) && run(e.callback);
                    break;
                case PressType.Released:
                    bool _b = isReleased(e.button) && run(e.callback);
                    break;
                case PressType.Held:
                    bool _c = isHeld(e.button) && run(e.callback);
                    break;
                default:
                    throw new Exception("This code is unreachable");
            }
        }
    }

    public void update(KeyboardState keyState) {
        update(new CompoundState(keyState));
    }
    
    public void update(GamePadState gamePadState) {
        update(new CompoundState(gamePadState));
    }

    public void update(GamePadState gamePadState, KeyboardState keyState) {
        update(new CompoundState(keyState, gamePadState));
    }
    
    public void update(KeyboardState keyState, GamePadState gamePadState) {
        update(new CompoundState(keyState, gamePadState));
    }

    private int framesPressed(CompoundButton button) {
        int acc = 0;
        for (int i = 0; i < debounce; i++) {
            acc += button.get(_compoundStates[i]) ? 1 : 0;
        }
        return acc;
    }

    private CompoundState getState(int prev = 0) {
            return _compoundStates[(ptr - prev + debounce) % debounce];
    }

    private bool isPressed(CompoundButton button) {
        return button.get(getState()) && framesPressed(button) == 1;
    }

    private bool isReleased(CompoundButton button) {
        return !button.get(getState()) && button.get(getState(1));
    }

    private bool isHeld(CompoundButton button) {
        return button.get(getState()) && button.get(getState(1));
    }
    
    public void onPressed(CompoundButton button, Action callback) {
        _events.Add(new InputEvent(button, PressType.Pressed, callback));
    }
    
    public void onReleased(CompoundButton button, Action callback) {
        _events.Add(new InputEvent(button, PressType.Released, callback));
    }
    
    public void onHeld(CompoundButton button, Action callback) {
        _events.Add(new InputEvent(button, PressType.Held, callback));
    }

    public void onPressed(GenericButton button, Action callback) {
        _events.Add(new InputEvent(CompoundButton.fromGeneric(button), PressType.Pressed, callback));
    }
    
    public void onReleased(GenericButton button, Action callback) {
        _events.Add(new InputEvent(CompoundButton.fromGeneric(button), PressType.Released, callback));
    }
    
    public void onHeld(GenericButton button, Action callback) {
        _events.Add(new InputEvent(CompoundButton.fromGeneric(button), PressType.Held, callback));
    }
    
    private static bool run(Action action) {
        action();
        return true;
    }
}
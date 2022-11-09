using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEvents; 

public class CompoundState {
    private KeyboardState _keyBoardState;
    private GamePadState _gamePadState;
    
    public CompoundState(KeyboardState keyBoardState, GamePadState gamePadState) {
        _keyBoardState = keyBoardState;
        _gamePadState = gamePadState;
    }

    public CompoundState(KeyboardState keyBoardState) {
        _keyBoardState = keyBoardState;
        _gamePadState = GamePadState.Default; // this is the default state
    }
    
    public CompoundState(GamePadState gamePadState) {
        _keyBoardState = new KeyboardState(); // this is also the default state. The fact they are different is vexing to me.
        _gamePadState = gamePadState;
    }

    public bool get(GenericButton button) {
        // if the button is a keyboard button, check the keyboard state
        return button switch {
            >= GenericButton.KeyNone and <= GenericButton.KeyOemClear => _keyBoardState.IsKeyDown((Keys)button),
            >= GenericButton.GPNone and <= GenericButton.DevStickRight => _gamePadState.IsButtonDown((Buttons)button),
            _ => false
        };
    }
}
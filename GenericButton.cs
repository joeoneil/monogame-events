using System;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEvents; 

    public enum GenericButton {
    // Keyboard buttons
    KeyNone = Keys.None,
    KeyBack = Keys.Back,
    KeyTab = Keys.Tab,
    KeyEnter = Keys.Enter, // 0x0000000D
    KeyPause = Keys.Pause, // 0x00000013
    KeyCapsLock = Keys.CapsLock, // 0x00000014
    KeyKana = Keys.Kana, // 0x00000015
    KeyKanji = Keys.Kanji, // 0x00000019
    KeyEscape = Keys.Escape, // 0x0000001B
    KeyImeConvert = Keys.ImeConvert, // 0x0000001C
    KeyImeNoConvert = Keys.ImeNoConvert, // 0x0000001D
    KeySpace = Keys.Space, // 0x00000020
    KeyPageUp = Keys.PageUp, // 0x00000021
    KeyPageDown = Keys.PageDown, // 0x00000022
    KeyEnd = Keys.End, // 0x00000023
    KeyHome = Keys.Home, // 0x00000024
    KeyLeft = Keys.Left, // 0x00000025
    KeyUp = Keys.Up, // 0x00000026
    KeyRight = Keys.Right, // 0x00000027
    KeyDown = Keys.Down, // 0x00000028
    KeySelect = Keys.Select, // 0x00000029
    KeyPrint = Keys.Print, // 0x0000002A
    KeyExecute = Keys.Execute, // 0x0000002B
    KeyPrintScreen = Keys.PrintScreen, // 0x0000002C
    KeyInsert = Keys.Insert, // 0x0000002D
    KeyDelete = Keys.Delete, // 0x0000002E
    KeyHelp = Keys.Help, // 0x0000002F
    KeyD0 = Keys.D0, // 0x00000030
    KeyD1 = Keys.D1, // 0x00000031
    KeyD2 = Keys.D2, // 0x00000032
    KeyD3 = Keys.D3, // 0x00000033
    KeyD4 = Keys.D4, // 0x00000034
    KeyD5 = Keys.D5, // 0x00000035
    KeyD6 = Keys.D6, // 0x00000036
    KeyD7 = Keys.D7, // 0x00000037
    KeyD8 = Keys.D8, // 0x00000038
    KeyD9 = Keys.D9, // 0x00000039
    KeyA = Keys.A, // 0x00000041
    KeyB = Keys.B, // 0x00000042
    KeyC = Keys.C, // 0x00000043
    KeyD = Keys.D, // 0x00000044
    KeyE = Keys.E, // 0x00000045
    KeyF = Keys.F, // 0x00000046
    KeyG = Keys.G, // 0x00000047
    KeyH = Keys.H, // 0x00000048
    KeyI = Keys.I, // 0x00000049
    KeyJ = Keys.J, // 0x0000004A
    KeyK = Keys.K, // 0x0000004B
    KeyL = Keys.L, // 0x0000004C
    KeyM = Keys.M, // 0x0000004D
    KeyN = Keys.N, // 0x0000004E
    KeyO = Keys.O, // 0x0000004F
    KeyP = Keys.P, // 0x00000050
    KeyQ = Keys.Q, // 0x00000051
    KeyR = Keys.R, // 0x00000052
    KeyS = Keys.S, // 0x00000053
    KeyT = Keys.T, // 0x00000054
    KeyU = Keys.U, // 0x00000055
    KeyV = Keys.V, // 0x00000056
    KeyW = Keys.W, // 0x00000057
    KeyX = Keys.X, // 0x00000058
    KeyY = Keys.Y, // 0x00000059
    KeyZ = Keys.Z, // 0x0000005A
    KeyLeftWindows = Keys.LeftWindows, // 0x0000005B
    KeyRightWindows = Keys.RightWindows, // 0x0000005C
    KeyApps = Keys.Apps, // 0x0000005D
    KeySleep = Keys.Sleep, // 0x0000005F
    KeyNumPad0 = Keys.NumPad0, // 0x00000060
    KeyNumPad1 = Keys.NumPad1, // 0x00000061
    KeyNumPad2 = Keys.NumPad2, // 0x00000062
    KeyNumPad3 = Keys.NumPad3, // 0x00000063
    KeyNumPad4 = Keys.NumPad4, // 0x00000064
    KeyNumPad5 = Keys.NumPad5, // 0x00000065
    KeyNumPad6 = Keys.NumPad6, // 0x00000066
    KeyNumPad7 = Keys.NumPad7, // 0x00000067
    KeyNumPad8 = Keys.NumPad8, // 0x00000068
    KeyNumPad9 = Keys.NumPad9, // 0x00000069
    KeyMultiply = Keys.Multiply, // 0x0000006A
    KeyAdd = Keys.Add, // 0x0000006B
    KeySeparator = Keys.Separator, // 0x0000006C
    KeySubtract = Keys.Subtract, // 0x0000006D
    KeyDecimal = Keys.Decimal, // 0x0000006E
    KeyDivide = Keys.Divide, // 0x0000006F
    KeyF1 = Keys.F1, // 0x00000070
    KeyF2 = Keys.F2, // 0x00000071
    KeyF3 = Keys.F3, // 0x00000072
    KeyF4 = Keys.F4, // 0x00000073
    KeyF5 = Keys.F5, // 0x00000074
    KeyF6 = Keys.F6, // 0x00000075
    KeyF7 = Keys.F7, // 0x00000076
    KeyF8 = Keys.F8, // 0x00000077
    KeyF9 = Keys.F9, // 0x00000078
    KeyF10 = Keys.F10, // 0x00000079
    KeyF11 = Keys.F11, // 0x0000007A
    KeyF12 = Keys.F12, // 0x0000007B
    KeyF13 = Keys.F13, // 0x0000007C
    KeyF14 = Keys.F14, // 0x0000007D
    KeyF15 = Keys.F15, // 0x0000007E
    KeyF16 = Keys.F16, // 0x0000007F
    KeyF17 = Keys.F17, // 0x00000080
    KeyF18 = Keys.F18, // 0x00000081
    KeyF19 = Keys.F19, // 0x00000082
    KeyF20 = Keys.F20, // 0x00000083
    KeyF21 = Keys.F21, // 0x00000084
    KeyF22 = Keys.F22, // 0x00000085
    KeyF23 = Keys.F23, // 0x00000086
    KeyF24 = Keys.F24, // 0x00000087
    KeyNumLock = Keys.NumLock, // 0x00000090
    KeyScroll = Keys.Scroll, // 0x00000091
    KeyLeftShift = Keys.LeftShift, // 0x000000A0
    KeyRightShift = Keys.RightShift, // 0x000000A1
    KeyLeftControl = Keys.LeftControl, // 0x000000A2
    KeyRightControl = Keys.RightControl, // 0x000000A3
    KeyLeftAlt = Keys.LeftAlt, // 0x000000A4
    KeyRightAlt = Keys.RightAlt, // 0x000000A5
    KeyBrowserBack = Keys.BrowserBack, // 0x000000A6
    KeyBrowserForward = Keys.BrowserForward, // 0x000000A7
    KeyBrowserRefresh = Keys.BrowserRefresh, // 0x000000A8
    KeyBrowserStop = Keys.BrowserStop, // 0x000000A9
    KeyBrowserSearch = Keys.BrowserSearch, // 0x000000AA
    KeyBrowserFavorites = Keys.BrowserFavorites, // 0x000000AB
    KeyBrowserHome = Keys.BrowserHome, // 0x000000AC
    KeyVolumeMute = Keys.VolumeMute, // 0x000000AD
    KeyVolumeDown = Keys.VolumeDown, // 0x000000AE
    KeyVolumeUp = Keys.VolumeUp, // 0x000000AF
    KeyMediaNextTrack = Keys.MediaNextTrack, // 0x000000B0
    KeyMediaPreviousTrack = Keys.MediaPreviousTrack, // 0x000000B1
    KeyMediaStop = Keys.MediaStop, // 0x000000B2
    KeyMediaPlayPause = Keys.MediaPlayPause, // 0x000000B3
    KeyLaunchMail = Keys.LaunchMail, // 0x000000B4
    KeySelectMedia = Keys.SelectMedia, // 0x000000B5
    KeyLaunchApplication1 = Keys.LaunchApplication1, // 0x000000B6
    KeyLaunchApplication2 = Keys.LaunchApplication2, // 0x000000B7
    KeyOemSemicolon = Keys.OemSemicolon, // 0x000000BA
    KeyOemPlus = Keys.OemPipe, // 0x000000BB
    KeyOemComma = Keys.OemComma, // 0x000000BC
    KeyOemMinus = Keys.OemMinus, // 0x000000BD
    KeyOemPeriod = Keys.OemPeriod, // 0x000000BE
    KeyOemQuestion = Keys.OemQuestion, // 0x000000BF
    KeyOemTilde = Keys.OemTilde, // 0x000000C0
    KeyChatPadGreen = Keys.ChatPadGreen, // 0x000000CA
    KeyChatPadOrange = Keys.ChatPadOrange, // 0x000000CB
    KeyOemOpenBrackets = Keys.OemOpenBrackets, // 0x000000DB
    KeyOemPipe = Keys.OemPipe, // 0x000000DC
    KeyOemCloseBrackets = Keys.OemCloseBrackets, // 0x000000DD
    KeyOemQuotes = Keys.OemQuotes, // 0x000000DE
    KeyOem8 = Keys.Oem8, // 0x000000DF
    KeyOemBackslash = Keys.OemBackslash, // 0x000000E2
    KeyProcessKey = Keys.ProcessKey, // 0x000000E5
    KeyOemCopy = Keys.OemCopy, // 0x000000F2
    KeyOemAuto = Keys.OemAuto, // 0x000000F3
    KeyOemEnlW = Keys.OemEnlW, // 0x000000F4
    KeyAttn = Keys.Attn, // 0x000000F6
    KeyCrsel = Keys.Crsel, // 0x000000F7
    KeyExsel = Keys.Exsel, // 0x000000F8
    KeyEraseEof = Keys.EraseEof, // 0x000000F9
    KeyPlay = Keys.Play, // 0x000000FA
    KeyZoom = Keys.Zoom, // 0x000000FB
    KeyPa1 = Keys.Pa1, // 0x000000FD
    KeyOemClear = Keys.OemClear, // 0x000000FE
    
    // Gamepad buttons
    GPNone = Buttons.None,
    GPDPadUp = Buttons.DPadUp,
    GPDPadDown = Buttons.DPadDown,
    GPDPadLeft = Buttons.DPadLeft,
    GPDPadRight = Buttons.DPadRight,
    GPStart = Buttons.Start,
    GPBack = Buttons.Back,
    GPLeftStick = Buttons.LeftStick,
    GPRightStick = Buttons.RightStick,
    GPLeftShoulder = Buttons.LeftShoulder,
    GPRightShoulder = Buttons.RightShoulder,
    GPBigButton = Buttons.BigButton,
    GPA = Buttons.A,
    GPB = Buttons.B,
    GPX = Buttons.X,
    GPY = Buttons.Y,
    GPLeftTrigger = Buttons.LeftTrigger,
    GPRightTrigger = Buttons.RightTrigger,
    GPLeftThumbstickUp = Buttons.LeftThumbstickUp,
    GPLeftThumbstickDown = Buttons.LeftThumbstickDown,
    GPLeftThumbstickLeft = Buttons.LeftThumbstickLeft,
    GPLeftThumbstickRight = Buttons.LeftThumbstickRight,
    GPRightThumbstickUp = Buttons.RightThumbstickUp,
    GPRightThumbstickDown = Buttons.RightThumbstickDown,
    GPRightThumbstickLeft = Buttons.RightThumbstickLeft,
    GPRightThumbstickRight = Buttons.RightThumbstickRight,
    
    // Devcade buttons
    DevA1=Buttons.X,
    DevA2=Buttons.Y,
    DevA3=Buttons.RightShoulder,
    DevA4=Buttons.LeftShoulder,
    DevB1=Buttons.A,
    DevB2=Buttons.B,
    DevB3=Buttons.RightTrigger,
    DevB4=Buttons.LeftTrigger,
    DevMenu=Buttons.Start,
    DevStickDown=Buttons.LeftThumbstickDown,
    DevStickUp=Buttons.LeftThumbstickUp,
    DevStickLeft=Buttons.LeftThumbstickLeft,
    DevStickRight=Buttons.LeftThumbstickRight,
    
    // Null button
    Null = 0x00000000
}


[Flags]
public enum InputType
{
    Keyboard,
    Gamepad,
    Devcade,
    Null,
}

public enum ButtonOperator {
    And,
    Or,
    Xor,
    Not,
    None
}

public class CompoundButton {
    
    private CompoundButton left;
    private CompoundButton right;
    private GenericButton button;
    private InputType type;
    private ButtonOperator Operator;

    private CompoundButton(CompoundButton left, CompoundButton right, ButtonOperator Operator) {
        this.left = left;
        this.right = right;
        this.button = GenericButton.Null;
        this.type = InputType.Null;
        this.Operator = Operator;
    }
    
    private CompoundButton(GenericButton button, InputType type) {
        this.left = null;
        this.right = null;
        this.button = button;
        this.type = type;
        this.Operator = ButtonOperator.None;
    }
    
    public static CompoundButton operator &(CompoundButton left, CompoundButton right) {
        return new CompoundButton(left, right, ButtonOperator.And);
    }
    
    public static CompoundButton operator &(CompoundButton left, GenericButton right) {
        return new CompoundButton(left, fromGeneric(right), ButtonOperator.And);
    }
    
    public static CompoundButton operator &(GenericButton left, CompoundButton right) {
        return new CompoundButton(fromGeneric(left), right, ButtonOperator.And);
    }

    public static CompoundButton and(GenericButton left, GenericButton right) {
            return new CompoundButton(fromGeneric(left), fromGeneric(right), ButtonOperator.And);
    }
    
    public static CompoundButton and(GenericButton left, CompoundButton right) {
            return new CompoundButton(fromGeneric(left), right, ButtonOperator.And);
    }
    
    public static CompoundButton and(CompoundButton left, GenericButton right) {
            return new CompoundButton(left, fromGeneric(right), ButtonOperator.And);
    }
    
    public static CompoundButton and(CompoundButton left, CompoundButton right) {
            return new CompoundButton(left, right, ButtonOperator.And);
    }

    public static CompoundButton operator |(CompoundButton left, CompoundButton right) {
        return new CompoundButton(left, right, ButtonOperator.Or);
    }
    
    public static CompoundButton operator |(CompoundButton left, GenericButton right) {
        return new CompoundButton(left, fromGeneric(right), ButtonOperator.Or);
    }
    
    public static CompoundButton operator |(GenericButton left, CompoundButton right) {
        return new CompoundButton(fromGeneric(left), right, ButtonOperator.Or);
    }
    
    public static CompoundButton or(GenericButton left, GenericButton right) {
            return new CompoundButton(fromGeneric(left), fromGeneric(right), ButtonOperator.Or);
    }
    
    public static CompoundButton or(GenericButton left, CompoundButton right) {
            return new CompoundButton(fromGeneric(left), right, ButtonOperator.Or);
    }
    
    public static CompoundButton or(CompoundButton left, GenericButton right) {
            return new CompoundButton(left, fromGeneric(right), ButtonOperator.Or);
    }
    
    public static CompoundButton or(CompoundButton left, CompoundButton right) {
            return new CompoundButton(left, right, ButtonOperator.Or);
    }
    
    public static CompoundButton operator ^(CompoundButton left, CompoundButton right) {
        return new CompoundButton(left, right, ButtonOperator.Xor);
    }
    
    public static CompoundButton operator ^(CompoundButton left, GenericButton right) {
        return new CompoundButton(left, fromGeneric(right), ButtonOperator.Xor);
    }
    
    public static CompoundButton operator ^(GenericButton left, CompoundButton right) {
        return new CompoundButton(fromGeneric(left), right, ButtonOperator.Xor);
    }
    
    public static CompoundButton xor(GenericButton left, GenericButton right) {
            return new CompoundButton(fromGeneric(left), fromGeneric(right), ButtonOperator.Xor);
    }
    
    public static CompoundButton xor(GenericButton left, CompoundButton right) {
            return new CompoundButton(fromGeneric(left), right, ButtonOperator.Xor);
    }
    
    public static CompoundButton xor(CompoundButton left, GenericButton right) {
            return new CompoundButton(left, fromGeneric(right), ButtonOperator.Xor);
    }
    
    public static CompoundButton xor(CompoundButton left, CompoundButton right) {
            return new CompoundButton(left, right, ButtonOperator.Xor);
    }
    
    public static CompoundButton operator !(CompoundButton button) {
        return new CompoundButton(button, null, ButtonOperator.Not);
    }
    
    public static CompoundButton not(GenericButton button) {
        return new CompoundButton(fromGeneric(button), null, ButtonOperator.Not);
    }
    
    public static CompoundButton not(CompoundButton button) {
        return new CompoundButton(button, null, ButtonOperator.Not);
    }

    public CompoundButton and(GenericButton other) {
            return new CompoundButton(this, fromGeneric(other), ButtonOperator.And);
    }
    
    public CompoundButton and(CompoundButton other) {
            return new CompoundButton(this, other, ButtonOperator.And);
    }
    
    public CompoundButton or(GenericButton other) {
            return new CompoundButton(this, fromGeneric(other), ButtonOperator.Or);
    }
    
    public CompoundButton or(CompoundButton other) {
            return new CompoundButton(this, other, ButtonOperator.Or);
    }
    
    public CompoundButton xor(GenericButton other) {
            return new CompoundButton(this, fromGeneric(other), ButtonOperator.Xor);
    }
    
    public CompoundButton xor(CompoundButton other) {
            return new CompoundButton(this, other, ButtonOperator.Xor);
    }
    
    public CompoundButton not() {
        return new CompoundButton(this, null, ButtonOperator.Not);
    }

    public static CompoundButton fromGeneric(GenericButton button) {
        return button switch {
            // check if a button is a key
            >= GenericButton.KeyNone and <= GenericButton.KeyOemClear => new CompoundButton(button, InputType.Keyboard),
            // check if a button is a gamepad button
            >= GenericButton.GPNone and <= GenericButton.GPRightThumbstickRight => new CompoundButton(button,
                InputType.Gamepad),
            // check if a button is a devcade button
            >= GenericButton.DevA1 and <= GenericButton.DevStickRight => new CompoundButton(button, InputType.Devcade),
            _ => new CompoundButton(button, InputType.Null)
        };
    }

    public bool get(CompoundState state) {
        return Operator switch {
            ButtonOperator.And => left.get(state) && right.get(state),
            ButtonOperator.Or => left.get(state) || right.get(state),
            ButtonOperator.Xor => left.get(state) ^ right.get(state),
            ButtonOperator.Not => !left.get(state),
            ButtonOperator.None => state?.get(button) ?? false,
            _ => false
        };
    }
}
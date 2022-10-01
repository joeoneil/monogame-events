using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace MonoGameCross_PlatformDesktopApplication1;

public class ButtonManager
{
    private static List<Button> _buttons = new List<Button>();

    public static void AddButton(Button b)
    {
        _buttons.Add(b);
    }

    public static void Update(MouseState state)
    {
        foreach (var b in _buttons)
        {
            if (b.Contains(state.Position))
            {
                b.Click();
            }
        }
    }
}
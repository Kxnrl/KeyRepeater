using System;

namespace KeyRepeater.Keyboard
{
    public enum InputType
    {
        Mouse = 0,
        Keyboard = 1,
        Hardware = 2
    }

    [Flags]
    public enum KeyEvents
    {
        KeyDown = 0x0000,
        ExtendedKey = 0x0001,
        KeyUp = 0x0002,
        Unicode = 0x0004,
        Scancode = 0x0008,
    }

    [Flags]
    public enum KeyStates
    {
        None = 0,
        Down = 1,
        Toggled = 2
    }
}

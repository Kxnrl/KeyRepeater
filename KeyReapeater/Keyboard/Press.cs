using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyRepeater.Keyboard
{
    class Press
    {
        public static void KeyPress(DirectXKeyCodes key)
        {
            SendKey(key, false, InputType.Keyboard);
            SendKey(key, true, InputType.Keyboard);
        }

        public static int KeyPress(DirectXKeyCodes key, int holdTime = 10)
        {
            SendKey(key, false, InputType.Keyboard);
            Thread.Sleep(holdTime);
            SendKey(key, true, InputType.Keyboard);
            return holdTime;
        }

        public static void KeyHold(DirectXKeyCodes key, bool release = false)
        {
            SendKey(key, release, InputType.Keyboard);
        }

        public static KeyStates GetKeyState(VKcodes key)
        {
            var val = Win32Api.GetKeyState((ushort)key);
            var ret = KeyStates.None;

            if ((val & 0x8000) == 0x8000)
                ret |= KeyStates.Down;

            if ((val & 1) == 1)
                ret |= KeyStates.Toggled;

            return ret;
        }

        public static bool IsKeyDown(VKcodes key)
        {
            return (int)(GetKeyState(key) & KeyStates.Down) == 1;
        }

        public static uint SendKey(DirectXKeyCodes key, bool KeyUp, InputType inputType)
        {
            uint flagtosend;
            if (KeyUp)
            {
                flagtosend = (uint)(KeyEvents.KeyUp | KeyEvents.Scancode);
            }
            else
            {
                flagtosend = (uint)(KeyEvents.KeyDown | KeyEvents.Scancode);
            }

            Input[] inputs =
            {
                    new Input
                    {
                        type = (int) inputType,
                        u = new InputUnion
                        {
                            ki = new KeyboardInput
                            {
                                wVk = 0,
                                wScan = (ushort) key,
                                dwFlags = flagtosend,
                                dwExtraInfo = Win32Api.GetMessageExtraInfo()
                            }
                        }
                    }
                };

            return Win32Api.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }
    }
}

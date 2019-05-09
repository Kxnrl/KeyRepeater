using System;
using System.Runtime.InteropServices;

namespace KeyRepeater.Keyboard
{
    class Win32Api
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern short GetKeyState(int keyCode);
    }
}

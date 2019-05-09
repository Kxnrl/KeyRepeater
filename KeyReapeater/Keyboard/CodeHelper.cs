namespace KeyRepeater.Keyboard
{
    class CodeHelper
    {
        public static string DXCodeToDisplay(DirectXKeyCodes code)
        {
            switch (code)
            {
                default: return null;

                // 数字键
                case DirectXKeyCodes.DIK_0: return "数字键 [ 0 ]";
                case DirectXKeyCodes.DIK_1: return "数字键 [ 1 ]";
                case DirectXKeyCodes.DIK_2: return "数字键 [ 2 ]";
                case DirectXKeyCodes.DIK_3: return "数字键 [ 3 ]";
                case DirectXKeyCodes.DIK_4: return "数字键 [ 4 ]";
                case DirectXKeyCodes.DIK_5: return "数字键 [ 5 ]";
                case DirectXKeyCodes.DIK_6: return "数字键 [ 6 ]";
                case DirectXKeyCodes.DIK_7: return "数字键 [ 7 ]";
                case DirectXKeyCodes.DIK_8: return "数字键 [ 8 ]";
                case DirectXKeyCodes.DIK_9: return "数字键 [ 9 ]";

                // 字母键
                case DirectXKeyCodes.DIK_A: return "字母键 [ A ]";
                case DirectXKeyCodes.DIK_B: return "字母键 [ B ]";
                case DirectXKeyCodes.DIK_C: return "字母键 [ C ]";
                case DirectXKeyCodes.DIK_D: return "字母键 [ D ]";
                case DirectXKeyCodes.DIK_E: return "字母键 [ E ]";
                case DirectXKeyCodes.DIK_F: return "字母键 [ F ]";
                case DirectXKeyCodes.DIK_G: return "字母键 [ G ]";
                case DirectXKeyCodes.DIK_H: return "字母键 [ H ]";
                case DirectXKeyCodes.DIK_I: return "字母键 [ I ]";
                case DirectXKeyCodes.DIK_J: return "字母键 [ J ]";
                case DirectXKeyCodes.DIK_K: return "字母键 [ K ]";
                case DirectXKeyCodes.DIK_L: return "字母键 [ L ]";
                case DirectXKeyCodes.DIK_M: return "字母键 [ M ]";
                case DirectXKeyCodes.DIK_N: return "字母键 [ N ]";
                case DirectXKeyCodes.DIK_O: return "字母键 [ O ]";
                case DirectXKeyCodes.DIK_P: return "字母键 [ P ]";
                case DirectXKeyCodes.DIK_Q: return "字母键 [ Q ]";
                case DirectXKeyCodes.DIK_R: return "字母键 [ R ]";
                case DirectXKeyCodes.DIK_S: return "字母键 [ S ]";
                case DirectXKeyCodes.DIK_T: return "字母键 [ T ]";
                case DirectXKeyCodes.DIK_U: return "字母键 [ U ]";
                case DirectXKeyCodes.DIK_V: return "字母键 [ V ]";
                case DirectXKeyCodes.DIK_W: return "字母键 [ W ]";
                case DirectXKeyCodes.DIK_X: return "字母键 [ X ]";
                case DirectXKeyCodes.DIK_Y: return "字母键 [ Y ]";
                case DirectXKeyCodes.DIK_Z: return "字母键 [ Z ]";

                // 符号键
                case DirectXKeyCodes.DIK_GRAVE:      return "符号键 [ ` ]";
                case DirectXKeyCodes.DIK_MINUS:      return "符号键 [ - ]";
                case DirectXKeyCodes.DIK_EQUALS:     return "符号键 [ = ]";
                case DirectXKeyCodes.DIK_LBRACKET:   return "符号键 \" [ \"";
                case DirectXKeyCodes.DIK_RBRACKET:   return "符号键 \" ] \"";
                case DirectXKeyCodes.DIK_BACKSLASH:  return "符号键 [ \\ ]";
                case DirectXKeyCodes.DIK_SEMICOLON:  return "符号键 [ ; ]";
                case DirectXKeyCodes.DIK_APOSTROPHE: return "符号键 [ ' ]";
                case DirectXKeyCodes.DIK_COMMA:      return "符号键 [ , ]";
                case DirectXKeyCodes.DIK_PERIOD:     return "符号键 [ . ]";
                case DirectXKeyCodes.DIK_SLASH:      return "符号键 [ / ]";

                // 功能键
                case DirectXKeyCodes.DIK_F1:  return "功能键 [ F1 ]";
                case DirectXKeyCodes.DIK_F2:  return "功能键 [ F2 ]";
                case DirectXKeyCodes.DIK_F3:  return "功能键 [ F3 ]";
                case DirectXKeyCodes.DIK_F4:  return "功能键 [ F4 ]";
                case DirectXKeyCodes.DIK_F5:  return "功能键 [ F5 ]";
                case DirectXKeyCodes.DIK_F6:  return "功能键 [ F6 ]";
                case DirectXKeyCodes.DIK_F7:  return "功能键 [ F7 ]";
                case DirectXKeyCodes.DIK_F8:  return "功能键 [ F8 ]";
                case DirectXKeyCodes.DIK_F9:  return "功能键 [ F9 ]";
                case DirectXKeyCodes.DIK_F10: return "功能键 [ F10 ]";
                case DirectXKeyCodes.DIK_F11: return "功能键 [ F11 ]";
                case DirectXKeyCodes.DIK_F12: return "功能键 [ F12 ]";
                case DirectXKeyCodes.DIK_F13: return "功能键 [ F13 ]";
                case DirectXKeyCodes.DIK_F14: return "功能键 [ F14 ]";
                case DirectXKeyCodes.DIK_F15: return "功能键 [ F15 ]";

                // 小键盘
                case DirectXKeyCodes.DIK_NUMPAD1: return "小键盘 [ 1 ]";
                case DirectXKeyCodes.DIK_NUMPAD2: return "小键盘 [ 2 ]";
                case DirectXKeyCodes.DIK_NUMPAD3: return "小键盘 [ 3 ]";
                case DirectXKeyCodes.DIK_NUMPAD4: return "小键盘 [ 4 ]";
                case DirectXKeyCodes.DIK_NUMPAD5: return "小键盘 [ 5 ]";
                case DirectXKeyCodes.DIK_NUMPAD6: return "小键盘 [ 6 ]";
                case DirectXKeyCodes.DIK_NUMPAD7: return "小键盘 [ 7 ]";
                case DirectXKeyCodes.DIK_NUMPAD8: return "小键盘 [ 8 ]";
                case DirectXKeyCodes.DIK_NUMPAD9: return "小键盘 [ 9 ]";
                case DirectXKeyCodes.DIK_NUMPAD0: return "小键盘 [ 0 ]";

                case DirectXKeyCodes.DIK_NUMPADCOMMA: return "小键盘 [ , ]";
                case DirectXKeyCodes.DIK_DECIMAL:     return "小键盘 [ . ]";
                case DirectXKeyCodes.DIK_ADD:         return "小键盘 [ + ]";
                case DirectXKeyCodes.DIK_SUBTRACT:    return "小键盘 [ - ]";
                case DirectXKeyCodes.DIK_MULTIPLY:    return "小键盘 [ * ]";
                case DirectXKeyCodes.DIK_DIVIDE:      return "小键盘 [ / ]";
                case DirectXKeyCodes.DIK_NUMPADENTER: return "小键盘 [ Enter ]";

                // 方向键
                case DirectXKeyCodes.DIK_UP:    return "方向键 [ ↑ ]";
                case DirectXKeyCodes.DIK_DOWN:  return "方向键 [ ↓ ]";
                case DirectXKeyCodes.DIK_LEFT:  return "方向键 [ ← ]";
                case DirectXKeyCodes.DIK_RIGHT: return "方向键 [ → ]";

                // 特殊键
                case DirectXKeyCodes.DIK_ESCAPE:    return "功能键 [ Esc ]";
                case DirectXKeyCodes.DIK_BACK:      return "功能键 [ BackSpace ]";
                case DirectXKeyCodes.DIK_SPACE:     return "功能键 [ Space ]";
                case DirectXKeyCodes.DIK_RETURN:    return "功能键 [ Enter ]";
                case DirectXKeyCodes.DIK_TAB:       return "功能键 [ Tab ]";
                case DirectXKeyCodes.DIK_CAPITAL:   return "功能键 [ CapsLock ]";
                case DirectXKeyCodes.DIK_LSHIFT:    return "功能键 [ L_Shift ]";
                case DirectXKeyCodes.DIK_RSHIFT:    return "功能键 [ R_Shift ]";
                case DirectXKeyCodes.DIK_LCONTROL:  return "功能键 [ L_Ctrl ]";
                case DirectXKeyCodes.DIK_RCONTROL:  return "功能键 [ R_Ctrl ]";
                case DirectXKeyCodes.DIK_LMENU:     return "功能键 [ L_Alt ]";
                case DirectXKeyCodes.DIK_RMENU:     return "功能键 [ R_Alt ]";
                case DirectXKeyCodes.DIK_INSERT:    return "功能键 [ Insert ]";
                case DirectXKeyCodes.DIK_DELETE:    return "功能键 [ Delete ]";
                case DirectXKeyCodes.DIK_HOME:      return "功能键 [ Home ]";
                case DirectXKeyCodes.DIK_END:       return "功能键 [ End ]";
                case DirectXKeyCodes.DIK_PAUSE:     return "功能键 [ Pause ]";
                case DirectXKeyCodes.DIK_PRIOR:     return "功能键 [ PgUp ]";
                case DirectXKeyCodes.DIK_NEXT:      return "功能键 [ PgDn ]";

                // 鼠标
                case DirectXKeyCodes.DIK_LEFTMOUSEBUTTON:   return "鼠标键 [ 左 ]";
                case DirectXKeyCodes.DIK_RIGHTMOUSEBUTTON:  return "鼠标键 [ 右 ]";
                case DirectXKeyCodes.DIK_MIDDLEWHEELBUTTON: return "鼠标键 [ 中 ]";
                case DirectXKeyCodes.DIK_MOUSEBUTTON3:      return "鼠标键 [ 3 ]";
                case DirectXKeyCodes.DIK_MOUSEBUTTON4:      return "鼠标键 [ 4 ]";
                case DirectXKeyCodes.DIK_MOUSEBUTTON5:      return "鼠标键 [ 5 ]";
                case DirectXKeyCodes.DIK_MOUSEBUTTON6:      return "鼠标键 [ 6 ]";
                case DirectXKeyCodes.DIK_MOUSEBUTTON7:      return "鼠标键 [ 7 ]";
                case DirectXKeyCodes.DIK_MOUSEWHEELUP:      return "鼠标键 [ ↑ ]";
                case DirectXKeyCodes.DIK_MOUSEWHEELDOWN:    return "鼠标键 [ ↓ ]";
            }
        }

        public static string VKCodeToDisplay(VKcodes code)
        {
            switch (code)
            {
                default: return null;

                // 数字键
                case VKcodes.VK_0: return "数字键 [ 0 ]";
                case VKcodes.VK_1: return "数字键 [ 1 ]";
                case VKcodes.VK_2: return "数字键 [ 2 ]";
                case VKcodes.VK_3: return "数字键 [ 3 ]";
                case VKcodes.VK_4: return "数字键 [ 4 ]";
                case VKcodes.VK_5: return "数字键 [ 5 ]";
                case VKcodes.VK_6: return "数字键 [ 6 ]";
                case VKcodes.VK_7: return "数字键 [ 7 ]";
                case VKcodes.VK_8: return "数字键 [ 8 ]";
                case VKcodes.VK_9: return "数字键 [ 9 ]";

                // 字母键
                case VKcodes.VK_A: return "字母键 [ A ]";
                case VKcodes.VK_B: return "字母键 [ B ]";
                case VKcodes.VK_C: return "字母键 [ C ]";
                case VKcodes.VK_D: return "字母键 [ D ]";
                case VKcodes.VK_E: return "字母键 [ E ]";
                case VKcodes.VK_F: return "字母键 [ F ]";
                case VKcodes.VK_G: return "字母键 [ G ]";
                case VKcodes.VK_H: return "字母键 [ H ]";
                case VKcodes.VK_I: return "字母键 [ I ]";
                case VKcodes.VK_J: return "字母键 [ J ]";
                case VKcodes.VK_K: return "字母键 [ K ]";
                case VKcodes.VK_L: return "字母键 [ L ]";
                case VKcodes.VK_M: return "字母键 [ M ]";
                case VKcodes.VK_N: return "字母键 [ N ]";
                case VKcodes.VK_O: return "字母键 [ O ]";
                case VKcodes.VK_P: return "字母键 [ P ]";
                case VKcodes.VK_Q: return "字母键 [ Q ]";
                case VKcodes.VK_R: return "字母键 [ R ]";
                case VKcodes.VK_S: return "字母键 [ S ]";
                case VKcodes.VK_T: return "字母键 [ T ]";
                case VKcodes.VK_U: return "字母键 [ U ]";
                case VKcodes.VK_V: return "字母键 [ V ]";
                case VKcodes.VK_W: return "字母键 [ W ]";
                case VKcodes.VK_X: return "字母键 [ X ]";
                case VKcodes.VK_Y: return "字母键 [ Y ]";
                case VKcodes.VK_Z: return "字母键 [ Z ]";

                // 功能键
                case VKcodes.VK_F1:  return "功能键 [ F1 ]";
                case VKcodes.VK_F2:  return "功能键 [ F2 ]";
                case VKcodes.VK_F3:  return "功能键 [ F3 ]";
                case VKcodes.VK_F4:  return "功能键 [ F4 ]";
                case VKcodes.VK_F5:  return "功能键 [ F5 ]";
                case VKcodes.VK_F6:  return "功能键 [ F6 ]";
                case VKcodes.VK_F7:  return "功能键 [ F7 ]";
                case VKcodes.VK_F8:  return "功能键 [ F8 ]";
                case VKcodes.VK_F9:  return "功能键 [ F9 ]";
                case VKcodes.VK_F10: return "功能键 [ F10 ]";
                case VKcodes.VK_F11: return "功能键 [ F11 ]";
                case VKcodes.VK_F12: return "功能键 [ F12 ]";
                case VKcodes.VK_F13: return "功能键 [ F13 ]";
                case VKcodes.VK_F14: return "功能键 [ F14 ]";
                case VKcodes.VK_F15: return "功能键 [ F15 ]";

                // 小键盘
                case VKcodes.VK_NUMPAD1: return "小键盘 [ 1 ]";
                case VKcodes.VK_NUMPAD2: return "小键盘 [ 2 ]";
                case VKcodes.VK_NUMPAD3: return "小键盘 [ 3 ]";
                case VKcodes.VK_NUMPAD4: return "小键盘 [ 4 ]";
                case VKcodes.VK_NUMPAD5: return "小键盘 [ 5 ]";
                case VKcodes.VK_NUMPAD6: return "小键盘 [ 6 ]";
                case VKcodes.VK_NUMPAD7: return "小键盘 [ 7 ]";
                case VKcodes.VK_NUMPAD8: return "小键盘 [ 8 ]";
                case VKcodes.VK_NUMPAD9: return "小键盘 [ 9 ]";
                case VKcodes.VK_NUMPAD0: return "小键盘 [ 0 ]";

                case VKcodes.VK_DECIMAL:     return "小键盘 [ . ]";
                case VKcodes.VK_ADD:         return "小键盘 [ + ]";
                case VKcodes.VK_SUBTRACT:    return "小键盘 [ - ]";
                case VKcodes.VK_MULTIPLY:    return "小键盘 [ * ]";
                case VKcodes.VK_DIVIDE:      return "小键盘 [ / ]";

                // 方向键
                case VKcodes.VK_UP:    return "方向键 [ ↑ ]";
                case VKcodes.VK_DOWN:  return "方向键 [ ↓ ]";
                case VKcodes.VK_LEFT:  return "方向键 [ ← ]";
                case VKcodes.VK_RIGHT: return "方向键 [ → ]";

                // 特殊键
                case VKcodes.VK_ESCAPE:    return "功能键 [ Esc ]";
                case VKcodes.VK_BACK:      return "功能键 [ BackSpace ]";
                case VKcodes.VK_SPACE:     return "功能键 [ Space ]";
                case VKcodes.VK_RETURN:    return "功能键 [ Enter ]";
                case VKcodes.VK_TAB:       return "功能键 [ Tab ]";
                case VKcodes.VK_CAPITAL:   return "功能键 [ CapsLock ]";
                case VKcodes.VK_LSHIFT:    return "功能键 [ L_Shift ]";
                case VKcodes.VK_RSHIFT:    return "功能键 [ R_Shift ]";
                case VKcodes.VK_LCONTROL:  return "功能键 [ L_Ctrl ]";
                case VKcodes.VK_RCONTROL:  return "功能键 [ R_Ctrl ]";
                case VKcodes.VK_LMENU:     return "功能键 [ L_Alt ]";
                case VKcodes.VK_RMENU:     return "功能键 [ R_Alt ]";
                case VKcodes.VK_INSERT:    return "功能键 [ Insert ]";
                case VKcodes.VK_DELETE:    return "功能键 [ Delete ]";
                case VKcodes.VK_HOME:      return "功能键 [ Home ]";
                case VKcodes.VK_END:       return "功能键 [ End ]";
                case VKcodes.VK_PAUSE:     return "功能键 [ Pause ]";
                case VKcodes.VK_PRIOR:     return "功能键 [ PgUp ]";
                case VKcodes.VK_NEXT:      return "功能键 [ PgDn ]";
            }
        }
    }
}

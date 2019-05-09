using KeyRepeater.Utils;
using System;
using System.IO;

namespace KeyRepeater
{
    class Config
    {
        private static string configFile;

        public static void LoadConf()
        {
            configFile = Path.Combine(Program.baseFolder, "dnf.conf");
        }

        public static Keyboard.VKcodes EnabledHotKey
        {
            set => Win32Api.SetIniSectionValue(configFile, "KeyRepeater.Enabled", "HotKey", Enum.GetName(typeof(Keyboard.VKcodes), value));
            get
            {
                var val = Win32Api.GetIniSectionValue(configFile, "KeyRepeater.Enabled", "HotKey");
                return string.IsNullOrEmpty(val) ? Keyboard.VKcodes.VK_INSERT : (Keyboard.VKcodes)Enum.Parse(typeof(Keyboard.VKcodes), val);
            }
        }

        public static Keyboard.VKcodes RefreshHotKey
        {
            set => Win32Api.SetIniSectionValue(configFile, "KeyRepeater.Refresh", "HotKey", Enum.GetName(typeof(Keyboard.VKcodes), value));
            get
            {
                var val = Win32Api.GetIniSectionValue(configFile, "KeyRepeater.Refresh", "HotKey");
                return string.IsNullOrEmpty(val) ? Keyboard.VKcodes.VK_DELETE : (Keyboard.VKcodes)Enum.Parse(typeof(Keyboard.VKcodes), val);
            }
        }

        public class GroupHotKey
        {
            public Keyboard.DirectXKeyCodes this[int index]
            {
                set => Win32Api.SetIniSectionValue(configFile, "KeyRepeater.Group." + index, "HotKey", Enum.GetName(typeof(Keyboard.DirectXKeyCodes), value));
                get
                {
                    var val = Win32Api.GetIniSectionValue(configFile, "KeyRepeater.Group." + index, "HotKey");
                    if (string.IsNullOrEmpty(val))
                    {
                        switch (index)
                        {
                            case 0: return Keyboard.DirectXKeyCodes.DIK_1;
                            case 1: return Keyboard.DirectXKeyCodes.DIK_2;
                            case 2: return Keyboard.DirectXKeyCodes.DIK_3;
                            case 3: return Keyboard.DirectXKeyCodes.DIK_4;
                            case 4: return Keyboard.DirectXKeyCodes.DIK_5;
                            default: return Keyboard.DirectXKeyCodes.DIK_SLASH;
                        }
                    }
                    return (Keyboard.DirectXKeyCodes)Enum.Parse(typeof(Keyboard.DirectXKeyCodes), val);
                 }
            }
        }
        
        public class GroupInterval
        {
            public uint this[int index]
            {
                set => Win32Api.SetIniSectionValue(configFile, "KeyRepeater.Group." + index, "Interval", value.ToString());
                get
                {
                    var val = Win32Api.GetIniSectionValue(configFile, "KeyRepeater.Group." + index, "Interval");
                    return string.IsNullOrEmpty(val) ? 5000 : Convert.ToUInt32(val);
                }
            }
        }

        public class GroupDelay
        {
            public uint this[int index]
            {
                set => Win32Api.SetIniSectionValue(configFile, "KeyRepeater.Group." + index, "Delay", value.ToString());
                get
                {
                    var val = Win32Api.GetIniSectionValue(configFile, "KeyRepeater.Group." + index, "Delay");
                    return string.IsNullOrEmpty(val) ? 0 : Convert.ToUInt32(val);
                }
            }
        }

        public class GroupState
        {
            public bool this[int index]
            {
                set => Win32Api.SetIniSectionValue(configFile, "KeyRepeater.Group." + index, "State", value ? "Enabled" : "Disabled");
                get
                {
                    var val = Win32Api.GetIniSectionValue(configFile, "KeyRepeater.Group." + index, "State");
                    return string.IsNullOrEmpty(val) ? false : val.Equals("Enabled");
                }
            }
        }
    }
}
using System;
using System.Windows.Forms;

namespace KeyRepeater
{
    public partial class HotKeyUI : Form
    {
        public Keyboard.VKcodes vHotKey = Keyboard.VKcodes.VK_INSERT;

        public class VKCodes
        {
            public Keyboard.VKcodes VKKey;

            public VKCodes(Keyboard.VKcodes key)
            {
                VKKey = key;
            }

            public override string ToString()
            {
                return Keyboard.CodeHelper.VKCodeToDisplay(VKKey);
            }
        }

        public HotKeyUI()
        {
            InitializeComponent();
            Icon = Properties.Resources.dfo;

            KeyGlobal.Items.Clear();

            var kb = typeof(Keyboard.VKcodes);
            foreach (var each in (Keyboard.VKcodes[])Enum.GetValues(kb))
            {
                var data = new VKCodes(each);
                if (data.ToString() == null)
                {
                    continue;
                }
                KeyGlobal.Items.Add(data);
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            vHotKey = ((VKCodes)KeyGlobal.SelectedItem).VKKey;
            DialogResult = DialogResult.Yes;
            var owner = Owner as UI;
            Close();
            owner.Activate();
        }
    }
}

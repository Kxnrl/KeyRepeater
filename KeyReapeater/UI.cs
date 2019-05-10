using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace KeyRepeater
{
    public partial class UI : Form
    {
        private static Keyboard.VKcodes HotKey_Enabled = Keyboard.VKcodes.VK_INSERT;
        private static Keyboard.VKcodes HotKey_Refresh = Keyboard.VKcodes.VK_DELETE;

        private static Thread[] backgroundWorkers = new Thread[6];
        private static bool[]   backgroundRefresh = new bool[6];
        private static bool[]   backgroundStarted = new bool[6];
        private static bool[]   backgroundStopped = new bool[6];

        private Config.GroupHotKey hotkey = new Config.GroupHotKey();
        private Config.GroupInterval interval = new Config.GroupInterval();
        private Config.GroupDelay delay = new Config.GroupDelay();
        private Config.GroupState state = new Config.GroupState();

        static bool enabled = false;
        static bool initiazed = false;
        static bool closing = false;

        private TextBox GameLog;

        public class GroupData
        {
            public bool gEnabled;
            public int gInterval;
            public int gDelay;
            public Keyboard.DirectXKeyCodes gHotKey;

            public GroupData(bool e,  int i, int d, Keyboard.DirectXKeyCodes h)
            {
                gEnabled = e;
                gInterval = i;
                gDelay = d;
                gHotKey = h;
            }
        }

        public class DXCodes
        {
            public Keyboard.DirectXKeyCodes DirectXKey;

            public DXCodes(Keyboard.DirectXKeyCodes key)
            {
                DirectXKey = key;
            }

            public override string ToString()
            {
                return Keyboard.CodeHelper.DXCodeToDisplay(DirectXKey);
            }
        }

        public List<GroupData> groupDatas = new List<GroupData>();

        public UI()
        {
            InitializeComponent();
            Icon = Properties.Resources.dfo;

            GameLog = new TextBox
            {
                Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 134),
                Location = new Point(2, 12),
                Name = "GameLog",
                ReadOnly = true,
                Size = new Size(383, 363),
                TabIndex = 0,
                Text = "",
                Visible = false,
                AllowDrop = false,
                Multiline = true,
                AcceptsReturn = false,
                Cursor = Cursors.No,
                Enabled = false,
                Width = 383,
                Height = 363,
                ScrollBars = ScrollBars.Vertical
            };
            Controls.Add(GameLog);
        }

        private Control FindGroup(int index)
        {
            foreach (Control c in Controls)
            {
                if (c.Name.Equals("Group" + index))
                {
                    return c;
                }
            }
            return null;
        }

        private Control FindChild(Control group, string name)
        {
            foreach (Control c in group.Controls)
            {
                if (c.Name.Equals(name))
                {
                    return c;
                }
            }
            throw new Exception();
        }

        private void UI_Load(object sender, EventArgs e)
        {
            // Load Confs
            LoadConf();

            backgroundWorkers[0] = new Thread(Thread_KeyboardHook)
            {
                IsBackground = true,
                Name = "Background Worker Keyboard",
                Priority = ThreadPriority.AboveNormal
            };

            for (var t = 1; t < backgroundWorkers.Length; ++t)
            {
                backgroundWorkers[t] = new Thread(() => Thread_KeyboardHandler())
                {
                    IsBackground = true,
                    Name = "Background Worker #" + t.ToString(),
                    Priority = ThreadPriority.BelowNormal
                };
            }

            foreach (var t in backgroundWorkers)
            {
                t.Start();
            }

            initiazed = true;

            SetControls(true);
        }

        private void LoadConf()
        {
            groupDatas.Clear();
            Config.LoadConf();
            var vk = typeof(Keyboard.VKcodes);
            var dx = typeof(Keyboard.DirectXKeyCodes);

            // 全局热键
            try
            {
                HotKey_Enabled = Config.EnabledHotKey;
                Button_Enabled.Text = "启动热键 [" + Enum.GetName(vk, HotKey_Enabled) + "]";

                HotKey_Refresh = Config.RefreshHotKey;
                Button_Refresh.Text = "刷新热键 [" + Enum.GetName(vk, HotKey_Refresh) + "]";
            }
            catch (Exception ex) { Console.WriteLine("Exception: {0}\n{1}", ex.Message, ex.StackTrace); }

            for (var i = 1; i <= 5; ++i)
            {
                try
                {
                    var _g = FindGroup(i);
                    var _k = FindChild(_g, "Key" + i) as ComboBox;
                    var _i = FindChild(_g, "Interval" + i) as NumericUpDown;
                    var _d = FindChild(_g, "Delay" + i) as NumericUpDown;
                    var _s = FindChild(_g, "State" + i) as CheckBox;

                    _k.Tag = hotkey[i - 1];
                    _s.Tag = state[i - 1];
                    _s.Checked = state[i - 1];
                    _i.Tag = interval[i - 1];
                    _i.Value = interval[i - 1];
                    _d.Tag = delay[i - 1];
                    _d.Value = delay[i - 1];

                    foreach (var each in (Keyboard.DirectXKeyCodes[])Enum.GetValues(dx))
                    {
                        var data = new DXCodes(each);
                        if (data.ToString() == null)
                        {
                            continue;
                        }
                        var item = _k.Items.Add(data);
                        if (each == (Keyboard.DirectXKeyCodes)_k.Tag)
                        {
                            _k.SelectedIndex = item;
                        }
                    }

                    groupDatas.Add(new GroupData(_s.Checked, (int)_i.Value, (int)_d.Value, (Keyboard.DirectXKeyCodes)_k.Tag));
                }
                catch (Exception ex) { Console.WriteLine("Exception: {0}\n{1}", ex.Message, ex.StackTrace); }
            }
        }

        private void Button_Global_Click(object sender, EventArgs e)
        {
            Program.hotKeyUI.Text = "设置全局启动热键";
            Program.hotKeyUI.ShowDialog(this);
            if (Program.hotKeyUI.DialogResult == DialogResult.Yes)
            {
                HotKey_Enabled = Program.hotKeyUI.vHotKey;
                Button_Enabled.Text = "启动热键 [" + Enum.GetName(typeof(Keyboard.VKcodes), HotKey_Enabled) + "]";
                Config.EnabledHotKey = HotKey_Enabled;
            }
        }

        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            Program.hotKeyUI.Text = "设置全局刷新热键";
            Program.hotKeyUI.ShowDialog(this);
            if (Program.hotKeyUI.DialogResult == DialogResult.Yes)
            {
                HotKey_Refresh = Program.hotKeyUI.vHotKey;
                Button_Refresh.Text = "刷新热键 [" + Enum.GetName(typeof(Keyboard.VKcodes), HotKey_Refresh) + "]";
                Config.RefreshHotKey = HotKey_Refresh;
            }
        }

        private void KxnrlLink(object sender, EventArgs e)
        {
            Process.Start("https://www.kxnrl.com");
        }

        private void Event_StateChanged(object sender, EventArgs e)
        {
            if (!initiazed) return;
            var c = sender as CheckBox;
            var i = Convert.ToInt16(c.Name.Replace("State", ""));
            state[i - 1] = c.Checked;
            groupDatas[i - 1].gEnabled = c.Checked;
        }

        private void Interval_Changed(object sender, EventArgs e)
        {
            if (!initiazed) return;
            var c = sender as NumericUpDown;
            var i = Convert.ToInt16(c.Name.Replace("Interval", ""));
            interval[i - 1] = (uint)c.Value;
            groupDatas[i - 1].gInterval = (int)c.Value;
        }

        private void Delay_Changed(object sender, EventArgs e)
        {
            if (!initiazed) return;
            var c = sender as NumericUpDown;
            var i = Convert.ToInt16(c.Name.Replace("Delay", ""));
            delay[i - 1] = (uint)c.Value;
            groupDatas[i - 1].gDelay = (int)c.Value;
        }

        private void HotKey_Changed(object sender, EventArgs e)
        {
            if (!initiazed) return;
            var c = sender as ComboBox;
            var i = Convert.ToInt16(c.Name.Replace("Key", ""));
            var k = ((DXCodes)c.SelectedItem).DirectXKey;
            hotkey[i - 1] = k;
            groupDatas[i - 1].gHotKey = k;
        }

        private void Thread_KeyboardHook()
        {
            while (!closing)
            {
                Thread.Sleep(10);

                if (Keyboard.Press.IsKeyDown(HotKey_Enabled))
                {
                    enabled = !enabled;
                    if (enabled)
                    {
                        for (var t = 1; t < backgroundWorkers.Length; ++t)
                        {
                            backgroundStarted[t] = true;
                        }
                    }
                    else
                    {
                        for (var t = 1; t < backgroundWorkers.Length; ++t)
                        {
                            backgroundStopped[t] = true;
                        }
                    }
                    Invoke(new Action(() =>
                    {
                        SetControls(!enabled);
                        GameLog.Text = string.Format("================================{0}[{1}]    程序{2}...", Environment.NewLine, DateTime.Now.ToString("HH:mm:ss"), enabled ? "启动" : "停止");
                    }));
                    Thread.Sleep(1000);
                }
                else if (enabled && Keyboard.Press.IsKeyDown(HotKey_Refresh))
                {
                    AppendLog("================================{0}[{1}]    程序刷新中...", Environment.NewLine, DateTime.Now.ToString("HH:mm:ss"));

                    for (var t = 1; t < backgroundWorkers.Length; ++t)
                    {
                        backgroundRefresh[t] = true;
                    }

                    Thread.Sleep(1000);

                    AppendLog("================================{0}[{1}]    程序已刷新...", Environment.NewLine, DateTime.Now.ToString("HH:mm:ss"));
                }
            }
        }

        private void Thread_KeyboardHandler()
        {
            int tid = int.Parse(Thread.CurrentThread.Name.Replace("Background Worker #", ""));
            AppendLog("[线程#{0}]    {1}开始执行循环...", tid, Thread.CurrentThread.Name);

            while (!closing)
            {
                if (backgroundStarted[tid])
                {
                    backgroundStarted[tid] = false;
                    usleep(tid, groupDatas[tid - 1].gDelay);
                }

                var total = ThreadHandler(tid);
                if (total > -1)
                {
                    usleep(tid, groupDatas[tid - 1].gInterval - total);
                }

                Thread.Sleep(10);
            }
        }

        private static void usleep(int tid, int ms)
        {
            if (ms < 10) ms = 10;

            while (ms > 0)
            {
                if (backgroundRefresh[tid])
                {
                    backgroundRefresh[tid] = false;
                    break;
                }

                if (backgroundStopped[tid])
                {
                    backgroundStopped[tid] = false;
                    break;
                }

                ms -= 10;
                Thread.Sleep(10);
            }
        }

        private int ThreadHandler(int tid)
        {
            int i = tid - 1;
            if (!enabled) return -1;
            if (!groupDatas[i].gEnabled) return -1;
            var ms = Keyboard.Press.KeyPress(groupDatas[i].gHotKey, new Random().Next(10, 50));
            AppendLog("[线程#{0}]    Pressed [{1}] using {2}ms", tid, Keyboard.CodeHelper.DXCodeToDisplay(groupDatas[i].gHotKey), ms);
            return ms;
        }

        void SetControls(bool enabled)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = enabled;
                c.Visible = enabled;
            }

            GameLog.Enabled = !enabled;
            GameLog.Visible = !enabled;

            Label_Kxnrl.Enabled = true;
            Label_Kxnrl.Visible = true;

            Text = "Kxnrl's KeyRepeater ["+ (!enabled ? "工作中" : "空闲中" ) +"]";
        }

        void AppendLog(string fmt, params object[] args)
        {
            Invoke(new Action(() =>
            {
                var text = string.Format(fmt, args);
                GameLog.Text += Environment.NewLine + text;
                GameLog.SelectionStart = GameLog.TextLength;
                GameLog.ScrollToCaret();
            }));
        }

        private void OnExited(object sender, FormClosingEventArgs e)
        {
            closing = true;
        }
    }
}

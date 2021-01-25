using JobPlayer.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;


namespace JobPlayer
{
    public partial class JobPlayer : Form
    {
        ExcuteEngine excuteEngine = new ExcuteEngine();



        public JobPlayer()
        {

            excuteEngine.init();
            excuteEngine.searchBar = new SearchBar();
            excuteEngine.jobplayer = this;
            excuteEngine.searchBar.WindowState = FormWindowState.Minimized;
            excuteEngine.searchBar.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            RegisterHotkey();
            InitializeComponent();
        }

        private void jobPlayerIcon_DoubleClick(object sender, EventArgs e)
        {
            HideOrShow_Home();
        }
        private void JobPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnregisterHotKey();
            this.Dispose();
            this.Close();
        }

        //Hot key
        #region

        #endregion


        //动态注册热键
        private void RegisterHotkey() {
            //excuteEngine.init();
            HotKey.info.Clear();
            XDocument  doc =  XDocument.Load(Environment.CurrentDirectory + "/hotkeySetting.xml");
            var hotkeys = doc.Root.XPathSelectElements("//item").ToList();
            int order = 0;            
            foreach (var item in hotkeys)
            {
                order = int.Parse(item.Attribute("order").Value);
                dynamic hotkey1 = Enum.Parse(typeof(HotKey.KeyModifiers), item.Attribute("hotkey1").Value);
                dynamic hotkey2 = Enum.Parse(typeof(Keys), item.Attribute("hotkey2").Value);
                HotKey.info.Add(order, item.Attribute("action").Value);
                HotKey.RegisterHotKey(Handle, order, hotkey1, hotkey2);
            }
        }
        //注销热键
        private void UnregisterHotKey()
        {
            foreach (var item in HotKey.info)
            {
                HotKey.UnregisterHotKey(Handle, item.Key);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    int order = m.WParam.ToInt32();
                    if (HotKey.info.ContainsKey(order))
                    {
                        string action = HotKey.info[order];
                        excuteEngine.Excute(action);
                    }
                    //switch (m.WParam.ToInt32())
                    //{
                    //    case 100:    //按下的是Ctrl+1
                    //        excuteEngine.Excute("/process:访问199");
                    //        //CmdAction.ProcessExcute("访问199");
                    //        break;
                    //    case 101:    //按下的是Ctrl+2
                    //        CmdAction.ProcessExcute("访问53");
                    //                 //此处填写快捷键响应代码
                    //        break;
                    //    case 102:   //按下的是Ctrl+Home
                    //        HideOrShow_Home();
                    //        break;
                    //    case 103:   //按下的是Ctrl+B
                    //        searchBar.HideOrShow_SearchBar();
                    //        break;
                    //}
                    break;
            }
            base.WndProc(ref m);
        }

        public  void HideOrShow_Home() {
            if(this.WindowState == FormWindowState.Minimized){
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
            else{
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            RegisterHotkey();
        }

        private void JobPlayer_Load(object sender, EventArgs e)
        {
            LoadHotkeyConfig();
            var query = excuteEngine.GetActionList().ToList();
            foreach (Keys foo in Enum.GetValues(typeof(Keys)))
            {
                 combox_hotkey2.Items.Add(foo);
            }
            foreach (var item in query)
            {
                combox_Service.Items.Add(item);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            HashSet<object> set = new HashSet<object>();
            string hotkey1, hotkey2, service;
            hotkey1 = combox_hotkey1.Text;
            hotkey2 = combox_hotkey2.Text;
            service = combox_Service.Text;

            //Judge is exist hotkey
            if (!HotKey.HotkeyManage.Add(new
            {
                hotkey1 = hotkey1,
                hotkey2 = hotkey2
            }))
            {
                MessageBox.Show(string.Format("已存在快捷键{0}+{1}", hotkey1, hotkey2));
            }
            else {
                object hotkeyConfig = new
                {
                    hotkey1 = hotkey1,
                    hotkey2 = hotkey2,
                    action = service
                };
                int order = HotKey.HotKeyList.Max(x => x.Key) + 1;
                HotKey.HotKeyList.Add(order, hotkeyConfig);
                dgv_infor.Rows.Add(order,hotkey1, hotkey2, service);
            }
        }

        private void LoadHotkeyConfig() {
            XDocument doc = XDocument.Load(Environment.CurrentDirectory + "/hotkeySetting.xml");
            var hotkeys = doc.Root.XPathSelectElements("//item");
            int order = 100;
            object hotkeyConfig;
            string hotkey1, hotkey2, action;
            foreach (XElement item in hotkeys)
            {
                order = (int)item.Attribute("order");
                hotkey1 = item.Attribute("hotkey1").Value;
                hotkey2 = item.Attribute("hotkey2").Value;
                action = item.Attribute("action").Value;
                
                hotkeyConfig = new
                {
                    hotkey1 = hotkey1,
                    hotkey2 = hotkey2,
                    action = action
                };
                if (!HotKey.HotkeyManage.Add(new
                {
                    hotkey1 = hotkey1,
                    hotkey2 = hotkey2,
                })) {
                    MessageBox.Show(string.Format("已存在快捷键{0}{1}", hotkey1, hotkey2));
                    return;
                }
                HotKey.HotKeyList.Add(order, hotkeyConfig);
                dgv_infor.Rows.Add(order,hotkey1, hotkey2, action);
            }
        }

        private void dgv_infor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete) {
                var Items = dgv_infor.SelectedRows;
                object hotkeyConfig;
                string hotkey1;
                string hotkey2;
                string action;
                int order;
                foreach (DataGridViewRow item in Items)
                {
                    order = (int)item.Cells[0].Value;
                    hotkey1 = item.Cells[1].Value.ToString();
                    hotkey2 = item.Cells[2].Value.ToString();
                    action = item.Cells[3].Value.ToString();
                    if (action.Contains("显示搜索") || action.Contains("显示主界面")) continue;                        
                    hotkeyConfig = new
                    {
                        hotkey1 = hotkey1,
                        hotkey2 = hotkey2,                        
                    };
                    HotKey.HotkeyManage.RemoveWhere(x=> ((dynamic)x).hotkey1 == hotkey1 && ((dynamic)x).hotkey2 == hotkey2);
                    HotKey.HotKeyList.Remove(order);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XDocument Content =
            new XDocument(
                new XElement("Hotkey")
            );
            XAttribute order;
            XAttribute hotkey1;
            XAttribute hotkey2;
            XAttribute action;
            XElement XmlElement;
            foreach (var item in HotKey.HotKeyList.OrderBy(x=>x.Key))
            {
                 order = new XAttribute("order", item.Key);
                 hotkey1 = new XAttribute("hotkey1", ((dynamic)item.Value).hotkey1);
                 hotkey2 = new XAttribute("hotkey2", ((dynamic)item.Value).hotkey2);
                 action = new XAttribute("action", ((dynamic)item.Value).action);
                 XmlElement = new XElement("item", order, hotkey1, hotkey2, action);
                 Content.Root.Add(XmlElement);
            }
            //2.Add element to document
            Content.Save(Environment.CurrentDirectory + "/hotkeySetting.xml");
            MessageBox.Show("保存成功，请重启软件");

        }
    }
}

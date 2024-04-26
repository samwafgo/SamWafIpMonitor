using SamWafIpMonitor.domain;
using System;

namespace SamWafIpMonitor
{
    public partial class Form1 : Form
    {
        private ListViewVirtualModeManager listViewManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listViewManager = new ListViewVirtualModeManager(this.lvLog);

            lvLog.RetrieveVirtualItem += listViewManager.RetrieveVirtualItem;
            lvLog.CacheVirtualItems += listViewManager.CacheVirtualItems;

            bgwNet.RunWorkerAsync();
        }

        private void timerFlush_Tick(object sender, EventArgs e)
        {

            flushListView();
        }
        void flushListView()
        {
            listViewManager.preClearData();
            if (cbxFilter.Checked == true)
            {
                FilterNetBean filterNet = new FilterNetBean();
                filterNet.pid = txtFilterPid.Text;
                filterNet.dstIp = txtFilterDstIp.Text;
                listViewManager.LoadNewFilter(filterNet);
            }
            else
            {
                listViewManager.LoadNew();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listViewManager.LoadNew();
        }

        private void bgwNet_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            WindivertUtils.StartInst();
        }

        private void cbxFilter_CheckedChanged(object sender, EventArgs e)
        {
            listViewManager.ClearData();
        }

        private void cbxIsScroll_CheckedChanged(object sender, EventArgs e)
        {
            listViewManager.SetScroll(cbxIsScroll.Checked);
        }

        private void cbxClear_CheckedChanged(object sender, EventArgs e)
        {
            listViewManager.SetAutoClear(cbxClear.Checked);
        }

        private void btnJumpGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "https://github.com/samwafgo/SamWafIpMonitor");
        }
    }
}

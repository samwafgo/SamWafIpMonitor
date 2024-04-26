using SamWafIpMonitor.component;
using SamWafIpMonitor.domain;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamWafIpMonitor
{
    internal class ListViewVirtualModeManager
    {
        private ListViewBuff listView;
        int index = 0; 
        bool isScoll = true;//是否滚动
        bool autoClear = true;//超量是否自动清空
        protected List<ListViewItem> ItemsSource
        {
            get;
            private set;
        } = new List<ListViewItem>();
         
        public ListViewVirtualModeManager(ListViewBuff listView)
        {
            this.listView = listView;
            this.listView.VirtualMode = true;
        }
        public void LoadNew() {
            //ItemsSource.Clear();
            int counter = 0;
            while (GlobalData.queueNetBeanLogs.Count>0)
            {
                var item = GlobalData.queueNetBeanLogs.Dequeue();
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = index.ToString();
                lvItem.SubItems.Add(item.nowTime.ToString());
                lvItem.SubItems.Add(item.pid);
                lvItem.SubItems.Add(item.title);
                lvItem.SubItems.Add(item.srcIp.ToString());
                lvItem.SubItems.Add(item.dstIp.ToString());
                lvItem.SubItems.Add(item.dstPort.ToString());
                lvItem.SubItems.Add(item.path.ToString());
                lvItem.Tag = item;
                ItemsSource.Add(lvItem);
                index++;
                counter ++;
            }  
            listView.VirtualListSize = ItemsSource.Count; // 设置虚拟列表的大小
            listView.Invalidate();
            if (isScoll) {
                jumpBottom();
            }
           
        }
        private void jumpBottom() {
            //滚动到最底部
            if (this.listView.Items.Count > 1)
            {
                listView.Items[this.listView.Items.Count - 1].EnsureVisible();
            }
        }
        public void SetAutoClear(bool autoClear) {
            this.autoClear = autoClear;
        }
        public void SetScroll(bool isScroll) {
            this.isScoll = isScroll;
        }
        public void ClearData() {
            listView.VirtualListSize = 0;
            ItemsSource.Clear();
            index = 0;
        }
        public void LoadNewFilter(FilterNetBean filterNetBean)
        {
            List<NetBeanLog> tempNetBeanList = new List<NetBeanLog>();


            while (GlobalData.queueNetBeanLogs.Count > 0)
            {
                var item = GlobalData.queueNetBeanLogs.Dequeue();
                tempNetBeanList.Add(item); 
            }
             
            int counter = 0;
            var results = tempNetBeanList.Where(p =>
            p.pid.Contains(filterNetBean.pid) && 
            p.srcIp.Contains(filterNetBean.srcIp)&&
            p.dstIp.Contains(filterNetBean.dstIp)&&
            p.dstPort.Contains(filterNetBean.dstPort)
            );

            foreach (var item in results)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = index.ToString();
                lvItem.SubItems.Add(item.nowTime.ToString());
                lvItem.SubItems.Add(item.pid);
                lvItem.SubItems.Add(item.title);
                lvItem.SubItems.Add(item.srcIp.ToString());
                lvItem.SubItems.Add(item.dstIp.ToString());
                lvItem.SubItems.Add(item.dstPort.ToString());
                lvItem.SubItems.Add(item.path.ToString());
                lvItem.Tag = item;
                ItemsSource.Add(lvItem);
                counter++;
                index++;
            } 

            listView.VirtualListSize = ItemsSource.Count; // 设置虚拟列表的大小
            listView.Invalidate();
            if (isScoll)
            {
                jumpBottom();
            }
        }

        public void RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (ItemsSource.Count == 0 || e.ItemIndex>=ItemsSource.Count)
            {
                return;
            }
            e.Item = ItemsSource[e.ItemIndex]; 
        }

        public void CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            // 这里可以预先加载数据，提高滚动性能
        }

        public void preClearData() { 
            if (ItemsSource.Count > 100000)
            {
                ClearData();
            }
        }
    }
}

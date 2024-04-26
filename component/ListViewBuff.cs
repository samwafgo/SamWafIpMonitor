using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamWafIpMonitor.component
{
    internal class ListViewBuff : System.Windows.Forms.ListView
    {
        public ListViewBuff()
        {
            this.SetStyle(                                //设置控件的样式和行为
            ControlStyles.DoubleBuffer |                   //绘制在缓冲区中进行，完成后将结果输出到屏幕上。双重缓冲区可防止由控件重绘引起的闪烁
            ControlStyles.OptimizedDoubleBuffer |          //控件首先在缓冲区中绘制，而不是直接绘制到屏幕上，这样可以减少闪烁
            ControlStyles.AllPaintingInWmPaint, true);     //控件将忽略WM_ERASEBKGND（当窗口背景必须被擦除时 例如窗口改变大小时）窗口消息以减少闪烁
            UpdateStyles();                               //更新控件的样式和行为
        }
    }
}

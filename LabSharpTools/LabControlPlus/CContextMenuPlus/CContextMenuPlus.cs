using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
    public class CContextMenuPlus
	{
        /// <summary>
		/// 添加子菜单
		/// </summary>
		/// <param name="text">要显示的文字，如果为 - 则显示为分割线</param>
		/// <param name="cms">要添加到的子菜单集合</param>
		/// <param name="callback">点击时触发的事件</param>
		/// <returns>生成的子菜单，如果为分隔条则返回null</returns>
		public static ToolStripMenuItem AddContextMenu(string text, ToolStripItemCollection cms, EventHandler callback)
        {
            if (text == "-")
            {
                ToolStripSeparator tsp = new ToolStripSeparator();
                cms.Add(tsp);
                return null;
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(text);
                if (callback != null)
                {
                    tsmi.Click += callback;
                }
                cms.Add(tsmi);
                return tsmi;
            }
            return null;
        }
    }
}

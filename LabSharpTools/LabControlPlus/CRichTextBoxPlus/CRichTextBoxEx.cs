using System;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
	/// <summary>
	/// 功能拓展
	/// </summary>
	public class CRichTextBoxEx : RichTextBox
	{
		#region 变量定义

		/// <summary>
		///
		/// </summary>
		private ContextMenuStrip userContextMenuStrip = new ContextMenuStrip();

		#endregion 变量定义

		#region 属性定义
		
		#endregion

		#region 构造函数

		/// <summary>
		///
		/// </summary>
		public CRichTextBoxEx() : base()
		{

			//设置控件风格
			this.SetStyle(ControlStyles.AllPaintingInWmPaint |  //全部在窗口绘制消息中绘图
							ControlStyles.OptimizedDoubleBuffer,    //使用双缓冲
							true
						);

			//加载contextMenuTrip的子项---消息显示的清楚和
			ToolStripItem tsItem;
			this.ContextMenuStrip=this.userContextMenuStrip;

			//---添加清除消息的功能
			tsItem = CContextMenuPlus.AddContextMenu("清除", this.userContextMenuStrip.Items, new EventHandler(this.Delete_Click));
			tsItem = CContextMenuPlus.AddContextMenu("复制", this.userContextMenuStrip.Items, new EventHandler(this.Copy_Click));
			tsItem = CContextMenuPlus.AddContextMenu("粘贴", this.userContextMenuStrip.Items, new EventHandler(this.Paste_Click));
			tsItem = CContextMenuPlus.AddContextMenu("剪切", this.userContextMenuStrip.Items, new EventHandler(this.Cut_Click));

			this.ContextMenuStrip.Width=64;
		}

		#endregion 构造函数

		#region 事件定义

		/// <summary>
		/// 删除操作
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Delete_Click(object sender, EventArgs e)
		{
			this.Clear();
        }

		/// <summary>
		/// 复制操作
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Copy_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetDataObject(this.SelectedText, true);
			}
			catch
			{
				return;
			}
		}

		/// <summary>
		/// 粘贴操作
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Paste_Click(object sender, EventArgs e)
		{
			if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
			{
				this.Paste();
			}
		}

		/// <summary>
		/// 剪切操作
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Cut_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetDataObject(this.SelectedText);
				this.SelectedText = "";
			}
			catch
			{
				return;
			}
		}

		#endregion 事件定义
	}
}
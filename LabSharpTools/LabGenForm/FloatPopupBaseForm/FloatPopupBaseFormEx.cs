using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools
{
	public partial class FloatPopupBaseFormEx : Form
	{
		#region 变量定义

		/// <summary>
		/// 鼠标消息筛选器
		/// </summary>
		//由于本窗体为WS_CHILD，所以不会收到在窗体以外点击鼠标的消息
		//该消息筛选器的作用就是让本窗体获知鼠标点击情况，进而根据鼠标是否在本窗体以外的区域点击，做出相应处理
		private MouseMessageFilter defaultMousMessageFilter = null;

		/// <summary>
		/// 指示本窗体是否已ShowDialog过
		/// </summary>
		//由于多次ShowDialog会使OnLoad/OnShown重入，故需设置此标记以供重入时判断
		private bool defaultIsShowDialogAgain = false;

		//===边框相关字段
		private BorderStyle defaultBorderType = BorderStyle.Fixed3D;
		private Border3DStyle defaultBorder3DStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
		private ButtonBorderStyle defaultBorderSingleStyle = ButtonBorderStyle.Solid;
		private Color defaultBorderColor = Color.DarkGray;

		#endregion

		#region 属性定义

		/// <summary>
		/// 获取或设置边框类型
		/// </summary>
		[Description("获取或设置边框类型。")]
		[DefaultValue(BorderStyle.Fixed3D)]
		public BorderStyle BorderType
		{
			get
			{
				return this.defaultBorderType;
			}
			set
			{
				if (this.defaultBorderType == value)
				{
					return;
				}
				else
				{
					this.defaultBorderType = value;
					this.Invalidate();
				}
			}
		}

		/// <summary>
		/// 获取或设置三维边框样式
		/// </summary>
		[Description("获取或设置三维边框样式。")]
		[DefaultValue(Border3DStyle.RaisedInner)]
		public Border3DStyle Border3DStyle
		{
			get
			{
				return this.defaultBorder3DStyle;
			}
			set
			{
				if (this.defaultBorder3DStyle == value)
				{
					return;
				}
				else
				{
					this.defaultBorder3DStyle = value;
					this.Invalidate();
				}
			}
		}

		/// <summary>
		/// 获取或设置线型边框样式
		/// </summary>
		[Description("获取或设置线型边框样式。")]
		[DefaultValue(ButtonBorderStyle.Solid)]
		public ButtonBorderStyle BorderSingleStyle
		{
			get
			{
				return this.defaultBorderSingleStyle;
			}
			set
			{
				if (this.defaultBorderSingleStyle == value)
				{
					return;
				}
				else
				{
					this.defaultBorderSingleStyle = value;
					this.Invalidate();
				}
			}
		}

		/// <summary>
		/// 获取或设置边框颜色（仅当边框类型为线型时有效）
		/// </summary>
		[Description("获取或设置边框颜色（仅当边框类型为线型时有效）。")]
		[DefaultValue(typeof(Color), "DarkGray")]
		public Color BorderColor
		{
			get
			{
				return this.defaultBorderColor;
			}
			set
			{
				if (this.defaultBorderColor == value)
				{
					return;
				}
				else
				{
					this.defaultBorderColor = value;
					this.Invalidate();
				}
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public FloatPopupBaseFormEx()
		{
			InitializeComponent();

			//初始化基类属性
			this.InitBaseProperties();

			//初始化边框相关
			this.defaultBorderType = BorderStyle.Fixed3D;
			this.defaultBorder3DStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
			this.defaultBorderSingleStyle = ButtonBorderStyle.Solid;
			this.defaultBorderColor = Color.DarkGray;

			//初始化消息筛选器。添加和移除在显示/隐藏时负责
			this.defaultMousMessageFilter = new MouseMessageFilter(this);
		}

		#endregion

		#region 析构函数

		/// <summary>
		/// 
		/// </summary>
		~FloatPopupBaseFormEx()
		{
			if (this.Visible)
			{
				this.Hide();
			}
			if (this.defaultMousMessageFilter != null)
			{
				GC.SuppressFinalize(this.defaultMousMessageFilter);
			}
			//---释放资源
			this.Dispose(true);
		}

		#endregion

		#region 公有函数
		/// <summary>
		/// 显示为模式窗体
		/// </summary>
		/// <param name="control">显示在该控件下方</param>
		public DialogResult ShowDialog(Control control)
		{
			return this.ShowDialog(control, 0, control.Height);
		}

		/// <summary>
		/// 显示为模式窗体
		/// </summary>
		/// <param name="control">触发弹出窗体的控件</param>
		/// <param name="offsetX">相对control水平偏移</param>
		/// <param name="offsetY">相对control垂直偏移</param>
		public DialogResult ShowDialog(Control control, int offsetX, int offsetY)
		{
			return this.ShowDialog(control, new Point(offsetX, offsetY));
		}

		/// <summary>
		/// 显示为模式窗体
		/// </summary>
		/// <param name="control">触发弹出窗体的控件</param>
		/// <param name="offset">相对control偏移</param>
		public DialogResult ShowDialog(Control control, Point offset)
		{
			return this.ShowDialogInternal(control, offset);
		}

		/// <summary>
		/// 显示为模式窗体
		/// </summary>
		/// <param name="item">显示在该工具栏项的下方</param>
		public DialogResult ShowDialog(ToolStripItem item)
		{
			return this.ShowDialog(item, 0, item.Height);
		}

		/// <summary>
		/// 显示为模式窗体
		/// </summary>
		/// <param name="item">触发弹出窗体的工具栏项</param>
		/// <param name="offsetX">相对item水平偏移</param>
		/// <param name="offsetY">相对item垂直偏移</param>
		public DialogResult ShowDialog(ToolStripItem item, int offsetX, int offsetY)
		{
			return this.ShowDialog(item, new Point(offsetX, offsetY));
		}

		/// <summary>
		/// 显示为模式窗体
		/// </summary>
		/// <param name="item">触发弹出窗体的工具栏项</param>
		/// <param name="offset">相对item偏移</param>
		public DialogResult ShowDialog(ToolStripItem item, Point offset)
		{
			return this.ShowDialogInternal(item, offset);
		}

		/// <summary>
		/// 显示窗体
		/// </summary>
		/// <param name="control">显示在该控件下方</param>
		public void Show(Control control)
		{
			this.Show(control, 0, control.Height);
		}

		/// <summary>
		/// 显示窗体
		/// </summary>
		/// <param name="control">触发弹出窗体的控件</param>
		/// <param name="offsetX">相对control水平偏移</param>
		/// <param name="offsetY">相对control垂直偏移</param>
		public void Show(Control control, int offsetX, int offsetY)
		{
			this.Show(control, new Point(offsetX, offsetY));
		}

		/// <summary>
		/// 显示窗体
		/// </summary>
		/// <param name="control">触发弹出窗体的控件</param>
		/// <param name="offset">相对control偏移</param>
		public void Show(Control control, Point offset)
		{
			this.ShowInternal(control, offset);
		}

		/// <summary>
		/// 显示窗体
		/// </summary>
		/// <param name="item">显示在该工具栏下方</param>
		public void Show(ToolStripItem item)
		{
			this.Show(item, 0, item.Height);
		}

		/// <summary>
		/// 显示窗体
		/// </summary>
		/// <param name="item">触发弹出窗体的工具栏项</param>
		/// <param name="offsetX">相对item水平偏移</param>
		/// <param name="offsetY">相对item垂直偏移</param>
		public void Show(ToolStripItem item, int offsetX, int offsetY)
		{
			this.Show(item, new Point(offsetX, offsetY));
		}

		/// <summary>
		/// 显示窗体
		/// </summary>
		/// <param name="item">触发弹出窗体的工具栏项</param>
		/// <param name="offset">相对item偏移</param>
		public void Show(ToolStripItem item, Point offset)
		{
			this.ShowInternal(item, offset);
		}

		#endregion

		#region 保护函数

		/// <summary>
		/// 
		/// </summary>
		protected override sealed CreateParams CreateParams
		{
			get
			{
				CreateParams prms = base.CreateParams;

				//prms.Style = 0;
				//prms.Style |= -2147483648;	//WS_POPUP
				prms.Style |= 0x40000000;		//WS_CHILD  重要，只有CHILD窗体才不会抢父窗体焦点
				prms.Style |= 0x4000000;		//WS_CLIPSIBLINGS
				prms.Style |= 0x10000;			//WS_TABSTOP
				prms.Style &= ~0x40000;			//WS_SIZEBOX       去除
				//prms.Style &= ~0x800000;			//WS_BORDER        去除
				//prms.Style |= 0x400000;			//WS_DLGFRAME      去除
				prms.Style &= ~0x20000;		//WS_MINIMIZEBOX   去除
				prms.Style &= ~0x10000;		//WS_MAXIMIZEBOX   去除
				prms.ExStyle = 0;
				//prms.ExStyle |= 0x1;         //WS_EX_DLGMODALFRAME 立体边框
				//prms.ExStyle |= 0x8;         //WS_EX_TOPMOST
				prms.ExStyle |= 0x10000;       //WS_EX_CONTROLPARENT
				//prms.ExStyle |= 0x80;        //WS_EX_TOOLWINDOW
				//prms.ExStyle |= 0x100;       //WS_EX_WINDOWEDGE
				//prms.ExStyle |= 0x8000000;   //WS_EX_NOACTIVATE
				//prms.ExStyle |= 0x4;         //WS_EX_NOPARENTNOTIFY

				return prms;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			//防止重入
			if (this.defaultIsShowDialogAgain)
			{
				return;
			}

			//需得减掉两层边框宽度，运行时尺寸才与设计时完全相符，原因不明
			//确定与ControlBox、FormBorderStyle有关，但具体联系不明
			if (!DesignMode)
			{
				Size size = SystemInformation.FrameBorderSize;
				//不可以用ClientSize，后者会根据窗口风格重新调整Size
				this.Size -= size + size;
			}
			base.OnLoad(e);
		}

		/// <summary>
		/// 显示
		/// </summary>
		/// <param name="e"></param>
		protected override void OnShown(EventArgs e)
		{
			//防止重入
			if (this.defaultIsShowDialogAgain)
			{
				return;
			}

			//在OnShown中为首次ShowDialog设标记
			if (this.Modal)
			{
				this.defaultIsShowDialogAgain = true;
			}

			if (!DesignMode)
			{
				//激活首控件
				Control firstControl;
				if ((firstControl = this.GetNextControl(this, true)) != null)
				{
					firstControl.Focus();
				}
			}
			base.OnShown(e);
		}

		/// <summary>
		/// 消息处理
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
		{
			//当本窗体作为ShowDialog弹出时，在收到WM_SHOWWINDOW前，Owner会被Disable
			//故需在收到该消息后立即Enable它，不然Owner窗体和本窗体都将处于无响应状态
			if (m.Msg == 0x18 && m.WParam != IntPtr.Zero && m.LParam == IntPtr.Zero
				&& Modal && this.Owner != null && !this.Owner.IsDisposed)
			{
				if (this.Owner.IsMdiChild)
				{
					//当Owner是MDI子窗体时，被Disable的是MDI主窗体
					//并且Parent也会指向MDI主窗体，故需改回为Owner，这样弹出窗体的Location才会相对于Owner而非MDIParent
					NativeMethods.EnableWindow(this.Owner.MdiParent.Handle, true);
					//只能用API设置Parent，因为模式窗体是TopLevel，.Net拒绝为顶级窗体设置Parent
					NativeMethods.SetParent(this.Handle, this.Owner.Handle);
				}
				else
				{
					NativeMethods.EnableWindow(Owner.Handle, true);
				}
			}
			base.WndProc(ref m);
		}

		/// <summary>
		/// 画边框
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			//---绘制3D边框
			if (this.defaultBorderType == BorderStyle.Fixed3D)
			{
				ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, this.defaultBorder3DStyle);
			}
			//---绘制线型边框
			else if (this.defaultBorderType == BorderStyle.FixedSingle)
			{
				ControlPaint.DrawBorder(e.Graphics, ClientRectangle, this.defaultBorderColor, this.defaultBorderSingleStyle);
			}
			else
			{

				ControlPaint.DrawBorder(e.Graphics, ClientRectangle, this.defaultBorderColor, ButtonBorderStyle.Solid);
			}
		}

		/// <summary>
		/// 显示后添加鼠标消息筛选器以开始捕捉，隐藏时则移除筛选器。之所以不放Dispose中是想尽早移除筛选器
		/// </summary>
		/// <param name="e"></param>
		protected override void OnVisibleChanged(EventArgs e)
		{
			if (!DesignMode)
			{
				if (Visible)
				{
					Application.AddMessageFilter(this.defaultMousMessageFilter);
				}
				else
				{
					Application.RemoveMessageFilter(this.defaultMousMessageFilter);
				}
			}
			base.OnVisibleChanged(e);
		}

		/// <summary>
		/// 实现窗体客户区拖动
		/// 在WndProc中实现这个较麻烦，所以放到这里做
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			//让鼠标点击客户区时达到与点击标题栏一样的效果，以此实现客户区拖动
			NativeMethods.ReleaseCapture();
			NativeMethods.SendMessage(this.Handle, 0xA1/*WM_NCLBUTTONDOWN*/, (IntPtr)2/*CAPTION*/, IntPtr.Zero);
			base.OnMouseDown(e);
		}
		#endregion

		#region 私有函数

		/// <summary>
		/// ShowDialog内部方法
		/// </summary>
		private DialogResult ShowDialogInternal(Component controlOrItem, Point offset)
		{
			//快速连续弹出本窗体将有可能遇到尚未Hide的情况下再次弹出，这会引发异常，故需做处理
			if (this.Visible)
			{
				return System.Windows.Forms.DialogResult.None;
			}

			if (base.Visible)
			{
				return System.Windows.Forms.DialogResult.None;
			}

			if (this.defaultIsShowDialogAgain == true)
			{
				return System.Windows.Forms.DialogResult.None;
			}

			this.SetLocationAndOwner(controlOrItem, offset);
			//---延时等待句柄的获取，暂时不知道怎么优化，频繁的操作控件，这里会发生崩溃
			//---调试发现，如果再这里等待，发生崩溃的现象减少
			LabGenFunc.CGenFuncDelay.GenFuncDelayms(150);
			//---返回结果
			DialogResult _return = DialogResult.None;
			try
			{
				//---委托调用
				if (this.InvokeRequired)
				{
					this.Invoke((EventHandler)
						(delegate
						{
							_return = base.ShowDialog();
						}
						)
						);
				}
				else
				{
					_return = base.ShowDialog();
				}
			}
			catch
			{
				_return = DialogResult.None;
			}
			return _return;
		}

		/// <summary>
		/// Show内部方法
		/// </summary>
		private void ShowInternal(Component controlOrItem, Point offset)
		{
			//原因见ShowDialogInternal
			if (this.Visible)
			{
				return;
			}
			if (base.Visible)
			{
				return;
			}

			this.SetLocationAndOwner(controlOrItem, offset);
			base.Show();
		}

		/// <summary>
		/// 设置坐标及所有者
		/// </summary>
		/// <param name="controlOrItem">控件或工具栏项</param>
		/// <param name="offset">相对偏移</param>
		private void SetLocationAndOwner(Component controlOrItem, Point offset)
		{
			Point pt = Point.Empty;

			if (controlOrItem is ToolStripItem)
			{
				ToolStripItem item = (ToolStripItem)controlOrItem;
				pt.Offset(item.Bounds.Location);
				controlOrItem = item.Owner;
			}

			Control c = (Control)controlOrItem;
			pt.Offset(this.GetControlLocationInForm(c));
			pt.Offset(offset);
			this.Location = pt;

			//设置Owner属性与Show[Dialog](Owner)有不同，当Owner是MDIChild时，后者会改Owner为MDIParent
			this.Owner = c.FindForm();
		}

		/// <summary>
		/// 获取控件在窗体中的坐标
		/// </summary>
		private Point GetControlLocationInForm(Control c)
		{
			Point pt = c.Location;
			while (!((c = c.Parent) is Form))
			{
				pt.Offset(c.Location);
			}
			return pt;
		}

		#endregion

		#region 事件函数


		/// <summary>
		/// 检查是否需要隐藏
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckToHide(object sender, EventArgs e)
		{
			if (this.Visible == false)
			{
				return;
			}
			if (base.Visible == false)
			{
				return;
			}
			this.Hide();
		}


		#endregion

		#region 屏蔽对本类影响重大的基类方法和属性

		/// <summary>
		/// 初始化部分基类属性
		/// </summary>
		private void InitBaseProperties()
		{
			// base.ControlBox = false;                           //重要
			//必须得是SizableToolWindow才能支持调整大小的同时，不受SystemInformation.MinWindowTrackSize的限制
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Text = string.Empty;                          //重要
			base.HelpButton = false;
			base.IsMdiContainer = false;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.Manual;     //重要
			base.TopMost = false;
			base.WindowState = FormWindowState.Normal;

			this.Leave += new EventHandler(this.CheckToHide);
			this.Deactivate += new System.EventHandler(this.CheckToHide);

		}

		/// <summary>
		/// 屏蔽原方法
		/// </summary>
		/// <returns></returns>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("请使用别的重载！", true)]
		public new DialogResult ShowDialog()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="owner"></param>
		/// <returns></returns>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("请使用别的重载！", true)]
		public new DialogResult ShowDialog(IWin32Window owner)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("请使用别的重载！", true)]
		public new void Show()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="owner"></param>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("请使用别的重载！", true)]
		public new void Show(IWin32Window owner)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("设置边框请使用Border相关属性！", true)]
		public new FormBorderStyle FormBorderStyle
		{
			get
			{
				return System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			}
			set
			{
			}
		}

		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("禁用该属性！", true)]
		public new bool HelpButton
		{
			get
			{
				return false;
			}
			set
			{
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("禁用该属性！", true)]
		public new bool IsMdiContainer
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("禁用该属性！", true)]
		public new bool MaximizeBox
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("禁用该属性！", true)]
		public new bool MinimizeBox
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("禁用该属性！", true)]
		public new bool ShowInTaskbar
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("禁用该属性！", true)]
		public new FormStartPosition StartPosition
		{
			get
			{
				return FormStartPosition.Manual;
			}
			set
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("禁用该属性！", true)]
		public new bool TopMost
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("禁用该属性！", true)]
		public new FormWindowState WindowState
		{
			get
			{
				return FormWindowState.Normal;
			}
			set
			{
			}
		}

		#endregion

		/// <summary>
		/// 程序鼠标消息筛选器
		/// </summary>
		private class MouseMessageFilter : IMessageFilter
		{
			#region 变量定义
			/// <summary>
			/// 
			/// </summary>
			private FloatPopupBaseFormEx defaultFloatPopupForm = null;

			#endregion

			#region 属性定义

			#endregion

			#region 构造函数

			/// <summary>
			/// 
			/// </summary>
			/// <param name="foatPopupBaseForm"></param>
			public MouseMessageFilter(FloatPopupBaseFormEx foatPopupBaseForm)
			{
				this.defaultFloatPopupForm = foatPopupBaseForm;
			}

			#endregion

			#region 公有函数

			/// <summary>
			/// 
			/// </summary>
			/// <param name="m"></param>
			/// <returns></returns>
			public bool PreFilterMessage(ref Message m)
			{
				bool _return = false;
				//如果在本窗体以外点击鼠标，隐藏本窗体
				//若想在点击标题栏、滚动条等非客户区也要让本窗体消失，取消0xA1的注释即可
				//本例是根据坐标判断，亦可以改为根据句柄，但要考虑子孙控件
				//之所以用API而不用Form.DesktopBounds是因为后者不可靠
				//WM_MOUSEMOVE = 0X0200;
				if ((m.Msg == 0x201/*|| (m.Msg==0xA1)*/)
					&& this.defaultFloatPopupForm.Visible
					&& !NativeMethods.GetWindowRect(this.defaultFloatPopupForm.Handle).Contains(MousePosition))
				{
					this.defaultFloatPopupForm.Hide();//之所以不Close是考虑应该由调用者负责销毁
					_return = true;
				}

				return _return;
			}
			#endregion

			#region 保护函数

			#endregion

			#region 私有函数

			#endregion


		}

		/// <summary>
		/// API封装类
		/// </summary>
		private static class NativeMethods
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="hWnd"></param>
			/// <param name="bEnable"></param>
			/// <returns></returns>
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

			/// <summary>
			/// 
			/// </summary>
			/// <param name="hWnd"></param>
			/// <param name="Msg"></param>
			/// <param name="wParam"></param>
			/// <param name="lParam"></param>
			/// <returns></returns>
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

			/// <summary>
			/// 
			/// </summary>
			/// <returns></returns>
			[DllImport("user32.dll")]
			public static extern bool ReleaseCapture();

			/// <summary>
			/// 
			/// </summary>
			/// <param name="hWndChild"></param>
			/// <param name="hWndNewParent"></param>
			/// <returns></returns>
			[DllImport("user32.dll", SetLastError = true)]
			public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

			/// <summary>
			/// 
			/// </summary>
			/// <param name="hwnd"></param>
			/// <param name="lpRect"></param>
			/// <returns></returns>
			[DllImport("user32.dll", SetLastError = true)]
			private static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

			/// <summary>
			/// 
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			private struct RECT
			{
				public int left;
				public int top;
				public int right;
				public int bottom;

				public static explicit operator Rectangle(RECT rect)
				{
					return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
				}
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="hwnd"></param>
			/// <returns></returns>
			public static Rectangle GetWindowRect(IntPtr hwnd)
			{
				RECT rect;
				GetWindowRect(hwnd, out rect);
				return (Rectangle)rect;
			}

			[DllImport("user32.dll", ExactSpelling = true)]
			public static extern IntPtr GetAncestor(IntPtr hwnd, uint flags);
		}

	}
}

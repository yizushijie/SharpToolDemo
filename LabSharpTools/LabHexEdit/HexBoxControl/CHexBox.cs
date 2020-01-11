using Harry.LabTools.LabWinAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Harry.LabTools.LabHexEdit
{
	public partial class CHexBox : Control
	{
		#region 属性定义

		/// <summary>
		/// 系统类型
		/// </summary>
		private Boolean IsXpOr2003
		{
			get
			{
				OperatingSystem os = Environment.OSVersion;
				Version vs = os.Version;
				if (os.Platform == PlatformID.Win32NT)
				{
					if ((vs.Major == 5) && (vs.Minor != 0))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// 设置控件窗口创建参数的扩展风格
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				// Turn on WS_EX_COMPOSITED    
				cp.ExStyle |= 0x02000000;
				if (this.IsXpOr2003 == true)
				{
					// Turn on WS_EX_LAYERED  
					cp.ExStyle |= 0x00080000;
					//---设置窗体不透明度
					//this.Opacity = 1;
				}
				return cp;
			}
		}

		#endregion

		#region 构造函数

		public CHexBox()
		{
			#region	设置窗体的Style

			//---支持用户重绘窗体
			this.SetStyle(ControlStyles.UserPaint, true);

			//---在内存中先绘制界面，禁止擦除背景
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			//---双缓冲，防止绘制时抖动
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			//---双缓存
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			//---调整大小时重绘
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.UpdateStyles();

			//---初始化尺寸大小
			this.Size = new Size(600, 300);

			#endregion 构造函数

			#region 控件初始化

			//---获取控件的地址的宽度
			this.defaultYScaleWidth = this.FontWidth("0x0000", this.mFont)+this.defaultYScaleOffsetWidth;

			if (this.defaultXScaleShowBit8==XScaleShowBit8.BIT8X16)
			{
				this.defaultRowShowNum=16;
			}
			else if (this.defaultXScaleShowBit8 == XScaleShowBit8.BIT8X32)
			{
				this.defaultRowShowNum=32;
			}
			else
			{
				this.defaultRowShowNum=16;
			}
			#endregion 控件初始化

			#region 光标

			//---设置鼠标位置属性
			this.defaultMousePos=new POS();
			this.defaultMousePos.iPos=-1;
			this.defaultMousePos.iArea=-1;
			this.defaultMousePos.bLeftPos=false;
			this.defaultMousePos.bRightPos=false;

			#endregion 光标

			#region 初始化垂直滚动条

			//---初始化滑块
			this.defaultVScrollBar=new VScrollBar();
			this.defaultVScrollBar.Visible=false;
			this.defaultVScrollBar.Enabled=false;
			this.defaultVScrollBar.Width=this.defaultScrollBarWidth;
			this.defaultVScrollBar.Minimum=0;
			this.defaultVScrollBar.Maximum=0;
			this.defaultVScrollBar.Height = this.defaultScrollBarWidth*2;

			//---滑块滑动事件处理
			defaultVScrollBar.Scroll+=new ScrollEventHandler(VScrollBar_Scroll);

			//---在当前控件中添加垂直滚动条
			this.Controls.Add(defaultVScrollBar);

			#endregion 初始化垂直滚动条

			//强制设置输入法为英文输入模式
			this.ImeMode=ImeMode.Disable;
			this.AddData(256);
		}

		#endregion

		#region 析够函数

		/// <summary>
		///
		/// </summary>
		~CHexBox()
		{
			if (this.defaultIsCreateCaret)
			{
				CWinAPICaret.DestroyCaret();
			}

			GC.SuppressFinalize(this);
		}

		#endregion

		#region 窗体绘制函数

		/// <summary>
		/// 重新绘制窗体函数
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			//---设置窗体的背景色
			this.BackColor=this.defaultFontBackGroundColor;
			//设置输入焦点
			this.Focus();
			//---计算控件现实的行数
			this.defaultMaxRow = this.CalcYScaleMaxRow();
			//---显示垂直滚动条
			if ((this.defaultNowData!=null)&&(this.defaultNowData.Length!=0))
			{
				this.VScrollBarShow();
			}
			//---绘制X轴刻度
			if (this.defaultXScaleShow)
			{
				if (this.defaultXScaleStringShow==true)
				{
					this.OnPaintXScaleAll(e);
				}
				else
				{
					this.OnPaintXScale(e);
				}				
			}
			//---绘制Y轴刻度
			if (this.defaultYScaleShow)
			{
				this.OnPaintYScale(e);
			}
			//---绘制数据刻度
			this.OnPaintDataScale(e);
			//---绘制Y轴刻度选择背景
			if (this.defaultXScaleBackGroundRectangleShow)
			{
				this.OnDrawYScaleBackGroundRectangle(e);
			}
			//---绘制X轴刻度选择背景
			if (this.defaultXScaleBackGroundRectangleShow)
			{
				this.OnDrawXScaleBackGroundRectangle(e);
			}
			//---绘制船体外部线条,最后绘制，避免因为控制尺寸绘制最后一组数据的时候覆盖
			this.OnPaintExternalRectangle(e);
		}
		
		#endregion

		#region 绘制外部矩形框
		/// <summary>
		/// 绘制矩形框
		/// </summary>
		/// <param name="e"></param>
		private void OnPaintExternalRectangle(PaintEventArgs e)
		{
			//---获取二位平面的X和Y坐标
			Point[] nowPoint = { new Point(0, 0),
								 new Point(this.Width, 0),
								 new Point(this.Width, this.Height),
								 new Point(0, this.Height),
								 new Point(0, 0)
								};
			//---画笔
			Pen nowPen = new Pen(this.defaultExternalLineColor, this.defaultExternalLineWidth);
			//---绘制线条
			e.Graphics.DrawLines(nowPen, nowPoint);
		}
		#endregion

		#region 滚动滑块的处理

		/// <summary>
		/// 垂直滚动条处理函数
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="e"></param>
		private void VScrollBar_Scroll(object obj, ScrollEventArgs e)
		{
			//---当前行号号滑块的值
			if (this.defaultRowNowNum!=e.NewValue)
			{
				this.defaultRowNowNum=e.NewValue;
				//---判断光标是否隐藏
				if (this.defaultIsHideCaret==false)
				{
					//---隐藏光标
					this.OnHideCaret();
					this.defaultIsHideCaret=true;
				}
				//---复位鼠标信息
				this.defaultMousePos.iPos=-1;
				this.defaultMousePos.iArea=-1;
				this.defaultMousePos.bLeftPos=false;
				this.defaultMousePos.bRightPos=false;
				//---绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 垂直滚动条显示函数
		/// </summary>
		private void VScrollBarShow()
		{
			//---获取字体大小信息
			SizeF fontSizef = this.FontSize();
			int fontWidth = (int)fontSizef.Width;
			int fontHeight = (int)fontSizef.Height;
			//---计算当前控件能够显示的最大行数
			int iMaxRowCount = this.defaultMaxRow;//this.CalcYScaleMaxRow();
			//---计算数据需要显示的行数
			int iTotalRowCount = this.CalcYScaleTotalRow()+1;
			//---当前位置
			if (iTotalRowCount>iMaxRowCount)
			{
				this.defaultVScrollBar.Visible=true;
				this.defaultVScrollBar.Enabled=true;
				//---设置控件位置
				this.defaultVScrollBar.Location=new Point((this.Width-this.defaultExternalLineWidth - this.defaultScrollBarWidth), this.defaultExternalLineWidth);
				//---控件尺寸
				this.defaultVScrollBar.Size=new Size(this.defaultScrollBarWidth, (this.Height-this.defaultExternalLineWidth * 2));
				//---设置控件的最大值
				this.defaultVScrollBar.LargeChange=1;
				this.defaultVScrollBar.Maximum=iTotalRowCount-iMaxRowCount;
			}
			else
			{
				this.defaultVScrollBar.Visible=false;
				this.defaultVScrollBar.Enabled=false;
			}
		}

		#endregion

		#region 输入符位置处理

		/// <summary>
		/// 查找输入符
		/// </summary>
		public void OnFindCaret()
		{
			//---获取焦点
			this.Focus();
			this.defaultIsCreateCaret=false;
			//---判断选中行是否合法
			if (this.defaultRowSelectedNum==-1)
			{
				return;
			}
			//---数据选择的列号
			int currentColumn = this.CalcXScaleColIndex();
			//---判断当前列号是否合法
			if (currentColumn==-1)
			{
				return;
			}
			//---计算宽度
			int fontWidth = this.FontWidth();
			//---计算字体的高度
			int fontHeight = this.FontHeigth();
			//---当前起始位置
			Point pointA = this.CalcDataScalePoint();
			if (this.defaultMousePos.bLeftPos)
			{
				pointA.X = pointA.X + currentColumn * (fontWidth + this.defaultRowStaffWidth) + (fontWidth) / 2;
			}
			if (this.defaultMousePos.bRightPos)
			{
				pointA.X=pointA.X+currentColumn*(fontWidth+this.defaultRowStaffWidth)+fontWidth;
			}
			pointA.Y+=(this.defaultRowSelectedNum)*(fontHeight+this.defaultColStaffWidth);
			//---显示输入符
			this.OnCreateCaret();
			//---设置输入符的位置
			//CWinAPICaret.SetCaretPos(pointA.X, pointA.Y+1);
			CWinAPICaret.SetCaretPos((pointA.X - this.defaultCaretXOffset), (pointA.Y + this.defaultCaretYOffset));
			//---显示输入符
			CWinAPICaret.ShowCaret(this.Handle);
		}

		/// <summary>
		/// 隐藏光标,,并设置相关位置
		/// </summary>
		private void OnHideCaret()
		{
			if (!this.defaultIsHideCaret)
			{
				CWinAPICaret.HideCaret(this.Handle);
				this.defaultIsHideCaret=true;
			}
			this.defaultMousePos.iPos=-1;
			this.defaultMousePos.iArea=-1;
			this.defaultMousePos.bLeftPos=false;
			this.defaultMousePos.bRightPos=false;
		}

		/// <summary>
		/// 创建光标
		/// </summary>
		private void OnCreateCaret()
		{
			//---获取焦点
			this.Focus();
			//float size = 0.0f;
			//如果没有创建Caret，则创建
			if (!this.defaultIsCreateCaret)
			{
				this.defaultIsCreateCaret = true;
				CWinAPICaret.CreateCaret(this.Handle, IntPtr.Zero, (int)(this.defaultFont.Size), this.defaultFont.Height + this.defaultColStaffWidth);
			}
			if (this.Visible == false)
			{
				this.defaultIsCreateCaret = false;
			}
		}

		#endregion

		#region 消息处理

		/// <summary>
		/// 消息处理函数
		/// 该函数不处理WM_ERASEBKGRND消息
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
		{
			if (m.Msg==0x00000014)
			{
				return;
			}
			base.WndProc(ref m);
		}

		#endregion

		#region 按键处理------对输入的按键值处理

		/// <summary>
		/// 处理键盘输入键消息
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (this.defaultMousePos.iPos!=-1&&this.defaultMousePos.iArea!=-1)
			{
				if (((keyData>=Keys.D0)&&(keyData<=Keys.F))||(keyData>=Keys.NumPad0&&keyData<=Keys.NumPad9))
				{
					//---设置焦点
					this.Focus();
					int c = 0;
					int b = 0;
					if (this.defaultMousePos.iPos<this.mNowData.Length)
					{
						if (this.defaultMousePos.bLeftPos)
						{
							c=(byte)(this.mNowData[defaultMousePos.iPos]&0x0F);
							b=this.GetKeyBoardInput((byte)keyData);
						}
						if (this.defaultMousePos.bRightPos)
						{
							b=(byte)((this.mNowData[defaultMousePos.iPos]&0xF0)>>4);
							c=this.GetKeyBoardInput((byte)keyData);
						}
						this.mNowData[defaultMousePos.iPos]=(byte)((b<<4)|c);

						//光标向右移动
						this.OnCaretMove_Right();
					}
				}
				else
				{
					switch (keyData)
					{
						case Keys.Up:
							this.OnCaretMove_Up();
							break;

						case Keys.Down:
							this.OnCaretMove_Down();
							break;

						case Keys.Left:
							this.OnCaretMove_Left();
							break;

						case Keys.Right:
							this.OnCaretMove_Right();
							break;

						case Keys.Enter:
							string temp = keyData.ToString();
							break;
					}
				}
				return true;

				//不做基类的处理，不然在有多个控件的时候会发生问题
				//return base.ProcessCmdKey( ref msg, keyData );
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 获取键盘的输入值
		/// 16进制的数据和数字小键盘的数据
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		private byte GetKeyBoardInput(byte b)
		{
			if ('0'<=b&&b<='9')
			{
				return (byte)(b-'0');
			}
			else if ('A'<=b&&b<='F')
			{
				return (byte)(b-'A'+10);
			}
			else if (97<=b&&b<=105)
			{
				return (byte)(b-97+1);
			}
			else
			{
				return 0;
			}
		}

		#endregion

		#region 鼠标的操作

		/// <summary>
		/// 鼠标按下的处理-----用于获取光标的位置------显示光标的信息
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((this.defaultNowData==null)||(this.defaultNowData.Length==0))
			{
				return;
			}
			else
			{
				if (e.Button==MouseButtons.Left)
				{
					//---获取焦点
					this.Focus();

					//---记录鼠标的坐标
					Point mousePoint = new Point(e.X, e.Y);
					//---获取地址栏的起始位置
					Point pointA = this.CalcYScalePoint();
					//---计算字体的宽度
					int fontWidth = this.FontWidth();
					//---计算字体的高度
					int fontHeight = this.FontHeigth();
					//---计算当前控件能够显示的最大行数
					int iMaxRowCount = this.defaultMaxRow;//this.CalcYScaleMaxRow();
					//---计算数据需要显示的行数
					int iTotalRowCount = this.defaultTotalRow;// this.CalcYScaleTotalRow();
					//---判断鼠标左键是否是右侧的空白位置
					if ((mousePoint.X<this.defaultDataStartHeight)||(mousePoint.X>(this.defaultDataStartWidth-10)))
					{
						return;
					}

					//---判定是否在当前行中
					Rectangle nowRectangle = new Rectangle();

					Region nowRegion;

					//---高度
					int iHeight = pointA.Y;

					#region 鼠标位于地址区域	-----获取当前选中的行号

					for (int ix = this.defaultRowNowNum ; ix<this.defaultRowNowNum+iMaxRowCount ; ix++)
					{
						if (iTotalRowCount<=ix)
						{
							//---表明没有选中行
							this.defaultRowSelectedNum=-1;
							break;
						}
						else
						{
							//---计算矩形区域的尺寸
							nowRectangle.X=pointA.X;
							nowRectangle.Y=iHeight;
							nowRectangle.Width=this.Width-this.defaultExternalLineWidth;
							nowRectangle.Height=fontHeight+this.defaultColStaffWidth;

							//---指示由矩形和由路径构成的图形形状的内部
							nowRegion=new Region(nowRectangle);

							//---判断是否找到光标的位置
							if (nowRegion.IsVisible(mousePoint))
							{
								//---表明选中了某一行
								this.defaultRowSelectedNum=ix-this.defaultRowNowNum;

								//---重新绘制控件
								this.Invalidate();
								break;
							}
							iHeight+=fontHeight+this.defaultColStaffWidth;
						}
					}

					//---判断是否是本行被选中
					if (this.defaultRowSelectedNum==-1)
					{
						//---没有选中行
						return;
					}
					#endregion

					#region 鼠标位于数据区域-----用于创建光标

					Point poinaB;

					int dataOffset = 0;

					if (this.defaultYScaleShow)
					{
						dataOffset=this.defaultExternalLineWidth / 2+this.defaultYScaleWidth;
					}
					else
					{
						dataOffset=this.defaultExternalLineWidth / 2;
					}
					poinaB=new Point(dataOffset, pointA.Y);

					//---计算位置
					nowRectangle.X=poinaB.X;
					nowRectangle.Y=poinaB.Y+this.defaultRowSelectedNum*(fontHeight+this.defaultColStaffWidth);
					nowRectangle.Width=this.defaultRowShowNum*(this.defaultRowStaffWidth+fontWidth);

					nowRectangle.Height=fontHeight+this.defaultColStaffWidth;

					//---断鼠标左键是否是左侧的空白位置
					if (mousePoint.X<this.defaultDataEndWidth)
					{
						//---创建光标
						this.OnCreateCaret();
						//---设置光标
						CWinAPICaret.SetCaretPos((this.defaultDataEndWidth+8), (nowRectangle.Y+this.defaultCaretYOffset/2));
						//---显示光标
						CWinAPICaret.ShowCaret(this.Handle);
						this.defaultIsHideCaret=false;
						this.defaultMousePos.iPos=(this.defaultRowNowNum+this.defaultRowSelectedNum)*this.defaultRowShowNum+0;
						this.defaultMousePos.iArea=1;
						this.defaultMousePos.bLeftPos=true;
						this.defaultMousePos.bRightPos=false;
						return;
					}

					nowRegion=new Region(nowRectangle);

					//鼠标在指定的区域内
					if (nowRegion.IsVisible(mousePoint))
					{
						//---创建光标
						this.OnCreateCaret();
						int iDataOffset = nowRectangle.X+this.defaultRowStaffWidth;
						int iDataHeight = nowRectangle.Y;

						//---遍历查找光标的位置
						for (int iy = 0 ; iy<this.defaultRowShowNum ; iy++)
						{
							nowRectangle.X=iDataOffset;
							nowRectangle.Y=iDataHeight;
							nowRectangle.Width=fontWidth/2;
							nowRectangle.Height=fontHeight+this.defaultColStaffWidth;
							nowRegion=new Region(nowRectangle);

							//---数据的左边
							if (nowRegion.IsVisible(mousePoint))
							{
								//---设置光标
								CWinAPICaret.SetCaretPos((nowRectangle.X - this.defaultCaretXOffset), (nowRectangle.Y + this.defaultCaretYOffset/2));
								//---显示光标
								CWinAPICaret.ShowCaret(this.Handle);
								this.defaultIsHideCaret=false;
								this.defaultMousePos.iPos=(this.defaultRowNowNum+this.defaultRowSelectedNum)*this.defaultRowShowNum+iy;
								this.defaultMousePos.iArea=1;
								this.defaultMousePos.bLeftPos=true;
								this.defaultMousePos.bRightPos=false;
								break;
							}
							nowRectangle.X+=(fontWidth+1)/2;
							nowRectangle.Width=(fontWidth+3)/2+this.defaultRowStaffWidth;
							nowRegion=new Region(nowRectangle);

							//---数据的右边
							if (nowRegion.IsVisible(mousePoint))
							{
								//---设置光标
								CWinAPICaret.SetCaretPos((nowRectangle.X-this.defaultCaretXOffset), (nowRectangle.Y+this.defaultCaretYOffset/2));
								//---显示光标
								CWinAPICaret.ShowCaret(this.Handle);
								this.defaultIsHideCaret=false;
								this.defaultMousePos.iPos=(this.defaultRowNowNum+this.defaultRowSelectedNum)*this.defaultRowShowNum+iy;
								this.defaultMousePos.iArea=1;
								this.defaultMousePos.bLeftPos=false;
								this.defaultMousePos.bRightPos=true;

								break;
							}
							iDataOffset+=fontWidth+this.defaultRowStaffWidth;
						}

						//---如果点击区域超过最大值，则不显示
						if (this.defaultMousePos.iPos!=-1&&this.defaultMousePos.iPos>=this.defaultNowData.Length)
						{
							this.OnHideCaret();
						}

						//---添加---注销
						nowRegion.Dispose();
					}
					else
					{
						this.OnHideCaret();
					}
					#endregion
				}
			}

			//处理基类鼠标按下的事件
			//base.OnMouseDown( e );
		}

		/// <summary>
		/// 滑轮滚动处理
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			//表明像下滚动
			if (e.Delta==-120)
			{
				if (this.defaultRowNowNum<this.defaultVScrollBar.Maximum)
				{
					if (this.defaultVScrollBar.Enabled)
					{
						this.defaultRowNowNum+=1;
						this.defaultVScrollBar.Value=this.defaultRowNowNum;
						this.Invalidate();
					}
				}
			}
			//---表明向上滚动
			else if (e.Delta==120)
			{
				if (this.defaultRowNowNum>0)
				{
					defaultRowNowNum-=1;
					this.defaultVScrollBar.Value=this.defaultRowNowNum;
					this.Invalidate();
				}
				else
				{
					this.defaultRowNowNum=0;
				}
			}
		}

		/// <summary>
		/// 鼠标按键弹起
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if ((this.defaultNowData==null)||(this.defaultNowData.Length==0))
			{
				return;
			}

			//---获取焦点
			this.Focus();
			//处理基类的按键释放
			//base.OnMouseUp(e);
		}

		#endregion

		#region 输入符移动

		/// <summary>
		/// 输入符向右移动
		/// </summary>
		private void OnCaretMove_Right()
		{
			if ((this.defaultMousePos.iPos!=-1)&&(this.defaultMousePos.iArea!=-1))
			{
				//---设置输入点
				this.Focus();

				//---光标在数据区域
				if (this.defaultMousePos.iArea==1)
				{
					//---计算字体的宽度
					int fonWidth = this.FontWidth();

					//---计算字体的高度
					int fontHeight = this.FontHeigth();

					//---获取当前的列信息
					int colPosition = this.CalcXScaleColIndex();

					//---获取数据所在行的起始信息---仅仅是起始信息
					Point pointA = this.CalcYScaleRowPoint();

					//---用于计算光标的二维坐标
					Point pointB = new Point();

					//---表明在最后一个字节
					if (colPosition==(this.defaultRowShowNum-1))
					{
						//---表明在字节的右部
						if (this.defaultMousePos.bRightPos)
						{
							//---计算控件最大可显示的行数
							int iMaxDataRow = this.defaultMaxRow;//this.CalcYScaleMaxRow();
							//---计算实际的行数
							int iDataRow = this.defaultTotalRow;// this.CalcYScaleTotalRow();
							//---判断选择数据所在的行号-----从1开始
							if (this.defaultRowSelectedNum<(iMaxDataRow-1))
							{
								this.defaultRowSelectedNum++;
								//---为了避免光标在最后一个位置,依然能够移动位置
								if (this.defaultRowSelectedNum!=iDataRow)
								{
									pointB.X=pointA.X+this.defaultRowStaffWidth;
									pointB.Y=pointA.Y+fontHeight+this.defaultColStaffWidth-2;
									this.defaultMousePos.iPos+=1;

									//---设置光标的位置;同时置位光标的位置标志
									this.defaultMousePos.bRightPos=false;
									this.defaultMousePos.bLeftPos=true;
									CWinAPICaret.SetCaretPos((pointB.X-this.defaultCaretXOffset), (pointB.Y+this.defaultCaretYOffset));
								}
								else
								{
									//---保持光标位置不变，选择的列号页不变
									this.defaultRowSelectedNum-=1;

									//---最后一行数据的最后一个数据---位置信息保留
									this.defaultMousePos.bRightPos=true;
									this.defaultMousePos.bLeftPos=false;
								}

								//---重新绘制窗体
								this.Invalidate();
								return;
							}
							else if ((this.defaultRowSelectedNum==(iMaxDataRow-1)&&(iDataRow-this.defaultRowNowNum-iMaxDataRow)>0))
							{
								this.defaultRowNowNum+=1;
								this.defaultVScrollBar.Value=this.defaultRowNowNum;
								this.Invalidate();

								pointB.X=pointA.X+this.defaultRowStaffWidth;
								pointB.Y=pointA.Y-2;
								this.defaultMousePos.iPos+=1;
								this.defaultMousePos.bRightPos=false;
								this.defaultMousePos.bLeftPos=true;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								return;
							}

							//---如果本窗体的最后一行且是最后一个数据，则如下处理
							else if ((this.defaultRowSelectedNum==(iMaxDataRow-1)&&(iDataRow-this.defaultRowNowNum-iMaxDataRow)==0))
							{
								//SetCaretPos( pt.X, pt.Y );
								this.Invalidate();
								return;
							}
						}

						//---表明在字节的左部
						if (this.defaultMousePos.bLeftPos)
						{
							//---用于显示光标位置
							pointB.X=pointA.X+colPosition*(fonWidth+this.defaultRowStaffWidth)+this.defaultRowStaffWidth+(fonWidth)/2;
							pointB.Y=pointA.Y-2;
							this.defaultMousePos.bRightPos=true;
							this.defaultMousePos.bLeftPos=false;
							CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
							this.Invalidate();
							return;
						}
					}
					else
					{
						//---表明在字节的右部
						if (this.defaultMousePos.bRightPos)
						{
							//---判定是否在最后一个字节
							if ((this.defaultMousePos.iPos+1)>=(this.mNowData.Length))
							{
								return;
							}

							pointB.X=pointA.X+(colPosition+1)*(fonWidth+this.defaultRowStaffWidth)+this.defaultRowStaffWidth;
							pointB.Y=pointA.Y-2;
							this.defaultMousePos.iPos+=1;
							this.defaultMousePos.bRightPos=false;
							this.defaultMousePos.bLeftPos=true;
							CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
							this.Invalidate();
							return;
						}

						//---表明在字节的左部
						if (this.defaultMousePos.bLeftPos)
						{
							pointB.X=pointA.X+colPosition*(fonWidth+this.defaultRowStaffWidth)+this.defaultRowStaffWidth+(fonWidth)/2;
							pointB.Y=pointA.Y-2;
							this.defaultMousePos.bRightPos=true;
							this.defaultMousePos.bLeftPos=false;
							CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
							this.Invalidate();
							return;
						}
					}
				}
			}
		}

		/// <summary>
		/// 输入符向左移动
		/// </summary>
		private void OnCaretMove_Left()
		{
			if (this.defaultMousePos.iPos!=-1&&this.defaultMousePos.iArea!=-1)
			{
				this.Focus();

				//---表明在Data区
				if (this.defaultMousePos.iArea==1)
				{
					//---获取字体的宽度及长度
					int fontWidth = this.FontWidth();
					int fontHeight = this.FontHeigth();

					//---查找在第几列
					int colPosition = this.CalcXScaleColIndex();

					//---获取所在行的启动信息
					Point pointA = this.CalcYScaleRowPoint();

					//---表示在每行的起始位置
					Point pointB = new Point();
					if (colPosition==0)
					{
						//---表明在第一个字节的右部
						if (this.defaultMousePos.bRightPos)
						{
							pointB.X=pointA.X+this.defaultRowStaffWidth;
							pointB.Y=pointA.Y-2;
							this.defaultMousePos.bRightPos=false;
							this.defaultMousePos.bLeftPos=true;
							CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
							this.Invalidate();
							return;
						}

						//---表明在第一个字节的左部
						if (this.defaultMousePos.bLeftPos)
						{
							if (this.defaultRowSelectedNum>0)
							{
								this.defaultRowSelectedNum-=1;
								pointB.X=pointA.X+defaultRowShowNum*(fontWidth+this.defaultRowStaffWidth)-(fontWidth)/2;
								pointB.Y=pointA.Y-fontHeight-this.defaultColStaffWidth-2;
								this.defaultMousePos.iPos-=1;
								this.defaultMousePos.bRightPos=true;
								this.defaultMousePos.bLeftPos=false;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.Invalidate();
								return;
							}
							else if (this.defaultRowSelectedNum==0&&this.defaultRowNowNum>0)
							{
								this.defaultRowSelectedNum=0;
								this.defaultRowNowNum-=1;

								this.defaultVScrollBar.Value=this.defaultRowNowNum;
								this.Invalidate();
								pointB.X=pointA.X+defaultRowShowNum*(fontWidth+this.defaultRowStaffWidth)-(fontWidth)/2;
								pointB.Y=pointA.Y;
								defaultMousePos.iPos-=1;
								this.defaultMousePos.bRightPos=true;
								this.defaultMousePos.bLeftPos=false;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.Invalidate();
								return;
							}
						}
					}

					//---表示不在每行的起始位置
					else
					{
						//---表明在字节的右部
						if (this.defaultMousePos.bRightPos)
						{
							pointB.X=pointA.X+colPosition*(fontWidth+this.defaultRowStaffWidth)+this.defaultRowStaffWidth;
							pointB.Y=pointA.Y-2;
							this.defaultMousePos.bRightPos=false;
							this.defaultMousePos.bLeftPos=true;
							CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
							this.Invalidate();
							return;
						}

						//---表明在字节的左部
						if (this.defaultMousePos.bLeftPos)
						{
							pointB.X=pointA.X+(colPosition-1)*(fontWidth+this.defaultRowStaffWidth)+this.defaultRowStaffWidth+fontWidth-(fontWidth)/2;
							pointB.Y=pointA.Y-2;
							this.defaultMousePos.iPos-=1;
							this.defaultMousePos.bRightPos=true;
							this.defaultMousePos.bLeftPos=false;
							CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
							this.Invalidate();
							return;
						}
					}
				}
			}
		}

		/// <summary>
		/// 输入符向上移动
		/// </summary>
		private void OnCaretMove_Up()
		{
			if (defaultMousePos.iPos!=-1&&defaultMousePos.iArea!=-1)
			{
				//---表明在Data区
				if (defaultMousePos.iArea==1)
				{
					//---获取字体的宽度及长度
					int i_font_width = this.FontWidth();
					int i_font_height = this.FontHeigth();
					//---查找在第几列
					int iColumn = this.CalcXScaleColIndex();
					//---获取所在行的启动信息
					Point pointA = this.CalcYScaleRowPoint();
					//---计算最大显示行数
					int iMaxDataRow = this.defaultMaxRow;//this.CalcYScaleMaxRow();
					//---计算实际数据可显示的行数
					int i_data_row = this.defaultTotalRow;// this.CalcYScaleTotalRow();
					//---进行判定
					Point pointB = new Point();
					if ((defaultMousePos.iPos-defaultRowShowNum)>=0)
					{
						if (defaultRowSelectedNum>0)
						{
							defaultRowSelectedNum-=1;

							//---表明在第一个字节的右部
							if (defaultMousePos.bRightPos)
							{
								pointB.X=pointA.X+iColumn*(i_font_width+defaultRowStaffWidth)+defaultRowStaffWidth+(i_font_width)/2;
								pointB.Y=pointA.Y-i_font_height-defaultColStaffWidth-2;

								defaultMousePos.iPos-=defaultRowShowNum;
								defaultMousePos.bRightPos=true;
								defaultMousePos.bLeftPos=false;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.Invalidate();
								return;
							}

							//---表明在第一个字节的左部
							if (defaultMousePos.bLeftPos)
							{
								pointB.X=pointA.X+iColumn*(i_font_width+defaultRowStaffWidth)+defaultRowStaffWidth;
								pointB.Y=pointA.Y-i_font_height-defaultColStaffWidth-2;

								defaultMousePos.iPos-=defaultRowShowNum;
								defaultMousePos.bRightPos=false;
								defaultMousePos.bLeftPos=true;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.Invalidate();
								return;
							}
						}
						else
						{
							defaultRowNowNum-=1;

							//---表明在第一个字节的右部
							if (defaultMousePos.bRightPos)
							{
								pointB.X=pointA.X+iColumn*(i_font_width+defaultRowStaffWidth)+defaultRowStaffWidth+(i_font_width)/2;

								pointB.Y=pointA.Y;

								defaultMousePos.iPos-=defaultRowShowNum;
								defaultMousePos.bRightPos=true;
								defaultMousePos.bLeftPos=false;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.defaultVScrollBar.Value=defaultRowNowNum;
								this.Invalidate();
								return;
							}

							//---表明在第一个字节的左部
							if (defaultMousePos.bLeftPos)
							{
								pointB.X=pointA.X+iColumn*(i_font_width+defaultRowStaffWidth)+defaultRowStaffWidth;
								pointB.Y=pointA.Y;

								defaultMousePos.iPos-=defaultRowShowNum;
								defaultMousePos.bRightPos=false;
								defaultMousePos.bLeftPos=true;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.defaultVScrollBar.Value=defaultRowNowNum;
								this.Invalidate();
								return;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// 输入符向下移动
		/// </summary>
		private void OnCaretMove_Down()
		{
			if (defaultMousePos.iPos!=-1&&defaultMousePos.iArea!=-1)
			{
				//---获取焦点
				//this.Focus();

				//----表明在Data区
				if (defaultMousePos.iArea==1)
				{
					//---获取字体的宽度及长度
					int iFontWidth =  this.FontWidth();
					int iFontHeight = this.FontHeigth();

					//---查找在第几列
					int iColumn = this.CalcXScaleColIndex();
					//---获取所在行的启动信息
					Point pointA = this.CalcYScaleRowPoint();
					//---计算最大显示行数
					int iMaxDataRow = this.defaultMaxRow;//this.CalcYScaleMaxRow();
					//---计算实际数据可显示的行数
					int iTotalDataRow = this.defaultTotalRow;// this.CalcYScaleTotalRow();
					//---进行判定
					Point pointB = new Point();
					if ((this.defaultMousePos.iPos+defaultRowShowNum)<(this.mNowData.Length))
					{
						if (defaultRowSelectedNum<iMaxDataRow-1)
						{
							defaultRowSelectedNum+=1;

							//---表明在第一个字节的右部
							if (defaultMousePos.bRightPos)
							{
								pointB.X=pointA.X+iColumn*(iFontWidth+defaultRowStaffWidth)+defaultRowStaffWidth+(iFontWidth)/2;
								pointB.Y=pointA.Y+iFontHeight+defaultColStaffWidth-2;

								defaultMousePos.iPos+=defaultRowShowNum;
								defaultMousePos.bRightPos=true;
								defaultMousePos.bLeftPos=false;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.Invalidate();
								return;
							}

							//---表明在第一个字节的左部
							if (defaultMousePos.bLeftPos)
							{
								pointB.X=pointA.X+iColumn*(iFontWidth+defaultRowStaffWidth)+defaultRowStaffWidth;
								pointB.Y=pointA.Y+iFontHeight+defaultColStaffWidth-2;

								defaultMousePos.iPos+=defaultRowShowNum;
								defaultMousePos.bRightPos=false;
								defaultMousePos.bLeftPos=true;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.Invalidate();
								return;
							}
						}
						else
						{
							defaultRowNowNum+=1;

							//---表明在第一个字节的右部
							if (defaultMousePos.bRightPos)
							{
								pointB.X=pointA.X+iColumn*(iFontWidth+defaultRowStaffWidth)+defaultRowStaffWidth+(iFontWidth)/2;
								pointB.Y=pointA.Y;

								defaultMousePos.iPos+=defaultRowShowNum;
								defaultMousePos.bRightPos=true;
								defaultMousePos.bLeftPos=false;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.defaultVScrollBar.Value=defaultRowNowNum;
								this.Invalidate();
								return;
							}

							//---表明在第一个字节的左部
							if (defaultMousePos.bLeftPos)
							{
								pointB.X=pointA.X+iColumn*(iFontWidth+defaultRowStaffWidth)+defaultRowStaffWidth;
								pointB.Y=pointA.Y;

								defaultMousePos.iPos+=defaultRowShowNum;
								defaultMousePos.bRightPos=false;
								defaultMousePos.bLeftPos=true;
								CWinAPICaret.SetCaretPos((pointB.X - this.defaultCaretXOffset), (pointB.Y + this.defaultCaretYOffset));
								this.defaultVScrollBar.Value=defaultRowNowNum;
								this.Invalidate();
								return;
							}
						}
					}
				}
			}
		}

		#endregion

		#region 私有函数

		/// <summary>
		/// 获取窗体可操作区域位置
		/// </summary>
		/// <returns></returns>
		private Rectangle CalcHexBoxRectangle()
		{
			Rectangle rt = new Rectangle();
			rt.X = this.defaultExternalLineWidth / 2;
			rt.Y = this.defaultExternalLineWidth / 2;
			//---判断垂直滚动条是否可见
			if (this.defaultVScrollBar.Visible)
			{
				rt.Width = this.Width - this.defaultExternalLineWidth - this.defaultScrollBarWidth;
			}
			else
			{
				rt.Width = this.Width - this.defaultExternalLineWidth;
			}
			if (this.defaultXScaleShow)
			{
				rt.Height = this.Height - this.defaultExternalLineWidth - this.defaultXScaleHeight - this.defaultXScaleHeightOffset+1;
			}
			else
			{
				rt.Height = this.Height - this.defaultExternalLineWidth;
			}
			return rt;
		}

		#endregion

	}
}
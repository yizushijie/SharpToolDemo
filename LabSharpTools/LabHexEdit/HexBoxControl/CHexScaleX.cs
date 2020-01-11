using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabHexEdit
{
	public partial class CHexBox
	{
		#region 绘制X轴刻度
		/// <summary>
		/// 绘制标题栏框
		/// </summary>
		/// <param name="e"></param>
		private void OnPaintXScale(PaintEventArgs e)
		{
			if ((this.defaultNowData == null) || (this.defaultNowData.Length == 0))
			{
				return;
			}
			else
			{
				//---获取标题栏的起始点
				Point nowPoint = new Point(this.defaultExternalLineWidth / 2, this.defaultExternalLineWidth / 2);

				//---计算标题栏的宽度
				int nowWidth = 0;

				//---判断垂直滚动条是否可见
				if (this.defaultVScrollBar.Visible)
				{
					nowWidth = this.Width - this.defaultExternalLineWidth - this.defaultScrollBarWidth;
				}
				else
				{
					nowWidth = this.Width - this.defaultExternalLineWidth;
				}

				//---计算标题栏的高度
				int nowHeight = (this.defaultXScaleHeight + this.defaultXScaleHeightOffset);

				//---获得字体的宽度
				int fontWidth = this.FontWidth();

				//---设置字体的起始位置
				int fontOffset = this.defaultExternalLineWidth / 2 + this.defaultRowStaffWidth;

				//---判断是否显示地址栏
				if (this.mYScaleShow)
				{
					//---计算字体的大小
					SizeF sizefAdd;
					if (this.defaultYScaleShowBit4 == YScaleShowBit4.BIT4X2)
					{
						sizefAdd = FontSize("0x00", this.defaultFont);
					}
					else if (this.defaultYScaleShowBit4 == YScaleShowBit4.BIT4X4)
					{
						sizefAdd = FontSize("0x0000", this.defaultFont);
					}
					else if (this.defaultYScaleShowBit4 == YScaleShowBit4.BIT4X6)
					{
						sizefAdd = FontSize("0x000000", this.defaultFont);
					}
					else
					{
						sizefAdd = FontSize("0x00000000", this.defaultFont);
					}

					//---标题栏第一个字符的起始地址
					fontOffset += (int)sizefAdd.Width + this.defaultYScaleOffsetWidth;

					//---数据地址栏的宽度
					this.defaultYScaleWidth = (int)sizefAdd.Width + this.defaultYScaleOffsetWidth;
				}

				//---获取坐标
				Point nowPointA = new Point();
				Point nowPointB = new Point();

				//---标题栏要填充的背景色
				Brush nowBrush = new SolidBrush(this.defaultXScaleBackGroundColor);

				//---计算标题栏的操作区域
				Rectangle nowRectangle = new Rectangle(nowPoint.X, nowPoint.Y, nowWidth, nowHeight);

				//---绘制指定大小的矩形区域并填充指定的背景色
				e.Graphics.FillRectangle(nowBrush, nowRectangle);

				//---设置标题栏字体颜色
				nowBrush = new SolidBrush(this.defaultXScaleFontColor);

				//---绘制标题栏
				for (int i = 0; i < this.defaultRowShowNum; i++)
				{
					//---绘制数据
					string msg = i.ToString("X2");

					nowPointA.X = fontOffset;
					nowPointA.Y = nowHeight / 6;

					//---绘制字符串
					e.Graphics.DrawString(msg, this.defaultFont, nowBrush, nowPointA);

					//---计算下一个数据的地址
					fontOffset += fontWidth + this.defaultRowStaffWidth;
				}

				this.defaultXScaleStringStartWidth = fontOffset + this.FontWidth("0000");

				//---标题栏下划线的颜色
				Pen nowPen = new Pen(this.defaultExternalLineColor);

				//---获取第一个点的二维坐标
				nowPointA.X = this.defaultColStaffWidth + this.defaultYScaleWidth - this.defaultExternalLineWidth / 2; //this.HexBoxOutLineWidth / 2; //---顶格显示
				nowPointA.Y = nowHeight - this.defaultExternalLineWidth / 2;

				//---获取的第二个点的二维坐标
				if (this.defaultVScrollBar.Visible)
				{
					nowPointB.X = this.Width - this.defaultScrollBarWidth - this.defaultExternalLineWidth / 2;
				}
				else
				{
					nowPointB.X = this.Width - this.defaultExternalLineWidth / 2;
				}
				nowPointB.Y = nowPointA.Y;
				//---数据地址的偏移
				this.defaultDataStartHeight = nowPointB.Y;
				//---绘制标题栏的下划线
				e.Graphics.DrawLine(nowPen, nowPointA, nowPointB);
			}
		}

		/// <summary>
		/// 绘制字符串
		/// </summary>
		/// <param name="e"></param>
		private void OnPaintXScaleString(PaintEventArgs e)
		{
			if ((this.defaultNowData == null) || (this.defaultNowData.Length == 0))
			{
				return;
			}
			else
			{
				//---获取标题栏的起始点
				Point nowPoint = new Point(this.defaultXScaleStringStartWidth, this.defaultExternalLineWidth / 2);

				//---计算标题栏的宽度
				int nowWidth = 0;

				//---判断垂直滚动条是否可见
				if (this.defaultVScrollBar.Visible)
				{
					nowWidth = this.Width - this.defaultExternalLineWidth - this.defaultScrollBarWidth;
				}
				else
				{
					nowWidth = this.Width - this.defaultExternalLineWidth;
				}

				//---计算标题栏的高度
				int nowHeight = (this.defaultXScaleHeight + this.defaultXScaleHeightOffset);

				//---获得字体的宽度
				int fontWidth = this.FontWidth("0");

				//---设置字体的起始位置
				int fontOffset = this.defaultXScaleStringStartWidth;

				//---获取坐标
				Point nowPointA = new Point();
				Point nowPointB = new Point();

				//---标题栏要填充的背景色
				Brush nowBrush = new SolidBrush(this.defaultXScaleBackGroundColor);

				//---计算标题栏的操作区域
				Rectangle nowRectangle = new Rectangle(nowPoint.X, nowPoint.Y, nowWidth, nowHeight);

				//---绘制指定大小的矩形区域并填充指定的背景色
				e.Graphics.FillRectangle(nowBrush, nowRectangle);

				//---设置标题栏字体颜色
				nowBrush = new SolidBrush(this.defaultXScaleFontColor);

				//---绘制标题栏
				for (int i = 0; i < this.defaultRowShowNum; i++)
				{
					//---绘制数据
					string msg = i.ToString("X1");

					nowPointA.X = fontOffset;
					nowPointA.Y = nowHeight / 6;

					//---绘制字符串
					e.Graphics.DrawString(msg, this.defaultFont, nowBrush, nowPointA);

					//---计算下一个数据的地址
					fontOffset += fontWidth;
				}
				
				//---标题栏下划线的颜色
				Pen nowPen = new Pen(this.defaultExternalLineColor);

				//---获取第一个点的二维坐标
				nowPointA.X = this.defaultColStaffWidth + this.defaultYScaleWidth - this.defaultExternalLineWidth / 2; //this.HexBoxOutLineWidth / 2; //---顶格显示
				nowPointA.Y = nowHeight - this.defaultExternalLineWidth / 2;

				//---获取的第二个点的二维坐标
				if (this.defaultVScrollBar.Visible)
				{
					nowPointB.X = this.Width - this.defaultScrollBarWidth - this.defaultExternalLineWidth / 2;
				}
				else
				{
					nowPointB.X = this.Width - this.defaultExternalLineWidth / 2;
				}
				nowPointB.Y = nowPointA.Y;
				//this.defaultDataStartHeight = nowPointB.Y;

				//---绘制标题栏的下划线
				e.Graphics.DrawLine(nowPen, nowPointA, nowPointB);
			}
		}

		/// <summary>
		/// 绘制包含ASCII码的刻度栏
		/// </summary>
		/// <param name="e"></param>
		private void OnPaintXScaleAll(PaintEventArgs e)
		{
			//---绘制地址栏
			this.OnPaintXScale(e);
			//---绘制字符串栏
			this.OnPaintXScaleString(e);
		}

		#endregion

		#region 绘制X轴刻度被选中

		/// <summary>
		/// 绘制X轴刻度选择背景
		/// </summary>
		/// <param name="e"></param>
		private void OnDrawXScaleBackGroundRectangle(PaintEventArgs e)
		{
			if (this.defaultXScaleShow && (this.defaultRowSelectedNum != -1))
			{
				//---数据选择的列号
				int currentColumn = this.CalcXScaleColIndex();
				//---判断列号是否合法
				if (currentColumn == -1)
				{
					return;
				}
				else
				{
					//---获取起始地址
					Point pointA;
					if (this.mYScaleShow)
					{
						pointA = new Point(this.defaultYScaleWidth + this.defaultColStaffWidth - this.defaultExternalLineWidth / 2, this.defaultExternalLineWidth / 2);
					}
					else
					{
						pointA = new Point(this.defaultExternalLineWidth / 2, this.defaultExternalLineWidth / 2);
					}
					//---计算宽度
					int fontWidthA = this.FontWidth();
					int fontWidthB = this.FontWidth("0");
					//---
					//---计算字体的高度
					int fontHeight = this.FontHeigth();
					Rectangle nowRectangle = new Rectangle();
					//---初值计算
					nowRectangle.X = pointA.X;
					//---计算起点X的位置
					if (this.defaultMousePos.bLeftPos)
					{
						nowRectangle.X = pointA.X + currentColumn * (fontWidthA + this.defaultRowStaffWidth) + (fontWidthA) / 2 - 3;
					}
					if (this.defaultMousePos.bRightPos)
					{
						nowRectangle.X = pointA.X + currentColumn * (fontWidthA + this.defaultRowStaffWidth) + fontWidthA - 4;
					}
					//---计算起点Y的位置
					nowRectangle.Y = pointA.Y- (this.defaultExternalLineWidth/2);
					//---计算宽度
					nowRectangle.Width = (fontWidthA + 1) / 2;
					//---计算高度
					nowRectangle.Height = this.defaultXScaleHeight;// - this.defaultExternalLineWidth;
					//---区域矩形背景填充
					Brush backGroundBrush = new SolidBrush(Color.FromArgb(60, Color.Black));
					e.Graphics.FillRectangle(backGroundBrush, nowRectangle);
					//---外边框线条
					e.Graphics.DrawRectangle(new Pen(Color.DarkGray, 1), nowRectangle);

					//---绘制当前在字符串区域选择的数据信息
					if (this.defaultXScaleStringShow)
					{
						Point nowPointB = this.CalcYScalePoint();
						//---起点(X,Y)坐标
						nowRectangle.X = this.mXScaleStringStartWidth + currentColumn * fontWidthB + 2;
						nowRectangle.Y = nowPointB.Y + this.defaultRowSelectedNum * (fontHeight + this.defaultColStaffWidth) + (this.defaultExternalLineWidth);
						//---计算高度
						nowRectangle.Height = fontHeight + this.defaultColStaffWidth;
						//e.Graphics.FillRectangle(backGroundBrush, nowRectangle);
						//---外边框线条
						e.Graphics.DrawRectangle(new Pen(Color.DarkGray, 1), nowRectangle);
					}
				}
			}
			else
			{
				return;
			}
		}

		#endregion

		#region X轴刻度的列

		/// <summary>
		/// 计算当前显示的列的列号
		/// </summary>
		/// <returns></returns>
		private int CalcXScaleColIndex()
		{
			int _return = 0;
			if (this.defaultMousePos.iPos >= 0)
			{
				_return = this.defaultMousePos.iPos % this.defaultRowShowNum;
			}
			else
			{
				//_return = -1;
				_return = 0;
			}

			return _return;
		}



		#endregion
	}
}

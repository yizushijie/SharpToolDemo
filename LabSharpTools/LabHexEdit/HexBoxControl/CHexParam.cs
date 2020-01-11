using System.Drawing;
using System.Windows.Forms;

namespace Harry.LabTools.LabHexEdit
{
	/// <summary>
	/// Hex编辑窗体的参数
	/// </summary>
	public partial class CHexBox 
	{
		
		#region 在更新数据的时候是否需要对比现在的数据和已经存在的数据，已经存在的数据进行颜色的标注

		/// <summary>
		/// 是否在更新的数据时候进行数据的不同的标注
		/// </summary>
		private bool defaultShowChangeFlag = false;

		/// <summary>
		/// 属性读写
		/// </summary>
		public bool mShowChangeFlag
		{
			get
			{
				return this.defaultShowChangeFlag;
			}

			set
			{
				this.defaultShowChangeFlag = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}


		/// <summary>
		/// 变化数据的背景色
		/// </summary>
		private Color defaultShowChangeBackGroundColor = Color.Yellow;

		/// <summary>
		/// 属性读写
		/// </summary>
		public Color mShowChangeBackGroundColor
		{
			get
			{
				return this.defaultShowChangeBackGroundColor;
			}

			set
			{
				this.defaultShowChangeBackGroundColor = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		#endregion

		#region X轴

		/// <summary>
		/// X方向刻度
		/// </summary>
		private bool defaultXScaleShow = true;

		/// <summary>
		/// 属性读写
		/// </summary>
		public bool mXScaleShow
		{
			get
			{
				return this.defaultXScaleShow;
			}

			set
			{
				this.defaultXScaleShow = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// X方向刻度,显示地址位置和ASCII码信息
		/// </summary>
		private bool defaultXScaleStringShow = true;

		/// <summary>
		/// 属性读写
		/// </summary>
		public bool mXScaleStringShow
		{
			get
			{
				return this.defaultXScaleStringShow;
			}

			set
			{
				this.defaultXScaleStringShow = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 显示字符串的位置
		/// </summary>
		private int defaultXScaleStringStartWidth = 0;

		/// <summary>
		/// 属性读写
		/// </summary>
		public int mXScaleStringStartWidth
		{
			get
			{
				return this.defaultXScaleStringStartWidth;
			}

			set
			{
				this.defaultXScaleStringStartWidth = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// X方向刻度的高度
		/// </summary>
		private int defaultXScaleHeight= 24;

		/// <summary>
		/// 属性读写
		/// </summary>
		public int mXScaleHeight
		{
			get
			{
				return this.defaultXScaleHeight;
			}

			set
			{
				this.defaultXScaleHeight = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 地址的背景色
		/// </summary>
		private Color defaultXScaleBackGroundColor = Color.FromArgb(240, 240, 240);

		/// <summary>
		/// 属性读写
		/// </summary>
		public Color mXScaleBackGroundColor
		{
			get
			{
				return this.defaultXScaleBackGroundColor;
			}

			set
			{
				this.defaultXScaleBackGroundColor = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 字体大小
		/// </summary>
		private Color defaultXScaleFontColor = Color.Black;

		/// <summary>
		/// 属性读写
		/// </summary>
		public Color mXScaleFontColor
		{
			get
			{
				return this.defaultXScaleFontColor;
			}

			set
			{
				this.defaultXScaleFontColor = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 数据显示的bit位数
		/// </summary>
		public enum XScaleShowBit8
		{
			BIT8X16 = 16,
			BIT8X32 = 32,
		}

		/// <summary>
		/// 显示数据的个数
		/// </summary>
		private XScaleShowBit8 defaultXScaleShowBit8 = XScaleShowBit8.BIT8X16;

		/// <summary>
		/// 属性读写
		/// </summary>
		public XScaleShowBit8 mXScaleShowBit8
		{
			get
			{
				return this.defaultXScaleShowBit8;
			}

			set
			{
				this.defaultXScaleShowBit8 = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// X方向刻度高度的偏移
		/// </summary>
		private int defaultXScaleHeightOffset = 2;

		/// <summary>
		/// 
		/// </summary>
		public int mXScaleHeightOffset
		{
			get
			{
				return this.defaultXScaleHeightOffset;
			}

			set
			{
				this.defaultXScaleHeightOffset = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// X方向刻度
		/// </summary>
		private bool defaultXScaleBackGroundRectangleShow = true;

		/// <summary>
		/// 属性读写
		/// </summary>
		public bool mXScaleBackGroundRectangleShow
		{
			get
			{
				return this.defaultXScaleBackGroundRectangleShow;
			}

			set
			{
				this.defaultXScaleBackGroundRectangleShow = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		#endregion X轴地址

		#region Y轴地址

		/// <summary>
		/// 是都显示地址
		/// </summary>
		private bool defaultYScaleShow = true;

		/// <summary>
		/// 属性读写
		/// </summary>
		public bool mYScaleShow
		{
			get
			{
				return this.defaultYScaleShow;
			}

			set
			{
				this.defaultYScaleShow = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}
		/// <summary>
		/// 地址起始的地址
		/// </summary>
		private int defaultYScaleOffsetWidth = 32;

		/// <summary>
		/// 属性读写
		/// </summary>
		public int mYScaleOffsetWidth
		{
			get
			{
				return this.defaultYScaleOffsetWidth;
			}

			set
			{
				this.defaultYScaleOffsetWidth = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}
		
		/// <summary>
		/// 地址的宽度
		/// </summary>
		private int defaultYScaleWidth = 100;

		/// <summary>
		/// 属性读写
		/// </summary>
		public int mYScaleWidth
		{
			get
			{
				return this.defaultYScaleWidth;
			}

			set
			{
				this.defaultYScaleWidth = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}


		/// <summary>
		/// 地址的背景色
		/// </summary>
		private Color defaultYScaleBackGroundColor = Color.FromArgb(240, 240, 240);

		/// <summary>
		/// 属性读写
		/// </summary>
		public Color mYScaleBackGroundColor
		{
			get
			{
				return this.defaultYScaleBackGroundColor;
			}

			set
			{
				this.defaultYScaleBackGroundColor = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}


		/// <summary>
		/// 地址的字体颜色
		/// </summary>
		private Color defaultYScaleFontColor = Color.Black;

		/// <summary>
		/// 属性读写
		/// </summary>
		public Color mYScaleFontColor
		{
			get
			{
				return this.defaultYScaleFontColor;
			}

			set
			{
				this.defaultYScaleFontColor = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}


		/// <summary>
		/// 地址显示的位数
		/// </summary>
		public enum YScaleShowBit4
		{
			BIT4X2 = 2,
			BIT4X4 = 4,
			BIT4X6 = 6,
			BIT4X8 = 8,
		}

		/// <summary>
		/// 显示数据的位数
		/// </summary>
		private YScaleShowBit4 defaultYScaleShowBit4 = YScaleShowBit4.BIT4X4;

		/// <summary>
		/// 属性读写
		/// </summary>
		public YScaleShowBit4 mYScaleShowBit4
		{
			get
			{
				return this.defaultYScaleShowBit4;
			}

			set
			{
				this.defaultYScaleShowBit4 = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// X方向刻度
		/// </summary>
		private bool defaultYScaleBackGroundRectangleShow = true;

		/// <summary>
		/// 属性读写
		/// </summary>
		public bool mYScaleBackGroundRectangleShow
		{
			get
			{
				return this.defaultYScaleBackGroundRectangleShow;
			}

			set
			{
				this.defaultYScaleBackGroundRectangleShow = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		#endregion Y轴地址

		#region 数据地址

		/// <summary>
		/// 数据格式
		/// </summary>
		public enum EncodingType
		{
			ANSI = 1,
			Unicond = 2,
		} 

		/// <summary>
		/// 数据的格式
		/// </summary>
		private EncodingType defaultDataEncodingType = EncodingType.ANSI;

		/// <summary>
		/// 数据的字体的颜色A
		/// </summary>
		private Color defaultDataFontColorA = Color.HotPink;//Color.Black;

		/// <summary>
		/// 数据的字体的颜色A为读写属性
		/// </summary>
		public Color mDataFontColorA
		{
			get
			{
				return this.defaultDataFontColorA;
			}
			set
			{
				this.defaultDataFontColorA = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 数据的字体的颜色A
		/// </summary>
		private Color defaultDataFontColorB = Color.MidnightBlue;

		/// <summary>
		/// 数据的字体的颜色B为读写属性
		/// </summary>
		public Color mDataFontColorB
		{
			get
			{
				return this.defaultDataFontColorB;
			}
			set
			{
				this.defaultDataFontColorB = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 数据地址偏移
		/// </summary>
		private int defaultDataScaleOffset = 1;

		#endregion 数据地址

		#region 字体

		/// <summary>
		/// 字体
		/// </summary>
		private Font defaultFont = new Font("楷体", 12);

		/// <summary>
		/// 属性读写
		/// </summary>
		public Font mFont
		{
			get
			{
				return this.defaultFont;
			}

			set
			{
				this.defaultFont = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 字体背景色
		/// </summary>
		private Color defaultFontBackGroundColor = Color.White;

		/// <summary>
		/// 属性读写
		/// </summary>
		public Color mFontBackGroundColor
		{
			get
			{
				return this.defaultFontBackGroundColor;
			}

			set
			{
				this.defaultFontBackGroundColor = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		#endregion 字体

		#region 外部线条

		/// <summary>
		/// 外部线条颜色
		/// </summary>
		private Color defaultExternalLineColor = Color.DarkGray;

		/// <summary>
		/// 属性读写
		/// </summary>
		public Color mExternalLineColor
		{
			get
			{
				return this.defaultExternalLineColor;
			}

			set
			{
				this.defaultExternalLineColor = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 外部线条的宽度
		/// </summary>
		private int defaultExternalLineWidth = 2;

		/// <summary>
		/// 属性读写
		/// </summary>
		public int mExternalLineWidth
		{
			get
			{
				return this.defaultExternalLineWidth;
			}

			set
			{
				this.defaultExternalLineWidth = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		#endregion 外部线条

		#region 缓存区定义

		/// <summary>
		/// 当前数据
		/// </summary>
		private byte[] defaultNowData = null;

		/// <summary>
		/// 属性只读
		/// </summary>
		public byte[] mNowData
		{
			get
			{
				return this.defaultNowData;
			}

			set
			{
				this.defaultNowData = value;

			}
		}


		/// <summary>
		/// 最后的数据
		/// </summary>
		private byte[] defaultLastData = null;

		/// <summary>
		/// 属性只读
		/// </summary>
		public byte[] mLastData
		{
			get
			{
				return this.defaultLastData;
			}

			//set
			//{
			//    this._bufferLast = value;
			//}
		}


		/// <summary>
		/// 是否有新数据
		/// </summary>
		private bool defaultNewDataChange = false;

		/// <summary>
		/// 属性读写
		/// </summary>
		public bool mNewDataChange
		{
			get
			{
				return this.defaultNewDataChange;
			}

			set
			{
				this.defaultNewDataChange = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}		

		#endregion 缓存区定义

		#region 垂直滚动条

		/// <summary>
		/// 垂直滚动条
		/// </summary>
		private VScrollBar defaultVScrollBar;

		/// <summary>
		/// 垂直滚动条的下拉控件的宽度
		/// </summary>
		private int defaultScrollBarWidth = 16;

		/// <summary>
		/// 下拉控件的位置
		/// </summary>
		private int defaultScrollBarPos = 0;

		#endregion 垂直滚动条

		#region 字符

		/// <summary>
		/// 每行显示的数据个数
		/// </summary>
		private int defaultRowShowNum = 16;

		/// <summary>
		/// 属性读写
		/// </summary>
		public int mRowDisplayNum
		{
			get
			{
				return this.defaultRowShowNum;
			}
			set
			{
				this.defaultRowShowNum = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 每行中字符间的间隔
		/// </summary>
		private int defaultRowStaffWidth = 8;//10;

		/// <summary>
		/// 属性读写
		/// </summary>
		public int mRowStaffWidth
		{
			get
			{
				return this.defaultRowStaffWidth;
			}
			set
			{
				this.defaultRowStaffWidth = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 当前显示的起始行号
		/// </summary>
		private int defaultRowNowNum = 0;

		/// <summary>
		/// 当前选中的行号
		/// </summary>
		private int defaultRowSelectedNum = -1;

		/// <summary>
		/// 第一列偏移位置
		/// </summary>
		private int defaultFirstRowOffset = 4;//7;

		/// <summary>
		/// 属性读写
		/// </summary>
		public int mFirstRowOffset
		{
			get
			{
				return this.defaultFirstRowOffset;
			}
			set
			{
				this.defaultFirstRowOffset = value;
				//---重新绘制窗体
				this.Invalidate();
			}
		}

		/// <summary>
		/// 每列中字符间的间隔
		/// </summary>
		private int defaultColStaffWidth = 4;

		#endregion 字符

		#region 光标信息

		private struct POS
		{
			public int iPos;
			public int iArea;
			public bool bLeftPos;
			public bool bRightPos;
		}

		/// <summary>
		/// 鼠标位置
		/// </summary>
		private POS defaultMousePos;
		
		/// <summary>
		/// 是否创建了Caret
		/// </summary>
		private bool defaultIsCreateCaret = false;

		/// <summary>
		/// 是否隐藏了Caret
		/// </summary>
		private bool defaultIsHideCaret = false;

		/// <summary>
		/// 光标的X方向偏移
		/// </summary>
		private int defaultCaretXOffset = 1;

		/// 光标的Y方向偏移
		/// </summary>
		private int defaultCaretYOffset = 4;//2;

		#endregion 光标信息

		#region 变量定义

		/// <summary>
		/// 记录数据区域的数据结束的位置
		/// </summary>
		private int defaultDataEndWidth = 0;

		/// <summary>
		/// 记录数据区域的数据开始的位置
		/// </summary>
		private int defaultDataStartWidth = 0;

		/// <summary>
		/// 记录数据区域每行的高度
		/// </summary>
		private int defaultDataStartHeight = 0;

		/// <summary>
		/// 数据区域显示的最大行数
		/// </summary>
		private int defaultMaxRow = 0;

		/// <summary>
		/// 数据显示的最大行数
		/// </summary>
		private int defaultTotalRow = 0;

		#endregion 变量定义

	}
}
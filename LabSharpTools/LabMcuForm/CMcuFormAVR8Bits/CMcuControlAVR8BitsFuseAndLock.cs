using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Harry.LabTools.LabComm;
using Harry.LabTools.LabMcuFunc;

namespace LabMcuForm.CMcuFormAVR8Bits
{
	public partial class CMcuControlAVR8BitsFuseAndLock : UserControl
	{
		#region 变量定义

		/// <summary>
		/// 使用的通讯端口
		/// </summary>
		private CCommBase defaultCCOMM = null;

		/// <summary>
		/// MCU的参数
		/// </summary>
		private CMcuFuncInfoBaseParam defaultMcuParam = null;

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 无参数构造函数
		/// </summary>
		public CMcuControlAVR8BitsFuseAndLock()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 有参数构造函数
		/// </summary>
		/// <param name="cCommBase"></param>
		/// <param name="cMcuFuncInfoBaseParam"></param>
		public CMcuControlAVR8BitsFuseAndLock(CCommBase cCommBase, CMcuFuncInfoBaseParam cMcuFuncInfoBaseParam)
		{
			InitializeComponent();
			//---初始化通讯端口
			if (this.defaultCCOMM==null)
			{
				this.defaultCCOMM = new CCommBase();
			}
			this.defaultCCOMM = cCommBase;
			//---初始化芯片信息
			if (this.defaultMcuParam==null)
			{
				this.defaultMcuParam = new CMcuFuncInfoAVR8BitsParam();
			}
			this.defaultMcuParam = cMcuFuncInfoBaseParam;
		}	

		#endregion

	}
}

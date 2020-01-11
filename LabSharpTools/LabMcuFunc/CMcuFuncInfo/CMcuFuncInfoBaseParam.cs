using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabMcuFunc
{
	/// <summary>
	/// 支持的MCU类型
	/// </summary>
	public enum MCU_INFO_TYPE : int
	{
		MCU_NONE	=0,
		MCU_AVR8BITS = 1,            //---AVR的8BIT的MCU
	};
	
	public class CMcuFuncInfoBaseParam:ICloneable
	{
		#region 变量定义

		#endregion

		#region 属性定义

		/// <summary>
		/// 芯片类型
		/// </summary>
		public virtual string mTypeChip
		{
			get
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// 芯片名称
		/// </summary>
		public virtual string mTypeName
		{
			get
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// 
		/// </summary>
	    public virtual MCU_INFO_TYPE mTypeMcuInfo
		{
			get
			{
				return MCU_INFO_TYPE.MCU_NONE;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public CMcuFuncInfoBaseParam()
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cMcuFuncInfoBaseParam"></param>
		public CMcuFuncInfoBaseParam(CMcuFuncInfoBaseParam cMcuFuncInfoBaseParam)
		{
			
		}

		#endregion

		#region 公有函数

		/// <summary>
		/// 初始化类型MCU的信息
		/// </summary>
		/// <param name="chipName"></param>
		/// <returns></returns>
		public virtual bool McuTypeInfo(string chipName, ComboBox cbbInterface=null,TextBox tbChipID=null)
		{
			return false;			
		}

		/// <summary>
		/// 初始化MCU类型列表
		/// </summary>
		/// <param name="chipName"></param>
		/// <returns></returns>
		public virtual string[] McuListInfo(ComboBox cbbList=null)
		{
			return null;
		}

	
		/// <summary>
		/// 获取默认熔丝位
		/// </summary>
		/// <returns></returns>
		public virtual int[] McuDefaultFuseInfo()
		{
			return null;
		}

		/// <summary>
		/// MCU的接口信息
		/// </summary>
		/// <param name="chipName"></param>
		/// <returns></returns>
		public virtual bool McuInterfaceInfo(ComboBox cbbInterface)
		{
			return false;
		}



		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion

		#region 克隆函数

		/// <summary>
		/// 克隆对象
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			return this as object;
		}

		/// <summary>
		/// 克隆
		/// </summary>
		/// <returns></returns>
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		#endregion
	}
}

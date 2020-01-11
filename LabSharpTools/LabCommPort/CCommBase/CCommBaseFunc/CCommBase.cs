using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabCommType
{
	public partial class CCommBase : IDisposable,ICloneable
	{
		#region 变量定义

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		public CCommBase()
		{
			
		}

		#endregion

		#region 析构函数
		/// <summary>
		/// 析构函数
		/// </summary>
		~CCommBase()
		{
			this.Dispose();
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual void Dispose()
		{
            //---注销控件
			this.DestroyControl();
            //---注销监控时间
			this.DestroyWatcherCommEvent();
            //---串口参数回收处理
            if (this.mSerialParam!=null)
            {
                this.mSerialParam = null;
            }
            //---USB参数回收处理
            if (this.mUSBParam != null)
            {
                this.mUSBParam = null;
            }
            //---垃圾回收
            GC.SuppressFinalize(this);
		}

		#endregion

		#region 公有函数

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion

		#region 克隆函数

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public object  Clone()
		{
			return this as object;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		#endregion

	}
}

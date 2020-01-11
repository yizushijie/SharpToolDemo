
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabCommType
{
	public partial class CCommBase : ICommData
	{
		#region 变量定义

		#endregion

		#region 属性定义

		/// <summary>
		/// 接收数据
		/// </summary>
		public virtual CCommData mReceData
		{
			get
			{
				return null;
			}
			set
			{

			}
		}

		/// <summary>
		/// 发送数据
		/// </summary>
		public virtual CCommData mSendData
		{
			get
			{
				return null;
			}
			set
			{

			}
		}

		/// <summary>
		/// 数据校验通过
		/// </summary>
		public virtual bool mReceCheckPass
		{
			get
			{
				return false;
			}
		}

		#endregion

		#region 构造函数

		#endregion

		#region 公有函数

		/// <summary>
		/// 解析接收数据
		/// </summary>
		/// <returns></returns>
		public virtual bool AnalyseReceData(byte[] cmd)
		{
			return false;
		}

		/// <summary>
		/// 解析发送数据
		/// </summary>
		/// <param name="cmd">要发送的命令</param>
		/// <returns></returns>
		public virtual bool AnalyseSendData(byte[] cmd)
		{
			return false;
		}

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabGenFunc
{
	public partial class CGenFuncUnPackage
	{
		#region 函数定义

		/// <summary>
		/// 将数据包拆包处理
		/// </summary>
		/// <param name="buffer"></param>
		/// <returns></returns>
		public static byte[] GenFuncUnPackage(byte[][] buffer)
		{
			//---返回结果
			List<byte> _return = new List<byte>();
			//---解包处理
			for (int i = 0; i < buffer.Length; i++)
			{
				_return.AddRange(buffer[i]);
			}
			return _return.ToArray();
		}

		#endregion
	}
}

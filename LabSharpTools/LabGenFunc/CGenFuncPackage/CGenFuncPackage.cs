
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabGenFunc
{
	public partial class CGenFuncPackage
	{
		#region 函数定义

		/// <summary>
		/// 对数据进行打包处理，不足一包的进行整包处理，并填充为指定数据
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="packageSize"></param>
		/// <param name="val"></param>
		public static byte[][] GenFuncPackage( byte[] buffer, int packageSize, byte val = 0xFF)
		{
			byte[][] _return = null;
			//---计算包总数
			int packageNum = buffer.Length / packageSize;
			//---校验整数包
			if ((buffer.Length%packageSize)!=0)
			{
				packageNum += 1;
			}
			//---申请缓存空间
			_return = new byte[packageNum][];
			//---数据进行分包处理
			for (int i = 0; i < packageNum; i++)
			{
				int length = ((buffer.Length - i * packageSize) > packageSize) ? packageSize : (buffer.Length - i * packageSize);
				//---数据缓存区
				_return[i] = new byte[length];
				//---判断是不是最后一包
				if (i==(packageNum-1))
				{
					CGenFuncMem.GenFuncMemset(ref _return[i]);
				}
				//数据拷贝处理
				Array.Copy(buffer, i * packageSize, _return[i], 0, length);
			}
			return _return;
		}

		/// <summary>
		/// 对数据进行打包处理
		/// </summary>
		/// <param name="buffer">数据</param>
		/// <param name="packageDataSize">大包的大小</param>
		/// <param name="packageMaxSize">小包的大小</param>
		/// <param name="val"></param>
		/// <returns></returns>
		public static byte[][][] GenFuncPackage(byte[] buffer, int packageDataSize, int packageMaxSize, byte val = 0xFF)
		{
			//---大包数据量进行打包
			byte[][] pacaageDataBuffer = CGenFuncPackage.GenFuncPackage(buffer, packageDataSize, val);
			//---数据缓存区
			byte[][][] _return = null;
			//---校验大包的处理
			if ((pacaageDataBuffer == null) || (pacaageDataBuffer.Length == 0))
			{
				_return = null;
			}
			else
			{
				//---小包处理的缓存区
				_return = new byte[pacaageDataBuffer.Length][][];
				//---小包数据处理
				for (int i = 0; i < pacaageDataBuffer.Length; i++)
				{
					//---小包数据打包处理
					_return[i] = CGenFuncPackage.GenFuncPackage(pacaageDataBuffer[i], packageMaxSize, val);
				}
			}
			return _return;
		}

		#endregion
	}
}

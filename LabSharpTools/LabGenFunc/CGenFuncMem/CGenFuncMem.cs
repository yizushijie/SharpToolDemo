using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabGenFunc
{
	public partial class CGenFuncMem
	{
		#region 函数定义

		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="length"></param>
		/// <param name="val"></param>
		public static void GenFuncMemset(ref byte[] buffer, long length, byte val = 0xFF)
		{
			if ((buffer == null) || (buffer.Length != length))
			{
				buffer = new byte[length];
			}
			for (int i = 0; i < length; i++)
			{
				buffer[i] = val;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="length"></param>
		/// <param name="val"></param>
		public static void GenFuncMemset(ref byte[] buffer,byte val = 0xFF)
		{
			CGenFuncMem.GenFuncMemset(ref buffer, buffer.Length, val);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="length"></param>
		/// <param name="val"></param>
		public static void GenFuncMemset(ref int[] buffer, long length, int val = 0xFFFF)
		{
			if ((buffer == null) || (buffer.Length != length))
			{
				buffer = new int[length];
			}
			for (int i = 0; i < length; i++)
			{
				buffer[i] = val;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="val"></param>
		public static void GenFuncMemset(ref int[] buffer, int val = 0xFFFF)
		{
			CGenFuncMem.GenFuncMemset(ref buffer, buffer.Length, val);
		}

		#endregion
	}
}

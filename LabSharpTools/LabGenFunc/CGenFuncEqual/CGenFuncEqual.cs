using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabGenFunc
{
	public partial  class CGenFuncEqual
	{
		#region 函数定义

		/// <summary>
		/// 判断指定数组中的数据是不是全部为指定的数据
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public static bool GenFuncEqual(byte[] buffer, byte val = 0xFF)
		{
			if ((buffer==null)||(buffer.Length==0))
			{
				return false;
			}

			for (int i = 0; i < buffer.Length; i++)
			{
				if (buffer[i]!=val)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 判断指定数组中的数据是不是全部为指定的数据
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public static bool GenFuncEqual(int[] buffer, int val = 0xFFFF)
		{
			if ((buffer == null) || (buffer.Length == 0))
			{
				return false;
			}

			for (int i = 0; i < buffer.Length; i++)
			{
				if (buffer[i] != val)
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 比较两个数组是否想相等
		/// </summary>
		/// <param name="aArray"></param>
		/// <param name="bArray"></param>
		/// <returns></returns>
		public static bool GenFuncEqual(byte[] aArray, byte[] bArray)
		{
			if ((aArray == null) || (bArray == null) || (aArray.Length != bArray.Length))
			{
				return false;
			}
			else
			{
				for (int i = 0; i < aArray.Length; i++)
				{
					if (aArray[i]!=bArray[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="aArray"></param>
		/// <param name="bArray"></param>
		/// <returns></returns>
		public static bool GenFuncEqual(byte[] aArray, byte[] bArray,ref int index)
		{
			if ((aArray == null) || (bArray == null) || (aArray.Length != bArray.Length))
			{
				return false;
			}
			else
			{
				for (int i = 0; i < aArray.Length; i++)
				{
					if (aArray[i] != bArray[i])
					{
						index += 1;
						return false;
					}
				}
			}
			return true;
		}

		#endregion
	}
}

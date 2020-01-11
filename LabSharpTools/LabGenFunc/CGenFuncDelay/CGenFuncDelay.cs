
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabGenFunc
{
	public static partial class CGenFuncDelay
	{

		#region 变量定义

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		#endregion

		#region 公共函数

		/// <summary>
		/// us延时函数
		/// </summary>
		/// <param name="delayus"></param>
		public static void GenFuncDelayus(long delayus)
		{
			long stop_Value = 0;
			long start_Value = 0;
			long freq = 0;
			long n = 0;
			//---获得时钟频率
			CGenFuncDelay.QueryPerformanceFrequency(ref freq);
			//---计数次数
			long count = delayus * freq / 1000000;   
			//---获取当前值
			CGenFuncDelay.QueryPerformanceCounter(ref start_Value); 
			//---判断延时的到达
			while (n < count) 
			{
				//---获取终止变量值
				CGenFuncDelay.QueryPerformanceCounter(ref stop_Value);
				n = stop_Value - start_Value;
				Application.DoEvents();
			}
		}

		/// <summary>
		/// ms延时函数
		/// </summary>
		/// <param name="delayms"></param>
		public static void GenFuncDelayms(long delayms)
		{
			long stop_Value = 0;
			long start_Value = 0;
			long freq = 0;
			long n = 0;
			//---获得时钟频率
			CGenFuncDelay.QueryPerformanceFrequency(ref freq);
			//---计数次数
			long count = delayms * freq / 1000;
			//---获取当前值
			CGenFuncDelay.QueryPerformanceCounter(ref start_Value);
			//---判断延时的到达
			while (n < count)
			{
				//---获取终止变量值
				CGenFuncDelay.QueryPerformanceCounter(ref stop_Value);
				n = stop_Value - start_Value;
				Application.DoEvents();
			}
		}

		/// <summary>
		/// ms延时函数
		/// </summary>
		/// <param name="delays"></param>
		public static void GenFuncDelays(long delays)
		{
			long stop_Value = 0;
			long start_Value = 0;
			long freq = 0;
			long n = 0;
			//---获得时钟频率
			CGenFuncDelay.QueryPerformanceFrequency(ref freq);
			//---计数次数
			long count = delays * freq;
			//---获取当前值
			CGenFuncDelay.QueryPerformanceCounter(ref start_Value);
			//---判断延时的到达
			while (n < count)
			{
				//---获取终止变量值
				CGenFuncDelay.QueryPerformanceCounter(ref stop_Value);
				n = stop_Value - start_Value;
				Application.DoEvents();
			}
		}

		#endregion

		#region 私有函数

		#endregion

		#region API函数

		/// <summary>
		/// 获取当前计数值
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		[DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long x);

		/// <summary>
		/// 获得机器内部计时器的时钟频率
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		[DllImport("kernel32.dll")]
		extern static short QueryPerformanceFrequency(ref long x);

		#endregion

	}
}

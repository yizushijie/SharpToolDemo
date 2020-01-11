
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabGenFunc
{
	public static partial class CGenFuncBitMap
	{

		#region 函数定义


		/// <summary>
		/// 比较连个BitMap是否相等
		/// </summary>
		/// <param name="img1"></param>
		/// <param name="img2"></param>
		/// <returns>true---相等</returns>

		public static bool GenFuncCompareBitMap(Bitmap img1, Bitmap img2)
		{
			bool flag = true;
			string img1_ref, img2_ref;
			if ((img1==null)||(img2==null))
			{
				return false;
			}
			if (img1.Width == img2.Width && img1.Height == img2.Height)
			{
				for (int i = 0; i < img1.Width; i++)
				{
					for (int j = 0; j < img1.Height; j++)
					{
						img1_ref = img1.GetPixel(i, j).ToString();
						img2_ref = img2.GetPixel(i, j).ToString();
						if (img1_ref != img2_ref)
						{
							flag = false;
							break;
						}
					}
				}
			}
			return flag;
		}

		#endregion

	}
}

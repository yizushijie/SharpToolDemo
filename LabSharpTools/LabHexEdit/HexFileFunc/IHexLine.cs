using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabHexEdit
{

	/// <summary>
	/// Hex文件类型
	/// </summary>
	public enum HexType : byte
	{
		DATA_RECORD							= 0,				//---用来记录数据，HEX文件的大部分记录都是数据记录
		END_OF_FILE_RECORD					= 1,				//---用来标识文件结束，放在文件的最后，标识HEX文件的结尾
		EXTEND_SEGMENT_ADDRESS_RECORD		= 2,				//---用来标识扩展段地址的记录
		START_SEGMENT_ADDRESS_RECORD		= 3,				//---开始段地址记录
		EXTEND_LINEAR_ADDRESS_RECORD		= 4,				//---用来标识扩展线性地址的记录
		START_LINEAR_ADDRESS_RECORD			= 5,				//---开始线性地址记录
	}

	/// <summary>
	/// 数据文件信息
	/// </summary>
	interface IHexLine
	{
		#region 变量定义

		/// <summary>
		/// 数据是否有效
		/// </summary>
		bool IsOK
		{
			get;
		}

		/// <summary>
		/// 数据长度
		/// </summary>
		byte Length
		{
			get;
		}

		/// <summary>
		/// 地址
		/// </summary>
		long Addr
		{
			get;
		}

		/// <summary>
		/// 数据类型
		/// </summary>
		HexType Type
		{
			get;
		}

		/// <summary>
		/// 数据
		/// </summary>
		byte[] InfoData
		{
			get;
		}

		/// <summary>
		/// 校验和
		/// </summary>
		byte CheckSum
		{
			get;
		}

		/// <summary>
		/// 错误信息
		/// </summary>
		string LogMessage
		{
			get;
		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 解析十六进制数据行
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		bool AnalyseHexLine(string str);
		
		#endregion
	}
}

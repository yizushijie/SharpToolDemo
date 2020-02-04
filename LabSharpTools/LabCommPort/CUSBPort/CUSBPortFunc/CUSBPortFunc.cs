using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommPort
{
	public partial class CUSBPort
	{
		#region 变量定义

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		#endregion

		#region 公有函数
		/// <summary>
		/// 初始化设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(ComboBox cbb, RichTextBox msg = null)
		{
			if (cbb != null)
			{
				//---异步调用
				if (cbb.InvokeRequired)
				{
					cbb.BeginInvoke((EventHandler)
							 //cbb.Invoke((EventHandler)
							 (delegate
							 {
								 cbb.Items.Clear();
								 cbb.SelectedIndex = -1;

							 }));
				}
				else
				{
					cbb.Items.Clear();
					cbb.SelectedIndex = -1;
				}
			}
			return -1;
		}

		/// <summary>
		/// 刷新设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		public override int RefreshDevice(ComboBox cbb, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 向设备写入命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteCmdToDevice(string cmd, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 向设备写入命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteCmdToDevice(byte[] cmd, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 从设备中读取命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadCmdFromDevice(ref string cmd, int timeout = 200, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 从设备中读取命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadCmdFromDevice(ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 发送并读取响应
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(byte[] cmd, ref byte[] res, int timeout = 300, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 发送并读取响应
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(string cmd, ref string res, int timeout = 200, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <returns></returns>
		public override int OpenDevice()
		{
			return -1;
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(string argName, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(int argIndex, RichTextBox msg = null)
		{
			return -1;
		}
		/// <summary>
		/// 打开设备
		/// </summary>
		/// <param name="argVID"></param>
		/// <param name="argPID"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(int argVID, int argPID, RichTextBox msg = null)
		{
			return -1;
		}
		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <returns></returns>
		public override int CloseDevice()
		{
			return -1;
		}

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(string argName, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(int argIndex, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <param name="argVID"></param>
		/// <param name="argPID"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(int argVID, int argPID, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <returns></returns>
		public override bool DetectDevice()
		{
			return false;
		}

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <param name="argName"></param>
		/// <returns></returns>
		public override bool DetectDevice(string argName)
		{
			return false;
		}

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <param name="argIndex"></param>
		/// <returns></returns>
		public override bool DetectDevice(int argIndex)
		{
			return false;
		}

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <param name="argVID"></param>
		/// <param name="argPID"></param>
		/// <returns></returns>
		public override bool DetectDevice(int argVID, int argPID)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommPort
{
	/// <summary>
	/// 通讯接口的功能函数
	/// </summary>
	interface ICommFunc
	{
		#region 函数定义
		/// <summary>
		/// 初始化设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int Init(ComboBox cbb, RichTextBox msg = null);

		/// <summary>
		/// 刷新设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		int RefreshDevice(ComboBox cbb, RichTextBox msg = null);

		/// <summary>
		/// 设备插入
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int InsertDevice();

		/// <summary>
		/// 设备移除
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int RemoveDevice();

		/// <summary>
		/// 向设备写入命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int WriteCmdToDevice(string cmd, RichTextBox msg = null);

		/// <summary>
		/// 向设备写入命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int WriteCmdToDevice(byte[] cmd, RichTextBox msg = null);

		/// <summary>
		/// 从设备中读取命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int ReadCmdFromDevice(ref string cmd, int timeout = 200, RichTextBox msg = null);

		/// <summary>
		/// 从设备中读取命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int ReadCmdFromDevice(ref byte[] cmd, int timeout = 200, RichTextBox msg = null);

		/// <summary>
		/// 发送并读取响应
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int SendCmdAndReadResponse(byte[] cmd, ref byte[] res, int timeout = 200, RichTextBox msg = null);

		/// <summary>
		/// 发送并读取响应
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int SendCmdAndReadResponse(string cmd, ref string res, int timeout = 200, RichTextBox msg = null);

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <returns></returns>
		int OpenDevice();

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int OpenDevice(string argName, RichTextBox msg = null);

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int OpenDevice(int argIndex, RichTextBox msg = null);

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <param name="argVID"></param>
		/// <param name="argPID"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int OpenDevice(int argVID, int argPID, RichTextBox msg = null);

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <returns></returns>
		int CloseDevice();

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int CloseDevice(string argName, RichTextBox msg = null);

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int CloseDevice(int argIndex, RichTextBox msg = null);

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <param name="argVID"></param>
		/// <param name="argPID"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		int CloseDevice(int argVID, int argPID, RichTextBox msg = null);

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <returns>true---连接，false---失败</returns>
		bool DetectDevice();

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <param name="argName"></param>
		/// <returns></returns>
		bool DetectDevice(string argName);

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <param name="argIndex"></param>
		/// <returns></returns>
		bool DetectDevice(int argIndex);

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <param name="argVID"></param>
		/// <param name="argPID"></param>
		/// <returns></returns>
		bool DetectDevice(int argVID, int argPID);

		/// <summary>
		/// 等待设备空闲
		/// </summary>
		/// <returns></returns>
		bool WaitForIdle();

		/// <summary>
		/// 等待设备空闲
		/// </summary>
		/// <param name="argName"></param>
		/// <returns></returns>
		bool WaitForIdle(string argName);

		/// <summary>
		/// 等待设备空闲
		/// </summary>
		/// <param name="argIndex"></param>
		/// <returns></returns>
		bool WaitForIdle(int argIndex);

		/// <summary>
		/// 等待设备空闲
		/// </summary>
		/// <param name="argVID"></param>
		/// <param name="argPID"></param>
		/// <returns></returns>
		bool WaitForIdle(int argVID, int argPID);

		#endregion


	}
}

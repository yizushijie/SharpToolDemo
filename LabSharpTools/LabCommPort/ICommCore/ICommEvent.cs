using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Harry.LabTools.LabCommType
{
	/// <summary>
	/// 设备变化设备变化事件
	/// </summary>
	public delegate void CCommChangeEvent();

	/// <summary>
	/// 委托事件
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void CCommEvent(object sender, EventArgs e);

	interface ICommEvent
	{
		#region 端口监控函数

		/// <summary>
		/// 添加端口监控函数
		/// </summary>
		/// <returns></returns>
		bool AddWatcherCommEvent();

		/// <summary>
		/// 添加端口监控函数
		/// </summary>
		/// <param name="interval">扫描周期</param>
		/// <returns></returns>
		bool AddWatcherCommEvent(TimeSpan interval);

		/// <summary>
		/// 监控端口的事件处理函数
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void EventWatcherCommHandler(Object sender, EventArrivedEventArgs e);

		/// <summary>
		/// 通讯数据接收事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void EventDataReceivedHandler(object sender, EventArgs e);

        /// <summary>
        /// 设备变化事件
        /// </summary>
        event CCommChangeEvent EventHandlerCCommChange;

		/// <summary>
		/// 数据接收事件
		/// </summary>
		event CCommEvent EventHandlerCCommReceData;

		#endregion

	}
}

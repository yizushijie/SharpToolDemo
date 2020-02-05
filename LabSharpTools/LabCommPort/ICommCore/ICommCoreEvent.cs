using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Harry.LabTools.LabCommPort
{
	/// <summary>
	/// 设备变化设备变化事件
	/// </summary>
	public delegate void EventCCommChanged();

	/// <summary>
	/// 委托事件
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void EventCCommDataReceived(object sender, EventArgs e);

	interface ICommEvent
	{
		#region	委托函数
		/// <summary>
		/// 设备变化事件句柄
		/// </summary>
		event EventCCommChanged			EventCCommChangedHandler;
		/// <summary>
		/// 数据接收事件句柄
		/// </summary>
		event EventCCommDataReceived	EventCCommDataReceivedHandler;

		#endregion
		
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

		#endregion

		#region 事件定义
		/// <summary>
		/// 监控端口的事件处理函数
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void HandleWatcherCommEvent(Object sender, EventArrivedEventArgs e);

		/// <summary>
		/// 通讯数据接收事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void HandleDataReceivedEvent(object sender, EventArgs e);
		
		#endregion
	}
}

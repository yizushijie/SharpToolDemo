using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Harry.LabTools.LabCommType
{
	public partial class CCommSerial
	{
		#region 变量定义
		/// <summary>
		/// 设备变化事件
		/// </summary>
		public override event CCommChangeEvent EventHandlerCCommChange;
		
		/// <summary>
		/// 数据接收事件
		/// </summary>
		public override event CCommEvent EventHandlerCCommReceData;

        #endregion

        #region 属性定义

        #endregion

        #region 构造函数

        #endregion

        #region 公有函数

        /// <summary>
        /// 通讯接口监控事件
        /// </summary>
        /// <returns></returns>
        public override bool AddWatcherCommEvent()
        {
            return base.AddWatcherCommEvent();
        }

        /// <summary>
        /// 通讯接口监控事件
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public override bool AddWatcherCommEvent(TimeSpan interval)
        {
            return base.AddWatcherCommEvent(interval);
        }

        #endregion

        #region 私有函数

        #endregion

        #region 事件函数

		/// <summary>
		/// 监控串口拔插事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void EventWatcherCommHandler(Object sender, EventArrivedEventArgs e)
		{
			//===备注：如果这个事件多次进入，请检查一下是否被多次注册；每次的初始化都会被注册一次
			if ((e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent"))
			{
				//---设备插入处理函数
				this.InsertDevice();
			}
			else if ((e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent"))
			{
				//---设备拔出处理函数
				this.RemoveDevice();
				//---设备变化事件
				if (this.EventHandlerCCommChange != null)
				{
					this.EventHandlerCCommChange?.Invoke();
				}
			}
		}

		/// <summary>
		/// 数据接收事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void EventDataReceivedHandler(object sender, EventArgs e)
		{
			string str = e.ToString();
			//---判断事件的类型
			if ((str == "SerialDataReceivedEventArgs") || (str == "System.IO.Ports.SerialDataReceivedEventArgs"))
			{
				if ((this.defaultSerialPort != null) && (this.defaultSerialPort.IsOpen == true) &&
					(this.defaultSerialSTATE == CCOMM_STATE.STATE_IDLE))
				{
					//---设置状态为事件读取
					this.defaultSerialSTATE = CCOMM_STATE.STATE_EVENTREAD;
					//---执行委托函数,数据接收函数
					if (this.EventHandlerCCommReceData!=null)
					{
						this.EventHandlerCCommReceData?.Invoke(sender, e);
					}					
					//---设置状态为空闲模式
					this.defaultSerialSTATE = CCOMM_STATE.STATE_IDLE;
				}
			}
		}

		#endregion
	}
}

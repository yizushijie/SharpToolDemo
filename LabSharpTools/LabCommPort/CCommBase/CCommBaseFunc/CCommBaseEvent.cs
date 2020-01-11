using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Harry.LabTools.LabCommType
{

	/// <summary>
	/// 端口监控事件函数
	/// </summary>
	public partial class CCommBase:ICommEvent
	{
		#region 变量定义

		/// <summary>
		/// 插入事件监视
		/// </summary>
		private ManagementEventWatcher defaultInsertWatcher = null;

		/// <summary>
		/// 拔出事件监视
		/// </summary>
		private ManagementEventWatcher defaultRemoveWatcher = null;


		/// <summary>
		/// 设备变化事件
		/// </summary>
		public virtual event CCommChangeEvent EventHandlerCCommChange = null;
		
		/// <summary>
		/// 数据接收事件
		/// </summary>
		public virtual event CCommEvent EventHandlerCCommReceData=null;

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
		public virtual bool AddWatcherCommEvent()
		{
            if ((this.defaultInsertWatcher == null) && (this.defaultRemoveWatcher == null))
            {
                return this.AddWatcherCommEvent(this.EventWatcherCommHandler, this.EventWatcherCommHandler, new TimeSpan(0, 0, 1));
            }
            else
            {
                return true;
            }
		}

		/// <summary>
		/// 通讯接口监控事件
		/// </summary>
		/// <param name="interval"></param>
		/// <returns></returns>
		public virtual bool AddWatcherCommEvent(TimeSpan interval)
		{
            if ((this.defaultInsertWatcher == null) && (this.defaultRemoveWatcher == null))
            {
                return this.AddWatcherCommEvent(this.EventWatcherCommHandler, this.EventWatcherCommHandler, interval);
            }
            else
            {
                return true;
            }
        }
		
		#endregion

		#region 私有函数
		/// <summary>
		/// 添加通讯端口监控事件
		/// </summary>
		/// <param name="insertHandler">插入事件</param>
		/// <param name="removeHandler">移除事件</param>
		/// <param name="interval">扫描周期，事件单位是秒</param>
		/// <returns></returns>
		private Boolean AddWatcherCommEvent(EventArrivedEventHandler insertHandler, EventArrivedEventHandler removeHandler, TimeSpan interval)
		{
			try
			{
				ManagementScope Scope = new ManagementScope("root\\CIMV2");
				Scope.Options.EnablePrivileges = true;

				//---USB插入监视
				if (insertHandler != null)
				{
					//---检查设备插入事件
					if (this.defaultInsertWatcher != null)
					{
						this.defaultInsertWatcher.Stop();
						this.defaultInsertWatcher = null;
					}
					WqlEventQuery insertQuery = new WqlEventQuery("__InstanceCreationEvent", interval, "TargetInstance isa 'Win32_USBControllerDevice'");
					this.defaultInsertWatcher = new ManagementEventWatcher(Scope, insertQuery);
					this.defaultInsertWatcher.EventArrived += insertHandler;
					this.defaultInsertWatcher.Options.Timeout = new TimeSpan(0, 0, 5);
					this.defaultInsertWatcher.Start();
				}

				//---USB拔出监视
				if (removeHandler != null)
				{
					//---检查设备移除事件
					if (this.defaultRemoveWatcher != null)
					{
						this.defaultRemoveWatcher.Stop();
						this.defaultRemoveWatcher = null;
					}
					WqlEventQuery removeQuery = new WqlEventQuery("__InstanceDeletionEvent", interval, "TargetInstance isa 'Win32_USBControllerDevice'");
                    this.defaultRemoveWatcher = new ManagementEventWatcher(Scope, removeQuery);
					this.defaultRemoveWatcher.EventArrived += removeHandler;
                    this.defaultRemoveWatcher.Options.Timeout = new TimeSpan(0, 0, 5);
                    this.defaultRemoveWatcher.Start();
				}
                
				return true;
			}
			catch (Exception)
			{
				this.DestroyWatcherCommEvent();
				return false;
			}
		}


		/// <summary>
		/// 移去USB事件监视器
		/// </summary>
		private void DestroyWatcherCommEvent()
		{
			if (this.defaultInsertWatcher != null)
			{
				this.defaultInsertWatcher.Stop();
				this.defaultInsertWatcher = null;
			}
			if (this.defaultRemoveWatcher != null)
			{
				this.defaultRemoveWatcher.Stop();
				this.defaultRemoveWatcher = null;
			}
		}
		#endregion

		#region 事件函数

		/// <summary>
		/// 端口监控事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void EventWatcherCommHandler(Object sender, EventArrivedEventArgs e)
		{
			
		}


		/// <summary>
		/// 数据接收事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void EventDataReceivedHandler(object sender, EventArgs e)
		{

		}

		#endregion
	}
}

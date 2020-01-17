using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Harry.LabTools.LabGenFunc
{
	public static partial class CGenFuncEvent
	{
		#region 函数定义

		/// <summary>
		/// 移除对象的事件
		/// </summary>
		/// <param name="obj">对象</param>
		/// <param name="eventName">事件名</param>
		public static void GenFuncClearAllEvents(object obj, string eventName)
		{
			EventInfo[] events = obj.GetType().GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			if (events == null || events.Length < 1)
			{
				return;
			}
			for (int i = 0; i < events.Length; i++)
			{
				EventInfo ei = events[i];
				if (ei.Name == eventName)
				{
					FieldInfo fi = ei.DeclaringType.GetField(eventName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
					if (fi != null)
					{
						fi.SetValue(obj, null);
					}
					break;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="control"></param>
		/// <param name="eventName"></param>
		public static void GenFuncClearAllEvents(Control control, string eventName)
		{
			if (control == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(eventName))
			{
				return;
			}
			
			BindingFlags mPropertyFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic;
			BindingFlags mFieldFlags = BindingFlags.Static | BindingFlags.NonPublic;
			Type controlType = typeof(System.Windows.Forms.Control);
			PropertyInfo propertyInfo = controlType.GetProperty("Events", mPropertyFlags);
			EventHandlerList eventHandlerList = (EventHandlerList)propertyInfo.GetValue(control, null);
			FieldInfo fieldInfo = (typeof(System.Windows.Forms.Control)).GetField("Event" + eventName, mFieldFlags);
			Delegate d = eventHandlerList[fieldInfo.GetValue(control)];
			
			if (d == null)
			{
				return;
			}
			EventInfo eventInfo = controlType.GetEvent(eventName);
			
			foreach (Delegate dx in d.GetInvocationList())
			{
				eventInfo.RemoveEventHandler(control, dx);
			}
		
		}

		#endregion
	}
}

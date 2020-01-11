using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
    /// <summary>
    /// 控件RichTextBox能够显示不用颜色的字体
    /// </summary>
    public static class CRichTextBoxPlus
    {
        /// <summary>
        /// 不同颜色显示数据
        /// </summary>
        /// <param name="rtBox">控件</param>
        /// <param name="text">显示信息</param>
        /// <param name="texColor">颜色</param>
        /// <param name="newLine ">是否换行</param>
        public static void AppendTextColorFull(RichTextBox rtBox, string text, Color textColor, bool newLine = true)
        {
			//---检查对象控件
			if (rtBox == null)
			{
				return;
			}
			//---检查消息是否为空
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			//---检查消息是否换行
			if (newLine)
            {
                text += Environment.NewLine;
            }

			//---异步调用
			if (rtBox.InvokeRequired)
            {
				rtBox.BeginInvoke((EventHandler)
			   //rtBox.Invoke((EventHandler)
                         (delegate
                         {
							 if ((rtBox.TextLength >= 0))
							 {
								 rtBox.SelectionStart = rtBox.TextLength;
								 rtBox.SelectionLength = 0;
								 rtBox.SelectionColor = textColor;

								 //在当前窗体中追加文本
								 rtBox.AppendText(text);
								 rtBox.SelectionColor = rtBox.ForeColor;
							 }
						 }));
            }
            else
            {
				if ((rtBox.TextLength >= 0))
				{
					rtBox.SelectionStart = rtBox.TextLength;
					rtBox.SelectionLength = 0;
					rtBox.SelectionColor = textColor;

					//在当前窗体中追加文本
					rtBox.AppendText(text);
					rtBox.SelectionColor = rtBox.ForeColor;
				}
            }
        }

        /// <summary>
        /// 显示指定颜色
        /// </summary>
        /// <param name="rtBox"></param>
        /// <param name="text"></param>
        /// <param name="textColor"></param>
        /// <param name="newLine"></param>
        public static void AppendTextInfo(RichTextBox rtBox, string text, Color textColor, bool newLine = true)
        {

			//---检查对象控件
			if (rtBox == null)
			{
				return;
			}
			//---检查消息是否为空
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			//---检查消息是否换行
			if (newLine)
            {
                text += Environment.NewLine;
            }
            if (rtBox.InvokeRequired)
            {
				rtBox.BeginInvoke((EventHandler)
						 //rtBox.Invoke((EventHandler)
						 (delegate
                         {
							 if ((rtBox.TextLength >= 0))
							 {
								 rtBox.SelectionStart = rtBox.TextLength;
								 rtBox.SelectionLength = 0;
								 rtBox.SelectionColor = textColor;

								 //在当前窗体中追加文本
								 rtBox.AppendText(text);
								 rtBox.SelectionColor = rtBox.ForeColor;

								 rtBox.SelectionStart = rtBox.Text.Length;
								 rtBox.ScrollToCaret();
								 rtBox.Focus();
							 }
                         }));
            }
            else
            {
				if ((rtBox.TextLength >= 0))
				{
					rtBox.SelectionStart = rtBox.TextLength;
					rtBox.SelectionLength = 0;
					rtBox.SelectionColor = textColor;

					//在当前窗体中追加文本
					rtBox.AppendText(text);
					rtBox.SelectionColor = rtBox.ForeColor;

					rtBox.SelectionStart = rtBox.Text.Length;
					rtBox.ScrollToCaret();
					rtBox.Focus();
				}
            }
        }

        /// <summary>
        /// 显示信息,在最上方显示
        /// </summary>
        /// <param name="rtBox"></param>
        /// <param name="text"></param>
        /// <param name="textColor"></param>
        /// <param name="newLine"></param>
        public static void AppendTextInfoTop(RichTextBox rtBox, string text, Color textColor, bool newLine = true)
        {
            string temp = string.Empty;

			//---检查对象控件
			if (rtBox == null)
			{
				return;
			}
			//---检查消息是否为空
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			//---检查消息是否换行
			if (newLine)
            {
                text += Environment.NewLine;
            }
            if (rtBox.InvokeRequired)
            {
				rtBox.BeginInvoke((EventHandler)
						 //rtBox.Invoke((EventHandler)
						 (delegate
                         {
							 if ((rtBox.TextLength >= 0))
							 {
								 temp = rtBox.Text;
								 rtBox.Clear();

								 rtBox.SelectionStart = rtBox.TextLength;
								 rtBox.SelectionLength = 0;
								 rtBox.SelectionColor = textColor;

								 //在当前窗体中追加文本
								 rtBox.AppendText(text);
								 rtBox.SelectionColor = rtBox.ForeColor;

								 rtBox.AppendText(temp);

								 //指向顶部
								 rtBox.SelectionStart = 0;
								 rtBox.ScrollToCaret();
								 rtBox.Focus();
							 }
                         }));
            }
            else
            {
				if ((rtBox.TextLength >= 0))
				{
					temp = rtBox.Text;
					rtBox.Clear();

					rtBox.SelectionStart = rtBox.TextLength;
					rtBox.SelectionLength = 0;
					rtBox.SelectionColor = textColor;

					//在当前窗体中追加文本
					rtBox.AppendText(text);
					rtBox.SelectionColor = rtBox.ForeColor;

					rtBox.AppendText(temp);

					//指向顶部
					rtBox.SelectionStart = 0;
					rtBox.ScrollToCaret();
					rtBox.Focus();
				}
            }
        }

        /// <summary>
        /// 显示信息，带有日期时间
        /// </summary>
        /// <param name="rtBox"></param>
        /// <param name="text"></param>
        /// <param name="textColor"></param>
        /// <param name="newLine"></param>
        public static void AppendTextInfoWithDataTime(RichTextBox rtBox, string text, Color textColor, bool newLine = true)
        {
			//---检查消息是否为空
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			
			string str = string.Format("{0} {1} {2}", System.DateTime.Now.ToString(), "：", text);

			//---检查对象控件
			if (rtBox == null)
			{
				return;
			}
			//---检查消息是否换行
			if (newLine)
            {
                str += Environment.NewLine;
            }
            if (rtBox.InvokeRequired)
            {
				rtBox.BeginInvoke((EventHandler)
						 //rtBox.Invoke((EventHandler)
						 (delegate
                         {
							 if ((rtBox.TextLength >= 0))
							 {
								 rtBox.SelectionStart = rtBox.TextLength;
								 rtBox.SelectionLength = 0;
								 rtBox.SelectionColor = textColor;

								 //在当前窗体中追加文本
								 rtBox.AppendText(str);
								 rtBox.SelectionColor = rtBox.ForeColor;

								 //直线底部
								 rtBox.SelectionStart = rtBox.Text.Length;
								 rtBox.ScrollToCaret();
								 rtBox.Focus();
							 }
                         }));
            }
            else
            {
				if ((rtBox.TextLength >= 0))
				{
					rtBox.SelectionStart = rtBox.TextLength;
					rtBox.SelectionLength = 0;
					rtBox.SelectionColor = textColor;

					//在当前窗体中追加文本
					rtBox.AppendText(str);
					rtBox.SelectionColor = rtBox.ForeColor;

					//直线底部
					rtBox.SelectionStart = rtBox.Text.Length;
					rtBox.ScrollToCaret();
					rtBox.Focus();
				}
            }
        }

        /// <summary>
        /// 显示信息，不含日期时间
        /// </summary>
        /// <param name="rtBox"></param>
        /// <param name="text"></param>
        /// <param name="textColor"></param>
        /// <param name="newLine"></param>
        public static void AppendTextInfoWithoutDataTime(RichTextBox rtBox, string text, Color textColor, bool newLine = true)
        {
			//---检查对象控件
			if (rtBox == null)
			{
				return;
			}
			//---检查消息是否为空
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (newLine)
            {
                text += Environment.NewLine;
            }
            if (rtBox.InvokeRequired)
            {
				rtBox.BeginInvoke((EventHandler)
						 //rtBox.Invoke((EventHandler)
						 (delegate
                         {
							 if ((rtBox.TextLength >= 0))
							 {
								 rtBox.SelectionStart = rtBox.TextLength;
								 rtBox.SelectionLength = 0;
								 rtBox.SelectionColor = textColor;

								 //在当前窗体中追加文本
								 rtBox.AppendText(text);
								 rtBox.SelectionColor = rtBox.ForeColor;

								 //直线底部
								 rtBox.SelectionStart = rtBox.Text.Length;
								 rtBox.ScrollToCaret();
								 rtBox.Focus();
							 }
                         }));
            }
            else
            {
				if((rtBox.TextLength >= 0))
				{
					rtBox.SelectionStart = rtBox.TextLength;
					rtBox.SelectionLength = 0;
					rtBox.SelectionColor = textColor;

					//在当前窗体中追加文本
					rtBox.AppendText(text);
					rtBox.SelectionColor = rtBox.ForeColor;

					//直线底部
					rtBox.SelectionStart = rtBox.Text.Length;
					rtBox.ScrollToCaret();
					rtBox.Focus();
				}
            }
        }

        /// <summary>
        /// 信息显示在顶部,并且含有日期时间
        /// </summary>
        /// <param name="rtBox"></param>
        /// <param name="text"></param>
        /// <param name="textColor"></param>
        /// <param name="newLine"></param>
        public static void AppendTextInfoTopWithDataTime(RichTextBox rtBox, string text, Color textColor, bool newLine = true)
        {
            string temp = string.Empty;
            string str = string.Empty;

			//---检查对象
			if (rtBox==null)
			{
				return;
			}
			//---检查消息是否为空
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (rtBox.InvokeRequired)
            {
				rtBox.BeginInvoke((EventHandler)
						 //rtBox.Invoke((EventHandler)
						 (delegate
                         {
							 temp = rtBox.Text;
							 rtBox.Clear();
							 str = string.Format("{0} {1} {2}", System.DateTime.Now.ToString(), "：", text);
							 AppendTextColorFull(rtBox, str, textColor, newLine);
							 rtBox.AppendText(temp);

							 //指向顶部
							 rtBox.SelectionStart = 0;
							 rtBox.ScrollToCaret();
							 rtBox.Focus();
						 }));
            }
            else
            {
				temp = rtBox.Text;
				rtBox.Clear();
				str = string.Format("{0} {1} {2}", System.DateTime.Now.ToString(), "：", text);
				AppendTextColorFull(rtBox, str, textColor, newLine);
				rtBox.AppendText(temp);

				//指向顶部
				rtBox.SelectionStart = 0;
				rtBox.ScrollToCaret();
				rtBox.Focus();
			}
        }

        /// <summary>
        /// 信息显示在顶部,不含有日期时间
        /// </summary>
        /// <param name="rtBox"></param>
        /// <param name="text"></param>
        /// <param name="textColor"></param>
        /// <param name="newLine"></param>
        public static void AppendTextInfoTopWithoutDataTime(RichTextBox rtBox, string text, Color textColor, bool newLine = true)
        {
            string temp = string.Empty;

			//---检查对象控件
			if (rtBox == null)
			{
				return;
			}
			//---检查消息是否为空
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			//---异步调用
			if (rtBox.InvokeRequired)
            {
				rtBox.BeginInvoke((EventHandler)
						 //rtBox.Invoke((EventHandler)
						 (delegate
                         {
							 temp = rtBox.Text;
							 rtBox.Clear();
							 AppendTextColorFull(rtBox, text, textColor, newLine);
							 rtBox.AppendText(temp);

							 //指向顶部
							 rtBox.SelectionStart = 0;
							 rtBox.ScrollToCaret();
							 rtBox.Focus();
						 }));
            }
            else
            {
				temp = rtBox.Text;
				rtBox.Clear();
				AppendTextColorFull(rtBox, text, textColor, newLine);
				rtBox.AppendText(temp);

				//指向顶部
				rtBox.SelectionStart = 0;
				rtBox.ScrollToCaret();
				rtBox.Focus();
			}
        }

        /// <summary>
        /// 清除文本
        /// </summary>
        /// <param name="rtb"></param>
        public static void Clear(RichTextBox rtBox)
        {
			//---检查对象控件
			if (rtBox == null)
			{
				return;
			}

			//---异步调用
			if (rtBox.InvokeRequired)
            {
				rtBox.BeginInvoke((EventHandler)
						 //rtBox.Invoke((EventHandler)
						 (delegate
                         {
                             rtBox.Clear();
                         }));
            }
            else
            {
                rtBox.Clear();
            }
        }

    }
}
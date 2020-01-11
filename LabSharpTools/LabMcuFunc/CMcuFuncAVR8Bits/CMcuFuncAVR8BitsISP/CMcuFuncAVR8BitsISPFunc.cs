using Harry.LabTools.LabControlPlus;
using Harry.LabTools.LabGenFunc;
using Harry.LabTools.LabHexEdit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabMcuFunc
{
	#region 使用的编程命令

	/// <summary>
	/// ISP编程使用的枚举变量
	/// </summary>
	public enum CMCUFUNC_CMD_ISP : byte 
	{
		CMD_ISP_OPEN_CLOSE		=0x10	,
		CMD_ISP_ERASE					,
		CMD_ISP_FLASH_PAGE_READ			,
		CMD_ISP_FLASH_PAGE_WRITE		,
		CMD_ISP_EEPROM_PAGE_READ		,
		CMD_ISP_EEPROM_PAGE_WRITE		,
		CMD_ISP_FUSE_LOCK_READ			,
		CMD_ISP_FUSE_WRITE				,
		CMD_ISP_LOCK_WRITE				,
		CMD_ISP_ID_READ					,
		CMD_ISP_CALIBRATIONBYTE_READ	,
		CMD_ISP_ROM_PAGE_READ			,
		CMD_ISP_PROG_CLOCK_SET			,
	}

	#endregion

	public partial class CMcuFuncAVR8BitsISP  
	{
		#region 变量定义

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		#endregion

		#region 公有函数

		#region 编程常规使用函数

		/// <summary>
		/// 打开连接
		/// </summary>
		/// <returns></returns>
		public override int CMcuFunc_OpenConnect(RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] {	(byte)CMCUFUNC_CMD_ISP.CMD_ISP_OPEN_CLOSE, 0x01,
											(byte)((this.mMcuInfoParam.mPollReady==true)?1:0),
											(byte)(this.mMcuInfoParam.mChipFlashPerPageWordNum>>8),(byte)(this.mMcuInfoParam.mChipFlashPerPageWordNum),
											(byte)(this.mMcuInfoParam.mChipEepromPerPageByteNum>>8),(byte)(this.mMcuInfoParam.mChipEepromPerPageByteNum),
											(byte)((this.mMcuInfoParam.mChipEepromPageMode==true)?1:0)
										};
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：接口打开成功!";
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：接口打开命令校验错误!";
					}
				}
				else
				{					
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return==0?Color.Black:Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 关闭连接
		/// </summary>
		/// <returns></returns>
		public override int CMcuFunc_CloseConnect( RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_OPEN_CLOSE, 0x00 };
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：接口关闭成功!";
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：接口关闭命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 芯片擦除
		/// </summary>
		/// <returns></returns>
		public override int CMcuFunc_EraseChip(RichTextBox msg)
		{
			int _return = -1;
			//---校验端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_ERASE, 0x00 };
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：擦除成功!";
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：擦除命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取Flash
		/// </summary>
		/// <param name="flash"></param>
		/// <returns></returns>
		public override int CMcuFunc_ReadChipFlash(ref byte[] chipFlash, RichTextBox msg, ToolStripLabel workState = null, ToolStripLabel workTime = null, ToolStripProgressBar workBar = null, string str = "读取Flash")
		{
			int _return = -1;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				if (chipFlash==null)
				{
					//---申请缓存区
					chipFlash = new byte[this.mMcuInfoParam.mChipFlashByteSize];
				}
				//---工作状态
				if (workState != null)
				{
					workState.Text = "读取Flash";
				}
				//---计算耗时
				DateTime nowTime = DateTime.Now;
				//---长度大小
				int length = 2;
				//---每包数据最大数量
				int packageMaxSize = 0;
				//---最大包数
				int packageMaxNum = 0;
				//---数据的地址
				long addr = 0;
				//---发送命令
				byte[] cmd = null;
				//---命令定义解析
				if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
				{
					//---大数据长度数据传输
					cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FLASH_PAGE_READ, 0x00,0x00,0x00,0x00,0x00 };
					length += 1;
				}
				else
				{
					//---小数据包长度
					cmd= new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FLASH_PAGE_READ, 0x00, 0x00, 0x00, 0x00 };
				}
				//---计算数据包的大小
				packageMaxSize = this.mCCOMM.mPerPackageMaxSize - length-cmd.Length;
				//---数据长度必须是偶数
				if ((packageMaxSize & 0x01)!=0)
				{
					packageMaxSize -= 1;
				}
				//---计算读取的包数
				packageMaxNum = (int)(this.mMcuInfoParam.mChipFlashByteSize / packageMaxSize);
				//---校验是不是整数包
				if ((this.mMcuInfoParam.mChipFlashByteSize%packageMaxSize)!=0)
				{
					packageMaxNum += 1;
				}
				//---进度条
				if (workBar != null)
				{
					workBar.Maximum = packageMaxNum;
					workBar.Step = 1;
					workBar.Value = 0;
				}
				//---读取命令
				byte[] res = null;
				//---循环读取数据
				for (int i=0;i<packageMaxNum;i++)
				{
					//---每包的数据长度
					length = ((this.mMcuInfoParam.mChipFlashByteSize - i * packageMaxSize) > packageMaxSize) ? packageMaxSize : (int)(this.mMcuInfoParam.mChipFlashByteSize - i * packageMaxSize);
					//---校验是不是大包数据传输
					if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
					{
						//---大数据长度数据传输
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FLASH_PAGE_READ,(byte)(addr>>16) , (byte)(addr>>8), (byte)(addr), (byte)(length>>8), (byte)(length) };
					}
					else
					{
						//---小数据包长度
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FLASH_PAGE_READ, (byte)(addr >> 16), (byte)(addr >> 8), (byte)(addr), (byte)(length) };
					}
					//---发送并读取命令
					_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
					//---校验结果
					if (_return == 0)
					{
						if (this.mCCOMM.mReceCheckPass)
						{
							//---将读取的数据拷贝到数据缓存区
							Array.Copy(this.mCCOMM.mReceData.mArray, this.mCCOMM.mReceData.mIndexOffset, chipFlash, (addr * 2), length);
							//---地址进行偏移，准备下次读取
							addr += (length / 2);
						}
						else
						{
							_return = 1;
							this.mMsgText = "ISP编程：Flash读取命令校验错误!";
							//---退出循环
							break;
						}
					}
					else
					{
						this.mMsgText = this.mCCOMM.mLogMsg;
						//---退出循环
						break;
					}
					//---加载进度条
					if (workBar != null)
					{
						workBar.Value += 1;
					}
				}
				if (_return==0)
				{
					this.mMsgText = "ISP编程：Flash读取成功!";
					TimeSpan timeSpan = DateTime.Now - nowTime;
					if (workTime != null)
					{
						workTime.Text = timeSpan.Hours.ToString("#00") + ":" + timeSpan.Minutes.ToString("#00") + ":" + timeSpan.Seconds.ToString("#00");
					}
				}
				if (workState != null)
				{
					workState.Text = "空闲";
				}
				if (workBar != null)
				{
					workBar.Value = 0;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 编程Flash
		/// </summary>
		/// <param name="flash"></param>
		/// <returns></returns>
		public override int CMcuFunc_WriteChipFlash(byte[] chipFlash, RichTextBox msg, bool isAuto = false, ToolStripLabel  workState=null, ToolStripLabel workTime=null, ToolStripProgressBar workBar=null, string str = "编程Flash")
		{
			int _return = 0;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{	
				//---校验是否需要进入编程模式
				if (isAuto==true)
				{
					_return = this.CMcuFunc_OpenConnect(null);
				}
				//---校验编程模式，进入Flash编程任务
				if (_return == 0)
				{
					//---工作状态
					if (workState!=null)
					{
						workState.Text = str;// "编程Flash";
					}
					//---计算耗时
					DateTime nowTime = DateTime.Now;
					//---保存读取的数据
					byte[][][] flash = null;
					//---发送命令
					byte[] cmd = null;
					//---数据接收
					byte[] res = null;
					//---
					int length = 2;
					//---每包数据最大数量
					int packageMaxSize = 0;
					//---数据的地址
					long addr = 0;
					//---校验最大数据传输量
					if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
					{
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FLASH_PAGE_WRITE, 0x00, 0x00, 0x00, 0x00, 0x00 };
						length += 1;
					}
					else
					{
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FLASH_PAGE_WRITE, 0x00, 0x00, 0x00, 0x00 };
					}
					//---计算数据包的大小
					packageMaxSize = this.mCCOMM.mPerPackageMaxSize - length - cmd.Length;
					//---数据长度必须是偶数
					if ((packageMaxSize & 0x01) != 0)
					{
						packageMaxSize -= 1;
					}
					//---命令数据的偏移
					int cmdDataOffset = cmd.Length;
					//---将数据进行打包处理
					flash = CGenFuncPackage.GenFuncPackage(chipFlash, this.mMcuInfoParam.mChipFlashPerPageByteNum, packageMaxSize);
					//---进度条
					if ((workBar!=null)&&(flash!=null))
					{
						workBar.Maximum = flash.Length;
						workBar.Step = 1;
						workBar.Value = 0;
					}
					//---大包数据处理
					for (int i = 0; i < flash.Length; i++)
					{
						//---计算页地址
						cmd[1] = (byte)(addr >> 16);
						cmd[2] = (byte)(addr >> 8);
						cmd[3] = (byte)(addr);
						//---校验数据包是不是全0xFF
						if (CGenFuncEqual.GenFuncEqual(CGenFuncUnPackage.GenFuncUnPackage(flash[i]))==false)
						{
							for (int j = 0; j < flash[i].Length; j++)
							{
								length = flash[i][j].Length;
								//---重置发送数据缓存区的大小
								Array.Resize<byte>(ref cmd, (length+ cmdDataOffset));
								//---将数据拷贝到指定位置
								Array.Copy(flash[i][j], 0, cmd, cmdDataOffset, length);
								//---计算数据的长度
								if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
								{
									cmd[4] = (byte)(length>>8);
									cmd[5] = (byte)(length);
								}
								else
								{
									cmd[4] = (byte)(length);
								}
								//---发送并读取命令
								_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
								//---校验结果
								if (_return == 0)
								{
									if (this.mCCOMM.mReceCheckPass==false)
									{
										_return = 1;
										this.mMsgText = "ISP编程：Flash编程命令校验错误!";
										//---退出循环
										break;
									}
								}
								else
								{
									this.mMsgText = this.mCCOMM.mLogMsg;
									//---退出循环
									break;
								}
							}
						}
						//---加载进度条
						if (workBar != null)
						{
							workBar.Value +=1;
						}
						//---也地址进行偏移
						addr += this.mMcuInfoParam.mChipFlashPerPageWordNum;
						//---校验编程是否出错
						if (_return!=0)
						{
							break;
						}
					}
					if (_return == 0)
					{
						this.mMsgText = "ISP编程：Flash编程成功!";
						TimeSpan timeSpan = DateTime.Now - nowTime;
						if (workTime!=null)
						{
							workTime.Text = timeSpan.Hours.ToString("#00")+":"+ timeSpan.Minutes.ToString("#00") + ":"+ timeSpan.Seconds.ToString("#00");
						}
					}
					if (workState != null)
					{
						workState.Text = "空闲";
					}
					if (workBar != null)
					{
						workBar.Value = 0;
					}
				}
				else
				{
					MessageBox.Show("进入编程模式错误，请检查编程器与目标板的连线是否正确？",
													"消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return -2;
				}
			}
			else
			{
				_return = -1;
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 校验Flash
		/// </summary>
		/// <param name="flash"></param>
		/// <returns></returns>
		public override int CMcuFunc_CheckChipFlash(byte[] chipFlash, RichTextBox msg, ToolStripLabel workState = null, ToolStripLabel workTime = null, ToolStripProgressBar workBar = null, string str = "校验Flash")
		{
			int _return = -1;
			byte[] tempFlash = null;
			_return = this.CMcuFunc_ReadChipFlash(ref tempFlash, msg,workState,workTime,workBar,str);
			//---校验Flash是否读取成功
			if (_return == 0)
			{
				//---位置信息
				int pos = 0;
				//---校验数据是否相等
				if (CGenFuncEqual.GenFuncEqual(tempFlash, chipFlash, ref pos) == true)
				{
					this.mMsgText = "ISP编程：Flash校验通过！";
					if (msg != null)
					{
						CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, Color.Black);
					}
				}
				else
				{
					_return = 1;
					this.mMsgText = "ISP编程：Flash校验错误！";
				}
			}
			return _return;
		}

		/// <summary>
		/// 校验Flash为空
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CMcuFunc_CheckChipFlashEmpty(RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				byte[] cmd = new byte[] {	(byte)CMCUFUNC_CMD_ISP.CMD_ISP_ERASE, 0x01,
											(byte)(this.mMcuInfoParam.mChipEepromPerPageByteNum>>8), (byte)(this.mMcuInfoParam.mChipEepromPerPageByteNum),
											(byte)(this.mMcuInfoParam.mChipFlashPageNum>>8), (byte)(this.mMcuInfoParam.mChipFlashPageNum),
										};
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						if (this.mCCOMM.mReceData.mArray[this.mCCOMM.mReceData.mIndexOffset] == 0x00)
						{
							this.mMsgText = "ISP编程：Flash为空!";
						}
						else
						{
							this.mMsgText = "ISP编程：Flash不为空!";
							//---弹出窗体
							MessageBox.Show("Flash不为空！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：Flash查空命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取Eeprom
		/// </summary>
		/// <param name="flash"></param>
		/// <returns></returns>
		public override int CMcuFunc_ReadChipEeprom(ref byte[] chipEeprom, RichTextBox msg, ToolStripLabel workState = null, ToolStripLabel workTime = null, ToolStripProgressBar workBar = null,string str="读取Eeprom")
		{
			int _return = -1;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---校验缓存区
				if (chipEeprom == null)
				{
					//---申请缓存区
					chipEeprom = new byte[this.mMcuInfoParam.mChipEepromByteSize];
				}
				//---工作状态
				if (workState != null)
				{
					workState.Text = str;//"读取Eeprom";
				}
				//---计算耗时
				DateTime nowTime = DateTime.Now;
				//---长度大小
				int length = 2;
				//---每包数据最大数量
				int packageMaxSize = 0;
				//---最大包数
				int packageMaxNum = 0;
				//---数据的地址
				long addr = 0;
				//---发送命令
				byte[] cmd = null;
				//---命令定义解析
				if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
				{
					//---大数据长度数据传输
					cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_EEPROM_PAGE_READ, 0x00, 0x00, 0x00, 0x00};
					length += 1;
				}
				else
				{
					//---小数据包长度
					cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_EEPROM_PAGE_READ, 0x00, 0x00, 0x00 };
				}
				//---计算数据包的大小
				packageMaxSize = this.mCCOMM.mPerPackageMaxSize - length - cmd.Length;
				//---数据长度必须是偶数
				if ((packageMaxSize & 0x01) != 0)
				{
					packageMaxSize -= 1;
				}
				//---计算读取的包数
				packageMaxNum = (int)(this.mMcuInfoParam.mChipEepromByteSize / packageMaxSize);
				//---校验是不是整数包
				if ((this.mMcuInfoParam.mChipEepromByteSize % packageMaxSize) != 0)
				{
					packageMaxNum += 1;
				}
				//---进度条
				if (workBar != null)
				{
					workBar.Maximum = packageMaxNum;
					workBar.Step = 1;
					workBar.Value = 0;
				}
				//---读取命令
				byte[] res = null;
				//---循环读取数据
				for (int i = 0; i < packageMaxNum; i++)
				{
					//---每包的数据长度
					length = ((this.mMcuInfoParam.mChipEepromByteSize - i * packageMaxSize) > packageMaxSize) ? packageMaxSize : (int)(this.mMcuInfoParam.mChipEepromByteSize - i * packageMaxSize);
					//---校验是不是大包数据传输
					if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
					{
						//---大数据长度数据传输
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_EEPROM_PAGE_READ, (byte)(addr >> 8), (byte)(addr), (byte)(length >> 8), (byte)(length) };
					}
					else
					{
						//---小数据包长度
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_EEPROM_PAGE_READ, (byte)(addr >> 8), (byte)(addr), (byte)(length) };
					}
					//---发送并读取命令
					_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
					//---校验结果
					if (_return == 0)
					{
						if (this.mCCOMM.mReceCheckPass)
						{
							//---将读取的数据拷贝到数据缓存区
							Array.Copy(this.mCCOMM.mReceData.mArray, this.mCCOMM.mReceData.mIndexOffset, chipEeprom, addr, length);
							//---地址进行偏移，准备下次读取
							addr += length ;
						}
						else
						{
							_return = 1;
							this.mMsgText = "ISP编程：Eeprom读取命令校验错误!";
							//---退出循环
							break;
						}
					}
					else
					{
						this.mMsgText = this.mCCOMM.mLogMsg;
						//---退出循环
						break;
					}
				}
				if (_return == 0)
				{
					this.mMsgText = "ISP编程：Eeprom读取成功!";
					TimeSpan timeSpan = DateTime.Now - nowTime;
					if (workTime != null)
					{
						workTime.Text = timeSpan.Hours.ToString("#00") + ":" + timeSpan.Minutes.ToString("#00") + ":" + timeSpan.Seconds.ToString("#00");
					}
				}
				if (workState != null)
				{
					workState.Text = "空闲";
				}
				if (workBar != null)
				{
					workBar.Value = 0;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 编程Eeprom
		/// </summary>
		/// <param name="flash"></param>
		/// <returns></returns>
		public override int CMcuFunc_WriteChipEeprom(byte[] chipEeprom, RichTextBox msg, bool isAuto = false, ToolStripLabel workState = null, ToolStripLabel workTime = null, ToolStripProgressBar workBar = null,string str= "编程Eeprom")
		{
			int _return = -1;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---校验是否需要进入编程模式
				if (isAuto == true)
				{
					_return = this.CMcuFunc_OpenConnect(null);
				}
				//---校验编程模式，进入Flash编程任务
				if (_return == 0)
				{

					//---工作状态
					if (workState != null)
					{
						workState.Text = str;// "编程Flash";
					}
					//---计算耗时
					DateTime nowTime = DateTime.Now;
					//---保存读取的数据
					byte[][] eeprom = null;
					//---发送命令
					byte[] cmd = null;
					//---数据接收
					byte[] res = null;
					//---
					int length = 2;
					//---每包数据最大数量
					int packageMaxSize = 0;
					//---数据的地址
					long addr = 0;
					//---校验最大数据传输量
					if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
					{
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_EEPROM_PAGE_WRITE, 0x00, 0x00, 0x00, 0x00 };
						length += 1;
					}
					else
					{
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_EEPROM_PAGE_WRITE, 0x00, 0x00, 0x00 };
					}
					//---计算数据包的大小
					packageMaxSize = this.mCCOMM.mPerPackageMaxSize - length - cmd.Length;
					//---数据长度必须是偶数
					if ((packageMaxSize & 0x01) != 0)
					{
						packageMaxSize -= 1;
					}
					//---校验支持页编程模式
					if (this.mMcuInfoParam.mChipEepromPageMode==true)
					{
						//---校验数据个数必须是页字节数的整数倍
						if ((packageMaxSize % (this.mMcuInfoParam.mChipEepromPerPageByteNum)) != 0)
						{
							//---计算页数
							packageMaxSize /= (this.mMcuInfoParam.mChipEepromPerPageByteNum);
							//---计算每包字节数
							packageMaxSize *= (this.mMcuInfoParam.mChipEepromPerPageByteNum);
						}
					}					
					//---命令数据的偏移
					int cmdDataOffset = cmd.Length;
					//---将数据进行打包处理
					eeprom = CGenFuncPackage.GenFuncPackage(chipEeprom, packageMaxSize);
					//---进度条
					if ((workBar != null) && (eeprom != null))
					{
						workBar.Maximum = eeprom.Length;
						workBar.Step = 1;
						workBar.Value = 0;
					}
					//---大包数据处理
					for (int i = 0; i < eeprom.Length; i++)
					{
						//---计算页地址
						cmd[1] = (byte)(addr >> 8);
						cmd[2] = (byte)(addr);
						length = eeprom[i].Length;
						//---重置发送数据缓存区的大小
						Array.Resize<byte>(ref cmd, (length + cmdDataOffset));
						//---将数据拷贝到指定位置
						Array.Copy(eeprom[i], 0, cmd, cmdDataOffset, length);
						//---计算数据的长度
						if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
						{
							cmd[3] = (byte)(length >> 8);
							cmd[4] = (byte)(length);
						}
						else
						{
							cmd[3] = (byte)(length);
						}
						//---发送并读取命令
						_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res, (length < 15) ? 200 : (length * 15));
						//---校验结果
						if (_return == 0)
						{
							if (this.mCCOMM.mReceCheckPass == false)
							{
								_return = 1;
								this.mMsgText = "ISP编程：Eeprom编程命令校验错误!";
								//---退出循环
								break;
							}
						}
						else
						{
							this.mMsgText = this.mCCOMM.mLogMsg;
							//---退出循环
							break;
						}
						//---加载进度条
						if (workBar != null)
						{
							workBar.Value += 1;
						}
						//---地址进行偏移
						addr += packageMaxSize;
						//---校验编程是否出错
						if (_return != 0)
						{
							break;
						}
					}
					if (_return == 0)
					{
						this.mMsgText = "ISP编程：Eeprom编程成功!";
						TimeSpan timeSpan = DateTime.Now - nowTime;
						if (workTime != null)
						{
							workTime.Text = timeSpan.Hours.ToString("#00") + ":" + timeSpan.Minutes.ToString("#00") + ":" + timeSpan.Seconds.ToString("#00");
						}
					}
					if (workState != null)
					{
						workState.Text = "空闲";
					}
					if (workBar != null)
					{
						workBar.Value = 0;
					}
				}
			}
			else
			{
				_return = -1;
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 校验Eeprom
		/// </summary>
		/// <param name="flash"></param>
		/// <returns></returns>
		public override int CMcuFunc_CheckChipEeprom(byte[] chipEeprom, RichTextBox msg, ToolStripLabel workState = null, ToolStripLabel workTime = null, ToolStripProgressBar workBar = null, string str = "校验Eeprom")
		{
			int _return = -1;
			byte[] tempEeprom = null;
			_return = this.CMcuFunc_ReadChipEeprom(ref tempEeprom, msg,workState,workTime,workBar,str);
			//---校验Eeprom是否读取成功
			if (_return==0)
			{
				//---位置信息
				int pos = 0;
				//---校验数据是否相等
				if (CGenFuncEqual.GenFuncEqual(tempEeprom, chipEeprom, ref pos) == true)
				{
					this.mMsgText = "ISP编程：Eeprom校验通过！";
					if (msg != null)
					{
						CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText,  Color.Black);
					}
				}
				else
				{
					_return = 1;
					this.mMsgText = "ISP编程：Eeprom校验错误！";
				}
			}
			return _return;
		}

		/// <summary>
		/// 校验Eeprom为空
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CMcuFunc_CheckChipEepromEmpty(RichTextBox msg)
		{
			int _return = -1;
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				byte[] cmd = new byte[] {	(byte)CMCUFUNC_CMD_ISP.CMD_ISP_ERASE, 0x02,
											(byte)(this.mMcuInfoParam.mChipEepromPerPageByteNum),
											(byte)(this.mMcuInfoParam.mChipEepromPageNum>>8),(byte)(this.mMcuInfoParam.mChipEepromPageNum)
										};
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						if (this.mCCOMM.mReceData.mArray[this.mCCOMM.mReceData.mIndexOffset]==0x00)
						{
							this.mMsgText = "ISP编程：Eeprom为空!";
						}
						else
						{
							this.mMsgText = "ISP编程：Eeprom不为空!";
							//---弹出窗体
							MessageBox.Show("Eeprom不为空！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：Eeprom查空命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取熔丝位
		/// </summary>
		/// <param name="fuse"></param>
		/// <returns></returns>
		public override int CMcuFunc_ReadChipFuse(ref byte[] chipFuse, RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FUSE_LOCK_READ, 0x00,(byte)(this.mMcuInfoParam.mChipFuse.Length>2?1:0)};
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：熔丝位读取成功!";
						//---申请缓存区
						chipFuse = new byte[this.mMcuInfoParam.mChipFuse.Length];
						//---拷贝数据
						Array.Copy(this.mCCOMM.mReceData.mArray, this.mCCOMM.mReceData.mIndexOffset, chipFuse,0, chipFuse.Length);
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：熔丝位读取命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取加密位
		/// </summary>
		/// <param name="fuse"></param>
		/// <returns></returns>
		public override int CMcuFunc_ReadChipLock(ref byte chipLock, RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FUSE_LOCK_READ, 0x01};
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：加密位读取成功!";
						//---获取加密位信息
						chipLock = this.mCCOMM.mReceData.mArray[this.mCCOMM.mReceData.mIndexOffset];
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：加密位读取命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取熔丝位
		/// </summary>
		/// <param name="fuse"></param>
		/// <returns></returns>
		public override int CMcuFunc_WriteChipFuse(byte[] chipFuse, RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = null;
				//---校验拓展位
				if (this.mMcuInfoParam.mChipFuse.Length > 2)
				{
					cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FUSE_WRITE,0x01, chipFuse[0], chipFuse[1], chipFuse[2] };
				}
				else
				{
					cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_FUSE_WRITE,0x00, chipFuse[0], chipFuse[1]};
				}				
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：熔丝位写入成功!";
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：熔丝位写入命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取加密位
		/// </summary>
		/// <param name="fuse"></param>
		/// <returns></returns>
		public override int CMcuFunc_WriteChipLock(byte chipLock, RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_LOCK_WRITE, chipLock };
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：加密位写入成功!";
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：加密位写入命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取芯片的ID信息
		/// </summary>
		/// <param name="chipID"></param>
		/// <returns></returns>
		public override int CMcuFunc_ReadChipID(ref byte[] chipID, RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_ID_READ};
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						if ((this.mCCOMM.mReceData.mLength - this.mCCOMM.mReceData.mIndexOffset) == this.mMcuInfoParam.mChipID.Length)
						{
							this.mMsgText = "ISP编程：ChipID读取成功!";
							//---申请缓存区
							chipID = new byte[this.mMcuInfoParam.mChipID.Length];
							//---拷贝数据
							Array.Copy(this.mCCOMM.mReceData.mArray, this.mCCOMM.mReceData.mIndexOffset, chipID, 0, chipID.Length);
						}
						else
						{
							this.mMsgText = "ISP编程：ChipID读取成功，但数据不完整!";
							_return = 1;
						}
					}
					else
					{
						_return = 2;
						this.mMsgText = "ISP编程：ChipID读取命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取校准字
		/// </summary>
		/// <param name="chipCalibration"></param>
		/// <returns></returns>
		public override int CMcuFunc_ReadChipCalibration(ref byte[] chipCalibration, RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_CALIBRATIONBYTE_READ,(byte)(this.mMcuInfoParam.mChipOSCCalibration.mText.Length) };
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：校准字读取成功!";
						//---申请缓存区
						chipCalibration = new byte[this.mMcuInfoParam.mChipOSCCalibration.mText.Length];
						//---拷贝数据
						Array.Copy(this.mCCOMM.mReceData.mArray, this.mCCOMM.mReceData.mIndexOffset, chipCalibration, 0, chipCalibration.Length);
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：校准字读取命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取ROM信息
		/// </summary>
		/// <param name="chipRom"></param>
		/// <returns></returns>
		public override int CMcuFunc_ReadChipRom(ref byte[] chipRom, RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				if (chipRom == null)
				{
					//---申请缓存区
					chipRom = new byte[this.mMcuInfoParam.mChipFlashPerPageByteNum];
				}
				//---计算耗时
				DateTime nowTime = DateTime.Now;
				//---长度大小
				int length = 2;
				//---每包数据最大数量
				int packageMaxSize = 0;
				//---最大包数
				int packageMaxNum = 0;
				//---数据的地址
				long addr = 0;
				//---发送命令
				byte[] cmd = null;
				//---命令定义解析
				if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
				{
					//---大数据长度数据传输
					cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_ROM_PAGE_READ, 0x00, 0x00, 0x00 };
					length += 1;
				}
				else
				{
					//---小数据包长度
					cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_ROM_PAGE_READ, 0x00, 0x00 };
				}
				//---计算数据包的大小
				packageMaxSize = this.mCCOMM.mPerPackageMaxSize - length - cmd.Length;
				//---数据长度必须是偶数
				if ((packageMaxSize & 0x01) != 0)
				{
					packageMaxSize -= 1;
				}
				//---计算读取的包数
				packageMaxNum = (int)(this.mMcuInfoParam.mChipFlashPerPageByteNum / packageMaxSize);
				//---校验是不是整数包
				if ((this.mMcuInfoParam.mChipFlashPerPageByteNum % packageMaxSize) != 0)
				{
					packageMaxNum += 1;
				}
				//---读取命令
				byte[] res = null;
				//---循环读取数据
				for (int i = 0; i < packageMaxNum; i++)
				{
					//---每包的数据长度
					length = ((this.mMcuInfoParam.mChipFlashPerPageByteNum - i * packageMaxSize) > packageMaxSize) ? packageMaxSize : (int)(this.mMcuInfoParam.mChipFlashPerPageByteNum - i * packageMaxSize);
					//---校验是不是大包数据传输
					if (this.mCCOMM.mPerPackageMaxSize > 0xFF)
					{
						//---大数据长度数据传输
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_ROM_PAGE_READ, (byte)(addr), (byte)(length >> 8), (byte)(length) };
					}
					else
					{
						//---小数据包长度
						cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_ROM_PAGE_READ, (byte)(addr), (byte)(length) };
					}
					//---发送并读取命令
					_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
					//---校验结果
					if (_return == 0)
					{
						if (this.mCCOMM.mReceCheckPass)
						{
							//---将读取的数据拷贝到数据缓存区
							Array.Copy(this.mCCOMM.mReceData.mArray, this.mCCOMM.mReceData.mIndexOffset, chipRom, (addr * 2), length);
							//---地址进行偏移，准备下次读取
							addr += (length / 2);
						}
						else
						{
							_return = 1;
							this.mMsgText = "ISP编程：ROM读取命令校验错误!";
							//---退出循环
							break;
						}
					}
					else
					{
						this.mMsgText = this.mCCOMM.mLogMsg;
						//---退出循环
						break;
					}
				}
				if (_return == 0)
				{
					this.mMsgText = "ISP编程：ROM读取成功!";
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 编程时钟设置
		/// </summary>
		/// <param name="chipClock"></param>
		/// <returns></returns>
		public override int CMcuFunc_SetProgClock(byte chipClock, RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] { (byte)CMCUFUNC_CMD_ISP.CMD_ISP_PROG_CLOCK_SET,0x00,chipClock };
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：编程时钟设置成功!";
					}
					else
					{
						_return = 2;
						this.mMsgText = "ISP编程：编程时钟设置命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 使能Eeprom的页编程模式
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CMcuFunc_EnableEepromPageMode(RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] {   (byte)CMCUFUNC_CMD_ISP.CMD_ISP_OPEN_CLOSE, 0x02,
											(byte)((this.mMcuInfoParam.mPollReady==true)?1:0),
											(byte)(this.mMcuInfoParam.mChipFlashPerPageWordNum>>8),(byte)(this.mMcuInfoParam.mChipFlashPerPageWordNum),
											(byte)(this.mMcuInfoParam.mChipEepromPerPageByteNum>>8),(byte)(this.mMcuInfoParam.mChipEepromPerPageByteNum),
											(byte)((this.mMcuInfoParam.mChipEepromPageMode==true)?1:0)
										};
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：EEPROM页编程模式打开!";
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：EEPROM页编程打开命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 不使能Eeprom的页编程模式
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CMcuFunc_DisableEepromPageMode(RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯端口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] {   (byte)CMCUFUNC_CMD_ISP.CMD_ISP_OPEN_CLOSE, 0x02,
											(byte)((this.mMcuInfoParam.mPollReady==true)?1:0),
											(byte)(this.mMcuInfoParam.mChipFlashPerPageWordNum>>8),(byte)(this.mMcuInfoParam.mChipFlashPerPageWordNum),
											(byte)(this.mMcuInfoParam.mChipEepromPerPageByteNum>>8),(byte)(this.mMcuInfoParam.mChipEepromPerPageByteNum),
											0
										};
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：EEPROM页编程模式关闭!";
					}
					else
					{
						_return = 1;
						this.mMsgText = "ISP编程：EEPROM页编程关闭命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 写入设备的供电电压
		/// </summary>
		/// <param name="pwr"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CMcuFunc_WriteChipPower(int chipPWR, RichTextBox msg, bool isOpen = true)
		{
			int _return = -1;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] {	(byte)CMCUFUNC_CMD_ISP.CMD_ISP_PROG_CLOCK_SET, 0x02, 
											(byte)(chipPWR>>8),(byte)(chipPWR),
											(byte)((isOpen==true)?1:0)
										};
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if (this.mCCOMM.mReceCheckPass)
					{
						this.mMsgText = "ISP编程：供电电压设置成功!";
					}
					else
					{
						_return = 2;
						this.mMsgText = "ISP编程：供电电压设置命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 读取设备的供电电压
		/// </summary>
		/// <param name="pwr"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CMcuFunc_ReadChipPower(ref int chipPWR, RichTextBox msg)
		{
			int _return = -1;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				//---发送命令
				byte[] cmd = new byte[] {   (byte)CMCUFUNC_CMD_ISP.CMD_ISP_PROG_CLOCK_SET, 0x01 };
				//---读取命令
				byte[] res = null;
				//---发送并读取命令
				_return = this.mCCOMM.SendCmdAndReadResponse(cmd, ref res);
				//---校验结果
				if (_return == 0)
				{
					if ((this.mCCOMM.mReceCheckPass)&&((this.mCCOMM.mReceData.mIndexOffset+1)<=this.mCCOMM.mReceData.mArray.Length))
					{
						this.mMsgText = "ISP编程：供电电压读取成功!";
						chipPWR=BitConverter.ToUInt16(new byte[2] { this.mCCOMM.mReceData.mArray[this.mCCOMM.mReceData.mIndexOffset+1], this.mCCOMM.mReceData.mArray[this.mCCOMM.mReceData.mIndexOffset] }, 0);
					}
					else
					{
						_return = 2;
						this.mMsgText = "ISP编程：供电电压读取命令校验错误!";
					}
				}
				else
				{
					this.mMsgText = this.mCCOMM.mLogMsg;
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="chipFuse"></param>
		/// <param name="chipLock"></param>
		/// <param name="chipFlash"></param>
		/// <param name="chipEeprom"></param>
		/// <param name="msg"></param>
		/// <param name="workState"></param>
		/// <param name="workTime"></param>
		/// <param name="workBar"></param>
		/// <returns></returns>
		public override int CMcuFunc_DoChipTask(byte[] chipFuse, byte chipLock, CHexBox chipFlash, CHexBox chipEeprom, RichTextBox msg, ToolStripLabel workState, ToolStripLabel workTime, ToolStripProgressBar workBar)
		{
			int _return = -1;
			int i = 0;
			int mask = 0;
			//---校验通讯接口
			if ((this.mCCOMM != null) && (this.mCCOMM.mOpen == true))
			{
				mask = this.mMcuInfoParam.mChipFuncMask1.mMask;
				for (i = 0; i < this.mMcuInfoParam.mChipFuncMask1.mCout; i++)
				{
					mask &= (1 << i);
					//---任务轮训判断
					switch (mask)
					{
						//---比较识别字
						case 0x02:
							_return = this.CMcuFunc_ReadChipID(null, null);
							break;
						//---芯片擦除:
						case 0x04:
							_return = this.CMcuFunc_EraseChip(null);
							break;
						//---空片检查
						case 0x08:
							_return = this.CMcuFunc_CheckChipMemeryEmpty(null, false);
							break;
						//---编程Flash
						case 0x10:
							_return = this.CMcuFunc_WriteChipFlash(chipFlash, null, true, workState, workTime, workBar);
							break;
						//---编程Eeprom
						case 0x20:
							_return = this.CMcuFunc_WriteChipEeprom(chipEeprom, null, true, workState, workTime, workBar);
							break;
						default:
							break;
					}
					if (_return != 0)
					{
						break;
					}
				}
				if (_return == 0)
				{
					mask = this.mMcuInfoParam.mChipFuncMask2.mMask;
					for (i = 0; i < this.mMcuInfoParam.mChipFuncMask2.mCout; i++)
					{
						mask &= (1 << i);
						//---任务轮训判断
						switch (mask)
						{
							default:
								break;
						}
					}
				}
				else
				{
					MessageBox.Show(this.mMsgText ,	"消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				this.mMsgText = "通讯端口初始化失败!";
			}
			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.mMsgText, (_return == 0 ? Color.Black : Color.Red));
			}
			return _return;
		}

		#endregion

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion
	}
}

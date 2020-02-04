
using Harry.LabTools.LabCommPort;
using Harry.LabTools.LabGenFunc;
using Harry.LabTools.LabHexEdit;
using Harry.LabTools.LabMcuFunc;
using System;
using System.IO;
using System.Windows.Forms;

namespace LabTestForm
{
	public partial class Form1 : Form
	{
		#region 变量定义
		
		/// <summary>
		/// 
		/// </summary>
		private CCommPort usedComm = null;

		/// <summary>
		/// 
		/// </summary>
		private CMcuFuncAVR8BitsBase usedMcu = new CMcuFuncAVR8BitsBase();

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public Form1()
		{
			InitializeComponent();
		}

		#endregion

		#region 事件函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			this.usedComm =new CSerialPort();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			int _return = -1;
			byte[] flash = null;
			OpenFileDialog flashFile = new OpenFileDialog();
			flashFile.AddExtension = true;
			flashFile.DefaultExt = "hex";
			flashFile.Filter = "Intel Hex(*.hex)|*.hex|All files(*.*)|*.*";
			flashFile.FilterIndex = 0;
			//---选择文件
			if ((flashFile.ShowDialog() == DialogResult.OK) && (!string.IsNullOrEmpty(flashFile.FileName)))
			{
				CHexFile loadFlash = new CHexFile(flashFile.FileName);
				//---校验文件的解析
				if (loadFlash.mIsOK)
				{
					flash = new byte[loadFlash.mSTOPAddr];
					//---填充默认数据是0xFF
					CGenFuncMem.GenFuncMemset(ref flash, 0xFF);
					//---数组拷贝
					Array.Copy(loadFlash.mDataMap, 0, flash, loadFlash.mSTARTAddr, loadFlash.mDataMap.Length);
					_return = 0;
					if (flash!=null)
					{
						this.cHexBox1.AddData(flash);
					}
				}
				else
				{
					MessageBox.Show("加载Flash文件失败", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			byte[] flash = this.cHexBox1.mDataMap;
			if ((flash != null) && (flash.Length > 1))
			{
				SaveFileDialog flashFile = new SaveFileDialog();
				//---文件存在是是否提示覆盖
				flashFile.OverwritePrompt = false;
				flashFile.DefaultExt = "hex";
				flashFile.Filter = "Intel Hex(*.hex)|*.hex|All files(*.*)|*.*";
				if (flashFile.ShowDialog() == DialogResult.OK)
				{
					//---Hex文件类
					CHexFile flashHexFile = new CHexFile();
					//---获取保存的数据
					string[] _return = flashHexFile.SaveHexLine(flash);
					//---将数据保存到指定文本中
					using (StreamWriter sw = new StreamWriter(flashFile.FileName))
					{
						for (int i = 0; i < _return.Length; i++)
						{
							sw.Write(_return[i]);
						}
						sw.Close();
					}
				}
			}
			else
			{
				MessageBox.Show("保存Flash文件失败", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		#endregion


	}
}

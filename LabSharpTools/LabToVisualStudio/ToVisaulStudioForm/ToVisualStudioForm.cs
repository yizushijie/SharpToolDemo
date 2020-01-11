using Harry.LabTools.LabControlPlus;
using Harry.LabTools.LabIniFile;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabToVisualStudio
{
	public partial class ToVisualStudioForm : Form
    {
		#region 变量定义

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public ToVisualStudioForm()
		{
			InitializeComponent();
			this.Init();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		public ToVisualStudioForm(string path)
		{
			InitializeComponent();
			this.TextBox_SrcProjectPath.Text = path;
			this.Init();
		}

		#endregion

		#region 公共函数
			
		#endregion

		#region 私有函数

		/// <summary>
		/// 初始化设备
		/// </summary>
		private void Init()
		{
			//---自动从ini文件中加载配置信息
			CIniFile ini = new CIniFile(Application.StartupPath + @"\Config.ini");
			if (ini.mPathExists)
			{
				NameValueCollection values = null;
				ini.CIniFileReadSectionValues("VS版本",ref values);
				if (values != null)
				{
					this.comboBox_VSVersion.SelectedIndex = Convert.ToInt32(values.GetValues(0)[0]);
				}
				else
				{
					this.comboBox_VSVersion.SelectedIndex = 0;
				}
			}
			else
			{
				this.comboBox_VSVersion.SelectedIndex = 0;
			}
			//---默认工程IDE不变
			this.comboBox_ProjectIDE.SelectedIndex = 0;
			//---事件注册
			this.button_SelectSourceProject.Click += new System.EventHandler(this.Button_Click);
			this.button_ToVisualStudioProject.Click += new System.EventHandler(this.Button_Click);
			this.comboBox_VSVersion.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);

			//---通过加载文件的不同自适应当前文档
			//if (this.TextBox_SrcProjectPath.Text != string.Empty)
			if (!string.IsNullOrEmpty(this.TextBox_SrcProjectPath.Text))
			{
				if (this.TextBox_SrcProjectPath.Text.Contains("uvprojx") || this.TextBox_SrcProjectPath.Text.Contains("uvproj"))
				{
					if (this.comboBox_ProjectIDE.Text != "Keil")
					{
						this.comboBox_ProjectIDE.Text = "Keil";
						this.comboBox_ProjectIDE.SelectedIndex = this.comboBox_ProjectIDE.Items.IndexOf("Keil");
					}
				}
				else if (this.TextBox_SrcProjectPath.Text.Contains("ewp"))
				{
					if (this.comboBox_ProjectIDE.Text != "IAR")
					{
						this.comboBox_ProjectIDE.Text = "IAR";
						this.comboBox_ProjectIDE.SelectedIndex = this.comboBox_ProjectIDE.Items.IndexOf("IAR");
					}
				}
			}
			else
			{
				//CMessageBoxPlus.Show(this, "不支持的软件版本","提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			//---限制窗体的大小
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;

		}

		/// <summary>
		/// 使用PreMaKe创建VS项目
		/// </summary>
		/// <returns></returns>
		private bool UsePreMakeToVisualStudio()
		{
			//---要装换为vs工程的文件
			string toVSPath = null;
			//---vs项目的文件
			string vsSlnPath = null;
			//---获取文件工程
			string vsPath = null;
			//---文件名称
			string fileName = null;

			if (this.comboBox_ProjectIDE.Text == "IAR")
			{
				toVSPath = Path.GetDirectoryName(this.TextBox_SrcProjectPath.Text);;
			}
			else if (this.comboBox_ProjectIDE.Text == "Keil")
			{
				toVSPath = Path.GetDirectoryName(this.TextBox_SrcProjectPath.Text);
			}
			else
			{
				return false;
			}
			//---解决方案路径
			vsSlnPath = Path.GetDirectoryName(toVSPath);
			//---工程路径
			vsPath = toVSPath.Split('\\')[vsSlnPath.Split('\\').Length];
			//---文件名称
			fileName = Path.ChangeExtension(this.TextBox_SrcProjectPath.Text, "vcxproj").Split('\\')[Path.ChangeExtension(this.TextBox_SrcProjectPath.Text, "vcxproj").Split('\\').Length - 1];
			//---解决方案路劲
			vsSlnPath = this.TextBox_SrcProjectPath.Text.Replace("\\" + vsPath, "");
			//---启动进程
			Process proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = @"Resources\premake5.exe",
					Arguments = "--File=\"" + toVSPath + "\\premake5.lua\" " + this.comboBox_VSVersion.Text,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					RedirectStandardInput = true,
					CreateNoWindow = true
				}
			};

			//---启动应用
			proc.Start();
			string makeOut = proc.StandardOutput.ReadToEnd();
			//---创建VS工程
			if (proc.ExitCode == 0)
			{
				CMessageBoxPlus.Show(this, makeOut, @"Make output");
				//---创建VS工程
				if (this.comboBox_VSVersion.Text.Contains("vs"))
				{
					//---移动vssln文件
					//---读取sln文件
					string str = Path.ChangeExtension(this.TextBox_SrcProjectPath.Text, "sln");
					//---读取数据
					StreamReader sr = new StreamReader(str, Encoding.UTF8);
					//---读取的内容
					string content = sr.ReadToEnd();
					sr.Close();
					content = content.Replace(fileName, vsPath + "\\" + fileName);
					//---修改正路径
					str = str.Replace("\\" + vsPath, "");
					//---写入文件
					StreamWriter sw = new StreamWriter(str, false, Encoding.UTF8);
					sw.Write(content);
					sw.Close();
					//---是否需要启动VS
					if (this.checkBox_OpenVSProject.Checked)
					{
						DialogResult dialogResult = CMessageBoxPlus.Show(this,"\tOpen " + this.comboBox_VSVersion.Text + " Project ?", this.Text, MessageBoxButtons.YesNo);
						if (dialogResult == DialogResult.Yes)
						{
							ProcessStartInfo psi = new ProcessStartInfo(Path.ChangeExtension(vsSlnPath, "sln"));
							Process.Start(psi);
						}
					}
				}
			}
			else
			{
				CMessageBoxPlus.Show(this, makeOut, @"Make output", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return true;
		}

		#endregion

		#region 事件函数
		/// <summary>
		/// 按键点击事件处理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Button_Click(object sender, EventArgs e)
		{
			Button bt = (Button)sender;
			bt.Enabled = false;
			bool _return = true;
			switch (bt.Text)
			{
				case "选择项目":
					this.TextBox_SrcProjectPath.Text = new CProjectFunc().AutoSelectSourceProject(this.comboBox_ProjectIDE.Text);
					//if ((this.TextBox_SrcProjectPath.Text == string.Empty) || (this.TextBox_SrcProjectPath.Text == null))
					if (string.IsNullOrEmpty(this.TextBox_SrcProjectPath.Text) || string.IsNullOrEmpty(this.TextBox_SrcProjectPath.Text))
					{
						_return = false;
					}
					break;

				case "工程转换":
					_return = new CProjectFunc().MakeVisualStudioProject(this.TextBox_SrcProjectPath.Text, this.comboBox_ProjectIDE.Text);
					if (_return)
					{
						_return = this.UsePreMakeToVisualStudio();
						if (_return)
						{
							if (this.checkBox_CloseApplication.Checked)
							{
								Application.Exit();
							}
						}
					}
					break;

				default:
					break;
			}
			bt.Enabled = true;
		}

		/// <summary>
		/// ComboBox事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender == null)
			{
				return;
			}
			ComboBox cbb = (ComboBox)sender;
			cbb.Enabled = false;
			cbb.Focus();
			switch (cbb.Name)
			{
				case "comboBox_VSVersion":
					CIniFile ini = new CIniFile(Application.StartupPath + @"\Config.ini",true);
					if (ini.CIniFileSectionExists("VS版本"))
					{
						ini.CIniFileEraseSection("VS版本");
					}
					ini.CIniFileWriteInt("VS版本", this.comboBox_VSVersion.Text, this.comboBox_VSVersion.SelectedIndex);
					break;
				default:
					break;
			}
			cbb.Focus();
			cbb.Enabled = true;
		}

		#endregion

	}
}

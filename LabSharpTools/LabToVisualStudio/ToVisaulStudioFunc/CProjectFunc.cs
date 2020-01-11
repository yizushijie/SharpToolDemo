using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Harry.LabTools.LabToVisualStudio
{
	public partial class CProjectFunc
	{
		#region 构造函数

		#endregion

		#region 公共函数

		/// <summary>
		/// 获取Keil程序的安装路径路劲
		/// </summary>
		/// <returns></returns>
		public string GetMDKPatch()
		{
			string _return = null;
			string softPath = @"SOFTWARE\WOW6432Node\Keil\Products\MDK";
			RegistryKey regKey = Registry.LocalMachine;
			RegistryKey regSubKey = regKey.OpenSubKey(softPath, false);

			//---判断注册表是否获取成功
			if (regKey==null)
			{
				softPath = @"SOFTWARE\WOW6432Node\Keil_V5\Products\MDK";
				regSubKey = regKey.OpenSubKey(softPath, false);
			}

			//---判断注册表是否获取成功
			if (regKey==null)
			{
				softPath = @"SOFTWARE\WOW6432Node\Keil_v5\Products\MDK";
				regSubKey = regKey.OpenSubKey(softPath, false);
			}

			//---注册表获取成功
			if (regKey!=null)
			{
				_return = regSubKey.GetValue("Path").ToString();
			}
			return _return;
		}

		
		/// <summary>
		/// 自动选择源工程
		/// </summary>
		/// <param name="srcVersion"></param>
		/// <returns></returns>
		public string AutoSelectSourceProject(string srcVersion)
		{
			OpenFileDialog openFile = null;
			if (srcVersion == "IAR")
			{
				openFile = new OpenFileDialog { Filter = @"IAR Project (*.ewp)|*.ewp" };
			}
			else if (srcVersion == "Keil")
			{
				openFile = new OpenFileDialog { Filter = @"Keil Project (*.uvprojx)|*.uvprojx|(*.uvproj)|*.uvproj" };
			}
			else
			{
				return null;
			}
			if (openFile.ShowDialog() != DialogResult.OK)
			{
				return null;
			}
			else
			{
				return openFile.FileName;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="srcVersion"></param>
		/// <param name="lbl"></param>
		/// <returns></returns>
		public string AutoSelectSourceProject(string srcVersion, System.Windows.Forms.Label lbl)
		{
			OpenFileDialog openFile = null;
			if (srcVersion == "IAR")
			{
				//lbl.Visible = false;
				openFile = new OpenFileDialog { Filter = @"IAR Project (*.ewp)|*.ewp" };
			}
			else if (srcVersion == "Keil")
			{
				//lbl.Visible = true;
				openFile = new OpenFileDialog { Filter = @"Keil Project (*.uvprojx)|*.uvprojx|(*.uvproj)|*.uvproj" };
			}
			else
			{
				return null;
			}
			if (openFile.ShowDialog() != DialogResult.OK)
			{
				return null;
			}
			else
			{
				return openFile.FileName;
			}
		}

		/// <summary>
		/// 递归调用查找节点
		/// </summary>
		/// <param name="inXmlNode"></param>
		/// <param name="inTreeNode"></param>
		public void FindTreeNode(XmlNode inXmlNode, TreeNode inTreeNode)
		{
			XmlNode xNode;
			TreeNode tNode;
			XmlNodeList nodeList;
			int i;

			// Loop through the XML nodes until the leaf is reached.
			// Add the nodes to the TreeView during the looping process.
			if (inXmlNode.HasChildNodes)
			{
				nodeList = inXmlNode.ChildNodes;
				for (i = 0; i <= nodeList.Count - 1; i++)
				{
					xNode = inXmlNode.ChildNodes[i];
					inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
					tNode = inTreeNode.Nodes[i];
					this.FindTreeNode(xNode, tNode);
				}
			}
			else
			{
				inTreeNode.Text = (inXmlNode.OuterXml).Trim();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inXmlNode"></param>
		/// <param name="inTreeNode"></param>
		/// <param name="name"></param>
		public void FindTreeNode(XmlNode inXmlNode, TreeNode inTreeNode, string name)
		{
			XmlNode xNode;
			TreeNode tNode;
			XmlNodeList nodeList;
			int i;

			// Loop through the XML nodes until the leaf is reached.
			// Add the nodes to the TreeView during the looping process.
			if (inXmlNode.HasChildNodes)
			{
				nodeList = inXmlNode.ChildNodes;

				int j = 0;
				for (i = 0; i <= nodeList.Count - 1; i++)
				{
					xNode = inXmlNode.ChildNodes[i];
					if (xNode.Name == name)
					{
						inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
						tNode = inTreeNode.Nodes[j];
						j++;
						this.FindTreeNode(xNode, tNode);
					}
					else
					{
						continue;
					}
				}
			}
			else
			{
				inTreeNode.Text = (inXmlNode.OuterXml).Trim();
			}
		}

		/// <summary>
		/// 递归查询,找到返回该节点
		/// </summary>
		/// <param name="tNode"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public TreeNode FindTreeNode(TreeNode tNode, string name)
		{
			//接受返回的节点
			TreeNode _return = null;

			//循环查找
			foreach (TreeNode temp in tNode.Nodes)
			{
				//是否有子节点
				if (temp.Nodes.Count != 0)
				{
					//如果找到
					if ((_return = this.FindTreeNode(temp, name)) != null)
					{
						return _return;
					}
				}

				//如果找到
				if (string.Equals(temp.Text, name))
				{
					return temp;
				}
			}
			return _return;
		}

		/// <summary>
		/// 设置VS工程
		/// </summary>
		/// <param name="projectName"></param>
		/// <param name="srcVersion"></param>
		/// <returns></returns>
		public bool MakeVisualStudioProject(string projectName, string srcVersion)
		{
			if (srcVersion == "IAR")
			{
				return this.IARToVisualStudio(projectName);
			}
			else if (srcVersion == "Keil")
			{
				return this.MDKToVisualStudio(projectName);
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 生成VS工程
		/// </summary>
		/// <param name="projectName"></param>
		/// <param name="srcVersion"></param>
		/// <returns></returns>
		public bool MakeVisualStudioProject(string projectName, ComboBox srcVersion)
		{
			if (projectName.Contains("uvprojx") || projectName.Contains("uvproj"))
			{
				if (srcVersion.Text != "Keil")
				{
					srcVersion.Text = "Keil";
				}
				return this.MDKToVisualStudio(projectName);
			}
			else if (projectName.Contains("ewp"))
			{
				if (srcVersion.Text != "IAR")
				{
					srcVersion.Text = "IAR";
				}
				return this.IARToVisualStudio(projectName);
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="projectName"></param>
		/// <returns></returns>
		public bool MDKToVisualStudio(string projectName)
		{
			//---判断文件是否存在
			if (!File.Exists(projectName))
			{
				return false;
			}

			//---变量定义
			CProjectConfig prjcfg = new CProjectConfig();
			List<CProjectGroup> prjgroup = new List<CProjectGroup>();

			//---读取设备的文件---创建XmlReader对象的实例并将其返回给调用程序
			XmlReader xmlRead = XmlReader.Create(new StringReader(File.ReadAllText(projectName)));

			//---读取配置文件---不断读取直至找到指定的元素
			xmlRead.ReadToFollowing("TargetOption");
			do
			{
				//---读取子节点---而是用于创建 XML 元素周围的边界
				XmlReader subXmlRead = xmlRead.ReadSubtree();

				//---移动读取器至下一个匹配子孙元素的节点
				subXmlRead.ReadToDescendant("OutputName");

				//---从流中读取下一个节点
				subXmlRead.Read();
				prjcfg.mName = subXmlRead.Value;

				//---获取设置
				subXmlRead.ReadToFollowing("Cads");

				//---
				subXmlRead.ReadToDescendant("Optim");

				//---从流中读取下一个节点
				subXmlRead.Read();

				//---判断数据值
				if (int.Parse(subXmlRead.Value) > 0)
				{
					prjcfg.mCMSIS = true;
				}
				else
				{
					prjcfg.mCMSIS = false;
				}

				//---读取下一个节点
				subXmlRead.ReadToFollowing("VariousControls");
				subXmlRead.ReadToFollowing("Define");
				prjcfg.mDefine = this.FindMDKSubNodeValue(subXmlRead.ReadSubtree());

				//----Keil工程的生成中借用了IAR的一些文件，用于避免一些数据类型报错的问题
				//---IAR中增加的信息
				prjcfg.mDefine.Add("_IAR_");
				prjcfg.mDefine.Add("__ICCARM__");
				prjcfg.mDefine.Add("__CC_ARM");
				prjcfg.mDefine.Add("_Pragma(x)=");
				prjcfg.mDefine.Add("__interrupt=");

				//prjcfg._define.Add("__packed=");
				//prjcfg._define.Add("__weak=");
				prjcfg.mDefine.Add("__packed=__attribute__((__packed__))");
				prjcfg.mDefine.Add("__weak=__attribute__((weak))");

				//prjcfg._define.Add("__attribute__((x))=");
				//prjcfg._define.Add("__STATIC_INLINE=");
				//---获取预包含的头文件
				//subXmlRead.ReadToFollowing("PreInclude");
				//prjcfg._preInclude = this.GetKeilSubNodeValue(subXmlRead,';');
				//---获取包含文件的路径
				subXmlRead.ReadToFollowing("IncludePath");
				prjcfg.mIncludePath = this.FindMDKSubNodeValue(subXmlRead.ReadSubtree(), ';');
			}
			while (xmlRead.ReadToNextSibling("TargetOption"));
			xmlRead.Close();

			xmlRead = XmlReader.Create(new StringReader(File.ReadAllText(projectName)));

			//---读取配置文件---不断读取直至找到指定的元素
			//---获取组文件

			do
			{
				xmlRead.ReadToFollowing("Group");
				if (xmlRead.Depth == 4 && xmlRead.NodeType == XmlNodeType.Element)
				{
					CProjectGroup _return = FindMDKSubNodeGroup(xmlRead, "Group");
					if (_return != null)
					{
						prjgroup.Add(_return);
					}
				}
			}
			while (!xmlRead.EOF);
			xmlRead.Close();

			//---处理MDK文档
			//foreach (var temp in prjgroup)
			//{
			//	if (temp._name.Contains("MDK"))
			//	{
			//		temp._name = temp._name.Substring(temp._name.IndexOf("/MDK") + 1);
			//	}
			//	else
			//	{
			//		continue;
			//	}
			//}

			//---获取C文件
			xmlRead = XmlReader.Create(new StringReader(File.ReadAllText(projectName)));
			do
			{
				xmlRead.ReadToFollowing("Files");
				if (xmlRead.Depth == 3 && xmlRead.NodeType == XmlNodeType.Element)
				{
					CProjectGroup _return = FindMDKSubNodeFile(xmlRead, "Files");
					if (_return != null)
					{
						prjgroup.Add(_return);
					}
				}
			}
			while (!xmlRead.EOF);
			xmlRead.Close();

			//---获取Keil的执行路径
			//---Keil5
			/*
			string keilPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetProcessesByName("UV4")[0].MainModule.FileName);
			if (keilPath == null)
			{
				//---keil4
				keilPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetProcessesByName("UV3")[0].MainModule.FileName);
			}
			if (keilPath == null)
			{
				//---keil2
				keilPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetProcessesByName("UV2")[0].MainModule.FileName);
			}
			*/
			string keilPath = this.GetMDKPatch();
			string includedirs = string.Join("\", \"", prjcfg.mIncludePath);
			if (keilPath != null)
			{
				keilPath +=@"\RV31";
				keilPath = keilPath.Replace("\\", "/");
				includedirs += "\", \"" + keilPath;
			}

			//string configurations = "Debug" + "\", \"" + "Release";
			//StreamWriter file = new StreamWriter(Path.GetDirectoryName(projectName) + "\\KeilToVS.lua");
			StreamWriter file = new StreamWriter(Path.GetDirectoryName(projectName) + "\\premake5.lua");

			//StreamWriter file = new StreamWriter(Directory.GetParent(Path.GetDirectoryName(projectName)).FullName + "\\premake5.lua");
			{
				//
				file.WriteLine("  solution \"" + Path.GetFileNameWithoutExtension(projectName) + "\"");
				file.WriteLine("  configurations { \"" + string.Join("\", \"", prjcfg.mName) + "\" }");

				//file.WriteLine("  configurations { \"" + configurations + "\" }");
				file.WriteLine("  project\"" + Path.GetFileNameWithoutExtension(projectName) + "\"");
				file.WriteLine("  kind \"ConsoleApp\"");
				file.WriteLine("  language \"C\"");
				file.WriteLine("  filter \"configurations:" + prjcfg.mName + "\"");
				file.WriteLine("  sysincludedirs  {\"$(VC_IncludePath)\"}");
				file.WriteLine("  defines { \"" + string.Join("\", \"", prjcfg.mDefine) + "\" }");
				file.WriteLine("  forceincludes { \"" + string.Join("\", \"", prjcfg.mPreInclude) + "\" }");
				file.WriteLine("  includedirs { \"" + includedirs + "\" }");
				List<string> srcFiles = new CProjectGroup().GetFile(prjgroup, prjcfg.mName);
				file.WriteLine("  files { \"" + string.Join("\", \"", srcFiles) + "\"}");
				List<string> vGroups = new CProjectGroup().GetPath(prjgroup, prjcfg.mName);
				file.WriteLine("  vpaths {" + string.Join(" , ", vGroups) + " }");

				//file.Write(IncOverride);
				file.Close();
			}

			return true;
		}

		/// <summary>
		/// IAR项目转VS工程
		/// </summary>
		/// <param name="projectName"></param>
		public bool IARToVisualStudio(string projectName)
		{
			//---判断文件是否存在
			if (!File.Exists(projectName))
			{
				return false;
			}

			//---变量定义
			CProjectConfig prjcfg = new CProjectConfig();
			List<CProjectGroup> prjgroup = new List<CProjectGroup>();

			//---读取设备的文件---创建XmlReader对象的实例并将其返回给调用程序
			XmlReader xmlRead = XmlReader.Create(new StringReader(File.ReadAllText(projectName)));

			//---读取配置文件---不断读取直至找到指定的元素
			xmlRead.ReadToFollowing("configuration");
			do
			{
				//---读取子节点---而是用于创建 XML 元素周围的边界
				XmlReader subXmlRead = xmlRead.ReadSubtree();

				//---移动读取器至下一个匹配子孙元素的节点
				subXmlRead.ReadToDescendant("name");

				//---从流中读取下一个节点
				subXmlRead.Read();
				prjcfg.mName = subXmlRead.Value;

				//---获取设置
				subXmlRead.ReadToFollowing("settings");

				//---
				subXmlRead.ReadToDescendant("archiveVersion");

				//---从流中读取下一个节点
				subXmlRead.Read();

				//---判断数据值
				if (int.Parse(subXmlRead.Value) > 0)
				{
					prjcfg.mCMSIS = true;
				}
				else
				{
					prjcfg.mCMSIS = false;
				}

				//---读取下一个节点
				subXmlRead.ReadToFollowing("settings");
				prjcfg.mDefine = this.FindIARSubNodeValue(subXmlRead, "CCDefines");

				//---IAR中增加的信息
				prjcfg.mDefine.Add("_IAR_");
				prjcfg.mDefine.Add("__ICCARM__");
				prjcfg.mDefine.Add("_Pragma(x)=");
				prjcfg.mDefine.Add("__interrupt=");

				//prjcfg._define.Add("__packed=");
				//prjcfg._define.Add("__weak=");
				prjcfg.mDefine.Add("__packed=__attribute__((__packed__))");
				prjcfg.mDefine.Add("__weak=__attribute__((weak))");

				//prjcfg._define.Add("__attribute__((x))=");
				//prjcfg._define.Add("__STATIC_INLINE=");
				//---获取预包含的头文件
				prjcfg.mPreInclude = this.FindIARSubNodeValue(subXmlRead, "PreInclude");

				//---获取包含文件的路径
				prjcfg.mIncludePath = this.FindIARSubNodeValue(subXmlRead, "CCIncludePath2");
			}
			while (xmlRead.ReadToNextSibling("configuration"));
			xmlRead.Close();

			xmlRead = XmlReader.Create(new StringReader(File.ReadAllText(projectName)));

			//---读取配置文件---不断读取直至找到指定的元素
			//---获取组文件
			xmlRead.ReadToFollowing("group");
			do
			{
				CProjectGroup _return = FindIARSubNodeGroup(xmlRead, "group");
				if (_return != null)
				{
					prjgroup.Add(_return);
				}
			}
			while (xmlRead.ReadToNextSibling("group"));
			xmlRead.Close();

			//---获取C文件
			xmlRead = XmlReader.Create(new StringReader(File.ReadAllText(projectName)));
			do
			{
				xmlRead.ReadToFollowing("file");
				if (xmlRead.Depth == 1 && xmlRead.NodeType == XmlNodeType.Element)
				{
					CProjectGroup _return = FindIARSubNodeFile(xmlRead, "file");
					if (_return != null)
					{
						prjgroup.Add(_return);
					}
				}
			}
			while (!xmlRead.EOF);
			xmlRead.Close();

			//string configurations = "Debug" + "\", \"" + "Release";
			//StreamWriter file =new StreamWriter(Path.GetDirectoryName(projectName) + "\\IARToVS.lua");
			StreamWriter file = new StreamWriter(Path.GetDirectoryName(projectName) + "\\premake5.lua");

			//StreamWriter file = new StreamWriter(Directory.GetParent(Path.GetDirectoryName(projectName)).FullName + "\\premake5.lua");
			{
				//
				file.WriteLine("  solution \"" + Path.GetFileNameWithoutExtension(projectName) + "\"");
				file.WriteLine("  configurations { \"" + string.Join("\", \"", prjcfg.mName) + "\" }");

				//file.WriteLine("  configurations { \"" + configurations + "\" }");
				file.WriteLine("  project\"" + Path.GetFileNameWithoutExtension(projectName) + "\"");
				file.WriteLine("  kind \"ConsoleApp\"");
				file.WriteLine("  language \"C\"");
				file.WriteLine("  filter \"configurations:" + prjcfg.mName + "\"");
				file.WriteLine("  sysincludedirs  {\"$(VC_IncludePath)\"}");
				file.WriteLine("  defines { \"" + string.Join("\", \"", prjcfg.mDefine) + "\" }");
				file.WriteLine("  forceincludes { \"" + string.Join("\", \"", prjcfg.mPreInclude) + "\" }");
				file.WriteLine("  includedirs { \"" + string.Join("\", \"", prjcfg.mIncludePath) + "\" }");
				List<string> srcFiles = new CProjectGroup().GetFile(prjgroup, prjcfg.mName);
				file.WriteLine("  files { \"" + string.Join("\", \"", srcFiles) + "\" }");
				List<string> vGroups = new CProjectGroup().GetPath(prjgroup, prjcfg.mName);
				file.WriteLine("  vpaths {" + string.Join(" , ", vGroups) + " }");

				//file.Write(IncOverride);
				file.Close();
			}

			return true;
		}

		#endregion

		#region 私有函数

		/// <summary>
		///
		/// </summary>
		/// <param name="xmlRead"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		private List<string> FindIARSubNodeValue(XmlReader xmlRead, string val)
		{
			List<string> _return = new List<string>();

			//---读取到指定的值为止
			do
			{
				xmlRead.Read();
				if (xmlRead.EOF)
				{
					return _return;
				}
			} while (xmlRead.Value != val);
			xmlRead.Read();
			int depth = xmlRead.Depth;

			//---读取指定值包含的数据
			do
			{
				if (xmlRead.Read() && (xmlRead.NodeType == XmlNodeType.Text) && (xmlRead.HasValue))
				{
					string temp = xmlRead.Value;
					temp = temp.Replace("$PROJ_DIR$\\", "");
					temp = temp.Replace("$PROJ_DIR$/", "");
					temp = temp.Replace("\\", "/");
					temp = temp.Replace("$PROJ_DIR$\\", "");
					temp = temp.Replace("$PROJ_DIR$/", "");
					temp = temp.Replace("\\", "/");
					_return.Add(temp);
				}
			} while (xmlRead.Depth >= depth);

			//---移动到当前元素
			xmlRead.MoveToElement();
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="xmlRead"></param>
		/// <returns></returns>
		private List<string> FindMDKSubNodeValue(XmlReader xmlRead, char split = ',')
		{
			List<string> _return = new List<string>();

			//---读取到指定的值为止
			xmlRead.Read();

			//---读取指定值包含的数据
			do
			{
				if (xmlRead.Read() && (xmlRead.NodeType == XmlNodeType.Text) && (xmlRead.HasValue))
				{
					string temp = xmlRead.Value;
					temp = temp.Replace("$PROJ_DIR$\\", "");
					temp = temp.Replace("$PROJ_DIR$/", "");
					temp = temp.Replace("\\", "/");
					temp = temp.Replace("$PROJ_DIR$\\", "");
					temp = temp.Replace("$PROJ_DIR$/", "");
					temp = temp.Replace("\\", "/");
					_return.AddRange(temp.Split(split));
				}
			} while (!xmlRead.EOF);

			//---移动到当前元素
			xmlRead.MoveToElement();
			return _return;
		}

		/// <summary>
		/// 获取IAR节点分组
		/// </summary>
		/// <param name="xmlRead"></param>
		/// <param name="parent"></param>
		/// <param name="str"></param>
		/// <returns></returns>
		private CProjectGroup FindIARSubNodeGroup(XmlReader xmlRead, string str, CProjectGroup parent = null)
		{
			CProjectGroup _return = new CProjectGroup(parent);
			if (xmlRead.NodeType != XmlNodeType.Element || xmlRead.Name != str)
			{
				xmlRead.ReadToFollowing(str);
			}
			if (xmlRead.EOF)
			{
				return _return;
			}
			XmlReader subXmlRead = xmlRead.ReadSubtree();
			do
			{
				subXmlRead.Read();
			}
			while (subXmlRead.NodeType != XmlNodeType.Text);
			_return.mName = subXmlRead.Value;
			do
			{
				if (subXmlRead.Read() && subXmlRead.NodeType == XmlNodeType.Element)
				{
					switch (subXmlRead.Name)
					{
						case "group":

							//---子分组信息---递归调用
							_return.mChildGroup.Add(this.FindIARSubNodeGroup(subXmlRead, str, _return));
							break;

						case "file":

							//---获取节点
							XmlReader subSubXmlRead = subXmlRead.ReadSubtree();
							do
							{
								subSubXmlRead.Read();
								switch (subSubXmlRead.Name)
								{
									case "name":
										if (subSubXmlRead.Read() && (subSubXmlRead.NodeType == XmlNodeType.Text) && subSubXmlRead.HasValue && (subSubXmlRead.Depth == 2))
										{
											_return.mFile.Add(new CProjectFile());
											string temp = subSubXmlRead.Value;
											temp = temp.Replace("$PROJ_DIR$\\", "");
											temp = temp.Replace("$PROJ_DIR$/", "");
											temp = temp.Replace("\\", "/");
											_return.mFile.Last().mName = temp;//subsubReader.Value;
										}
										break;

									case "excluded":
										if (subSubXmlRead.NodeType == XmlNodeType.Element)
										{
											XmlReader subSubSubXmlRead = subSubXmlRead.ReadSubtree();
											do
											{
												subSubSubXmlRead.Read();
												if (subSubSubXmlRead.NodeType == XmlNodeType.Text)
												{
													_return.mFile.Last().mExclude.Add(subSubSubXmlRead.Value);
												}
											}
											while (!subSubSubXmlRead.EOF);
											subSubSubXmlRead.Close();
										}
										break;

									default:
										break;
								}
							}
							while (!subSubXmlRead.EOF);
							subSubXmlRead.Close();
							break;

						case "excluded":
							do
							{
								if (subXmlRead.Read() && (subXmlRead.NodeType == XmlNodeType.Text) && (subXmlRead.HasValue))
								{
									_return.mExclude.Add(subXmlRead.Value);
								}
							}
							while (xmlRead.Name != "excluded");
							break;

						default:
							break;
					}
				}
			}
			while (!subXmlRead.EOF);
			subXmlRead.Close();
			return _return;
		}


		/// <summary>
		/// 超找MDK节点分组
		/// </summary>
		/// <param name="xmlRead"></param>
		/// <param name="str"></param>
		/// <param name="parent"></param>
		/// <returns></returns>
		private CProjectGroup FindMDKSubNodeGroup(XmlReader xmlRead, string str, CProjectGroup parent = null)
		{
			CProjectGroup _return = new CProjectGroup(parent);
			if (xmlRead.NodeType != XmlNodeType.Element || xmlRead.Name != str)
			{
				xmlRead.ReadToFollowing(str);
			}
			if (xmlRead.EOF)
			{
				return _return;
			}
			XmlReader subXmlRead = xmlRead.ReadSubtree();
			do
			{
				subXmlRead.Read();
			}
			while (subXmlRead.NodeType != XmlNodeType.Text);
			_return.mName = subXmlRead.Value;
			do
			{
				if (subXmlRead.Read() && subXmlRead.NodeType == XmlNodeType.Element)
				{
					switch (subXmlRead.Name)
					{
						case "Group":

							//---子分组信息---递归调用
							_return.mChildGroup.Add(this.FindMDKSubNodeGroup(subXmlRead, str, _return));
							break;

						case "Files":

							//---获取节点
							XmlReader subSubXmlRead = subXmlRead.ReadSubtree();
							do
							{
								subSubXmlRead.Read();
								switch (subSubXmlRead.Name)
								{
									case "FilePath"://"FilePath":
										if (subSubXmlRead.Read() && (subSubXmlRead.NodeType == XmlNodeType.Text) && subSubXmlRead.HasValue && (subSubXmlRead.Depth == 3))
										{
											_return.mFile.Add(new CProjectFile());
											string temp = subSubXmlRead.Value;
											temp = temp.Replace("$PROJ_DIR$\\", "");
											temp = temp.Replace("$PROJ_DIR$/", "");
											temp = temp.Replace("\\", "/");
											_return.mFile.Last().mName = temp;//subsubReader.Value;
										}
										break;

									case "excluded":
										if (subSubXmlRead.NodeType == XmlNodeType.Element)
										{
											XmlReader subSubSubXmlRead = subSubXmlRead.ReadSubtree();
											do
											{
												subSubSubXmlRead.Read();
												if (subSubSubXmlRead.NodeType == XmlNodeType.Text)
												{
													_return.mFile.Last().mExclude.Add(subSubSubXmlRead.Value);
												}
											}
											while (!subSubSubXmlRead.EOF);
											subSubSubXmlRead.Close();
										}
										break;

									default:
										break;
								}
							}
							while (!subSubXmlRead.EOF);
							subSubXmlRead.Close();
							break;

						case "excluded":
							do
							{
								if (subXmlRead.Read() && (subXmlRead.NodeType == XmlNodeType.Text) && (subXmlRead.HasValue))
								{
									_return.mExclude.Add(subXmlRead.Value);
								}
							}
							while (xmlRead.Name != "excluded");
							break;

						default:
							break;
					}
				}
			}
			while (!subXmlRead.EOF);
			subXmlRead.Close();
			return _return;
		}

		/// <summary>
		/// 查找IAR节点文件
		/// </summary>
		/// <param name="xmlRead"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public CProjectGroup FindIARSubNodeFile(XmlReader xmlRead, string NodeName)
		{
			CProjectGroup _return = new CProjectGroup();

			//---是否位于结尾
			if (xmlRead.EOF)
			{
				return _return;
			}
			_return.mName = string.Empty;

			//---读取包含的文件信息
			do
			{
				//---File后的节点深度是1
				if (xmlRead.Depth != 1)
				{
					continue;
				}
				XmlReader subXmlRead = xmlRead.ReadSubtree();
				if (subXmlRead.Read() && (subXmlRead.NodeType == XmlNodeType.Element))
				{
					//---读取当前节点以及子节点
					XmlReader subsubXmlRead = subXmlRead.ReadSubtree();
					do
					{
						subsubXmlRead.Read();
						switch (subsubXmlRead.Name)
						{
							case "name":
								if (subsubXmlRead.Read() && (subsubXmlRead.NodeType == XmlNodeType.Text) && (subsubXmlRead.HasValue) && (subsubXmlRead.Depth == 2))
								{
									_return.mFile.Add(new CProjectFile());
									string temp = subsubXmlRead.Value;
									temp = temp.Replace("$PROJ_DIR$\\", "");
									temp = temp.Replace("$PROJ_DIR$/", "");
									temp = temp.Replace("\\", "/");
									_return.mFile.Last().mName = temp;
								}
								break;

							case "excluded":
								if (subsubXmlRead.NodeType == XmlNodeType.Element)
								{
									XmlReader subSubSubXmlRead = subsubXmlRead.ReadSubtree();
									do
									{
										if (subSubSubXmlRead.Read() && (subSubSubXmlRead.NodeType == XmlNodeType.Text) && (subSubSubXmlRead.HasValue))
										{
											_return.mFile.Last().mExclude.Add(subSubSubXmlRead.Value);
										}
									}
									while (!subSubSubXmlRead.EOF);
									subSubSubXmlRead.Close();
								}
								break;
						}
					}
					while (!subsubXmlRead.EOF);
					subsubXmlRead.Close();
				}
			}
			while (xmlRead.ReadToNextSibling(NodeName));
			return _return;
		}

		/// <summary>
		/// 查找MDK节点文件
		/// </summary>
		/// <param name="xmlRead"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public CProjectGroup FindMDKSubNodeFile(XmlReader xmlRead, string NodeName)
		{
			CProjectGroup _return = new CProjectGroup();

			//---是否位于结尾
			if (xmlRead.EOF)
			{
				return null;
			}
			_return.mName = string.Empty;

			//---读取包含的文件信息
			do
			{
				//---Files后的节点深度是5
				if (xmlRead.Depth != 3)
				{
					continue;
				}
				XmlReader subXmlRead = xmlRead.ReadSubtree();
				if (subXmlRead.Read() && (subXmlRead.NodeType == XmlNodeType.Element))
				{
					//---读取当前节点以及子节点
					XmlReader subsubXmlRead = subXmlRead.ReadSubtree();
					do
					{
						subsubXmlRead.Read();
						switch (subsubXmlRead.Name)
						{
							case "FileName":
								subsubXmlRead.Read();
								if (/*subsubXmlRead.Read() && */(subsubXmlRead.NodeType == XmlNodeType.Text) && (subsubXmlRead.HasValue) && (subsubXmlRead.Depth == 3))
								{
									_return.mFile.Add(new CProjectFile());
									string temp = subsubXmlRead.Value;
									temp = temp.Replace("$PROJ_DIR$\\", "");
									temp = temp.Replace("$PROJ_DIR$/", "");
									temp = temp.Replace("\\", "/");
									_return.mFile.Last().mName = temp;
								}
								break;

							case "excluded":
								if (subsubXmlRead.NodeType == XmlNodeType.Element)
								{
									XmlReader subSubSubXmlRead = subsubXmlRead.ReadSubtree();
									do
									{
										if (subSubSubXmlRead.Read() && (subSubSubXmlRead.NodeType == XmlNodeType.Text) && (subSubSubXmlRead.HasValue))
										{
											_return.mFile.Last().mExclude.Add(subSubSubXmlRead.Value);
										}
									}
									while (!subSubSubXmlRead.EOF);
									subSubSubXmlRead.Close();
								}
								break;
						}
					}
					while (!subsubXmlRead.EOF);
					subsubXmlRead.Close();
				}
			}
			while (xmlRead.ReadToNextSibling(NodeName));
			return _return;
		}

		#endregion

	}
}

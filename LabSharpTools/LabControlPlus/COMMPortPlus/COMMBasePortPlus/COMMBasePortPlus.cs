using System.Windows.Forms;

namespace Harry.LabCOMMPort
{
	public partial class COMMBasePortPlus : UserControl
    {
		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		private Form commForm = null;

		/// <summary>
		/// 
		/// </summary>
		private RichTextBox commRichTextBox = null;

		/// <summary>
		/// 
		/// </summary>
		private ComboBox commComboBox = null;

		/// <summary>
		/// 
		/// </summary>
		//private COMMBasePort commPort = null;

		#endregion

		#region 构造函数
		public COMMBasePortPlus()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		public COMMBasePortPlus(Form argForm, ComboBox argComboBox, RichTextBox argRichTextBox)
		{
			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		//public COMMBasePortPlus(Form argForm, COMMBasePort argCOMM ,ComboBox argComboBox,RichTextBox argRichTextBox)
		//{
		//	InitializeComponent();
		//}

		#endregion

		#region 函数定义

		/// <summary>
		/// 
		/// </summary>
		public void Init()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argForm"></param>
		/// <param name="argComboBox"></param>
		/// <param name="argRichTextBox"></param>
		public void Init(Form argForm, ComboBox argComboBox, RichTextBox argRichTextBox)
		{
			if (this.commForm==null)
			{
				this.commForm = new Form();
			}
			this.commForm = argForm;

			if (this.commRichTextBox==null)
			{
				this.commRichTextBox = new RichTextBox();
			}
			this.commRichTextBox = argRichTextBox;

			if (this.commComboBox==null)
			{
				this.commComboBox = new ComboBox();
			}
			this.commComboBox = argComboBox;
		}

		#endregion
	}
}

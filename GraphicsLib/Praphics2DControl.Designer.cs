namespace TestAgent.GraphicsLib
{
    partial class Praphics2DControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_Graphics = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graphics)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Graphics
            // 
            this.pictureBox_Graphics.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Graphics.Name = "pictureBox_Graphics";
            this.pictureBox_Graphics.Size = new System.Drawing.Size(607, 444);
            this.pictureBox_Graphics.TabIndex = 0;
            this.pictureBox_Graphics.TabStop = false;
            // 
            // Praphics2DControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox_Graphics);
            this.Name = "Praphics2DControl";
            this.Size = new System.Drawing.Size(613, 450);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graphics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Graphics;

    }
}

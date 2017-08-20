namespace QiNiuUploader
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openImgDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnChoice = new System.Windows.Forms.Button();
            this.imgLocation = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.pbShow = new System.Windows.Forms.PictureBox();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.lbout = new System.Windows.Forms.Label();
            this.groupOut = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            this.groupOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // openImgDialog
            // 
            this.openImgDialog.FileName = "openFileDialog1";
            // 
            // btnChoice
            // 
            this.btnChoice.Location = new System.Drawing.Point(547, 32);
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Size = new System.Drawing.Size(75, 23);
            this.btnChoice.TabIndex = 0;
            this.btnChoice.Text = "选择图片";
            this.btnChoice.UseVisualStyleBackColor = true;
            this.btnChoice.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // imgLocation
            // 
            this.imgLocation.Location = new System.Drawing.Point(13, 32);
            this.imgLocation.Name = "imgLocation";
            this.imgLocation.ReadOnly = true;
            this.imgLocation.Size = new System.Drawing.Size(528, 21);
            this.imgLocation.TabIndex = 1;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(627, 447);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "上传";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // pbShow
            // 
            this.pbShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbShow.Location = new System.Drawing.Point(13, 81);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(690, 338);
            this.pbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShow.TabIndex = 3;
            this.pbShow.TabStop = false;
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(58, 20);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(459, 21);
            this.txtOut.TabIndex = 4;
            // 
            // lbout
            // 
            this.lbout.AutoSize = true;
            this.lbout.Location = new System.Drawing.Point(11, 23);
            this.lbout.Name = "lbout";
            this.lbout.Size = new System.Drawing.Size(41, 12);
            this.lbout.TabIndex = 5;
            this.lbout.Text = "外链：";
            // 
            // groupOut
            // 
            this.groupOut.Controls.Add(this.btnCopy);
            this.groupOut.Controls.Add(this.txtOut);
            this.groupOut.Controls.Add(this.lbout);
            this.groupOut.Location = new System.Drawing.Point(13, 427);
            this.groupOut.Name = "groupOut";
            this.groupOut.Size = new System.Drawing.Size(608, 51);
            this.groupOut.TabIndex = 6;
            this.groupOut.TabStop = false;
            this.groupOut.Text = "外链信息";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(527, 20);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClip
            // 
            this.btnClip.Location = new System.Drawing.Point(627, 32);
            this.btnClip.Name = "btnClip";
            this.btnClip.Size = new System.Drawing.Size(75, 23);
            this.btnClip.TabIndex = 7;
            this.btnClip.Text = "从粘贴板";
            this.btnClip.UseVisualStyleBackColor = true;
            this.btnClip.Click += new System.EventHandler(this.btnClip_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 487);
            this.Controls.Add(this.btnClip);
            this.Controls.Add(this.groupOut);
            this.Controls.Add(this.pbShow);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.imgLocation);
            this.Controls.Add(this.btnChoice);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "uploader";
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).EndInit();
            this.groupOut.ResumeLayout(false);
            this.groupOut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openImgDialog;
        private System.Windows.Forms.Button btnChoice;
        private System.Windows.Forms.TextBox imgLocation;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pbShow;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Label lbout;
        private System.Windows.Forms.GroupBox groupOut;
        private System.Windows.Forms.Button btnClip;
        private System.Windows.Forms.Button btnCopy;
    }
}


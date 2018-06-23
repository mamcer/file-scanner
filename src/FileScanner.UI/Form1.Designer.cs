namespace FileScanner.UI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScan = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.chkShowLog = new System.Windows.Forms.CheckBox();
            this.lnkCopyToClipboard = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(12, 38);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(12, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(506, 22);
            this.txtPath.TabIndex = 1;
            this.txtPath.Text = "C:\\Users\\mario\\Desktop\\file-scanner-test";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.SystemColors.Control;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Location = new System.Drawing.Point(12, 67);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(506, 327);
            this.txtLog.TabIndex = 2;
            // 
            // chkShowLog
            // 
            this.chkShowLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowLog.AutoSize = true;
            this.chkShowLog.Checked = true;
            this.chkShowLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowLog.Location = new System.Drawing.Point(441, 40);
            this.chkShowLog.Name = "chkShowLog";
            this.chkShowLog.Size = new System.Drawing.Size(77, 17);
            this.chkShowLog.TabIndex = 3;
            this.chkShowLog.Text = "Show Log";
            this.chkShowLog.UseVisualStyleBackColor = true;
            // 
            // lnkCopyToClipboard
            // 
            this.lnkCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkCopyToClipboard.AutoSize = true;
            this.lnkCopyToClipboard.Location = new System.Drawing.Point(417, 399);
            this.lnkCopyToClipboard.Name = "lnkCopyToClipboard";
            this.lnkCopyToClipboard.Size = new System.Drawing.Size(101, 13);
            this.lnkCopyToClipboard.TabIndex = 4;
            this.lnkCopyToClipboard.TabStop = true;
            this.lnkCopyToClipboard.Text = "Copy to Clipboard";
            this.lnkCopyToClipboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 421);
            this.Controls.Add(this.lnkCopyToClipboard);
            this.Controls.Add(this.chkShowLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnScan);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "File Scanner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.CheckBox chkShowLog;
        private System.Windows.Forms.LinkLabel lnkCopyToClipboard;
    }
}


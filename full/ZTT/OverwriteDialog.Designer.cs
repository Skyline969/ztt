namespace ZTT
{
    partial class OverwriteDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverwriteDialog));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnOverwrite = new System.Windows.Forms.Button();
            this.btnOverwriteAll = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnSkipAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 12);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(410, 208);
            this.txtMessage.TabIndex = 0;
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.Location = new System.Drawing.Point(18, 226);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Size = new System.Drawing.Size(75, 23);
            this.btnOverwrite.TabIndex = 1;
            this.btnOverwrite.Text = "Overwrite";
            this.btnOverwrite.UseVisualStyleBackColor = true;
            this.btnOverwrite.Click += new System.EventHandler(this.btnOverwrite_Click);
            // 
            // btnOverwriteAll
            // 
            this.btnOverwriteAll.Location = new System.Drawing.Point(99, 226);
            this.btnOverwriteAll.Name = "btnOverwriteAll";
            this.btnOverwriteAll.Size = new System.Drawing.Size(75, 23);
            this.btnOverwriteAll.TabIndex = 2;
            this.btnOverwriteAll.Text = "Overwrite All";
            this.btnOverwriteAll.UseVisualStyleBackColor = true;
            this.btnOverwriteAll.Click += new System.EventHandler(this.btnOverwriteAll_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(180, 226);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 3;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnSkipAll
            // 
            this.btnSkipAll.Location = new System.Drawing.Point(261, 226);
            this.btnSkipAll.Name = "btnSkipAll";
            this.btnSkipAll.Size = new System.Drawing.Size(75, 23);
            this.btnSkipAll.TabIndex = 4;
            this.btnSkipAll.Text = "Skip All";
            this.btnSkipAll.UseVisualStyleBackColor = true;
            this.btnSkipAll.Click += new System.EventHandler(this.btnSkipAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(342, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OverwriteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSkipAll);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnOverwriteAll);
            this.Controls.Add(this.btnOverwrite);
            this.Controls.Add(this.txtMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OverwriteDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm Overwrite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnOverwrite;
        private System.Windows.Forms.Button btnOverwriteAll;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnSkipAll;
        private System.Windows.Forms.Button btnCancel;
    }
}
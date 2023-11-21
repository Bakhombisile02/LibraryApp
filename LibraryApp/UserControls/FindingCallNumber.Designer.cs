namespace LibraryApp
{
    partial class FindingCallNumber
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.lblQ1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lilTimer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.hintsBtn = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkedListBox1);
            this.panel4.Controls.Add(this.lblQ1);
            this.panel4.Location = new System.Drawing.Point(233, 113);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(307, 167);
            this.panel4.TabIndex = 25;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 13);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(307, 154);
            this.checkedListBox1.TabIndex = 4;
            // 
            // lblQ1
            // 
            this.lblQ1.AutoSize = true;
            this.lblQ1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQ1.Location = new System.Drawing.Point(0, 0);
            this.lblQ1.Name = "lblQ1";
            this.lblQ1.Size = new System.Drawing.Size(166, 13);
            this.lblQ1.TabIndex = 5;
            this.lblQ1.Text = "Which Dewey Number belongs to";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(223, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(324, 56);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "Find Call Numbers";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lilTimer
            // 
            this.lilTimer.AutoSize = true;
            this.lilTimer.BackColor = System.Drawing.Color.Transparent;
            this.lilTimer.Location = new System.Drawing.Point(19, 55);
            this.lilTimer.Name = "lilTimer";
            this.lilTimer.Size = new System.Drawing.Size(34, 13);
            this.lilTimer.TabIndex = 29;
            this.lilTimer.Text = "00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Score:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.ForeColor = System.Drawing.Color.Red;
            this.lblScore.Location = new System.Drawing.Point(133, 55);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(13, 13);
            this.lblScore.TabIndex = 31;
            this.lblScore.Text = "0";
            // 
            // hintsBtn
            // 
            this.hintsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hintsBtn.Location = new System.Drawing.Point(665, 50);
            this.hintsBtn.Name = "hintsBtn";
            this.hintsBtn.Size = new System.Drawing.Size(75, 23);
            this.hintsBtn.TabIndex = 32;
            this.hintsBtn.Text = "Hint";
            this.hintsBtn.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSubmit.Location = new System.Drawing.Point(310, 340);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(136, 40);
            this.btnSubmit.TabIndex = 33;
            this.btnSubmit.Text = "Grade";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // FindingCallNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.hintsBtn);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lilTimer);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel4);
            this.Name = "FindingCallNumber";
            this.Size = new System.Drawing.Size(787, 419);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label lblQ1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lilTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button hintsBtn;
        private System.Windows.Forms.Button btnSubmit;
    }
}

namespace LibraryApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitlebar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnfindCallnumbers = new System.Windows.Forms.Button();
            this.btnIdentifiyingArea = new System.Windows.Forms.Button();
            this.btnReplaceBooks = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitlebar.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.btnfindCallnumbers);
            this.panelMenu.Controls.Add(this.btnIdentifiyingArea);
            this.panelMenu.Controls.Add(this.btnReplaceBooks);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(6);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(400, 865);
            this.panelMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.SkyBlue;
            this.panelLogo.Controls.Add(this.pictureBox2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(6);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(400, 138);
            this.panelLogo.TabIndex = 0;
            // 
            // panelTitlebar
            // 
            this.panelTitlebar.BackColor = System.Drawing.Color.SkyBlue;
            this.panelTitlebar.Controls.Add(this.lblTitle);
            this.panelTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitlebar.Location = new System.Drawing.Point(400, 0);
            this.panelTitlebar.Margin = new System.Windows.Forms.Padding(6);
            this.panelTitlebar.Name = "panelTitlebar";
            this.panelTitlebar.Size = new System.Drawing.Size(1235, 138);
            this.panelTitlebar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(517, 37);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(185, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Home Page";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.pictureBox1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelContent.Location = new System.Drawing.Point(400, 138);
            this.panelContent.Margin = new System.Windows.Forms.Padding(6);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1235, 727);
            this.panelContent.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::LibraryApp.Properties.Resources.Rlogo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1235, 727);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnfindCallnumbers
            // 
            this.btnfindCallnumbers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnfindCallnumbers.FlatAppearance.BorderSize = 0;
            this.btnfindCallnumbers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfindCallnumbers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnfindCallnumbers.Image = global::LibraryApp.Properties.Resources.icons8_barcode_scanner_64;
            this.btnfindCallnumbers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfindCallnumbers.Location = new System.Drawing.Point(0, 450);
            this.btnfindCallnumbers.Margin = new System.Windows.Forms.Padding(6);
            this.btnfindCallnumbers.Name = "btnfindCallnumbers";
            this.btnfindCallnumbers.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnfindCallnumbers.Size = new System.Drawing.Size(400, 162);
            this.btnfindCallnumbers.TabIndex = 3;
            this.btnfindCallnumbers.Text = "Find Call numbers";
            this.btnfindCallnumbers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfindCallnumbers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnfindCallnumbers.UseVisualStyleBackColor = true;
            this.btnfindCallnumbers.Click += new System.EventHandler(this.btnfindCallnumbers_Click);
            // 
            // btnIdentifiyingArea
            // 
            this.btnIdentifiyingArea.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIdentifiyingArea.FlatAppearance.BorderSize = 0;
            this.btnIdentifiyingArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIdentifiyingArea.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIdentifiyingArea.Image = global::LibraryApp.Properties.Resources.icons8_search_64;
            this.btnIdentifiyingArea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIdentifiyingArea.Location = new System.Drawing.Point(0, 300);
            this.btnIdentifiyingArea.Margin = new System.Windows.Forms.Padding(6);
            this.btnIdentifiyingArea.Name = "btnIdentifiyingArea";
            this.btnIdentifiyingArea.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnIdentifiyingArea.Size = new System.Drawing.Size(400, 150);
            this.btnIdentifiyingArea.TabIndex = 2;
            this.btnIdentifiyingArea.Text = "   Identifiying Areas";
            this.btnIdentifiyingArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIdentifiyingArea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIdentifiyingArea.UseVisualStyleBackColor = true;
            this.btnIdentifiyingArea.Click += new System.EventHandler(this.btnIdentifiyingArea_Click);
            // 
            // btnReplaceBooks
            // 
            this.btnReplaceBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReplaceBooks.FlatAppearance.BorderSize = 0;
            this.btnReplaceBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplaceBooks.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReplaceBooks.Image = global::LibraryApp.Properties.Resources.icons8_books_64;
            this.btnReplaceBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReplaceBooks.Location = new System.Drawing.Point(0, 138);
            this.btnReplaceBooks.Margin = new System.Windows.Forms.Padding(6);
            this.btnReplaceBooks.Name = "btnReplaceBooks";
            this.btnReplaceBooks.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.btnReplaceBooks.Size = new System.Drawing.Size(400, 162);
            this.btnReplaceBooks.TabIndex = 1;
            this.btnReplaceBooks.Text = "   Replace books";
            this.btnReplaceBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReplaceBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReplaceBooks.UseVisualStyleBackColor = true;
            this.btnReplaceBooks.Click += new System.EventHandler(this.btnReplaceBooks_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::LibraryApp.Properties.Resources.Rlogo1;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 138);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 535);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1635, 865);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTitlebar);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1644, 936);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelTitlebar.ResumeLayout(false);
            this.panelTitlebar.PerformLayout();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnReplaceBooks;
        private System.Windows.Forms.Button btnfindCallnumbers;
        private System.Windows.Forms.Button btnIdentifiyingArea;
        private System.Windows.Forms.Panel panelTitlebar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}


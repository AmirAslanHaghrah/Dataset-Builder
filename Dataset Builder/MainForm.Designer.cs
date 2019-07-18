namespace Dataset_Builder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.featureInfoText = new System.Windows.Forms.TextBox();
            this.featureIDText = new System.Windows.Forms.TextBox();
            this.addNewFeatureType = new System.Windows.Forms.Button();
            this.featureGridView = new System.Windows.Forms.DataGridView();
            this.featureID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.imageFeaturesGridView = new System.Windows.Forms.DataGridView();
            this.imageFeatureID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageFeatureInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageFeatureRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addFeature = new System.Windows.Forms.Button();
            this.clearSelectedRegion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.featureGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFeaturesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(838, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "of 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(255, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.featureInfoText);
            this.groupBox1.Controls.Add(this.featureIDText);
            this.groupBox1.Controls.Add(this.addNewFeatureType);
            this.groupBox1.Controls.Add(this.featureGridView);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 550);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Set Feature Types List";
            // 
            // featureInfoText
            // 
            this.featureInfoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.featureInfoText.ForeColor = System.Drawing.Color.LightGray;
            this.featureInfoText.Location = new System.Drawing.Point(83, 493);
            this.featureInfoText.Name = "featureInfoText";
            this.featureInfoText.Size = new System.Drawing.Size(139, 20);
            this.featureInfoText.TabIndex = 15;
            this.featureInfoText.Text = "Feature Info";
            this.featureInfoText.Enter += new System.EventHandler(this.featureInfoText_Enter);
            // 
            // featureIDText
            // 
            this.featureIDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.featureIDText.ForeColor = System.Drawing.Color.LightGray;
            this.featureIDText.Location = new System.Drawing.Point(6, 493);
            this.featureIDText.Name = "featureIDText";
            this.featureIDText.Size = new System.Drawing.Size(71, 20);
            this.featureIDText.TabIndex = 14;
            this.featureIDText.Text = "Feature ID";
            this.featureIDText.Enter += new System.EventHandler(this.featureIDText_Enter);
            // 
            // addNewFeatureType
            // 
            this.addNewFeatureType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewFeatureType.Location = new System.Drawing.Point(83, 519);
            this.addNewFeatureType.Name = "addNewFeatureType";
            this.addNewFeatureType.Size = new System.Drawing.Size(139, 23);
            this.addNewFeatureType.TabIndex = 13;
            this.addNewFeatureType.Text = "Add New Feature Type";
            this.addNewFeatureType.UseVisualStyleBackColor = true;
            this.addNewFeatureType.Click += new System.EventHandler(this.addNewFeatureType_Click);
            // 
            // featureGridView
            // 
            this.featureGridView.AllowUserToAddRows = false;
            this.featureGridView.AllowUserToDeleteRows = false;
            this.featureGridView.AllowUserToResizeColumns = false;
            this.featureGridView.AllowUserToResizeRows = false;
            this.featureGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.featureGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.featureGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.featureGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.featureGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.featureID,
            this.featureInfo});
            this.featureGridView.Location = new System.Drawing.Point(6, 23);
            this.featureGridView.MultiSelect = false;
            this.featureGridView.Name = "featureGridView";
            this.featureGridView.RowHeadersVisible = false;
            this.featureGridView.RowHeadersWidth = 30;
            this.featureGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.featureGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.featureGridView.Size = new System.Drawing.Size(216, 463);
            this.featureGridView.TabIndex = 8;
            this.featureGridView.TabStop = false;
            this.featureGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.FeatureGridView_CellBeginEdit);
            this.featureGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.FeatureGridView_CellEndEdit);
            this.featureGridView.Click += new System.EventHandler(this.featureGridView_Click);
            this.featureGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FeatureGridView_KeyUp);
            // 
            // featureID
            // 
            this.featureID.HeaderText = "ID";
            this.featureID.Name = "featureID";
            this.featureID.Width = 75;
            // 
            // featureInfo
            // 
            this.featureInfo.HeaderText = "Info";
            this.featureInfo.Name = "featureInfo";
            this.featureInfo.Width = 150;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1120, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStripStatusLabel
            // 
            this.statusStripStatusLabel.Name = "statusStripStatusLabel";
            this.statusStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusStripStatusLabel.Text = "Ready";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1120, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.newToolStripMenuItem.Text = "&New Project";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.openToolStripMenuItem.Text = "&Open Project...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Enabled = false;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.saveProjectToolStripMenuItem.Text = "&Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItem_Click);
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Enabled = false;
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            this.saveProjectAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.saveProjectAsToolStripMenuItem.Text = "&Save Project As...";
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(908, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // imageFeaturesGridView
            // 
            this.imageFeaturesGridView.AllowUserToAddRows = false;
            this.imageFeaturesGridView.AllowUserToDeleteRows = false;
            this.imageFeaturesGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.imageFeaturesGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.imageFeaturesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.imageFeaturesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imageFeatureID,
            this.imageFeatureInfo,
            this.imageFeatureRegion});
            this.imageFeaturesGridView.Enabled = false;
            this.imageFeaturesGridView.Location = new System.Drawing.Point(255, 451);
            this.imageFeaturesGridView.MultiSelect = false;
            this.imageFeaturesGridView.Name = "imageFeaturesGridView";
            this.imageFeaturesGridView.ReadOnly = true;
            this.imageFeaturesGridView.RowHeadersVisible = false;
            this.imageFeaturesGridView.RowHeadersWidth = 30;
            this.imageFeaturesGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.imageFeaturesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.imageFeaturesGridView.Size = new System.Drawing.Size(640, 136);
            this.imageFeaturesGridView.TabIndex = 15;
            this.imageFeaturesGridView.TabStop = false;
            this.imageFeaturesGridView.Click += new System.EventHandler(this.ImageFeaturesGridView_Click);
            this.imageFeaturesGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImageFeaturesGridView_KeyUp);
            // 
            // imageFeatureID
            // 
            this.imageFeatureID.HeaderText = "ID";
            this.imageFeatureID.Name = "imageFeatureID";
            this.imageFeatureID.ReadOnly = true;
            this.imageFeatureID.Width = 75;
            // 
            // imageFeatureInfo
            // 
            this.imageFeatureInfo.HeaderText = "Info";
            this.imageFeatureInfo.Name = "imageFeatureInfo";
            this.imageFeatureInfo.ReadOnly = true;
            this.imageFeatureInfo.Width = 150;
            // 
            // imageFeatureRegion
            // 
            this.imageFeatureRegion.HeaderText = "Region";
            this.imageFeatureRegion.Name = "imageFeatureRegion";
            this.imageFeatureRegion.ReadOnly = true;
            this.imageFeatureRegion.Width = 500;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Enabled = false;
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(717, 403);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(100, 29);
            this.hScrollBar1.TabIndex = 16;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(735, 404);
            this.textBox1.MaximumSize = new System.Drawing.Size(64, 28);
            this.textBox1.MinimumSize = new System.Drawing.Size(64, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 28);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // addFeature
            // 
            this.addFeature.Enabled = false;
            this.addFeature.Location = new System.Drawing.Point(255, 403);
            this.addFeature.Name = "addFeature";
            this.addFeature.Size = new System.Drawing.Size(131, 23);
            this.addFeature.TabIndex = 18;
            this.addFeature.Text = "Add Selected Feature";
            this.addFeature.UseVisualStyleBackColor = true;
            this.addFeature.Click += new System.EventHandler(this.addFeature_Click);
            // 
            // clearSelectedRegion
            // 
            this.clearSelectedRegion.Enabled = false;
            this.clearSelectedRegion.Location = new System.Drawing.Point(392, 403);
            this.clearSelectedRegion.Name = "clearSelectedRegion";
            this.clearSelectedRegion.Size = new System.Drawing.Size(131, 23);
            this.clearSelectedRegion.TabIndex = 19;
            this.clearSelectedRegion.Text = "Clear Selected Region";
            this.clearSelectedRegion.UseVisualStyleBackColor = true;
            this.clearSelectedRegion.Click += new System.EventHandler(this.clearSelectedRegion_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 616);
            this.Controls.Add(this.clearSelectedRegion);
            this.Controls.Add(this.addFeature);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.imageFeaturesGridView);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.hScrollBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataSet Builder (beta)";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.featureGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFeaturesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox featureInfoText;
        private System.Windows.Forms.TextBox featureIDText;
        private System.Windows.Forms.Button addNewFeatureType;
        private System.Windows.Forms.DataGridView featureGridView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusStripStatusLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView imageFeaturesGridView;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button addFeature;
        private System.Windows.Forms.Button clearSelectedRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureID;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageFeatureID;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageFeatureInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageFeatureRegion;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}


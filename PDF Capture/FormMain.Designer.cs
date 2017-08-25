using System.Data;

namespace PDF_Capture
{
    partial class fm_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_main));
            this.btn_run = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sdfsdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSolutionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSolutionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_modify = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_createdOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_createdBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(589, 45);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 21);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sdfsdfToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sdfsdfToolStripMenuItem
            // 
            this.sdfsdfToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.importSolutionsToolStripMenuItem,
            this.exportSolutionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.sdfsdfToolStripMenuItem.Name = "sdfsdfToolStripMenuItem";
            this.sdfsdfToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.sdfsdfToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openFileToolStripMenuItem.Text = "Open PDF File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // importSolutionsToolStripMenuItem
            // 
            this.importSolutionsToolStripMenuItem.Name = "importSolutionsToolStripMenuItem";
            this.importSolutionsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.importSolutionsToolStripMenuItem.Text = "Import Solutions";
            this.importSolutionsToolStripMenuItem.Click += new System.EventHandler(this.importSolutionsToolStripMenuItem_Click);
            // 
            // exportSolutionsToolStripMenuItem
            // 
            this.exportSolutionsToolStripMenuItem.Name = "exportSolutionsToolStripMenuItem";
            this.exportSolutionsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exportSolutionsToolStripMenuItem.Text = "Export Solutions";
            this.exportSolutionsToolStripMenuItem.Click += new System.EventHandler(this.exportSolutionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Solutions:";
            // 
            // btn_modify
            // 
            this.btn_modify.Location = new System.Drawing.Point(589, 73);
            this.btn_modify.Name = "btn_modify";
            this.btn_modify.Size = new System.Drawing.Size(75, 21);
            this.btn_modify.TabIndex = 2;
            this.btn_modify.Text = "Modify";
            this.btn_modify.UseVisualStyleBackColor = true;
            this.btn_modify.Click += new System.EventHandler(this.btn_modify_Click);
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(589, 101);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 21);
            this.btn_new.TabIndex = 3;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(589, 128);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 21);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_Name,
            this.col_desc,
            this.col_createdOn,
            this.col_createdBy});
            this.dataGridView1.Location = new System.Drawing.Point(15, 44);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(542, 310);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SolutionRow_Changed);
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "ID";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Width = 50;
            // 
            // col_Name
            // 
            this.col_Name.DataPropertyName = "Name";
            this.col_Name.HeaderText = "Name";
            this.col_Name.Name = "col_Name";
            this.col_Name.ReadOnly = true;
            this.col_Name.Width = 110;
            // 
            // col_desc
            // 
            this.col_desc.DataPropertyName = "Description";
            this.col_desc.HeaderText = "Description";
            this.col_desc.Name = "col_desc";
            this.col_desc.ReadOnly = true;
            this.col_desc.Width = 140;
            // 
            // col_createdOn
            // 
            this.col_createdOn.DataPropertyName = "CreatedOn";
            this.col_createdOn.HeaderText = "Created On";
            this.col_createdOn.Name = "col_createdOn";
            this.col_createdOn.ReadOnly = true;
            // 
            // col_createdBy
            // 
            this.col_createdBy.DataPropertyName = "CreatedBy";
            this.col_createdBy.HeaderText = "Created By";
            this.col_createdBy.Name = "col_createdBy";
            this.col_createdBy.ReadOnly = true;
            // 
            // fm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 366);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_modify);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(709, 405);
            this.Name = "fm_main";
            this.Text = "PDF Capture - Console";
            this.Load += new System.EventHandler(this.main_load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sdfsdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_modify;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_createdOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_createdBy;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem importSolutionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSolutionsToolStripMenuItem;
    }
}


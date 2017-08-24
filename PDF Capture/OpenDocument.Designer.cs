namespace PDF_Capture
{
    partial class OpenDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenDocument));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_document = new System.Windows.Forms.RichTextBox();
            this.grid_parameters = new System.Windows.Forms.DataGridView();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_exp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_runSolution = new System.Windows.Forms.Button();
            this.txt_sortGroup = new System.Windows.Forms.ComboBox();
            this.txt_sortMatch = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_group = new System.Windows.Forms.NumericUpDown();
            this.txt_match = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_savePara = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_addPara = new System.Windows.Forms.Button();
            this.btn_saveSolution = new System.Windows.Forms.Button();
            this.txt_solutionName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_solutionDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_display = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_parameters)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_match)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.txt_document, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.grid_parameters, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_result, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(567, 403);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(819, 531);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_document
            // 
            this.txt_document.AcceptsTab = true;
            this.txt_document.BackColor = System.Drawing.SystemColors.Window;
            this.txt_document.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_document.DetectUrls = false;
            this.txt_document.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_document.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_document.Location = new System.Drawing.Point(172, 195);
            this.txt_document.Name = "txt_document";
            this.txt_document.ReadOnly = true;
            this.txt_document.Size = new System.Drawing.Size(432, 323);
            this.txt_document.TabIndex = 0;
            this.txt_document.Text = "";
            // 
            // grid_parameters
            // 
            this.grid_parameters.AllowUserToAddRows = false;
            this.grid_parameters.AllowUserToDeleteRows = false;
            this.grid_parameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grid_parameters.BackgroundColor = System.Drawing.Color.White;
            this.grid_parameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_parameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_parameters.Location = new System.Drawing.Point(172, 54);
            this.grid_parameters.MultiSelect = false;
            this.grid_parameters.Name = "grid_parameters";
            this.grid_parameters.ReadOnly = true;
            this.grid_parameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_parameters.Size = new System.Drawing.Size(432, 135);
            this.grid_parameters.TabIndex = 0;
            this.grid_parameters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridRow_Change);
            // 
            // txt_result
            // 
            this.txt_result.AcceptsReturn = true;
            this.txt_result.AcceptsTab = true;
            this.txt_result.BackColor = System.Drawing.SystemColors.Window;
            this.txt_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_result.Enabled = false;
            this.txt_result.Location = new System.Drawing.Point(610, 54);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.txt_result, 2);
            this.txt_result.Size = new System.Drawing.Size(193, 464);
            this.txt_result.TabIndex = 3;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.txt_exp);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(172, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(631, 45);
            this.panel3.TabIndex = 4;
            // 
            // txt_exp
            // 
            this.txt_exp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_exp.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_exp.Location = new System.Drawing.Point(0, 23);
            this.txt_exp.Name = "txt_exp";
            this.txt_exp.Size = new System.Drawing.Size(631, 20);
            this.txt_exp.TabIndex = 1;
            this.txt_exp.TextChanged += new System.EventHandler(this.Parameters_Change);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Regular Expression:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btn_runSolution);
            this.panel1.Controls.Add(this.txt_sortGroup);
            this.panel1.Controls.Add(this.txt_sortMatch);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_group);
            this.panel1.Controls.Add(this.txt_match);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_saveSolution);
            this.panel1.Controls.Add(this.txt_solutionName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_solutionDesc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_display);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(159, 521);
            this.panel1.TabIndex = 1;
            // 
            // btn_runSolution
            // 
            this.btn_runSolution.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_runSolution.Location = new System.Drawing.Point(33, 428);
            this.btn_runSolution.Name = "btn_runSolution";
            this.btn_runSolution.Size = new System.Drawing.Size(77, 23);
            this.btn_runSolution.TabIndex = 24;
            this.btn_runSolution.Text = "Run";
            this.btn_runSolution.UseVisualStyleBackColor = true;
            this.btn_runSolution.Visible = false;
            this.btn_runSolution.Click += new System.EventHandler(this.btn_runSolution_Click);
            // 
            // txt_sortGroup
            // 
            this.txt_sortGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_sortGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_sortGroup.FormattingEnabled = true;
            this.txt_sortGroup.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.txt_sortGroup.Location = new System.Drawing.Point(9, 144);
            this.txt_sortGroup.Name = "txt_sortGroup";
            this.txt_sortGroup.Size = new System.Drawing.Size(134, 21);
            this.txt_sortGroup.TabIndex = 5;
            this.txt_sortGroup.TextChanged += new System.EventHandler(this.Parameters_Change);
            // 
            // txt_sortMatch
            // 
            this.txt_sortMatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_sortMatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_sortMatch.FormattingEnabled = true;
            this.txt_sortMatch.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.txt_sortMatch.Location = new System.Drawing.Point(9, 66);
            this.txt_sortMatch.Name = "txt_sortMatch";
            this.txt_sortMatch.Size = new System.Drawing.Size(134, 21);
            this.txt_sortMatch.TabIndex = 3;
            this.txt_sortMatch.TextChanged += new System.EventHandler(this.Parameters_Change);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Sort Of Groups:";
            // 
            // txt_group
            // 
            this.txt_group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_group.Location = new System.Drawing.Point(9, 183);
            this.txt_group.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.txt_group.Name = "txt_group";
            this.txt_group.Size = new System.Drawing.Size(134, 20);
            this.txt_group.TabIndex = 6;
            this.txt_group.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txt_group.ValueChanged += new System.EventHandler(this.Parameters_Change);
            // 
            // txt_match
            // 
            this.txt_match.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_match.Location = new System.Drawing.Point(9, 105);
            this.txt_match.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txt_match.Name = "txt_match";
            this.txt_match.Size = new System.Drawing.Size(134, 20);
            this.txt_match.TabIndex = 4;
            this.txt_match.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txt_match.ValueChanged += new System.EventHandler(this.Parameters_Change);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.btn_savePara);
            this.panel2.Controls.Add(this.btn_delete);
            this.panel2.Controls.Add(this.btn_addPara);
            this.panel2.Location = new System.Drawing.Point(9, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 64);
            this.panel2.TabIndex = 17;
            // 
            // btn_savePara
            // 
            this.btn_savePara.Location = new System.Drawing.Point(0, 6);
            this.btn_savePara.Name = "btn_savePara";
            this.btn_savePara.Size = new System.Drawing.Size(63, 23);
            this.btn_savePara.TabIndex = 7;
            this.btn_savePara.Text = "Save";
            this.btn_savePara.UseVisualStyleBackColor = true;
            this.btn_savePara.Click += new System.EventHandler(this.btn_savePara_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(71, 6);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(63, 23);
            this.btn_delete.TabIndex = 9;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_addPara
            // 
            this.btn_addPara.Location = new System.Drawing.Point(0, 35);
            this.btn_addPara.Name = "btn_addPara";
            this.btn_addPara.Size = new System.Drawing.Size(134, 23);
            this.btn_addPara.TabIndex = 8;
            this.btn_addPara.Text = "Insert Parameter";
            this.btn_addPara.UseVisualStyleBackColor = true;
            this.btn_addPara.Click += new System.EventHandler(this.btn_addPara_Click);
            // 
            // btn_saveSolution
            // 
            this.btn_saveSolution.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_saveSolution.Location = new System.Drawing.Point(33, 397);
            this.btn_saveSolution.Name = "btn_saveSolution";
            this.btn_saveSolution.Size = new System.Drawing.Size(77, 23);
            this.btn_saveSolution.TabIndex = 12;
            this.btn_saveSolution.Text = "Save";
            this.btn_saveSolution.UseVisualStyleBackColor = true;
            this.btn_saveSolution.Click += new System.EventHandler(this.btn_saveSolution_Click);
            // 
            // txt_solutionName
            // 
            this.txt_solutionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_solutionName.Location = new System.Drawing.Point(9, 323);
            this.txt_solutionName.Name = "txt_solutionName";
            this.txt_solutionName.Size = new System.Drawing.Size(134, 20);
            this.txt_solutionName.TabIndex = 10;
            this.txt_solutionName.TextChanged += new System.EventHandler(this.txt_solutionName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Solution Description:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Solution Name:";
            // 
            // txt_solutionDesc
            // 
            this.txt_solutionDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_solutionDesc.Location = new System.Drawing.Point(9, 362);
            this.txt_solutionDesc.Name = "txt_solutionDesc";
            this.txt_solutionDesc.Size = new System.Drawing.Size(134, 20);
            this.txt_solutionDesc.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sort Of Matches:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Index Of Groups:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Index Of Matches:";
            // 
            // txt_display
            // 
            this.txt_display.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_display.Location = new System.Drawing.Point(9, 26);
            this.txt_display.Name = "txt_display";
            this.txt_display.Size = new System.Drawing.Size(134, 20);
            this.txt_display.TabIndex = 2;
            this.txt_display.TextChanged += new System.EventHandler(this.Parameters_Change);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Display Name:";
            // 
            // OpenDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 531);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(835, 570);
            this.Name = "OpenDocument";
            this.Text = "Open Document";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OpenDocument_BeforeClose);
            this.Load += new System.EventHandler(this.OpenDocument_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_parameters)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_match)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.RichTextBox txt_document;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_exp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.TextBox txt_display;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView grid_parameters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_addPara;
        private System.Windows.Forms.Button btn_saveSolution;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown txt_group;
        private System.Windows.Forms.NumericUpDown txt_match;
        public System.Windows.Forms.TextBox txt_solutionDesc;
        public System.Windows.Forms.TextBox txt_solutionName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txt_sortGroup;
        private System.Windows.Forms.ComboBox txt_sortMatch;
        private System.Windows.Forms.Button btn_savePara;
        private System.Windows.Forms.Button btn_runSolution;
        private System.Windows.Forms.Panel panel3;
    }
}
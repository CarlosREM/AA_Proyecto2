namespace AA_Proyecto2
{
    partial class AppWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWin));
            this.pnl_options = new System.Windows.Forms.Panel();
            this.btn_solve = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.btn_useThreads = new System.Windows.Forms.CheckBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_generate = new System.Windows.Forms.Button();
            this.lbl_threadNum = new System.Windows.Forms.Label();
            this.lbl_sizeNum = new System.Windows.Forms.Label();
            this.sldr_thread = new System.Windows.Forms.TrackBar();
            this.sldr_size = new System.Windows.Forms.TrackBar();
            this.sp1 = new System.Windows.Forms.Label();
            this.lbl_size = new System.Windows.Forms.Label();
            this.lbl_options = new System.Windows.Forms.Label();
            this.pnl_options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sldr_thread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldr_size)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_options
            // 
            this.pnl_options.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_options.Controls.Add(this.btn_solve);
            this.pnl_options.Controls.Add(this.btn_clear);
            this.pnl_options.Controls.Add(this.btn_about);
            this.pnl_options.Controls.Add(this.btn_useThreads);
            this.pnl_options.Controls.Add(this.btn_load);
            this.pnl_options.Controls.Add(this.btn_save);
            this.pnl_options.Controls.Add(this.btn_generate);
            this.pnl_options.Controls.Add(this.lbl_threadNum);
            this.pnl_options.Controls.Add(this.lbl_sizeNum);
            this.pnl_options.Controls.Add(this.sldr_thread);
            this.pnl_options.Controls.Add(this.sldr_size);
            this.pnl_options.Controls.Add(this.sp1);
            this.pnl_options.Controls.Add(this.lbl_size);
            this.pnl_options.Controls.Add(this.lbl_options);
            this.pnl_options.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_options.Location = new System.Drawing.Point(0, 0);
            this.pnl_options.Name = "pnl_options";
            this.pnl_options.Size = new System.Drawing.Size(210, 633);
            this.pnl_options.TabIndex = 0;
            // 
            // btn_solve
            // 
            this.btn_solve.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_solve.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_solve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_solve.Enabled = false;
            this.btn_solve.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_solve.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_solve.Location = new System.Drawing.Point(9, 429);
            this.btn_solve.Name = "btn_solve";
            this.btn_solve.Size = new System.Drawing.Size(190, 60);
            this.btn_solve.TabIndex = 14;
            this.btn_solve.Text = "SOLVE SUDOKU";
            this.btn_solve.UseVisualStyleBackColor = false;
            this.btn_solve.Click += new System.EventHandler(this.btn_solve_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_clear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_clear.Enabled = false;
            this.btn_clear.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_clear.Location = new System.Drawing.Point(9, 495);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(190, 45);
            this.btn_clear.TabIndex = 13;
            this.btn_clear.Text = "Clear Board";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_about
            // 
            this.btn_about.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_about.Cursor = System.Windows.Forms.Cursors.Help;
            this.btn_about.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_about.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_about.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_about.Location = new System.Drawing.Point(-1, -1);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(30, 30);
            this.btn_about.TabIndex = 12;
            this.btn_about.Text = "i";
            this.btn_about.UseVisualStyleBackColor = false;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // btn_useThreads
            // 
            this.btn_useThreads.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_useThreads.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_useThreads.Location = new System.Drawing.Point(104, 61);
            this.btn_useThreads.Name = "btn_useThreads";
            this.btn_useThreads.Size = new System.Drawing.Size(101, 57);
            this.btn_useThreads.TabIndex = 11;
            this.btn_useThreads.Text = "Use Threads";
            this.btn_useThreads.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_useThreads.UseVisualStyleBackColor = true;
            this.btn_useThreads.CheckedChanged += new System.EventHandler(this.btn_useThreads_CheckedChanged);
            // 
            // btn_load
            // 
            this.btn_load.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_load.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_load.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_load.Location = new System.Drawing.Point(9, 588);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(190, 36);
            this.btn_load.TabIndex = 10;
            this.btn_load.Text = "Load Sudoku";
            this.btn_load.UseVisualStyleBackColor = false;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_save.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(9, 546);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(190, 36);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Save Sudoku";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_generate
            // 
            this.btn_generate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_generate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_generate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_generate.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_generate.Location = new System.Drawing.Point(9, 365);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(190, 60);
            this.btn_generate.TabIndex = 8;
            this.btn_generate.Text = "GENERATE";
            this.btn_generate.UseVisualStyleBackColor = false;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // lbl_threadNum
            // 
            this.lbl_threadNum.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_threadNum.Enabled = false;
            this.lbl_threadNum.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_threadNum.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_threadNum.Location = new System.Drawing.Point(143, 324);
            this.lbl_threadNum.Name = "lbl_threadNum";
            this.lbl_threadNum.Size = new System.Drawing.Size(56, 30);
            this.lbl_threadNum.TabIndex = 7;
            this.lbl_threadNum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_sizeNum
            // 
            this.lbl_sizeNum.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_sizeNum.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sizeNum.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_sizeNum.Location = new System.Drawing.Point(11, 324);
            this.lbl_sizeNum.Name = "lbl_sizeNum";
            this.lbl_sizeNum.Size = new System.Drawing.Size(56, 30);
            this.lbl_sizeNum.TabIndex = 6;
            this.lbl_sizeNum.Text = "9";
            this.lbl_sizeNum.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sldr_thread
            // 
            this.sldr_thread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sldr_thread.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.sldr_thread.Enabled = false;
            this.sldr_thread.LargeChange = 1;
            this.sldr_thread.Location = new System.Drawing.Point(143, 121);
            this.sldr_thread.Minimum = 1;
            this.sldr_thread.Name = "sldr_thread";
            this.sldr_thread.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sldr_thread.Size = new System.Drawing.Size(56, 200);
            this.sldr_thread.TabIndex = 5;
            this.sldr_thread.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.sldr_thread.Value = 1;
            this.sldr_thread.ValueChanged += new System.EventHandler(this.sldr_thread_ValueChanged);
            // 
            // sldr_size
            // 
            this.sldr_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sldr_size.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.sldr_size.LargeChange = 1;
            this.sldr_size.Location = new System.Drawing.Point(11, 121);
            this.sldr_size.Maximum = 19;
            this.sldr_size.Minimum = 5;
            this.sldr_size.Name = "sldr_size";
            this.sldr_size.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sldr_size.Size = new System.Drawing.Size(56, 200);
            this.sldr_size.TabIndex = 4;
            this.sldr_size.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.sldr_size.Value = 9;
            this.sldr_size.ValueChanged += new System.EventHandler(this.sldr_size_ValueChanged);
            // 
            // sp1
            // 
            this.sp1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sp1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sp1.Location = new System.Drawing.Point(9, 356);
            this.sp1.Name = "sp1";
            this.sp1.Size = new System.Drawing.Size(190, 2);
            this.sp1.TabIndex = 3;
            this.sp1.Text = "separador1";
            // 
            // lbl_size
            // 
            this.lbl_size.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_size.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_size.Location = new System.Drawing.Point(5, 58);
            this.lbl_size.Name = "lbl_size";
            this.lbl_size.Size = new System.Drawing.Size(80, 60);
            this.lbl_size.TabIndex = 1;
            this.lbl_size.Text = "Sudoku size";
            this.lbl_size.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_options
            // 
            this.lbl_options.Font = new System.Drawing.Font("Corbel", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_options.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_options.Location = new System.Drawing.Point(3, 8);
            this.lbl_options.Name = "lbl_options";
            this.lbl_options.Size = new System.Drawing.Size(202, 50);
            this.lbl_options.TabIndex = 0;
            this.lbl_options.Text = "Options";
            this.lbl_options.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AppWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(822, 633);
            this.Controls.Add(this.pnl_options);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(840, 680);
            this.Name = "AppWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyecto 2 - Killer Sudoku";
            this.pnl_options.ResumeLayout(false);
            this.pnl_options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sldr_thread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldr_size)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_options;
        private System.Windows.Forms.Label lbl_options;
        private System.Windows.Forms.TrackBar sldr_thread;
        private System.Windows.Forms.TrackBar sldr_size;
        private System.Windows.Forms.Label sp1;
        private System.Windows.Forms.Label lbl_size;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Label lbl_threadNum;
        private System.Windows.Forms.Label lbl_sizeNum;
        private System.Windows.Forms.CheckBox btn_useThreads;
        private System.Windows.Forms.Button btn_about;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_solve;
    }
}


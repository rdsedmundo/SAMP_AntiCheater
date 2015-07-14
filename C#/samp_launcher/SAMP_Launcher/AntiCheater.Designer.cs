namespace SAMP_Launcher
{
    partial class AntiCheater
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AntiCheater));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lHash = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lAuth = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cSamp = new System.Windows.Forms.Timer(this.components);
            this.IsRunning = new System.Windows.Forms.Timer(this.components);
            this.tCheck = new System.Windows.Forms.Timer(this.components);
            this.CreateFile = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bClearLog = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lHash);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lAuth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações";
            // 
            // lHash
            // 
            this.lHash.AutoSize = true;
            this.lHash.Location = new System.Drawing.Point(80, 34);
            this.lHash.Name = "lHash";
            this.lHash.Size = new System.Drawing.Size(0, 13);
            this.lHash.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unique HASH: ";
            // 
            // lAuth
            // 
            this.lAuth.AutoSize = true;
            this.lAuth.ForeColor = System.Drawing.Color.Green;
            this.lAuth.Location = new System.Drawing.Point(45, 20);
            this.lAuth.Name = "lAuth";
            this.lAuth.Size = new System.Drawing.Size(22, 13);
            this.lAuth.TabIndex = 1;
            this.lAuth.Text = "OK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estado: ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 209);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(344, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(329, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "(c) 2013 - Criado por Kyl3";
            // 
            // cSamp
            // 
            this.cSamp.Interval = 2000;
            this.cSamp.Tick += new System.EventHandler(this.cSamp_Tick);
            // 
            // IsRunning
            // 
            this.IsRunning.Interval = 5000;
            this.IsRunning.Tick += new System.EventHandler(this.IsRunning_Tick);
            // 
            // tCheck
            // 
            this.tCheck.Interval = 5000;
            this.tCheck.Tick += new System.EventHandler(this.tCheck_Tick);
            // 
            // CreateFile
            // 
            this.CreateFile.Interval = 10000;
            this.CreateFile.Tick += new System.EventHandler(this.CreateFile_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bClearLog);
            this.groupBox2.Controls.Add(this.logBox);
            this.groupBox2.Location = new System.Drawing.Point(10, 65);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(326, 137);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mensagens";
            // 
            // bClearLog
            // 
            this.bClearLog.Location = new System.Drawing.Point(4, 111);
            this.bClearLog.Margin = new System.Windows.Forms.Padding(2);
            this.bClearLog.Name = "bClearLog";
            this.bClearLog.Size = new System.Drawing.Size(315, 22);
            this.bClearLog.TabIndex = 1;
            this.bClearLog.Text = "Limpar";
            this.bClearLog.UseVisualStyleBackColor = true;
            this.bClearLog.Click += new System.EventHandler(this.bClearLog_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(4, 17);
            this.logBox.Margin = new System.Windows.Forms.Padding(2);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(315, 90);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // AntiCheater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 231);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AntiCheater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AntiCheater - v0.0.1";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.AntiCheater_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AntiCheater_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AntiCheater_FormClosed);
            this.Load += new System.EventHandler(this.AntiCheater_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer cSamp;
        private System.Windows.Forms.Timer IsRunning;
        private System.Windows.Forms.Label lHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tCheck;
        private System.Windows.Forms.Timer CreateFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button bClearLog;

    }
}
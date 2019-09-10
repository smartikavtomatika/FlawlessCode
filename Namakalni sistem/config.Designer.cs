namespace Namakalni_sistem
{
    partial class config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(config));
            this.ip_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ip_Label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pc_date_label = new System.Windows.Forms.Label();
            this.posodobi_time_btn = new System.Windows.Forms.Button();
            this.pc_time_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.dOMOVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ip_textBox
            // 
            this.ip_textBox.Location = new System.Drawing.Point(79, 61);
            this.ip_textBox.Name = "ip_textBox";
            this.ip_textBox.Size = new System.Drawing.Size(185, 20);
            this.ip_textBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trenutni IP:";
            // 
            // ip_Label
            // 
            this.ip_Label.AutoSize = true;
            this.ip_Label.Location = new System.Drawing.Point(76, 25);
            this.ip_Label.Name = "ip_Label";
            this.ip_Label.Size = new System.Drawing.Size(35, 13);
            this.ip_Label.TabIndex = 3;
            this.ip_Label.Text = "label3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Shrani";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(377, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "TEST";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(214, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 18);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ip_Label);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ip_textBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 131);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pc_date_label);
            this.groupBox2.Controls.Add(this.posodobi_time_btn);
            this.groupBox2.Controls.Add(this.pc_time_label);
            this.groupBox2.Location = new System.Drawing.Point(12, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 93);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Čas";
            // 
            // pc_date_label
            // 
            this.pc_date_label.AutoSize = true;
            this.pc_date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pc_date_label.Location = new System.Drawing.Point(152, 25);
            this.pc_date_label.Name = "pc_date_label";
            this.pc_date_label.Size = new System.Drawing.Size(69, 15);
            this.pc_date_label.TabIndex = 2;
            this.pc_date_label.Text = "01.01.2018";
            // 
            // posodobi_time_btn
            // 
            this.posodobi_time_btn.Location = new System.Drawing.Point(129, 53);
            this.posodobi_time_btn.Name = "posodobi_time_btn";
            this.posodobi_time_btn.Size = new System.Drawing.Size(75, 23);
            this.posodobi_time_btn.TabIndex = 1;
            this.posodobi_time_btn.Text = "Posodobi";
            this.posodobi_time_btn.UseVisualStyleBackColor = true;
            this.posodobi_time_btn.Click += new System.EventHandler(this.posodobi_time_btn_Click);
            // 
            // pc_time_label
            // 
            this.pc_time_label.AutoSize = true;
            this.pc_time_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pc_time_label.Location = new System.Drawing.Point(108, 25);
            this.pc_time_label.Name = "pc_time_label";
            this.pc_time_label.Size = new System.Drawing.Size(38, 15);
            this.pc_time_label.TabIndex = 0;
            this.pc_time_label.Text = "01:01";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dOMOVToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(377, 24);
            this.menuStrip2.TabIndex = 10;
            this.menuStrip2.Text = "menuStrip2";
            //this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // dOMOVToolStripMenuItem
            // 
            this.dOMOVToolStripMenuItem.Name = "dOMOVToolStripMenuItem";
            this.dOMOVToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.dOMOVToolStripMenuItem.Text = "DOMOV";
            this.dOMOVToolStripMenuItem.Click += new System.EventHandler(this.dOMOVToolStripMenuItem_Click);
            // 
            // config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 296);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nastavitve kontrolerja";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ip_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ip_Label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label pc_time_label;
        private System.Windows.Forms.Button posodobi_time_btn;
        private System.Windows.Forms.Label pc_date_label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem dOMOVToolStripMenuItem;
    }
}
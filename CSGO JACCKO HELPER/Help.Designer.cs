namespace CSGO_TOOL_FOR_DEBUG
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Method of Injection: We use 2 types of methods by now, Load Library & Manual Mapp" +
    "ing.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(462, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Path to dll/Select dll: When you click, you are able to select dll file which you" +
    " would like to inject.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(635, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select process: You can select from process list process you want to inject to. B" +
    "y default disabled due to INJECT INTO CSGO option.\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Options:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(445, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Inject: This will inject your dll from path you selected into process you selecte" +
    "d by process list.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(581, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Start/Kill CS:GO: This feature will start process \"steam://rungameid/730//\"  and " +
    "when needed it exit program immediately.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Start with map: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Custom launch options:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 134);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Injector";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(388, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Close on inject: This will close this application after successful inject into pr" +
    "ocess.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(48, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(403, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Inject into CSGO: This will disable process list option, and will set as process " +
    "\"csgo\".";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(104, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(492, 26);
            this.label12.TabIndex = 6;
            this.label12.Text = "Automatically inject dll after the process starts. When the process is called CSG" +
    "O we will wait 15 sec so\r\n CS:GO could start properly and then we will inject.\r\n" +
    "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Auto Inject:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(649, 95);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CS:GO Tools";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(118, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(466, 26);
            this.label10.TabIndex = 10;
            this.label10.Text = "This will execute CS:GO with parameters you typed into textbox called \"Custom Lau" +
    "nch Options\".\r\n An example you typed \"-window -novid \" the game will be started " +
    "in a window without intro video.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(545, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "This will start your game with the map you choose. An example if you write there " +
    "de_dust2 it will execute csgo with \r\nparameters +map your_map, in this case +map" +
    " de_dust2";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 244);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Help";
            this.Text = "Help";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}
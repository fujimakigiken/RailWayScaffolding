namespace RailWayScaffolding
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            ファイルToolStripMenuItem = new ToolStripMenuItem();
            編集ToolStripMenuItem = new ToolStripMenuItem();
            駅の設定ToolStripMenuItem = new ToolStripMenuItem();
            cSVからToolStripMenuItem = new ToolStripMenuItem();
            sVG作成ToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            statusStrip1 = new StatusStrip();
            listBox1 = new ListBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, 編集ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            ファイルToolStripMenuItem.Size = new Size(65, 24);
            ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 編集ToolStripMenuItem
            // 
            編集ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 駅の設定ToolStripMenuItem, sVG作成ToolStripMenuItem });
            編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            編集ToolStripMenuItem.Size = new Size(53, 24);
            編集ToolStripMenuItem.Text = "編集";
            // 
            // 駅の設定ToolStripMenuItem
            // 
            駅の設定ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cSVからToolStripMenuItem });
            駅の設定ToolStripMenuItem.Name = "駅の設定ToolStripMenuItem";
            駅の設定ToolStripMenuItem.Size = new Size(149, 26);
            駅の設定ToolStripMenuItem.Text = "駅の設定";
            // 
            // cSVからToolStripMenuItem
            // 
            cSVからToolStripMenuItem.Name = "cSVからToolStripMenuItem";
            cSVからToolStripMenuItem.Size = new Size(141, 26);
            cSVからToolStripMenuItem.Text = "CSVから";
            cSVからToolStripMenuItem.Click += cSVからToolStripMenuItem_Click;
            // 
            // sVG作成ToolStripMenuItem
            // 
            sVG作成ToolStripMenuItem.Name = "sVG作成ToolStripMenuItem";
            sVG作成ToolStripMenuItem.Size = new Size(149, 26);
            sVG作成ToolStripMenuItem.Text = "SVG作成";
            sVG作成ToolStripMenuItem.Click += sVG作成ToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(741, 422);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(747, 31);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(53, 384);
            listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(statusStrip1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private ToolStripMenuItem 編集ToolStripMenuItem;
        private ToolStripMenuItem 駅の設定ToolStripMenuItem;
        private ToolStripMenuItem cSVからToolStripMenuItem;
        private ToolStripMenuItem sVG作成ToolStripMenuItem;
        private PictureBox pictureBox1;
        private StatusStrip statusStrip1;
        private ListBox listBox1;
    }
}

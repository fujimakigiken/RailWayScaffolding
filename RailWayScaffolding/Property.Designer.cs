namespace RailWayScaffolding
{
    partial class Property
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
            OK = new Button();
            Cancel = new Button();
            t_title = new TextBox();
            groupBox1 = new GroupBox();
            t_y2 = new TextBox();
            t_x2 = new TextBox();
            t_y1 = new TextBox();
            t_x1 = new TextBox();
            l_y2 = new Label();
            l_x2 = new Label();
            l_y1 = new Label();
            L_x1 = new Label();
            l_Title = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // OK
            // 
            OK.DialogResult = DialogResult.OK;
            OK.Location = new Point(99, 341);
            OK.Name = "OK";
            OK.Size = new Size(94, 29);
            OK.TabIndex = 0;
            OK.Text = "OK";
            OK.UseVisualStyleBackColor = true;
            OK.Click += OK_Click;
            // 
            // Cancel
            // 
            Cancel.DialogResult = DialogResult.Cancel;
            Cancel.Location = new Point(209, 341);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(94, 29);
            Cancel.TabIndex = 1;
            Cancel.Text = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // t_title
            // 
            t_title.Location = new Point(66, 26);
            t_title.Name = "t_title";
            t_title.Size = new Size(200, 27);
            t_title.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(t_y2);
            groupBox1.Controls.Add(t_x2);
            groupBox1.Controls.Add(t_y1);
            groupBox1.Controls.Add(t_x1);
            groupBox1.Controls.Add(l_y2);
            groupBox1.Controls.Add(l_x2);
            groupBox1.Controls.Add(l_y1);
            groupBox1.Controls.Add(L_x1);
            groupBox1.Location = new Point(22, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(296, 219);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Position";
            // 
            // t_y2
            // 
            t_y2.Location = new Point(177, 169);
            t_y2.Name = "t_y2";
            t_y2.Size = new Size(89, 27);
            t_y2.TabIndex = 7;
            // 
            // t_x2
            // 
            t_x2.Location = new Point(20, 169);
            t_x2.Name = "t_x2";
            t_x2.Size = new Size(89, 27);
            t_x2.TabIndex = 6;
            // 
            // t_y1
            // 
            t_y1.Location = new Point(177, 78);
            t_y1.Name = "t_y1";
            t_y1.Size = new Size(89, 27);
            t_y1.TabIndex = 5;
            // 
            // t_x1
            // 
            t_x1.Location = new Point(20, 78);
            t_x1.Name = "t_x1";
            t_x1.Size = new Size(89, 27);
            t_x1.TabIndex = 4;
            // 
            // l_y2
            // 
            l_y2.AutoSize = true;
            l_y2.Location = new Point(177, 135);
            l_y2.Name = "l_y2";
            l_y2.Size = new Size(24, 20);
            l_y2.TabIndex = 3;
            l_y2.Text = "y2";
            // 
            // l_x2
            // 
            l_x2.AutoSize = true;
            l_x2.Location = new Point(18, 135);
            l_x2.Name = "l_x2";
            l_x2.Size = new Size(24, 20);
            l_x2.TabIndex = 2;
            l_x2.Text = "x2";
            // 
            // l_y1
            // 
            l_y1.AutoSize = true;
            l_y1.Location = new Point(177, 41);
            l_y1.Name = "l_y1";
            l_y1.Size = new Size(24, 20);
            l_y1.TabIndex = 1;
            l_y1.Text = "y1";
            // 
            // L_x1
            // 
            L_x1.AutoSize = true;
            L_x1.Location = new Point(20, 41);
            L_x1.Name = "L_x1";
            L_x1.Size = new Size(24, 20);
            L_x1.TabIndex = 0;
            L_x1.Text = "x1";
            // 
            // l_Title
            // 
            l_Title.AutoSize = true;
            l_Title.Location = new Point(22, 26);
            l_Title.Name = "l_Title";
            l_Title.Size = new Size(35, 20);
            l_Title.TabIndex = 4;
            l_Title.Text = "title";
            // 
            // Property
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 395);
            Controls.Add(l_Title);
            Controls.Add(groupBox1);
            Controls.Add(t_title);
            Controls.Add(Cancel);
            Controls.Add(OK);
            Name = "Property";
            Text = "Property";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OK;
        private Button Cancel;
        private TextBox t_title;
        private GroupBox groupBox1;
        private TextBox t_y2;
        private TextBox t_x2;
        private TextBox t_y1;
        private TextBox t_x1;
        private Label l_y2;
        private Label l_x2;
        private Label l_y1;
        private Label L_x1;
        private Label l_Title;
    }
}
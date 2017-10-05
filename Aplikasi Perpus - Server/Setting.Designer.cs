namespace Aplikasi_Perpus___Server
{
    partial class Setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.simpan = new System.Windows.Forms.Button();
            this.batal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.path = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.db = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "SETTINGS";
            // 
            // simpan
            // 
            this.simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simpan.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpan.Location = new System.Drawing.Point(420, 479);
            this.simpan.Name = "simpan";
            this.simpan.Size = new System.Drawing.Size(91, 43);
            this.simpan.TabIndex = 1;
            this.simpan.Text = "SIMPAN";
            this.simpan.UseVisualStyleBackColor = true;
            this.simpan.Click += new System.EventHandler(this.simpan_Click);
            // 
            // batal
            // 
            this.batal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.batal.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.batal.Location = new System.Drawing.Point(319, 479);
            this.batal.Name = "batal";
            this.batal.Size = new System.Drawing.Size(91, 43);
            this.batal.TabIndex = 2;
            this.batal.Text = "BATAL";
            this.batal.UseVisualStyleBackColor = true;
            this.batal.Click += new System.EventHandler(this.batal_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 381);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.path);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.ip);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.db);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(508, 378);
            this.panel3.TabIndex = 1;
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(117, 87);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(268, 25);
            this.path.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Path HTDOCS";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(117, 46);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(362, 25);
            this.ip.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "IP Server";
            // 
            // db
            // 
            this.db.Location = new System.Drawing.Point(117, 6);
            this.db.Name = "db";
            this.db.Size = new System.Drawing.Size(362, 25);
            this.db.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Koneksi DB";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(404, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "Pilih";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(523, 542);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.batal);
            this.Controls.Add(this.simpan);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_edit";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button simpan;
        private System.Windows.Forms.Button batal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox db;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}
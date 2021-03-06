﻿namespace BackupDatabase
{
    partial class Form1
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtAutoStart = new System.Windows.Forms.MaskedTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimeEnd = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeStart = new System.Windows.Forms.MaskedTextBox();
            this.txtTimeCurrent = new System.Windows.Forms.MaskedTextBox();
            this.chkBackup1 = new System.Windows.Forms.CheckBox();
            this.chkBackup2 = new System.Windows.Forms.CheckBox();
            this.chkBackup3 = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.chkTest1 = new System.Windows.Forms.RadioButton();
            this.chkTest2 = new System.Windows.Forms.RadioButton();
            this.chkTest3 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(81, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "เวลาดึงข้อมูล";
            // 
            // txtAutoStart
            // 
            this.txtAutoStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAutoStart.Location = new System.Drawing.Point(181, 12);
            this.txtAutoStart.Mask = "00:00";
            this.txtAutoStart.Name = "txtAutoStart";
            this.txtAutoStart.Size = new System.Drawing.Size(65, 29);
            this.txtAutoStart.TabIndex = 12;
            this.txtAutoStart.ValidatingType = typeof(System.DateTime);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnStart.Location = new System.Drawing.Point(96, 81);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(205, 46);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "เริ่มทำงาน แบบManually";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(431, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "เวลาสิ้นสุดทำงาน";
            // 
            // txtTimeEnd
            // 
            this.txtTimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTimeEnd.Location = new System.Drawing.Point(531, 65);
            this.txtTimeEnd.Mask = "00:00";
            this.txtTimeEnd.Name = "txtTimeEnd";
            this.txtTimeEnd.Size = new System.Drawing.Size(65, 26);
            this.txtTimeEnd.TabIndex = 14;
            this.txtTimeEnd.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "เวลาเริ่มทำงาน";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(431, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "เวลาปัจจุบัน";
            // 
            // txtTimeStart
            // 
            this.txtTimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTimeStart.Location = new System.Drawing.Point(531, 33);
            this.txtTimeStart.Mask = "00:00";
            this.txtTimeStart.Name = "txtTimeStart";
            this.txtTimeStart.Size = new System.Drawing.Size(65, 26);
            this.txtTimeStart.TabIndex = 8;
            this.txtTimeStart.ValidatingType = typeof(System.DateTime);
            // 
            // txtTimeCurrent
            // 
            this.txtTimeCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTimeCurrent.Location = new System.Drawing.Point(531, 98);
            this.txtTimeCurrent.Mask = "00:00";
            this.txtTimeCurrent.Name = "txtTimeCurrent";
            this.txtTimeCurrent.Size = new System.Drawing.Size(65, 29);
            this.txtTimeCurrent.TabIndex = 10;
            this.txtTimeCurrent.ValidatingType = typeof(System.DateTime);
            // 
            // chkBackup1
            // 
            this.chkBackup1.AutoSize = true;
            this.chkBackup1.Checked = true;
            this.chkBackup1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBackup1.Location = new System.Drawing.Point(24, 58);
            this.chkBackup1.Name = "chkBackup1";
            this.chkBackup1.Size = new System.Drawing.Size(118, 17);
            this.chkBackup1.TabIndex = 16;
            this.chkBackup1.Text = "Backup Database1";
            this.chkBackup1.UseVisualStyleBackColor = true;
            // 
            // chkBackup2
            // 
            this.chkBackup2.AutoSize = true;
            this.chkBackup2.Location = new System.Drawing.Point(149, 58);
            this.chkBackup2.Name = "chkBackup2";
            this.chkBackup2.Size = new System.Drawing.Size(118, 17);
            this.chkBackup2.TabIndex = 17;
            this.chkBackup2.Text = "Backup Database2";
            this.chkBackup2.UseVisualStyleBackColor = true;
            // 
            // chkBackup3
            // 
            this.chkBackup3.AutoSize = true;
            this.chkBackup3.Location = new System.Drawing.Point(284, 58);
            this.chkBackup3.Name = "chkBackup3";
            this.chkBackup3.Size = new System.Drawing.Size(118, 17);
            this.chkBackup3.TabIndex = 18;
            this.chkBackup3.Text = "Backup Database3";
            this.chkBackup3.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnTest.Location = new System.Drawing.Point(96, 133);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(205, 46);
            this.btnTest.TabIndex = 19;
            this.btnTest.Text = "Test Connection";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // chkTest1
            // 
            this.chkTest1.AutoSize = true;
            this.chkTest1.Location = new System.Drawing.Point(24, 185);
            this.chkTest1.Name = "chkTest1";
            this.chkTest1.Size = new System.Drawing.Size(117, 17);
            this.chkTest1.TabIndex = 20;
            this.chkTest1.TabStop = true;
            this.chkTest1.Text = "Backup Database1";
            this.chkTest1.UseVisualStyleBackColor = true;
            // 
            // chkTest2
            // 
            this.chkTest2.AutoSize = true;
            this.chkTest2.Location = new System.Drawing.Point(149, 185);
            this.chkTest2.Name = "chkTest2";
            this.chkTest2.Size = new System.Drawing.Size(117, 17);
            this.chkTest2.TabIndex = 21;
            this.chkTest2.TabStop = true;
            this.chkTest2.Text = "Backup Database2";
            this.chkTest2.UseVisualStyleBackColor = true;
            // 
            // chkTest3
            // 
            this.chkTest3.AutoSize = true;
            this.chkTest3.Location = new System.Drawing.Point(284, 185);
            this.chkTest3.Name = "chkTest3";
            this.chkTest3.Size = new System.Drawing.Size(117, 17);
            this.chkTest3.TabIndex = 22;
            this.chkTest3.TabStop = true;
            this.chkTest3.Text = "Backup Database3";
            this.chkTest3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 220);
            this.Controls.Add(this.chkTest3);
            this.Controls.Add(this.chkTest2);
            this.Controls.Add(this.chkTest1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.chkBackup3);
            this.Controls.Add(this.chkBackup2);
            this.Controls.Add(this.chkBackup1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAutoStart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTimeEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimeStart);
            this.Controls.Add(this.txtTimeCurrent);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtAutoStart;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtTimeEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtTimeStart;
        private System.Windows.Forms.MaskedTextBox txtTimeCurrent;
        private System.Windows.Forms.CheckBox chkBackup1;
        private System.Windows.Forms.CheckBox chkBackup2;
        private System.Windows.Forms.CheckBox chkBackup3;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.RadioButton chkTest1;
        private System.Windows.Forms.RadioButton chkTest2;
        private System.Windows.Forms.RadioButton chkTest3;
    }
}


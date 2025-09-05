namespace WindowsFormsApp1.GUI
{
    partial class FormTraBuzzer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTraBuzzer));
            this.dgvTraBuzzer = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btTraBuzzer = new System.Windows.Forms.Button();
            this.btDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraBuzzer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTraBuzzer
            // 
            this.dgvTraBuzzer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraBuzzer.Location = new System.Drawing.Point(0, 35);
            this.dgvTraBuzzer.Name = "dgvTraBuzzer";
            this.dgvTraBuzzer.RowHeadersWidth = 51;
            this.dgvTraBuzzer.RowTemplate.Height = 24;
            this.dgvTraBuzzer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTraBuzzer.Size = new System.Drawing.Size(765, 358);
            this.dgvTraBuzzer.TabIndex = 0;
            this.dgvTraBuzzer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraBuzzer_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTraBuzzer);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 257);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trả buzzer";
            // 
            // btTraBuzzer
            // 
            this.btTraBuzzer.BackColor = System.Drawing.Color.Olive;
            this.btTraBuzzer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTraBuzzer.ForeColor = System.Drawing.Color.Khaki;
            this.btTraBuzzer.Location = new System.Drawing.Point(116, 329);
            this.btTraBuzzer.Name = "btTraBuzzer";
            this.btTraBuzzer.Size = new System.Drawing.Size(179, 60);
            this.btTraBuzzer.TabIndex = 2;
            this.btTraBuzzer.Text = "Trả buzzer";
            this.btTraBuzzer.UseVisualStyleBackColor = false;
            this.btTraBuzzer.Click += new System.EventHandler(this.btTraBuzzer_Click);
            // 
            // btDong
            // 
            this.btDong.BackColor = System.Drawing.Color.Olive;
            this.btDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDong.ForeColor = System.Drawing.Color.Khaki;
            this.btDong.Location = new System.Drawing.Point(505, 329);
            this.btDong.Name = "btDong";
            this.btDong.Size = new System.Drawing.Size(179, 60);
            this.btDong.TabIndex = 3;
            this.btDong.Text = "Đóng";
            this.btDong.UseVisualStyleBackColor = false;
            this.btDong.Click += new System.EventHandler(this.btDong_Click);
            // 
            // FormTraBuzzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(800, 447);
            this.Controls.Add(this.btDong);
            this.Controls.Add(this.btTraBuzzer);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTraBuzzer";
            this.Text = "Trả Buzzer";
            this.Load += new System.EventHandler(this.FormTraBuzzer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraBuzzer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTraBuzzer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btTraBuzzer;
        private System.Windows.Forms.Button btDong;
    }
}
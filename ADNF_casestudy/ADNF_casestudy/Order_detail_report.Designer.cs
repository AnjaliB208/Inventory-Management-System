
namespace ADNF_casestudy
{
    partial class Order_detail_report
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
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.view_all_btn = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(914, 534);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 27);
            this.label3.TabIndex = 13;
            this.label3.Text = "0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1088, 370);
            this.dataGridView1.TabIndex = 12;
            // 
            // view_all_btn
            // 
            this.view_all_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.view_all_btn.Font = new System.Drawing.Font("Lucida Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_all_btn.Location = new System.Drawing.Point(633, 29);
            this.view_all_btn.Name = "view_all_btn";
            this.view_all_btn.Size = new System.Drawing.Size(288, 52);
            this.view_all_btn.TabIndex = 19;
            this.view_all_btn.Text = "View all Orders";
            this.view_all_btn.UseVisualStyleBackColor = false;
            this.view_all_btn.Click += new System.EventHandler(this.view_all_btn_Click);
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.search_btn.Font = new System.Drawing.Font("Lucida Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.Location = new System.Drawing.Point(192, 80);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(144, 52);
            this.search_btn.TabIndex = 18;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "Bill Type :";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cash",
            "Debit Card",
            "Credit Card",
            "Cheque",
            "UPI"});
            this.comboBox1.Location = new System.Drawing.Point(244, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 27);
            this.comboBox1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(817, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 27);
            this.label2.TabIndex = 21;
            this.label2.Text = "Total :";
            // 
            // Order_detail_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 583);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.view_all_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Order_detail_report";
            this.Text = "Order_detail_report";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button view_all_btn;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
    }
}
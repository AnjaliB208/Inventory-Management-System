
namespace ADNF_casestudy
{
    partial class Unit
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.add_unit_btn = new System.Windows.Forms.Button();
            this.del_unit_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unit name :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(230, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 28);
            this.textBox1.TabIndex = 1;
            // 
            // add_unit_btn
            // 
            this.add_unit_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.add_unit_btn.Font = new System.Drawing.Font("Lucida Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_unit_btn.Location = new System.Drawing.Point(171, 247);
            this.add_unit_btn.Name = "add_unit_btn";
            this.add_unit_btn.Size = new System.Drawing.Size(161, 38);
            this.add_unit_btn.TabIndex = 2;
            this.add_unit_btn.Text = "Add Unit";
            this.add_unit_btn.UseVisualStyleBackColor = false;
            this.add_unit_btn.Click += new System.EventHandler(this.add_unit_btn_Click);
            // 
            // del_unit_btn
            // 
            this.del_unit_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.del_unit_btn.Font = new System.Drawing.Font("Lucida Sans", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.del_unit_btn.Location = new System.Drawing.Point(152, 383);
            this.del_unit_btn.Name = "del_unit_btn";
            this.del_unit_btn.Size = new System.Drawing.Size(196, 38);
            this.del_unit_btn.TabIndex = 3;
            this.del_unit_btn.Text = "Delete Unit";
            this.del_unit_btn.UseVisualStyleBackColor = false;
            this.del_unit_btn.Click += new System.EventHandler(this.del_unit_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(521, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(507, 466);
            this.dataGridView1.TabIndex = 4;
            // 
            // Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 583);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.del_unit_btn);
            this.Controls.Add(this.add_unit_btn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Unit";
            this.Text = "Units";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button add_unit_btn;
        private System.Windows.Forms.Button del_unit_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
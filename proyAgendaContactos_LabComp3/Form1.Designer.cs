using System.Windows.Forms;

namespace proyAgendaContactos_LabComp3
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            //columna1 = new DataGridViewTextBoxColumn();
            //columna2 = new DataGridViewTextBoxColumn();
            //columna3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(290, 33);
            comboBox1.TabIndex = 0;
            comboBox1.DropDown += comboBox1_DropDown;
            comboBox1.SelectionChangeCommitted += comboBox1_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(451, 15);
            label1.Name = "label1";
            label1.Size = new Size(189, 25);
            label1.TabIndex = 1;
            label1.Text = "<Sin seleccionar aun.>";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //dataGridView1.Columns.AddRange(new DataGridViewColumn[] { columna1, columna2, columna3 });
            dataGridView1.Location = new Point(12, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.Size = new Size(776, 387);
            dataGridView1.TabIndex = 2;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Nombre Completo";
            dataGridView1.Columns[1].Name = "Id autogenerado";
            dataGridView1.Columns[2].Name = "Fecha de Creacion";
            //// 
            //// columna1
            //// 
            //columna1.HeaderText = "Nombre y Apellido";
            //columna1.MinimumWidth = 8;
            //columna1.Name = "columna1";
            //columna1.Width = 275;
            //// 
            //// columna2
            //// 
            //columna2.HeaderText = "Id Persona";
            //columna2.MinimumWidth = 8;
            //columna2.Name = "columna2";
            //columna2.Width = 130;
            //// 
            //// columna3
            //// 
            //columna3.HeaderText = "Momento de creacion";
            //columna3.MinimumWidth = 8;
            //columna3.Name = "columna3";
            //columna3.Width = 275;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private DataGridView dataGridView1;
        //private DataGridViewTextBoxColumn columna1;
        //private DataGridViewTextBoxColumn columna2;
        //private DataGridViewTextBoxColumn columna3;
    }
}

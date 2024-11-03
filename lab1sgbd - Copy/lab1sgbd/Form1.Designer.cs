namespace lab1sgbd
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewParinte = new System.Windows.Forms.DataGridView();
            this.profesorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeProfesorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specializareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varstaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profesoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sCOALASGBDDataSet = new lab1sgbd.SCOALASGBDDataSet();
            this.profesoriTableAdapter = new lab1sgbd.SCOALASGBDDataSetTableAdapters.ProfesoriTableAdapter();
            this.dataGridViewFiu = new System.Windows.Forms.DataGridView();
            this.cursIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numecursDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriereDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profesorIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cursuriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sCOALASGBDDataSet1 = new lab1sgbd.SCOALASGBDDataSet1();
            this.cursuriTableAdapter = new lab1sgbd.SCOALASGBDDataSet1TableAdapters.CursuriTableAdapter();
            this.refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Delete = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Insert = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParinte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profesoriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCOALASGBDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursuriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCOALASGBDDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewParinte
            // 
            this.dataGridViewParinte.AutoGenerateColumns = false;
            this.dataGridViewParinte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParinte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.profesorIDDataGridViewTextBoxColumn,
            this.numeProfesorDataGridViewTextBoxColumn,
            this.specializareDataGridViewTextBoxColumn,
            this.varstaDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dataGridViewParinte.DataSource = this.profesoriBindingSource;
            this.dataGridViewParinte.Location = new System.Drawing.Point(19, 78);
            this.dataGridViewParinte.Name = "dataGridViewParinte";
            this.dataGridViewParinte.RowHeadersWidth = 51;
            this.dataGridViewParinte.RowTemplate.Height = 24;
            this.dataGridViewParinte.Size = new System.Drawing.Size(677, 150);
            this.dataGridViewParinte.TabIndex = 0;
            // 
            // profesorIDDataGridViewTextBoxColumn
            // 
            this.profesorIDDataGridViewTextBoxColumn.DataPropertyName = "profesorID";
            this.profesorIDDataGridViewTextBoxColumn.HeaderText = "profesorID";
            this.profesorIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.profesorIDDataGridViewTextBoxColumn.Name = "profesorIDDataGridViewTextBoxColumn";
            this.profesorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.profesorIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // numeProfesorDataGridViewTextBoxColumn
            // 
            this.numeProfesorDataGridViewTextBoxColumn.DataPropertyName = "numeProfesor";
            this.numeProfesorDataGridViewTextBoxColumn.HeaderText = "numeProfesor";
            this.numeProfesorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numeProfesorDataGridViewTextBoxColumn.Name = "numeProfesorDataGridViewTextBoxColumn";
            this.numeProfesorDataGridViewTextBoxColumn.Width = 125;
            // 
            // specializareDataGridViewTextBoxColumn
            // 
            this.specializareDataGridViewTextBoxColumn.DataPropertyName = "specializare";
            this.specializareDataGridViewTextBoxColumn.HeaderText = "specializare";
            this.specializareDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.specializareDataGridViewTextBoxColumn.Name = "specializareDataGridViewTextBoxColumn";
            this.specializareDataGridViewTextBoxColumn.Width = 125;
            // 
            // varstaDataGridViewTextBoxColumn
            // 
            this.varstaDataGridViewTextBoxColumn.DataPropertyName = "varsta";
            this.varstaDataGridViewTextBoxColumn.HeaderText = "varsta";
            this.varstaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.varstaDataGridViewTextBoxColumn.Name = "varstaDataGridViewTextBoxColumn";
            this.varstaDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // profesoriBindingSource
            // 
            this.profesoriBindingSource.DataMember = "Profesori";
            this.profesoriBindingSource.DataSource = this.sCOALASGBDDataSet;
            // 
            // sCOALASGBDDataSet
            // 
            this.sCOALASGBDDataSet.DataSetName = "SCOALASGBDDataSet";
            this.sCOALASGBDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // profesoriTableAdapter
            // 
            this.profesoriTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewFiu
            // 
            this.dataGridViewFiu.AutoGenerateColumns = false;
            this.dataGridViewFiu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cursIDDataGridViewTextBoxColumn,
            this.numecursDataGridViewTextBoxColumn,
            this.descriereDataGridViewTextBoxColumn,
            this.profesorIDDataGridViewTextBoxColumn1});
            this.dataGridViewFiu.DataSource = this.cursuriBindingSource;
            this.dataGridViewFiu.Location = new System.Drawing.Point(17, 309);
            this.dataGridViewFiu.Name = "dataGridViewFiu";
            this.dataGridViewFiu.RowHeadersWidth = 51;
            this.dataGridViewFiu.RowTemplate.Height = 24;
            this.dataGridViewFiu.Size = new System.Drawing.Size(551, 150);
            this.dataGridViewFiu.TabIndex = 1;
            // 
            // cursIDDataGridViewTextBoxColumn
            // 
            this.cursIDDataGridViewTextBoxColumn.DataPropertyName = "cursID";
            this.cursIDDataGridViewTextBoxColumn.HeaderText = "cursID";
            this.cursIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cursIDDataGridViewTextBoxColumn.Name = "cursIDDataGridViewTextBoxColumn";
            this.cursIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cursIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // numecursDataGridViewTextBoxColumn
            // 
            this.numecursDataGridViewTextBoxColumn.DataPropertyName = "nume_curs";
            this.numecursDataGridViewTextBoxColumn.HeaderText = "nume_curs";
            this.numecursDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numecursDataGridViewTextBoxColumn.Name = "numecursDataGridViewTextBoxColumn";
            this.numecursDataGridViewTextBoxColumn.Width = 125;
            // 
            // descriereDataGridViewTextBoxColumn
            // 
            this.descriereDataGridViewTextBoxColumn.DataPropertyName = "descriere";
            this.descriereDataGridViewTextBoxColumn.HeaderText = "descriere";
            this.descriereDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriereDataGridViewTextBoxColumn.Name = "descriereDataGridViewTextBoxColumn";
            this.descriereDataGridViewTextBoxColumn.Width = 125;
            // 
            // profesorIDDataGridViewTextBoxColumn1
            // 
            this.profesorIDDataGridViewTextBoxColumn1.DataPropertyName = "profesorID";
            this.profesorIDDataGridViewTextBoxColumn1.HeaderText = "profesorID";
            this.profesorIDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.profesorIDDataGridViewTextBoxColumn1.Name = "profesorIDDataGridViewTextBoxColumn1";
            this.profesorIDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // cursuriBindingSource
            // 
            this.cursuriBindingSource.DataMember = "Cursuri";
            this.cursuriBindingSource.DataSource = this.sCOALASGBDDataSet1;
            // 
            // sCOALASGBDDataSet1
            // 
            this.sCOALASGBDDataSet1.DataSetName = "SCOALASGBDDataSet1";
            this.sCOALASGBDDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cursuriTableAdapter
            // 
            this.cursuriTableAdapter.ClearBeforeFill = true;
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.refresh.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.ForeColor = System.Drawing.Color.Navy;
            this.refresh.Location = new System.Drawing.Point(220, 533);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(141, 55);
            this.refresh.TabIndex = 2;
            this.refresh.Text = "REFRESH";
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tabela Parinte(Profesori)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(14, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tabela Fiu(Cursuri)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Thistle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(819, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "numeProfesor";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(984, 147);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 22);
            this.textBox1.TabIndex = 6;
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Thistle;
            this.Delete.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.ForeColor = System.Drawing.Color.DarkMagenta;
            this.Delete.Location = new System.Drawing.Point(735, 289);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(139, 65);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "DELETE";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.Color.Thistle;
            this.Update.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update.ForeColor = System.Drawing.Color.DarkMagenta;
            this.Update.Location = new System.Drawing.Point(910, 289);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(143, 65);
            this.Update.TabIndex = 8;
            this.Update.Text = "UPDATE";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(932, 377);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(172, 22);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(932, 426);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(172, 22);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(932, 474);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(172, 22);
            this.textBox4.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Orchid;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(820, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "nume_curs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Orchid;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(833, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "descriere";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Orchid;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(823, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "profesorID";
            // 
            // Insert
            // 
            this.Insert.BackColor = System.Drawing.Color.Thistle;
            this.Insert.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert.Location = new System.Drawing.Point(1083, 289);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(131, 65);
            this.Insert.TabIndex = 15;
            this.Insert.Text = "INSERT";
            this.Insert.UseVisualStyleBackColor = false;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Font = new System.Drawing.Font("Franklin Gothic Book", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label10.Location = new System.Drawing.Point(819, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 22;
            this.label10.Text = "Cerinta 2:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Font = new System.Drawing.Font("Lucida Sans Unicode", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label11.Location = new System.Drawing.Point(1098, 255);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 21);
            this.label11.TabIndex = 23;
            this.label11.Text = "Cerinta 4:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Font = new System.Drawing.Font("Lucida Sans Unicode", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label12.Location = new System.Drawing.Point(832, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 21);
            this.label12.TabIndex = 24;
            this.label12.Text = "Cerinta 3:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1265, 737);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.dataGridViewFiu);
            this.Controls.Add(this.dataGridViewParinte);
            this.ForeColor = System.Drawing.Color.DarkMagenta;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParinte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profesoriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCOALASGBDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursuriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCOALASGBDDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewParinte;
        private SCOALASGBDDataSet sCOALASGBDDataSet;
        private System.Windows.Forms.BindingSource profesoriBindingSource;
        private SCOALASGBDDataSetTableAdapters.ProfesoriTableAdapter profesoriTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn profesorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeProfesorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn specializareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varstaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridViewFiu;
        private SCOALASGBDDataSet1 sCOALASGBDDataSet1;
        private System.Windows.Forms.BindingSource cursuriBindingSource;
        private SCOALASGBDDataSet1TableAdapters.CursuriTableAdapter cursuriTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cursIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numecursDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriereDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profesorIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}


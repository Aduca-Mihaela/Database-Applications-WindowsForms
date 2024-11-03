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
            this.profesoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sCOALASGBDDataSet = new lab1sgbd.SCOALASGBDDataSet();
            this.profesoriTableAdapter = new lab1sgbd.SCOALASGBDDataSetTableAdapters.ProfesoriTableAdapter();
            this.dataGridViewFiu = new System.Windows.Forms.DataGridView();
            this.cursuriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sCOALASGBDDataSet1 = new lab1sgbd.SCOALASGBDDataSet1();
            this.cursuriTableAdapter = new lab1sgbd.SCOALASGBDDataSet1TableAdapters.CursuriTableAdapter();
            this.refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Delete = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Insert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.generatetextbox = new System.Windows.Forms.Button();
            this.scoalasgbdDataSet2 = new lab1sgbd.SCOALASGBDDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParinte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profesoriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCOALASGBDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursuriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sCOALASGBDDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoalasgbdDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewParinte
            // 
            this.dataGridViewParinte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParinte.Location = new System.Drawing.Point(19, 78);
            this.dataGridViewParinte.Name = "dataGridViewParinte";
            this.dataGridViewParinte.RowHeadersWidth = 51;
            this.dataGridViewParinte.RowTemplate.Height = 24;
            this.dataGridViewParinte.Size = new System.Drawing.Size(677, 150);
            this.dataGridViewParinte.TabIndex = 0;
            this.dataGridViewParinte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewParinte_CellContentClick);
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
            this.dataGridViewFiu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiu.Location = new System.Drawing.Point(19, 308);
            this.dataGridViewFiu.Name = "dataGridViewFiu";
            this.dataGridViewFiu.RowHeadersWidth = 51;
            this.dataGridViewFiu.RowTemplate.Height = 24;
            this.dataGridViewFiu.Size = new System.Drawing.Size(551, 150);
            this.dataGridViewFiu.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tabela Parinte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(14, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tabela Fiu";
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.ForeColor = System.Drawing.Color.Crimson;
            this.panel1.Location = new System.Drawing.Point(758, 369);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 219);
            this.panel1.TabIndex = 25;
            // 
            // generatetextbox
            // 
            this.generatetextbox.Location = new System.Drawing.Point(927, 184);
            this.generatetextbox.Name = "generatetextbox";
            this.generatetextbox.Size = new System.Drawing.Size(126, 55);
            this.generatetextbox.TabIndex = 26;
            this.generatetextbox.Text = "Generate textbox";
            this.generatetextbox.UseVisualStyleBackColor = true;
            this.generatetextbox.Click += new System.EventHandler(this.generatetextbox_Click);
            // 
            // scoalasgbdDataSet2
            // 
            this.scoalasgbdDataSet2.DataSetName = "SCOALASGBDDataSet";
            this.scoalasgbdDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1265, 737);
            this.Controls.Add(this.generatetextbox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Delete);
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
            ((System.ComponentModel.ISupportInitialize)(this.scoalasgbdDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewParinte;
        private SCOALASGBDDataSet sCOALASGBDDataSet;
        private System.Windows.Forms.BindingSource profesoriBindingSource;
        private SCOALASGBDDataSetTableAdapters.ProfesoriTableAdapter profesoriTableAdapter;
        private System.Windows.Forms.DataGridView dataGridViewFiu;
        private SCOALASGBDDataSet1 sCOALASGBDDataSet1;
        private System.Windows.Forms.BindingSource cursuriBindingSource;
        private SCOALASGBDDataSet1TableAdapters.CursuriTableAdapter cursuriTableAdapter;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button generatetextbox;
        private SCOALASGBDDataSet scoalasgbdDataSet2;
    }
}


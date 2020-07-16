namespace Aeropuerto
{
    partial class RegAvion
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
            this.dgvAvion = new System.Windows.Forms.DataGridView();
            this.NroAvion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvion)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAvion
            // 
            this.dgvAvion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroAvion,
            this.Model,
            this.Emp,
            this.Cant});
            this.dgvAvion.Location = new System.Drawing.Point(12, 12);
            this.dgvAvion.Name = "dgvAvion";
            this.dgvAvion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvion.Size = new System.Drawing.Size(444, 426);
            this.dgvAvion.TabIndex = 0;
            // 
            // NroAvion
            // 
            this.NroAvion.HeaderText = "Numero";
            this.NroAvion.Name = "NroAvion";
            // 
            // Model
            // 
            this.Model.HeaderText = "Modelo";
            this.Model.Name = "Model";
            // 
            // Emp
            // 
            this.Emp.HeaderText = "Empresa";
            this.Emp.Name = "Emp";
            // 
            // Cant
            // 
            this.Cant.HeaderText = "Lugares Disponibles";
            this.Cant.Name = "Cant";
            // 
            // RegAvion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAvion);
            this.Name = "RegAvion";
            this.Text = "RegAvion";
            this.Load += new System.EventHandler(this.RegAvion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAvion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroAvion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant;
    }
}
namespace WindowsFormsDataBinding
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.carInventoryGridView = new System.Windows.Forms.DataGridView();
            this.lblGridInfoMessage = new System.Windows.Forms.Label();
            this.groupBoxDeleteRow = new System.Windows.Forms.GroupBox();
            this.btnRemoveCar = new System.Windows.Forms.Button();
            this.txtCarToRemove = new System.Windows.Forms.TextBox();
            this.groupBoxViewMakes = new System.Windows.Forms.GroupBox();
            this.btnDisplayMakes = new System.Windows.Forms.Button();
            this.txtMakeToView = new System.Windows.Forms.TextBox();
            this.lblOnlyYugos = new System.Windows.Forms.Label();
            this.dataGridYugosView = new System.Windows.Forms.DataGridView();
            this.btnChangeMakes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).BeginInit();
            this.groupBoxDeleteRow.SuspendLayout();
            this.groupBoxViewMakes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).BeginInit();
            this.SuspendLayout();
            // 
            // carInventoryGridView
            // 
            this.carInventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carInventoryGridView.Location = new System.Drawing.Point(12, 55);
            this.carInventoryGridView.Name = "carInventoryGridView";
            this.carInventoryGridView.Size = new System.Drawing.Size(537, 191);
            this.carInventoryGridView.TabIndex = 0;
            // 
            // lblGridInfoMessage
            // 
            this.lblGridInfoMessage.AutoSize = true;
            this.lblGridInfoMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridInfoMessage.Location = new System.Drawing.Point(12, 13);
            this.lblGridInfoMessage.Name = "lblGridInfoMessage";
            this.lblGridInfoMessage.Size = new System.Drawing.Size(287, 24);
            this.lblGridInfoMessage.TabIndex = 1;
            this.lblGridInfoMessage.Text = "Here is what we have in stock";
            // 
            // groupBoxDeleteRow
            // 
            this.groupBoxDeleteRow.Controls.Add(this.btnRemoveCar);
            this.groupBoxDeleteRow.Controls.Add(this.txtCarToRemove);
            this.groupBoxDeleteRow.Location = new System.Drawing.Point(16, 273);
            this.groupBoxDeleteRow.Name = "groupBoxDeleteRow";
            this.groupBoxDeleteRow.Size = new System.Drawing.Size(267, 79);
            this.groupBoxDeleteRow.TabIndex = 2;
            this.groupBoxDeleteRow.TabStop = false;
            this.groupBoxDeleteRow.Text = "Enter ID of Car to Delete";
            // 
            // btnRemoveCar
            // 
            this.btnRemoveCar.Location = new System.Drawing.Point(160, 36);
            this.btnRemoveCar.Name = "btnRemoveCar";
            this.btnRemoveCar.Size = new System.Drawing.Size(99, 23);
            this.btnRemoveCar.TabIndex = 1;
            this.btnRemoveCar.Text = "Delete!";
            this.btnRemoveCar.UseVisualStyleBackColor = true;
            this.btnRemoveCar.Click += new System.EventHandler(this.btnRemoveCar_Click);
            // 
            // txtCarToRemove
            // 
            this.txtCarToRemove.Location = new System.Drawing.Point(17, 36);
            this.txtCarToRemove.Name = "txtCarToRemove";
            this.txtCarToRemove.Size = new System.Drawing.Size(137, 20);
            this.txtCarToRemove.TabIndex = 0;
            // 
            // groupBoxViewMakes
            // 
            this.groupBoxViewMakes.Controls.Add(this.btnDisplayMakes);
            this.groupBoxViewMakes.Controls.Add(this.txtMakeToView);
            this.groupBoxViewMakes.Location = new System.Drawing.Point(289, 273);
            this.groupBoxViewMakes.Name = "groupBoxViewMakes";
            this.groupBoxViewMakes.Size = new System.Drawing.Size(260, 79);
            this.groupBoxViewMakes.TabIndex = 3;
            this.groupBoxViewMakes.TabStop = false;
            this.groupBoxViewMakes.Text = "Enter Make to View";
            // 
            // btnDisplayMakes
            // 
            this.btnDisplayMakes.Location = new System.Drawing.Point(155, 36);
            this.btnDisplayMakes.Name = "btnDisplayMakes";
            this.btnDisplayMakes.Size = new System.Drawing.Size(99, 23);
            this.btnDisplayMakes.TabIndex = 3;
            this.btnDisplayMakes.Text = "View!";
            this.btnDisplayMakes.UseVisualStyleBackColor = true;
            this.btnDisplayMakes.Click += new System.EventHandler(this.btnDisplayMakes_Click);
            // 
            // txtMakeToView
            // 
            this.txtMakeToView.Location = new System.Drawing.Point(12, 36);
            this.txtMakeToView.Name = "txtMakeToView";
            this.txtMakeToView.Size = new System.Drawing.Size(137, 20);
            this.txtMakeToView.TabIndex = 2;
            // 
            // lblOnlyYugos
            // 
            this.lblOnlyYugos.AutoSize = true;
            this.lblOnlyYugos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnlyYugos.Location = new System.Drawing.Point(8, 366);
            this.lblOnlyYugos.Name = "lblOnlyYugos";
            this.lblOnlyYugos.Size = new System.Drawing.Size(118, 24);
            this.lblOnlyYugos.TabIndex = 6;
            this.lblOnlyYugos.Text = "Only Yugos";
            // 
            // dataGridYugosView
            // 
            this.dataGridYugosView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridYugosView.Location = new System.Drawing.Point(6, 393);
            this.dataGridYugosView.Name = "dataGridYugosView";
            this.dataGridYugosView.Size = new System.Drawing.Size(537, 116);
            this.dataGridYugosView.TabIndex = 5;
            // 
            // btnChangeMakes
            // 
            this.btnChangeMakes.Location = new System.Drawing.Point(326, 13);
            this.btnChangeMakes.Name = "btnChangeMakes";
            this.btnChangeMakes.Size = new System.Drawing.Size(223, 23);
            this.btnChangeMakes.TabIndex = 4;
            this.btnChangeMakes.Text = "Change All BMWs to Yugos";
            this.btnChangeMakes.UseVisualStyleBackColor = true;
            this.btnChangeMakes.Click += new System.EventHandler(this.btnChangeMakes_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 521);
            this.Controls.Add(this.lblOnlyYugos);
            this.Controls.Add(this.dataGridYugosView);
            this.Controls.Add(this.btnChangeMakes);
            this.Controls.Add(this.groupBoxViewMakes);
            this.Controls.Add(this.groupBoxDeleteRow);
            this.Controls.Add(this.lblGridInfoMessage);
            this.Controls.Add(this.carInventoryGridView);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Forms Data Binding";
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).EndInit();
            this.groupBoxDeleteRow.ResumeLayout(false);
            this.groupBoxDeleteRow.PerformLayout();
            this.groupBoxViewMakes.ResumeLayout(false);
            this.groupBoxViewMakes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView carInventoryGridView;
        private System.Windows.Forms.Label lblGridInfoMessage;
        private System.Windows.Forms.GroupBox groupBoxDeleteRow;
        private System.Windows.Forms.Button btnRemoveCar;
        private System.Windows.Forms.TextBox txtCarToRemove;
        private System.Windows.Forms.GroupBox groupBoxViewMakes;
        private System.Windows.Forms.Button btnDisplayMakes;
        private System.Windows.Forms.TextBox txtMakeToView;
        private System.Windows.Forms.Label lblOnlyYugos;
        private System.Windows.Forms.DataGridView dataGridYugosView;
        private System.Windows.Forms.Button btnChangeMakes;
    }
}


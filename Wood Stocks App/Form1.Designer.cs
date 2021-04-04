
namespace Wood_Stocks_App
{
    partial class frmWoodStocksInventory
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblImportCSV = new System.Windows.Forms.Label();
            this.lblSaveCSV = new System.Windows.Forms.Label();
            this.btnImportCSV = new System.Windows.Forms.Button();
            this.btnSaveCSV = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvStocklist = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblFilename = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocklist)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(24, 13);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(62, 15);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome,";
            // 
            // lblImportCSV
            // 
            this.lblImportCSV.AutoSize = true;
            this.lblImportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportCSV.Location = new System.Drawing.Point(24, 29);
            this.lblImportCSV.Name = "lblImportCSV";
            this.lblImportCSV.Size = new System.Drawing.Size(172, 15);
            this.lblImportCSV.TabIndex = 1;
            this.lblImportCSV.Text = "Click on \"Import CSV\" to begin.";
            // 
            // lblSaveCSV
            // 
            this.lblSaveCSV.AutoSize = true;
            this.lblSaveCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaveCSV.Location = new System.Drawing.Point(24, 45);
            this.lblSaveCSV.Name = "lblSaveCSV";
            this.lblSaveCSV.Size = new System.Drawing.Size(346, 15);
            this.lblSaveCSV.TabIndex = 2;
            this.lblSaveCSV.Text = "Once editing is complete click on \"Save CSV\" to update the file.";
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.Location = new System.Drawing.Point(394, 15);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(100, 45);
            this.btnImportCSV.TabIndex = 3;
            this.btnImportCSV.Text = "&Import CSV";
            this.btnImportCSV.UseVisualStyleBackColor = true;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // btnSaveCSV
            // 
            this.btnSaveCSV.Location = new System.Drawing.Point(521, 15);
            this.btnSaveCSV.Name = "btnSaveCSV";
            this.btnSaveCSV.Size = new System.Drawing.Size(100, 45);
            this.btnSaveCSV.TabIndex = 4;
            this.btnSaveCSV.Text = "&Save CSV";
            this.btnSaveCSV.UseVisualStyleBackColor = true;
            this.btnSaveCSV.Click += new System.EventHandler(this.btnSaveCSV_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(646, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 45);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvStocklist
            // 
            this.dgvStocklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStocklist.Location = new System.Drawing.Point(12, 104);
            this.dgvStocklist.Name = "dgvStocklist";
            this.dgvStocklist.Size = new System.Drawing.Size(752, 334);
            this.dgvStocklist.TabIndex = 6;
            this.dgvStocklist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStocklist_CellContentClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            this.openFileDialog1.Title = "Import";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "Save File";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(24, 76);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(52, 13);
            this.lblFilename.TabIndex = 7;
            this.lblFilename.Text = "Filename:";
            this.lblFilename.Click += new System.EventHandler(this.lblFilename_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(86, 73);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(660, 20);
            this.txtFilename.TabIndex = 8;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // frmWoodStocksInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.dgvStocklist);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveCSV);
            this.Controls.Add(this.btnImportCSV);
            this.Controls.Add(this.lblSaveCSV);
            this.Controls.Add(this.lblImportCSV);
            this.Controls.Add(this.lblWelcome);
            this.Name = "frmWoodStocksInventory";
            this.Text = "Wood Stocks Inventory";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocklist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblImportCSV;
        private System.Windows.Forms.Label lblSaveCSV;
        private System.Windows.Forms.Button btnImportCSV;
        private System.Windows.Forms.Button btnSaveCSV;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvStocklist;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.TextBox txtFilename;
    }
}


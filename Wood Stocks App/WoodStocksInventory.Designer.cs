
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
            this.lblOpen = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
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
            // lblOpen
            // 
            this.lblOpen.AutoSize = true;
            this.lblOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpen.Location = new System.Drawing.Point(24, 29);
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size(141, 15);
            this.lblOpen.TabIndex = 1;
            this.lblOpen.Text = "Click on \"Open\" to begin.";
            this.lblOpen.Click += new System.EventHandler(this.lblOpen_Click);
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.Location = new System.Drawing.Point(24, 45);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(320, 15);
            this.lblSave.TabIndex = 2;
            this.lblSave.Text = "Once editing is complete click on \"Save\" to update the file.";
            this.lblSave.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(415, 15);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 45);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSaveCSV
            // 
            this.btnSaveCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCSV.AutoSize = true;
            this.btnSaveCSV.Location = new System.Drawing.Point(540, 15);
            this.btnSaveCSV.Name = "btnSaveCSV";
            this.btnSaveCSV.Size = new System.Drawing.Size(100, 45);
            this.btnSaveCSV.TabIndex = 4;
            this.btnSaveCSV.Text = "&Save";
            this.btnSaveCSV.UseVisualStyleBackColor = true;
            this.btnSaveCSV.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.Location = new System.Drawing.Point(664, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 45);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvStocklist
            // 
            this.dgvStocklist.AllowUserToAddRows = false;
            this.dgvStocklist.AllowUserToDeleteRows = false;
            this.dgvStocklist.AllowUserToOrderColumns = true;
            this.dgvStocklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.openFileDialog1.Title = "Open";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CreatePrompt = true;
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
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
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(86, 73);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(678, 20);
            this.txtFilename.TabIndex = 8;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // frmWoodStocksInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.dgvStocklist);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSaveCSV);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.lblOpen);
            this.Controls.Add(this.lblWelcome);
            this.MinimumSize = new System.Drawing.Size(792, 489);
            this.Name = "frmWoodStocksInventory";
            this.Text = "Wood Stocks Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWoodStocksInventory_FormClosing);
            this.Load += new System.EventHandler(this.frmWoodStocksInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocklist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblOpen;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSaveCSV;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvStocklist;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.TextBox txtFilename;
    }
}


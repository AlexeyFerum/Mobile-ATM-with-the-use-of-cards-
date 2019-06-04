namespace DemoMoblieATM
{
    partial class MainForm
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
            this.btn_Card = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnBalance = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Card
            // 
            this.btn_Card.Location = new System.Drawing.Point(224, 58);
            this.btn_Card.Name = "btn_Card";
            this.btn_Card.Size = new System.Drawing.Size(100, 40);
            this.btn_Card.TabIndex = 0;
            this.btn_Card.Text = "Insert Card";
            this.btn_Card.UseVisualStyleBackColor = true;
            this.btn_Card.Click += new System.EventHandler(this.btn_Card_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 1;
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Enabled = false;
            this.btnWithdraw.Location = new System.Drawing.Point(12, 104);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(100, 40);
            this.btnWithdraw.TabIndex = 2;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.Enabled = false;
            this.btnDeposit.Location = new System.Drawing.Point(118, 104);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(100, 40);
            this.btnDeposit.TabIndex = 3;
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(224, 12);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(100, 40);
            this.btnStaff.TabIndex = 4;
            this.btnStaff.Text = "Staff Mode";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnBalance
            // 
            this.btnBalance.Enabled = false;
            this.btnBalance.Location = new System.Drawing.Point(224, 104);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(100, 40);
            this.btnBalance.TabIndex = 5;
            this.btnBalance.Text = "Check Balance";
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(12, 48);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(0, 13);
            this.lblBalance.TabIndex = 6;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(12, 85);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(12, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(312, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 200);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.btnBalance);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btn_Card);
            this.Name = "MainForm";
            this.Text = "MobileATM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Card;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnCancel;
    }
}


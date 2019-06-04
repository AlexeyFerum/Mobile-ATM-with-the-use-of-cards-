namespace DemoMoblieATM
{
    partial class ServiceStaffForm
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnRepair = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.rbCheckTape = new System.Windows.Forms.RadioButton();
            this.rbCartridge = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(206, 12);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(125, 44);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Check Device Condition";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnRepair
            // 
            this.btnRepair.Location = new System.Drawing.Point(206, 62);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(125, 44);
            this.btnRepair.TabIndex = 1;
            this.btnRepair.Text = "Repair";
            this.btnRepair.UseVisualStyleBackColor = true;
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 44);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tbInput.Location = new System.Drawing.Point(12, 12);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(179, 94);
            this.tbInput.TabIndex = 5;
            // 
            // rbCheckTape
            // 
            this.rbCheckTape.AutoSize = true;
            this.rbCheckTape.Location = new System.Drawing.Point(206, 122);
            this.rbCheckTape.Name = "rbCheckTape";
            this.rbCheckTape.Size = new System.Drawing.Size(80, 17);
            this.rbCheckTape.TabIndex = 6;
            this.rbCheckTape.TabStop = true;
            this.rbCheckTape.Text = "Check tape";
            this.rbCheckTape.UseVisualStyleBackColor = true;
            // 
            // rbCartridge
            // 
            this.rbCartridge.AutoSize = true;
            this.rbCartridge.Location = new System.Drawing.Point(206, 147);
            this.rbCartridge.Name = "rbCartridge";
            this.rbCartridge.Size = new System.Drawing.Size(67, 17);
            this.rbCartridge.TabIndex = 7;
            this.rbCartridge.TabStop = true;
            this.rbCartridge.Text = "Cartridge";
            this.rbCartridge.UseVisualStyleBackColor = true;
            // 
            // ServiceStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 176);
            this.Controls.Add(this.rbCartridge);
            this.Controls.Add(this.rbCheckTape);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRepair);
            this.Controls.Add(this.btnCheck);
            this.Name = "ServiceStaffForm";
            this.Text = "MobileATM (Service staff mode)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.RadioButton rbCheckTape;
        private System.Windows.Forms.RadioButton rbCartridge;
    }
}
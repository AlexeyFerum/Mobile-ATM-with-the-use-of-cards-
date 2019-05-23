namespace MainApp
{
    partial class MainApp
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
            this.btn_PIN = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_PIN
            // 
            this.btn_PIN.Location = new System.Drawing.Point(683, 12);
            this.btn_PIN.Name = "btn_PIN";
            this.btn_PIN.Size = new System.Drawing.Size(105, 35);
            this.btn_PIN.TabIndex = 0;
            this.btn_PIN.Text = "Ввести ПИН-код";
            this.btn_PIN.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(683, 53);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(105, 35);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Завершить обслуживание";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_PIN);
            this.Name = "MainApp";
            this.Text = "MobileATM";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_PIN;
        private System.Windows.Forms.Button btn_Cancel;
    }
}


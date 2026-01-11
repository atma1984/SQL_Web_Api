namespace SQL_Client
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
            this.connectButton = new System.Windows.Forms.Button();
            this.getVersionButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.connectionStringTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(125, 113);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(130, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "connectButton";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // getVersionButton
            // 
            this.getVersionButton.Location = new System.Drawing.Point(125, 156);
            this.getVersionButton.Name = "getVersionButton";
            this.getVersionButton.Size = new System.Drawing.Size(130, 23);
            this.getVersionButton.TabIndex = 1;
            this.getVersionButton.Text = "getVersionButton";
            this.getVersionButton.UseVisualStyleBackColor = true;
            this.getVersionButton.Click += new System.EventHandler(this.getVersionButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(125, 198);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(130, 23);
            this.disconnectButton.TabIndex = 2;
            this.disconnectButton.Text = "disconnectButton";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // connectionStringTextBox
            // 
            this.connectionStringTextBox.Location = new System.Drawing.Point(373, 135);
            this.connectionStringTextBox.Name = "connectionStringTextBox";
            this.connectionStringTextBox.Size = new System.Drawing.Size(328, 20);
            this.connectionStringTextBox.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(394, 40);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.connectionStringTextBox);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.getVersionButton);
            this.Controls.Add(this.connectButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button getVersionButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox connectionStringTextBox;
        private System.Windows.Forms.Label statusLabel;
    }
}


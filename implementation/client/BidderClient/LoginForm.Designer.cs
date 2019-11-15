namespace BidderClient
{
    partial class LoginForm
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
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userPasswordLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.userNameInput = new System.Windows.Forms.TextBox();
            this.userPasswordInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(104, 113);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(79, 17);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "User Name";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // userPasswordLabel
            // 
            this.userPasswordLabel.AutoSize = true;
            this.userPasswordLabel.Location = new System.Drawing.Point(107, 198);
            this.userPasswordLabel.Name = "userPasswordLabel";
            this.userPasswordLabel.Size = new System.Drawing.Size(69, 17);
            this.userPasswordLabel.TabIndex = 1;
            this.userPasswordLabel.Text = "Password";
            this.userPasswordLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(164, 280);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(163, 75);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // userNameInput
            // 
            this.userNameInput.Location = new System.Drawing.Point(279, 110);
            this.userNameInput.Name = "userNameInput";
            this.userNameInput.Size = new System.Drawing.Size(100, 22);
            this.userNameInput.TabIndex = 3;
            // 
            // userPasswordInput
            // 
            this.userPasswordInput.Location = new System.Drawing.Point(279, 198);
            this.userPasswordInput.Name = "userPasswordInput";
            this.userPasswordInput.Size = new System.Drawing.Size(100, 22);
            this.userPasswordInput.TabIndex = 4;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 423);
            this.Controls.Add(this.userPasswordInput);
            this.Controls.Add(this.userNameInput);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.userPasswordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label userPasswordLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox userNameInput;
        private System.Windows.Forms.TextBox userPasswordInput;
    }
}


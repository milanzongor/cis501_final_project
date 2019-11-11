namespace BidderServer
{
    partial class ServerDashBoardForm
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
            this.productsDetailsList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.connectedUsersList = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.manageProductsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productsDetailsList
            // 
            this.productsDetailsList.HideSelection = false;
            this.productsDetailsList.Location = new System.Drawing.Point(25, 75);
            this.productsDetailsList.Name = "productsDetailsList";
            this.productsDetailsList.Size = new System.Drawing.Size(1011, 1075);
            this.productsDetailsList.TabIndex = 0;
            this.productsDetailsList.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of Products";
            // 
            // connectedUsersList
            // 
            this.connectedUsersList.HideSelection = false;
            this.connectedUsersList.Location = new System.Drawing.Point(1070, 75);
            this.connectedUsersList.Name = "connectedUsersList";
            this.connectedUsersList.Size = new System.Drawing.Size(409, 1075);
            this.connectedUsersList.TabIndex = 2;
            this.connectedUsersList.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1128, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "List of Connected Users";
            // 
            // manageProductsButton
            // 
            this.manageProductsButton.Location = new System.Drawing.Point(420, 1164);
            this.manageProductsButton.Name = "manageProductsButton";
            this.manageProductsButton.Size = new System.Drawing.Size(204, 89);
            this.manageProductsButton.TabIndex = 4;
            this.manageProductsButton.Text = "Manage Products";
            this.manageProductsButton.UseVisualStyleBackColor = true;
            this.manageProductsButton.Click += new System.EventHandler(this.ManageProductsButton_Click);
            // 
            // ServerDashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1508, 1270);
            this.Controls.Add(this.manageProductsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connectedUsersList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productsDetailsList);
            this.Name = "ServerDashBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerDashBoardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView productsDetailsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView connectedUsersList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button manageProductsButton;
    }
}


namespace BidderServer
{
    partial class ManageProductsForm
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
            this.productsList = new System.Windows.Forms.ListView();
            this.addProductButton = new System.Windows.Forms.Button();
            this.removeProductButton = new System.Windows.Forms.Button();
            this.modifyProductButton = new System.Windows.Forms.Button();
            this.startProductAuction = new System.Windows.Forms.Button();
            this.stopProductAuction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productsList
            // 
            this.productsList.HideSelection = false;
            this.productsList.Location = new System.Drawing.Point(12, 12);
            this.productsList.Name = "productsList";
            this.productsList.Size = new System.Drawing.Size(744, 800);
            this.productsList.TabIndex = 0;
            this.productsList.UseCompatibleStateImageBehavior = false;
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(12, 835);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(220, 65);
            this.addProductButton.TabIndex = 1;
            this.addProductButton.Text = "Add";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // removeProductButton
            // 
            this.removeProductButton.Location = new System.Drawing.Point(274, 835);
            this.removeProductButton.Name = "removeProductButton";
            this.removeProductButton.Size = new System.Drawing.Size(220, 65);
            this.removeProductButton.TabIndex = 2;
            this.removeProductButton.Text = "Remove";
            this.removeProductButton.UseVisualStyleBackColor = true;
            this.removeProductButton.Click += new System.EventHandler(this.RemoveProductButton_Click);
            // 
            // modifyProductButton
            // 
            this.modifyProductButton.Location = new System.Drawing.Point(536, 835);
            this.modifyProductButton.Name = "modifyProductButton";
            this.modifyProductButton.Size = new System.Drawing.Size(220, 65);
            this.modifyProductButton.TabIndex = 3;
            this.modifyProductButton.Text = "Modify";
            this.modifyProductButton.UseVisualStyleBackColor = true;
            this.modifyProductButton.Click += new System.EventHandler(this.ModifyProductButton_Click);
            // 
            // startProductAuction
            // 
            this.startProductAuction.Location = new System.Drawing.Point(12, 924);
            this.startProductAuction.Name = "startProductAuction";
            this.startProductAuction.Size = new System.Drawing.Size(342, 65);
            this.startProductAuction.TabIndex = 4;
            this.startProductAuction.Text = "Start Auction";
            this.startProductAuction.UseVisualStyleBackColor = true;
            this.startProductAuction.Click += new System.EventHandler(this.StartProductAuction_Click);
            // 
            // stopProductAuction
            // 
            this.stopProductAuction.Location = new System.Drawing.Point(414, 924);
            this.stopProductAuction.Name = "stopProductAuction";
            this.stopProductAuction.Size = new System.Drawing.Size(342, 65);
            this.stopProductAuction.TabIndex = 5;
            this.stopProductAuction.Text = "Stop Auction";
            this.stopProductAuction.UseVisualStyleBackColor = true;
            this.stopProductAuction.Click += new System.EventHandler(this.StopProductAuction_Click);
            // 
            // ManageProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(768, 1012);
            this.Controls.Add(this.stopProductAuction);
            this.Controls.Add(this.startProductAuction);
            this.Controls.Add(this.modifyProductButton);
            this.Controls.Add(this.removeProductButton);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.productsList);
            this.Name = "ManageProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageProductsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView productsList;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button removeProductButton;
        private System.Windows.Forms.Button modifyProductButton;
        private System.Windows.Forms.Button startProductAuction;
        private System.Windows.Forms.Button stopProductAuction;
    }
}
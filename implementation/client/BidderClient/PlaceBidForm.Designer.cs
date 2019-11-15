namespace BidderClient
{
    partial class PlaceBidForm
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
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("");
            this.selectedProductNameLabel = new System.Windows.Forms.Label();
            this.placeBidButton = new System.Windows.Forms.Button();
            this.minimalBidValueLabel = new System.Windows.Forms.Label();
            this.biddingInput = new System.Windows.Forms.TextBox();
            this.bidNumberLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusColorField = new System.Windows.Forms.TextBox();
            this.expirationDateLabel = new System.Windows.Forms.Label();
            this.productsLabel = new System.Windows.Forms.Label();
            this.productListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // selectedProductNameLabel
            // 
            this.selectedProductNameLabel.AutoSize = true;
            this.selectedProductNameLabel.Location = new System.Drawing.Point(56, 74);
            this.selectedProductNameLabel.Name = "selectedProductNameLabel";
            this.selectedProductNameLabel.Size = new System.Drawing.Size(149, 17);
            this.selectedProductNameLabel.TabIndex = 0;
            this.selectedProductNameLabel.Text = "SelectedProductName";
            // 
            // placeBidButton
            // 
            this.placeBidButton.Location = new System.Drawing.Point(158, 357);
            this.placeBidButton.Name = "placeBidButton";
            this.placeBidButton.Size = new System.Drawing.Size(150, 69);
            this.placeBidButton.TabIndex = 1;
            this.placeBidButton.Text = "Place Bid";
            this.placeBidButton.UseVisualStyleBackColor = true;
            this.placeBidButton.Click += new System.EventHandler(this.placeBidButton_Click);
            // 
            // minimalBidValueLabel
            // 
            this.minimalBidValueLabel.AutoSize = true;
            this.minimalBidValueLabel.Location = new System.Drawing.Point(56, 280);
            this.minimalBidValueLabel.Name = "minimalBidValueLabel";
            this.minimalBidValueLabel.Size = new System.Drawing.Size(111, 17);
            this.minimalBidValueLabel.TabIndex = 3;
            this.minimalBidValueLabel.Text = "MinimalBidValue";
            // 
            // biddingInput
            // 
            this.biddingInput.Location = new System.Drawing.Point(59, 240);
            this.biddingInput.Name = "biddingInput";
            this.biddingInput.Size = new System.Drawing.Size(100, 22);
            this.biddingInput.TabIndex = 4;
            // 
            // bidNumberLabel
            // 
            this.bidNumberLabel.AutoSize = true;
            this.bidNumberLabel.Location = new System.Drawing.Point(172, 243);
            this.bidNumberLabel.Name = "bidNumberLabel";
            this.bidNumberLabel.Size = new System.Drawing.Size(100, 17);
            this.bidNumberLabel.TabIndex = 5;
            this.bidNumberLabel.Text = "NumberOfBids";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(56, 191);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(48, 17);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Status";
            // 
            // statusColorField
            // 
            this.statusColorField.BackColor = System.Drawing.SystemColors.HotTrack;
            this.statusColorField.Enabled = false;
            this.statusColorField.Location = new System.Drawing.Point(110, 188);
            this.statusColorField.Name = "statusColorField";
            this.statusColorField.ReadOnly = true;
            this.statusColorField.Size = new System.Drawing.Size(100, 22);
            this.statusColorField.TabIndex = 7;
            // 
            // expirationDateLabel
            // 
            this.expirationDateLabel.AutoSize = true;
            this.expirationDateLabel.Location = new System.Drawing.Point(56, 132);
            this.expirationDateLabel.Name = "expirationDateLabel";
            this.expirationDateLabel.Size = new System.Drawing.Size(100, 17);
            this.expirationDateLabel.TabIndex = 8;
            this.expirationDateLabel.Text = "ExpirationDate";
            // 
            // productsLabel
            // 
            this.productsLabel.AutoSize = true;
            this.productsLabel.Location = new System.Drawing.Point(334, 40);
            this.productsLabel.Name = "productsLabel";
            this.productsLabel.Size = new System.Drawing.Size(64, 17);
            this.productsLabel.TabIndex = 9;
            this.productsLabel.Text = "Products";
            // 
            // productListView
            // 
            this.productListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.productListView.HideSelection = false;
            this.productListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12});
            this.productListView.Location = new System.Drawing.Point(271, 74);
            this.productListView.MultiSelect = false;
            this.productListView.Name = "productListView";
            this.productListView.Size = new System.Drawing.Size(187, 241);
            this.productListView.TabIndex = 10;
            this.productListView.UseCompatibleStateImageBehavior = false;
            this.productListView.View = System.Windows.Forms.View.List;
            this.productListView.Click += new System.EventHandler(this.productListView_click);
            // 
            // PlaceBidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 461);
            this.Controls.Add(this.productListView);
            this.Controls.Add(this.productsLabel);
            this.Controls.Add(this.expirationDateLabel);
            this.Controls.Add(this.statusColorField);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.bidNumberLabel);
            this.Controls.Add(this.biddingInput);
            this.Controls.Add(this.minimalBidValueLabel);
            this.Controls.Add(this.placeBidButton);
            this.Controls.Add(this.selectedProductNameLabel);
            this.Name = "PlaceBidForm";
            this.Text = "PlaceBidForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlaceBidForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectedProductNameLabel;
        private System.Windows.Forms.Button placeBidButton;
        private System.Windows.Forms.Label minimalBidValueLabel;
        private System.Windows.Forms.TextBox biddingInput;
        private System.Windows.Forms.Label bidNumberLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox statusColorField;
        private System.Windows.Forms.Label expirationDateLabel;
        private System.Windows.Forms.Label productsLabel;
        private System.Windows.Forms.ListView productListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
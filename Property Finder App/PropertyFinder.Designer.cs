namespace Property_Finder_App
{
    partial class PropertyFinder
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
            this.components = new System.ComponentModel.Container();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchButton = new System.Windows.Forms.Button();
            this.propertyListView = new System.Windows.Forms.ListView();
            this.propertyTypeLabel = new System.Windows.Forms.Label();
            this.propertyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.minBedsLabel = new System.Windows.Forms.Label();
            this.minBedsComboBox = new System.Windows.Forms.ComboBox();
            this.maxBedsComboBox = new System.Windows.Forms.ComboBox();
            this.maxBedsLabel = new System.Windows.Forms.Label();
            this.minPriceComboBox = new System.Windows.Forms.ComboBox();
            this.minPriceLabel = new System.Windows.Forms.Label();
            this.maxPriceComboBox = new System.Windows.Forms.ComboBox();
            this.maxPriceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // locationComboBox
            // 
            this.locationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(15, 25);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(545, 21);
            this.locationComboBox.TabIndex = 0;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(12, 9);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(48, 13);
            this.locationLabel.TabIndex = 1;
            this.locationLabel.Text = "Location";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(566, 23);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // propertyListView
            // 
            this.propertyListView.FullRowSelect = true;
            this.propertyListView.Location = new System.Drawing.Point(12, 96);
            this.propertyListView.Name = "propertyListView";
            this.propertyListView.Size = new System.Drawing.Size(629, 219);
            this.propertyListView.TabIndex = 3;
            this.propertyListView.UseCompatibleStateImageBehavior = false;
            // 
            // propertyTypeLabel
            // 
            this.propertyTypeLabel.AutoSize = true;
            this.propertyTypeLabel.Location = new System.Drawing.Point(15, 53);
            this.propertyTypeLabel.Name = "propertyTypeLabel";
            this.propertyTypeLabel.Size = new System.Drawing.Size(69, 13);
            this.propertyTypeLabel.TabIndex = 4;
            this.propertyTypeLabel.Text = "Property type";
            // 
            // propertyTypeComboBox
            // 
            this.propertyTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.propertyTypeComboBox.FormattingEnabled = true;
            this.propertyTypeComboBox.Location = new System.Drawing.Point(12, 69);
            this.propertyTypeComboBox.Name = "propertyTypeComboBox";
            this.propertyTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.propertyTypeComboBox.TabIndex = 5;
            // 
            // minBedsLabel
            // 
            this.minBedsLabel.AutoSize = true;
            this.minBedsLabel.Location = new System.Drawing.Point(136, 53);
            this.minBedsLabel.Name = "minBedsLabel";
            this.minBedsLabel.Size = new System.Drawing.Size(53, 13);
            this.minBedsLabel.TabIndex = 6;
            this.minBedsLabel.Text = "Min. beds";
            // 
            // minBedsComboBox
            // 
            this.minBedsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minBedsComboBox.FormattingEnabled = true;
            this.minBedsComboBox.Location = new System.Drawing.Point(139, 69);
            this.minBedsComboBox.Name = "minBedsComboBox";
            this.minBedsComboBox.Size = new System.Drawing.Size(121, 21);
            this.minBedsComboBox.TabIndex = 7;
            // 
            // maxBedsComboBox
            // 
            this.maxBedsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maxBedsComboBox.FormattingEnabled = true;
            this.maxBedsComboBox.Location = new System.Drawing.Point(266, 69);
            this.maxBedsComboBox.Name = "maxBedsComboBox";
            this.maxBedsComboBox.Size = new System.Drawing.Size(121, 21);
            this.maxBedsComboBox.TabIndex = 8;
            // 
            // maxBedsLabel
            // 
            this.maxBedsLabel.AutoSize = true;
            this.maxBedsLabel.Location = new System.Drawing.Point(263, 53);
            this.maxBedsLabel.Name = "maxBedsLabel";
            this.maxBedsLabel.Size = new System.Drawing.Size(53, 13);
            this.maxBedsLabel.TabIndex = 9;
            this.maxBedsLabel.Text = "Max beds";
            // 
            // minPriceComboBox
            // 
            this.minPriceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minPriceComboBox.FormattingEnabled = true;
            this.minPriceComboBox.Location = new System.Drawing.Point(393, 69);
            this.minPriceComboBox.Name = "minPriceComboBox";
            this.minPriceComboBox.Size = new System.Drawing.Size(121, 21);
            this.minPriceComboBox.TabIndex = 10;
            // 
            // minPriceLabel
            // 
            this.minPriceLabel.AutoSize = true;
            this.minPriceLabel.Location = new System.Drawing.Point(390, 53);
            this.minPriceLabel.Name = "minPriceLabel";
            this.minPriceLabel.Size = new System.Drawing.Size(53, 13);
            this.minPriceLabel.TabIndex = 11;
            this.minPriceLabel.Text = "Min. price";
            // 
            // maxPriceComboBox
            // 
            this.maxPriceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maxPriceComboBox.FormattingEnabled = true;
            this.maxPriceComboBox.Location = new System.Drawing.Point(520, 69);
            this.maxPriceComboBox.Name = "maxPriceComboBox";
            this.maxPriceComboBox.Size = new System.Drawing.Size(121, 21);
            this.maxPriceComboBox.TabIndex = 12;
            // 
            // maxPriceLabel
            // 
            this.maxPriceLabel.AutoSize = true;
            this.maxPriceLabel.Location = new System.Drawing.Point(517, 53);
            this.maxPriceLabel.Name = "maxPriceLabel";
            this.maxPriceLabel.Size = new System.Drawing.Size(53, 13);
            this.maxPriceLabel.TabIndex = 13;
            this.maxPriceLabel.Text = "Max price";
            // 
            // PropertyFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 327);
            this.Controls.Add(this.maxPriceLabel);
            this.Controls.Add(this.maxPriceComboBox);
            this.Controls.Add(this.minPriceLabel);
            this.Controls.Add(this.minPriceComboBox);
            this.Controls.Add(this.maxBedsLabel);
            this.Controls.Add(this.maxBedsComboBox);
            this.Controls.Add(this.minBedsComboBox);
            this.Controls.Add(this.minBedsLabel);
            this.Controls.Add(this.propertyTypeComboBox);
            this.Controls.Add(this.propertyTypeLabel);
            this.Controls.Add(this.propertyListView);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.locationComboBox);
            this.Name = "PropertyFinder";
            this.Text = "Property Finder App";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListView propertyListView;
        private System.Windows.Forms.Label propertyTypeLabel;
        private System.Windows.Forms.ComboBox propertyTypeComboBox;
        private System.Windows.Forms.Label minBedsLabel;
        private System.Windows.Forms.ComboBox minBedsComboBox;
        private System.Windows.Forms.ComboBox maxBedsComboBox;
        private System.Windows.Forms.Label maxBedsLabel;
        private System.Windows.Forms.ComboBox minPriceComboBox;
        private System.Windows.Forms.Label minPriceLabel;
        private System.Windows.Forms.ComboBox maxPriceComboBox;
        private System.Windows.Forms.Label maxPriceLabel;
    }
}


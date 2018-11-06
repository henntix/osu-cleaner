namespace osu_cleaner
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
            this.elementList = new System.Windows.Forms.CheckedListBox();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.directoryPath = new System.Windows.Forms.TextBox();
            this.directorySelectButton = new System.Windows.Forms.Button();
            this.videoDeleteCheckbox = new System.Windows.Forms.CheckBox();
            this.skinDeleteCheckbox = new System.Windows.Forms.CheckBox();
            this.sbDeleteCheckbox = new System.Windows.Forms.CheckBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.findButton = new System.Windows.Forms.Button();
            this.DeletePermanentlyCheckbox = new System.Windows.Forms.CheckBox();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.deselectAllButton = new System.Windows.Forms.Button();
            this.filesSizeLabel = new System.Windows.Forms.Label();
            this.forRemovalSizeLabel = new System.Windows.Forms.Label();
            this.backgroundDeleteCheckbox = new System.Windows.Forms.CheckBox();
            this.moveCheckBox = new System.Windows.Forms.CheckBox();
            this.hitSoundsDeleteCheckbox = new System.Windows.Forms.CheckBox();
            this.FindProgressBar = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // elementList
            // 
            this.elementList.CheckOnClick = true;
            this.elementList.FormattingEnabled = true;
            this.elementList.Location = new System.Drawing.Point(9, 201);
            this.elementList.Name = "elementList";
            this.elementList.Size = new System.Drawing.Size(728, 304);
            this.elementList.TabIndex = 9;
            this.elementList.SelectedIndexChanged += new System.EventHandler(this.elementList_SelectedIndexChanged);
            // 
            // directoryLabel
            // 
            this.directoryLabel.Location = new System.Drawing.Point(12, 25);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(100, 23);
            this.directoryLabel.TabIndex = 8;
            this.directoryLabel.Text = "osu! directory path:";
            // 
            // directoryPath
            // 
            this.directoryPath.Location = new System.Drawing.Point(115, 22);
            this.directoryPath.Name = "directoryPath";
            this.directoryPath.Size = new System.Drawing.Size(460, 20);
            this.directoryPath.TabIndex = 7;
            // 
            // directorySelectButton
            // 
            this.directorySelectButton.Location = new System.Drawing.Point(581, 20);
            this.directorySelectButton.Name = "directorySelectButton";
            this.directorySelectButton.Size = new System.Drawing.Size(75, 23);
            this.directorySelectButton.TabIndex = 6;
            this.directorySelectButton.Text = "Browse";
            this.directorySelectButton.UseVisualStyleBackColor = true;
            this.directorySelectButton.Click += new System.EventHandler(this.directorySelectButton_Click);
            // 
            // videoDeleteCheckbox
            // 
            this.videoDeleteCheckbox.Location = new System.Drawing.Point(12, 51);
            this.videoDeleteCheckbox.Name = "videoDeleteCheckbox";
            this.videoDeleteCheckbox.Size = new System.Drawing.Size(133, 24);
            this.videoDeleteCheckbox.TabIndex = 5;
            this.videoDeleteCheckbox.Text = "Delete video";
            this.videoDeleteCheckbox.UseVisualStyleBackColor = true;
            // 
            // skinDeleteCheckbox
            // 
            this.skinDeleteCheckbox.Location = new System.Drawing.Point(12, 81);
            this.skinDeleteCheckbox.Name = "skinDeleteCheckbox";
            this.skinDeleteCheckbox.Size = new System.Drawing.Size(212, 24);
            this.skinDeleteCheckbox.TabIndex = 4;
            this.skinDeleteCheckbox.Text = "Delete skin elements";
            this.skinDeleteCheckbox.UseVisualStyleBackColor = true;
            // 
            // sbDeleteCheckbox
            // 
            this.sbDeleteCheckbox.Location = new System.Drawing.Point(12, 109);
            this.sbDeleteCheckbox.Name = "sbDeleteCheckbox";
            this.sbDeleteCheckbox.Size = new System.Drawing.Size(157, 24);
            this.sbDeleteCheckbox.TabIndex = 3;
            this.sbDeleteCheckbox.Text = "Delete storyboard elements";
            this.sbDeleteCheckbox.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(665, 588);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(581, 158);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // DeletePermanentlyCheckbox
            // 
            this.DeletePermanentlyCheckbox.Checked = true;
            this.DeletePermanentlyCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DeletePermanentlyCheckbox.Location = new System.Drawing.Point(12, 583);
            this.DeletePermanentlyCheckbox.Name = "DeletePermanentlyCheckbox";
            this.DeletePermanentlyCheckbox.Size = new System.Drawing.Size(281, 24);
            this.DeletePermanentlyCheckbox.TabIndex = 0;
            this.DeletePermanentlyCheckbox.Text = "Delete permanently instead of moving to Recycle Bin";
            this.DeletePermanentlyCheckbox.UseVisualStyleBackColor = true;
            this.DeletePermanentlyCheckbox.CheckedChanged += new System.EventHandler(this.DeletePermanentlyCheckbox_CheckedChanged);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(584, 554);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllButton.TabIndex = 10;
            this.selectAllButton.Text = "Select all";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // deselectAllButton
            // 
            this.deselectAllButton.Location = new System.Drawing.Point(665, 554);
            this.deselectAllButton.Name = "deselectAllButton";
            this.deselectAllButton.Size = new System.Drawing.Size(75, 23);
            this.deselectAllButton.TabIndex = 11;
            this.deselectAllButton.Text = "Unselect all";
            this.deselectAllButton.UseVisualStyleBackColor = true;
            this.deselectAllButton.Click += new System.EventHandler(this.deselectAllButton_Click);
            // 
            // filesSizeLabel
            // 
            this.filesSizeLabel.AutoSize = true;
            this.filesSizeLabel.Location = new System.Drawing.Point(9, 554);
            this.filesSizeLabel.Name = "filesSizeLabel";
            this.filesSizeLabel.Size = new System.Drawing.Size(68, 13);
            this.filesSizeLabel.TabIndex = 12;
            this.filesSizeLabel.Text = "Found: 0 MB";
            // 
            // forRemovalSizeLabel
            // 
            this.forRemovalSizeLabel.AutoSize = true;
            this.forRemovalSizeLabel.Location = new System.Drawing.Point(9, 567);
            this.forRemovalSizeLabel.Name = "forRemovalSizeLabel";
            this.forRemovalSizeLabel.Size = new System.Drawing.Size(132, 13);
            this.forRemovalSizeLabel.TabIndex = 13;
            this.forRemovalSizeLabel.Text = "Selected for removal: 0MB";
            // 
            // backgroundDeleteCheckbox
            // 
            this.backgroundDeleteCheckbox.AutoSize = true;
            this.backgroundDeleteCheckbox.Location = new System.Drawing.Point(12, 140);
            this.backgroundDeleteCheckbox.Name = "backgroundDeleteCheckbox";
            this.backgroundDeleteCheckbox.Size = new System.Drawing.Size(122, 17);
            this.backgroundDeleteCheckbox.TabIndex = 14;
            this.backgroundDeleteCheckbox.Text = "Delete backgrounds";
            this.backgroundDeleteCheckbox.UseVisualStyleBackColor = true;
            // 
            // moveCheckBox
            // 
            this.moveCheckBox.AutoSize = true;
            this.moveCheckBox.Location = new System.Drawing.Point(12, 611);
            this.moveCheckBox.Name = "moveCheckBox";
            this.moveCheckBox.Size = new System.Drawing.Size(206, 17);
            this.moveCheckBox.TabIndex = 15;
            this.moveCheckBox.Text = "Move to \'Cleaned\' instead of removing";
            this.moveCheckBox.UseVisualStyleBackColor = true;
            this.moveCheckBox.CheckedChanged += new System.EventHandler(this.moveCheckBox_CheckedChanged);
            // 
            // hitSoundsDeleteCheckbox
            // 
            this.hitSoundsDeleteCheckbox.AutoSize = true;
            this.hitSoundsDeleteCheckbox.Location = new System.Drawing.Point(12, 164);
            this.hitSoundsDeleteCheckbox.Name = "hitSoundsDeleteCheckbox";
            this.hitSoundsDeleteCheckbox.Size = new System.Drawing.Size(105, 17);
            this.hitSoundsDeleteCheckbox.TabIndex = 16;
            this.hitSoundsDeleteCheckbox.Text = "Delete hitsounds";
            this.hitSoundsDeleteCheckbox.UseVisualStyleBackColor = true;
            // 
            // FindProgressBar
            // 
            this.FindProgressBar.Location = new System.Drawing.Point(9, 511);
            this.FindProgressBar.Name = "FindProgressBar";
            this.FindProgressBar.Size = new System.Drawing.Size(728, 23);
            this.FindProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.FindProgressBar.TabIndex = 17;
            this.FindProgressBar.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(663, 158);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 635);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.FindProgressBar);
            this.Controls.Add(this.hitSoundsDeleteCheckbox);
            this.Controls.Add(this.moveCheckBox);
            this.Controls.Add(this.backgroundDeleteCheckbox);
            this.Controls.Add(this.forRemovalSizeLabel);
            this.Controls.Add(this.filesSizeLabel);
            this.Controls.Add(this.deselectAllButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.DeletePermanentlyCheckbox);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.sbDeleteCheckbox);
            this.Controls.Add(this.skinDeleteCheckbox);
            this.Controls.Add(this.videoDeleteCheckbox);
            this.Controls.Add(this.directorySelectButton);
            this.Controls.Add(this.directoryPath);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.elementList);
            this.Name = "MainApp";
            this.Text = "osu!Cleaner v1.05";
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.TextBox directoryPath;
        private System.Windows.Forms.Button directorySelectButton;
        private System.Windows.Forms.CheckBox videoDeleteCheckbox;
        private System.Windows.Forms.CheckBox skinDeleteCheckbox;
        private System.Windows.Forms.CheckBox sbDeleteCheckbox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.CheckBox DeletePermanentlyCheckbox;
        private System.Windows.Forms.CheckedListBox elementList;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button deselectAllButton;
        private System.Windows.Forms.Label filesSizeLabel;
        private System.Windows.Forms.Label forRemovalSizeLabel;
        private System.Windows.Forms.CheckBox backgroundDeleteCheckbox;
        private System.Windows.Forms.CheckBox moveCheckBox;
        private System.Windows.Forms.CheckBox hitSoundsDeleteCheckbox;
        private System.Windows.Forms.ProgressBar FindProgressBar;
        private System.Windows.Forms.Button cancelButton;
    }
}


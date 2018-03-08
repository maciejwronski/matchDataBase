namespace WindowsFormsApplication2
{
    partial class defaultMenu
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
            this.defaultMenuLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addTeamButton = new System.Windows.Forms.Button();
            this.addMatchButton = new System.Windows.Forms.Button();
            this.editTeamButton = new System.Windows.Forms.Button();
            this.deleteTeamButton = new System.Windows.Forms.Button();
            this.editMatchButton = new System.Windows.Forms.Button();
            this.removeMatchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // defaultMenuLabel
            // 
            this.defaultMenuLabel.AutoSize = true;
            this.defaultMenuLabel.Font = new System.Drawing.Font("Segoe Print", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.defaultMenuLabel.Location = new System.Drawing.Point(109, 24);
            this.defaultMenuLabel.Name = "defaultMenuLabel";
            this.defaultMenuLabel.Size = new System.Drawing.Size(531, 62);
            this.defaultMenuLabel.TabIndex = 0;
            this.defaultMenuLabel.Text = "Welcome to Match DataBase";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(201, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose an option:";
            // 
            // addTeamButton
            // 
            this.addTeamButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addTeamButton.Location = new System.Drawing.Point(120, 183);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(131, 106);
            this.addTeamButton.TabIndex = 2;
            this.addTeamButton.Text = "Add Team";
            this.addTeamButton.UseVisualStyleBackColor = true;
            // 
            // addMatchButton
            // 
            this.addMatchButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addMatchButton.Location = new System.Drawing.Point(120, 349);
            this.addMatchButton.Name = "addMatchButton";
            this.addMatchButton.Size = new System.Drawing.Size(131, 106);
            this.addMatchButton.TabIndex = 5;
            this.addMatchButton.Text = "Add Match";
            this.addMatchButton.UseVisualStyleBackColor = true;
            // 
            // editTeamButton
            // 
            this.editTeamButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editTeamButton.Location = new System.Drawing.Point(360, 183);
            this.editTeamButton.Name = "editTeamButton";
            this.editTeamButton.Size = new System.Drawing.Size(131, 106);
            this.editTeamButton.TabIndex = 6;
            this.editTeamButton.Text = "Edit Team";
            this.editTeamButton.UseVisualStyleBackColor = true;
            // 
            // deleteTeamButton
            // 
            this.deleteTeamButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteTeamButton.Location = new System.Drawing.Point(578, 183);
            this.deleteTeamButton.Name = "deleteTeamButton";
            this.deleteTeamButton.Size = new System.Drawing.Size(131, 106);
            this.deleteTeamButton.TabIndex = 7;
            this.deleteTeamButton.Text = "Delete Team";
            this.deleteTeamButton.UseVisualStyleBackColor = true;
            // 
            // editMatchButton
            // 
            this.editMatchButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editMatchButton.Location = new System.Drawing.Point(360, 349);
            this.editMatchButton.Name = "editMatchButton";
            this.editMatchButton.Size = new System.Drawing.Size(131, 106);
            this.editMatchButton.TabIndex = 8;
            this.editMatchButton.Text = "Edit Match";
            this.editMatchButton.UseVisualStyleBackColor = true;
            // 
            // removeMatchButton
            // 
            this.removeMatchButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeMatchButton.Location = new System.Drawing.Point(578, 349);
            this.removeMatchButton.Name = "removeMatchButton";
            this.removeMatchButton.Size = new System.Drawing.Size(131, 106);
            this.removeMatchButton.TabIndex = 9;
            this.removeMatchButton.Text = "Remove Match";
            this.removeMatchButton.UseVisualStyleBackColor = true;
            // 
            // defaultMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.removeMatchButton);
            this.Controls.Add(this.editMatchButton);
            this.Controls.Add(this.deleteTeamButton);
            this.Controls.Add(this.editTeamButton);
            this.Controls.Add(this.addMatchButton);
            this.Controls.Add(this.addTeamButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.defaultMenuLabel);
            this.Name = "defaultMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match DataBase - Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label defaultMenuLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.Button addMatchButton;
        private System.Windows.Forms.Button editTeamButton;
        private System.Windows.Forms.Button deleteTeamButton;
        private System.Windows.Forms.Button editMatchButton;
        private System.Windows.Forms.Button removeMatchButton;
    }
}
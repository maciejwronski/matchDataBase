namespace WindowsFormsApplication2
{
    partial class searchForAMatch
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
            this.editMatchLabel = new System.Windows.Forms.Label();
            this.returnButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.matchDateBox = new System.Windows.Forms.MaskedTextBox();
            this.competitionID = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.searchForMatchByCompetition = new System.Windows.Forms.RadioButton();
            this.SearchForMatchByDate = new System.Windows.Forms.RadioButton();
            this.searchForMatchByTeams = new System.Windows.Forms.RadioButton();
            this.SearchForTeamsMostGoals = new System.Windows.Forms.RadioButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.searchForBestScorers = new System.Windows.Forms.RadioButton();
            this.SearchForTeamsWithMostWins = new System.Windows.Forms.RadioButton();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SearchForTeamsWithMostDraws = new System.Windows.Forms.RadioButton();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.SearchForTeamsWithMostLoses = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // editMatchLabel
            // 
            this.editMatchLabel.AutoSize = true;
            this.editMatchLabel.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editMatchLabel.Location = new System.Drawing.Point(38, 33);
            this.editMatchLabel.Name = "editMatchLabel";
            this.editMatchLabel.Size = new System.Drawing.Size(140, 37);
            this.editMatchLabel.TabIndex = 18;
            this.editMatchLabel.Text = "Search Tool";
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(12, 607);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(75, 23);
            this.returnButton.TabIndex = 14;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(623, 607);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Search!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "vs";
            // 
            // matchDateBox
            // 
            this.matchDateBox.Location = new System.Drawing.Point(386, 125);
            this.matchDateBox.Mask = "0000-00-00";
            this.matchDateBox.Name = "matchDateBox";
            this.matchDateBox.Size = new System.Drawing.Size(138, 20);
            this.matchDateBox.TabIndex = 25;
            // 
            // competitionID
            // 
            this.competitionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.competitionID.FormattingEnabled = true;
            this.competitionID.Items.AddRange(new object[] {
            "League",
            "League Cup",
            "Champions League",
            "Friendly"});
            this.competitionID.Location = new System.Drawing.Point(386, 149);
            this.competitionID.Name = "competitionID";
            this.competitionID.Size = new System.Drawing.Size(138, 21);
            this.competitionID.TabIndex = 24;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(554, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 20);
            this.textBox2.TabIndex = 23;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(386, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 22;
            // 
            // searchForMatchByCompetition
            // 
            this.searchForMatchByCompetition.AutoSize = true;
            this.searchForMatchByCompetition.Location = new System.Drawing.Point(45, 153);
            this.searchForMatchByCompetition.Name = "searchForMatchByCompetition";
            this.searchForMatchByCompetition.Size = new System.Drawing.Size(178, 17);
            this.searchForMatchByCompetition.TabIndex = 21;
            this.searchForMatchByCompetition.TabStop = true;
            this.searchForMatchByCompetition.Text = "Search for match by Competition";
            this.searchForMatchByCompetition.UseVisualStyleBackColor = true;
            // 
            // SearchForMatchByDate
            // 
            this.SearchForMatchByDate.AutoSize = true;
            this.SearchForMatchByDate.Location = new System.Drawing.Point(45, 126);
            this.SearchForMatchByDate.Name = "SearchForMatchByDate";
            this.SearchForMatchByDate.Size = new System.Drawing.Size(146, 17);
            this.SearchForMatchByDate.TabIndex = 20;
            this.SearchForMatchByDate.TabStop = true;
            this.SearchForMatchByDate.Text = "Search for match by Date";
            this.SearchForMatchByDate.UseVisualStyleBackColor = true;
            // 
            // searchForMatchByTeams
            // 
            this.searchForMatchByTeams.AutoSize = true;
            this.searchForMatchByTeams.Location = new System.Drawing.Point(45, 97);
            this.searchForMatchByTeams.Name = "searchForMatchByTeams";
            this.searchForMatchByTeams.Size = new System.Drawing.Size(316, 17);
            this.searchForMatchByTeams.TabIndex = 19;
            this.searchForMatchByTeams.TabStop = true;
            this.searchForMatchByTeams.Text = "Search for match by Teams which played against themselves ";
            this.searchForMatchByTeams.UseVisualStyleBackColor = true;
            // 
            // SearchForTeamsMostGoals
            // 
            this.SearchForTeamsMostGoals.AutoSize = true;
            this.SearchForTeamsMostGoals.Location = new System.Drawing.Point(45, 176);
            this.SearchForTeamsMostGoals.Name = "SearchForTeamsMostGoals";
            this.SearchForTeamsMostGoals.Size = new System.Drawing.Size(295, 17);
            this.SearchForTeamsMostGoals.TabIndex = 28;
            this.SearchForTeamsMostGoals.TabStop = true;
            this.SearchForTeamsMostGoals.Text = "Search for Teams with most Goals ( Optional Competition)";
            this.SearchForTeamsMostGoals.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "None",
            "League",
            "League Cup",
            "Champions League",
            "Friendly"});
            this.comboBox2.Location = new System.Drawing.Point(386, 175);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(138, 21);
            this.comboBox2.TabIndex = 31;
            // 
            // comboBox3
            // 
            this.comboBox3.AccessibleName = "";
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "None",
            "League",
            "League Cup",
            "Champions League",
            "Friendly"});
            this.comboBox3.Location = new System.Drawing.Point(386, 202);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(138, 21);
            this.comboBox3.TabIndex = 33;
            // 
            // searchForBestScorers
            // 
            this.searchForBestScorers.AutoSize = true;
            this.searchForBestScorers.Location = new System.Drawing.Point(45, 203);
            this.searchForBestScorers.Name = "searchForBestScorers";
            this.searchForBestScorers.Size = new System.Drawing.Size(273, 17);
            this.searchForBestScorers.TabIndex = 32;
            this.searchForBestScorers.TabStop = true;
            this.searchForBestScorers.Text = "Search for Best Scorers(optional Competition/Team )";
            this.searchForBestScorers.UseVisualStyleBackColor = true;
            // 
            // SearchForTeamsWithMostWins
            // 
            this.SearchForTeamsWithMostWins.AutoSize = true;
            this.SearchForTeamsWithMostWins.Location = new System.Drawing.Point(45, 230);
            this.SearchForTeamsWithMostWins.Name = "SearchForTeamsWithMostWins";
            this.SearchForTeamsWithMostWins.Size = new System.Drawing.Size(258, 17);
            this.SearchForTeamsWithMostWins.TabIndex = 36;
            this.SearchForTeamsWithMostWins.TabStop = true;
            this.SearchForTeamsWithMostWins.Text = "Search for Teams with Most Wins at Home/Away";
            this.SearchForTeamsWithMostWins.UseVisualStyleBackColor = true;
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            "None",
            "Home",
            "Away"});
            this.comboBox6.Location = new System.Drawing.Point(386, 230);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(138, 21);
            this.comboBox6.TabIndex = 38;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "None"});
            this.comboBox4.Location = new System.Drawing.Point(554, 199);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(138, 21);
            this.comboBox4.TabIndex = 39;
            this.comboBox4.Click += new System.EventHandler(this.comboBox4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 357);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(695, 231);
            this.dataGridView1.TabIndex = 40;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Home",
            "Away"});
            this.comboBox1.Location = new System.Drawing.Point(386, 257);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 42;
            // 
            // SearchForTeamsWithMostDraws
            // 
            this.SearchForTeamsWithMostDraws.AutoSize = true;
            this.SearchForTeamsWithMostDraws.Location = new System.Drawing.Point(45, 257);
            this.SearchForTeamsWithMostDraws.Name = "SearchForTeamsWithMostDraws";
            this.SearchForTeamsWithMostDraws.Size = new System.Drawing.Size(264, 17);
            this.SearchForTeamsWithMostDraws.TabIndex = 41;
            this.SearchForTeamsWithMostDraws.TabStop = true;
            this.SearchForTeamsWithMostDraws.Text = "Search for Teams with Most Draws at Home/Away";
            this.SearchForTeamsWithMostDraws.UseVisualStyleBackColor = true;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "None",
            "Home",
            "Away"});
            this.comboBox5.Location = new System.Drawing.Point(386, 284);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(138, 21);
            this.comboBox5.TabIndex = 44;
            // 
            // SearchForTeamsWithMostLoses
            // 
            this.SearchForTeamsWithMostLoses.AutoSize = true;
            this.SearchForTeamsWithMostLoses.Location = new System.Drawing.Point(45, 284);
            this.SearchForTeamsWithMostLoses.Name = "SearchForTeamsWithMostLoses";
            this.SearchForTeamsWithMostLoses.Size = new System.Drawing.Size(262, 17);
            this.SearchForTeamsWithMostLoses.TabIndex = 43;
            this.SearchForTeamsWithMostLoses.TabStop = true;
            this.SearchForTeamsWithMostLoses.Text = "Search for Teams with Most Loses at Home/Away";
            this.SearchForTeamsWithMostLoses.UseVisualStyleBackColor = true;
            // 
            // searchForAMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.SearchForTeamsWithMostLoses);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SearchForTeamsWithMostDraws);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.SearchForTeamsWithMostWins);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.searchForBestScorers);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.SearchForTeamsMostGoals);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matchDateBox);
            this.Controls.Add(this.competitionID);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.searchForMatchByCompetition);
            this.Controls.Add(this.SearchForMatchByDate);
            this.Controls.Add(this.searchForMatchByTeams);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.editMatchLabel);
            this.Name = "searchForAMatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MatchDatabase - Search Tool";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label editMatchLabel;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox matchDateBox;
        private System.Windows.Forms.ComboBox competitionID;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton searchForMatchByCompetition;
        private System.Windows.Forms.RadioButton SearchForMatchByDate;
        private System.Windows.Forms.RadioButton searchForMatchByTeams;
        private System.Windows.Forms.RadioButton SearchForTeamsMostGoals;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.RadioButton searchForBestScorers;
        private System.Windows.Forms.RadioButton SearchForTeamsWithMostWins;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton SearchForTeamsWithMostDraws;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.RadioButton SearchForTeamsWithMostLoses;
    }
}
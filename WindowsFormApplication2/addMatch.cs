using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class addMatch : Form
    {
        DBConnect connectionWithDatabase;
        public addMatch()
        {
            InitializeComponent();
            connectionWithDatabase = new DBConnect();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void homeTeamComboBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                connectionWithDatabase.loadTeams(homeTeamComboBox);
            }
            catch
            {
                MessageBox.Show("Error 404 in adding Team. Check DataBaseConnection");
            }
            finally
            {
                connectionWithDatabase.CloseConnection();
            }
        }

        private void awayTeamComboBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                connectionWithDatabase.loadTeams(awayTeamComboBox);
            }
            catch
            {
                MessageBox.Show("Error 404 in adding Team. Check DataBaseConnection");
            }
            finally
            {
                connectionWithDatabase.CloseConnection();
            }
        }

        private void homeTeamComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox[] idBoxes = { PlayerID1Home, PlayerID2Home, PlayerID3Home, PlayerID4Home, PlayerID5Home, PlayerID6Home, PlayerID7Home, PlayerID8Home, PlayerID9Home, PlayerID10Home, PlayerID11Home };
            TextBox[] noBoxes = { PlayerNo1Home, PlayerNo2Home, PlayerNo3Home, PlayerNo4Home, PlayerNo5Home, PlayerNo6Home, PlayerNo7Home, PlayerNo8Home, PlayerNo9Home, PlayerNo10Home, PlayerNo11Home };
            ComboBox[] positionBoxes = { PlayerPosition1Home, PlayerPosition2Home, PlayerPosition3Home, PlayerPosition4Home, PlayerPosition5Home, PlayerPosition6Home, PlayerPosition7Home, PlayerPosition8Home, PlayerPosition9Home, PlayerPosition10Home, PlayerPosition11Home };
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                connectionWithDatabase.loadPlayersToBoxes(homeTeamComboBox, idBoxes, noBoxes, positionBoxes);
            }
            catch
            {
                MessageBox.Show("Error 404 in adding Team. Check DataBaseConnection");
            }
            finally
            {
                connectionWithDatabase.CloseConnection();
            }
        }

        private void awayTeamComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox[] idBoxes = { PlayerID1Away, PlayerID2Away, PlayerID3Away, PlayerID4Away, PlayerID5Away, PlayerID6Away, PlayerID7Away, PlayerID8Away, PlayerID9Away, PlayerID10Away, PlayerID11Away };
            TextBox[] noBoxes = { PlayerNo1Away, PlayerNo2Away, PlayerNo3Away, PlayerNo4Away, PlayerNo5Away, PlayerNo6Away, PlayerNo7Away, PlayerNo8Away, PlayerNo9Away, PlayerNo10Away, PlayerNo11Away };
            ComboBox[] positionBoxes = { PlayerPosition1Away, PlayerPosition2Away, PlayerPosition3Away, PlayerPosition4Away, PlayerPosition5Away, PlayerPosition6Away, PlayerPosition7Away, PlayerPosition8Away, PlayerPosition9Away, PlayerPosition10Away, PlayerPosition11Away };
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                connectionWithDatabase.loadPlayersToBoxes(awayTeamComboBox, idBoxes, noBoxes, positionBoxes);
            }
            catch
            {
                MessageBox.Show("Error 404 in adding Team. Check DataBaseConnection");
            }
            finally
            {
                connectionWithDatabase.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaskedTextBox[] goalBoxesHome = { Goals1Home, Goals2Home, Goals3Home, Goals4Home, Goals5Home, Goals6Home, Goals7Home, Goals8Home, Goals9Home, Goals10Home, Goals11Home };
            MaskedTextBox[] goalBoxesAway = { Goals1Away, Goals2Away, Goals3Away, Goals4Away, Goals5Away, Goals6Away, Goals7Away, Goals8Away, Goals9Away, Goals10Away, Goals11Away };
            totalHome.Text = sumOfGoals(goalBoxesHome).ToString();
     
            totalAway.Text = sumOfGoals(goalBoxesAway).ToString();
            if (MessageBox.Show("Add this match?", "Match Database", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (!connectionWithDatabase.isConnected())
                    {
                        connectionWithDatabase.OpenConnection();
                    }
                    long matchID = connectionWithDatabase.AddMatch(matchDateBox, matchTimeBox, competitionID, homeTeamComboBox, awayTeamComboBox, Winner(totalHome, totalAway));
                    for(int i=0; i<11; i++)
                    {
                            connectionWithDatabase.addGoalsToPlayer(homeTeamComboBox, i, int.Parse(goalBoxesHome[i].Text), matchID);
                            connectionWithDatabase.addGoalsToPlayer(awayTeamComboBox, i, int.Parse(goalBoxesAway[i].Text), matchID);
                    }
                }
                catch
                {
                    MessageBox.Show("Error 404 in adding Team. Check DataBaseConnection");
                }
                finally
                {
                    connectionWithDatabase.CloseConnection();
                }
            }
        }
        private int sumOfGoals(MaskedTextBox[] boxGoals)
        {
            int sum = 0;
            for (int i = 0; i < 11; i++)
            {
                if (boxGoals[i].Text == "")
                    boxGoals[i].Text = "0";
                sum += int.Parse(boxGoals[i].Text);
            }
            return sum;
        }
        private int Winner(TextBox t1, TextBox t2)
        {
            if (int.Parse(t1.Text) > int.Parse(t2.Text))
                return 1;
            else if (int.Parse(t2.Text) > int.Parse(t1.Text))
                return 2;
            else if (int.Parse(t2.Text) == int.Parse(t1.Text))
                return 0;
            else return -1;
        }
    }
}

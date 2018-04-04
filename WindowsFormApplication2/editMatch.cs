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
    public partial class editMatch : Form
    {
        DBConnect connectionWithDatabase;
        public editMatch()
        {
            InitializeComponent();
            connectionWithDatabase = new DBConnect();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void buttonLoadTeams_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                connectionWithDatabase.loadMatches(editMatchListBox);
            }
            catch (Exception es)
            {
                MessageBox.Show("Error 404 in adding Team. Check DataBaseConnection \r\n" + es.Message + "\r\n" + es.InnerException.Message);
            }
            finally
            {
                connectionWithDatabase.CloseConnection();
            }
        }

        private void editMatchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox[] idBoxesAway = { PlayerID1Away, PlayerID2Away, PlayerID3Away, PlayerID4Away, PlayerID5Away, PlayerID6Away, PlayerID7Away, PlayerID8Away, PlayerID9Away, PlayerID10Away, PlayerID11Away };
            TextBox[] noBoxesAway = { PlayerNo1Away, PlayerNo2Away, PlayerNo3Away, PlayerNo4Away, PlayerNo5Away, PlayerNo6Away, PlayerNo7Away, PlayerNo8Away, PlayerNo9Away, PlayerNo10Away, PlayerNo11Away };
            ComboBox[] positionBoxesAway = { PlayerPosition1Away, PlayerPosition2Away, PlayerPosition3Away, PlayerPosition4Away, PlayerPosition5Away, PlayerPosition6Away, PlayerPosition7Away, PlayerPosition8Away, PlayerPosition9Away, PlayerPosition10Away, PlayerPosition11Away };
            MaskedTextBox[] goalBoxesAway = { Goals1Away, Goals2Away, Goals3Away, Goals4Away, Goals5Away, Goals6Away, Goals7Away, Goals8Away, Goals9Away, Goals10Away, Goals11Away };
            TextBox[] idBoxesHome = { PlayerID1Home, PlayerID2Home, PlayerID3Home, PlayerID4Home, PlayerID5Home, PlayerID6Home, PlayerID7Home, PlayerID8Home, PlayerID9Home, PlayerID10Home, PlayerID11Home };
            TextBox[] noBoxesHome = { PlayerNo1Home, PlayerNo2Home, PlayerNo3Home, PlayerNo4Home, PlayerNo5Home, PlayerNo6Home, PlayerNo7Home, PlayerNo8Home, PlayerNo9Home, PlayerNo10Home, PlayerNo11Home };
            ComboBox[] positionBoxesHome = { PlayerPosition1Home, PlayerPosition2Home, PlayerPosition3Home, PlayerPosition4Home, PlayerPosition5Home, PlayerPosition6Home, PlayerPosition7Home, PlayerPosition8Home, PlayerPosition9Home, PlayerPosition10Home, PlayerPosition11Home };
            MaskedTextBox[] goalBoxesHome = { Goals1Home, Goals2Home, Goals3Home, Goals4Home, Goals5Home, Goals6Home, Goals7Home, Goals8Home, Goals9Home, Goals10Home, Goals11Home };
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                    object[] tab = new object[2];
                    tab = connectionWithDatabase.returnIdOfTeams(editMatchListBox);
                    connectionWithDatabase.loadMatch(matchDateBox, matchTimeBox, competitionID, editMatchListBox);
                    connectionWithDatabase.loadPlayersToBoxes(tab[0], idBoxesHome, noBoxesHome, positionBoxesHome, goalBoxesHome, editMatchListBox);
                    connectionWithDatabase.loadPlayersToBoxes(tab[1], idBoxesAway, noBoxesAway, positionBoxesAway, goalBoxesAway, editMatchListBox);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Error 404 in adding Team. Check DataBaseConnection \r\n" + es.Message + "\r\n" + es.InnerException.Message);
            }
            finally
            {

                connectionWithDatabase.CloseConnection();
            }


        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!matchDateBox.MaskCompleted || !matchTimeBox.MaskCompleted || competitionID.SelectedItem == null)
                {
                    MessageBox.Show("Please don't leave empty boxes");
                    return;
                }
                if (MessageBox.Show("Are you sure, that you want to edit this match?", "Match Database", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!connectionWithDatabase.isConnected())
                    {
                        connectionWithDatabase.OpenConnection();
                    }
                    {
                        object[] tab = new object[2];
                        MaskedTextBox[] GoalsAway = { Goals1Away, Goals2Away, Goals3Away, Goals4Away, Goals5Away, Goals6Away, Goals7Away, Goals8Away, Goals9Away, Goals10Away, Goals11Away };
                        MaskedTextBox[] GoalsHome = { Goals1Home, Goals2Home, Goals3Home, Goals4Home, Goals5Home, Goals6Home, Goals7Home, Goals8Home, Goals9Home, Goals10Home, Goals11Home };
                        tab = connectionWithDatabase.returnIdOfTeams(editMatchListBox);
                        connectionWithDatabase.updateGoalsInMatch(editMatchListBox, GoalsAway, int.Parse(tab[1].ToString()));
                        connectionWithDatabase.updateGoalsInMatch(editMatchListBox, GoalsHome, int.Parse(tab[0].ToString()));
                        totalHome.Text = sumOfGoals(GoalsHome).ToString();
                        totalAway.Text = sumOfGoals(GoalsAway).ToString();
                        connectionWithDatabase.updateMatch(editMatchListBox, matchDateBox, matchTimeBox, competitionID, Winner(totalHome, totalAway));
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Error 404 in adding Team. Check DataBaseConnection \r\n" + es.Message + "\r\n" + es.InnerException.Message);
            }
            finally
            {
                connectionWithDatabase.CloseConnection();
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

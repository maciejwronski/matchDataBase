﻿using System;
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
    public partial class removeMatch : Form
    {
        DBConnect connectionWithDatabase;
        public removeMatch()
        {
            InitializeComponent();
            connectionWithDatabase = new DBConnect();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void removeMatchListBox_SelectedIndexChanged(object sender, EventArgs e)
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
                }
                    object[] tab = new object[2];
                    tab = connectionWithDatabase.returnIdOfTeams(removeMatchListBox);
                    connectionWithDatabase.loadMatch(matchDateBox, matchTimeBox, competitionID, removeMatchListBox);
                    connectionWithDatabase.loadPlayersToBoxes(tab[0], idBoxesHome, noBoxesHome, positionBoxesHome, goalBoxesHome, removeMatchListBox);
                    connectionWithDatabase.loadPlayersToBoxes(tab[1], idBoxesAway, noBoxesAway, positionBoxesAway, goalBoxesAway, removeMatchListBox);
                    totalHome.Text = sumOfGoals(goalBoxesHome).ToString();
                    totalAway.Text = sumOfGoals(goalBoxesAway).ToString();
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

        private void returnButton_Click_1(object sender, EventArgs e)
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
                connectionWithDatabase.loadMatches(removeMatchListBox);
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

        private void deleteMatchButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure, that you want to delete this match?", "Match Database", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!connectionWithDatabase.isConnected())
                    {
                        connectionWithDatabase.OpenConnection();
                    }
                    connectionWithDatabase.removeMatch(removeMatchListBox);
                    MessageBox.Show("Succesfully removed this match.");
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
    }
}

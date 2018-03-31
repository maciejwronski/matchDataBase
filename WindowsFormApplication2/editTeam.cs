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
    public partial class editTeam : Form
    {
        DBConnect connectionWithDatabase;
        public editTeam()
        {
            InitializeComponent();
            connectionWithDatabase = new DBConnect();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            connectionWithDatabase.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                connectionWithDatabase.loadTeams(editTeamListBox);
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
        private void editTeamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox[] idBoxes = { PlayerID1, PlayerID2, PlayerID3, PlayerID4, PlayerID5, PlayerID6, PlayerID7, PlayerID8, PlayerID9, PlayerID10, PlayerID11 };
            TextBox[] noBoxes = { PlayerNo1, PlayerNo2, PlayerNo3, PlayerNo4, PlayerNo5, PlayerNo6, PlayerNo7, PlayerNo8, PlayerNo9, PlayerNo10, PlayerNo11 };
            ComboBox[] positionBoxes = { PlayerPosition1, PlayerPosition2, PlayerPosition3, PlayerPosition4, PlayerPosition5, PlayerPosition6, PlayerPosition7, PlayerPosition8, PlayerPosition9, PlayerPosition10, PlayerPosition11 };
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                connectionWithDatabase.loadPlayersToBoxes(editTeamListBox, idBoxes, noBoxes, positionBoxes);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(editTeamListBox.SelectedIndex != -1)
            {
                TextBox[] idBoxes = { PlayerID1, PlayerID2, PlayerID3, PlayerID4, PlayerID5, PlayerID6, PlayerID7, PlayerID8, PlayerID9, PlayerID10, PlayerID11 };
                TextBox[] noBoxes = { PlayerNo1, PlayerNo2, PlayerNo3, PlayerNo4, PlayerNo5, PlayerNo6, PlayerNo7, PlayerNo8, PlayerNo9, PlayerNo10, PlayerNo11 };
                ComboBox[] positionBoxes = { PlayerPosition1, PlayerPosition2, PlayerPosition3, PlayerPosition4, PlayerPosition5, PlayerPosition6, PlayerPosition7, PlayerPosition8, PlayerPosition9, PlayerPosition10, PlayerPosition11 };

                try
                {
                    if (MessageBox.Show("Are you sure that you want to edit this team?", "Match Database", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                    if (!connectionWithDatabase.isConnected())
                    {
                        connectionWithDatabase.OpenConnection();
                    }
                    for (int i = 0; i < 11; i++)
                    {
                        if (idBoxes[i].Text == "" || noBoxes[i].Text == "" || positionBoxes[i].SelectedItem == null)
                        {
                            MessageBox.Show("Error. Boxes cant be empty");
                            return;
                        }
                    }
                    connectionWithDatabase.updatePlayers(editTeamListBox, idBoxes, noBoxes, positionBoxes);
                    MessageBox.Show("Team " + editTeamListBox.SelectedIndex.ToString() + " has been updated");
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
                for (int i = 0; i < 11; i++)
                {
                    idBoxes[i].Text = "";
                    noBoxes[i].Text = "";
                    positionBoxes[i].SelectedIndex = -1;
                }
            }
        }
    }
}

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
    }
}

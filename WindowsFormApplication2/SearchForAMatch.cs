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
    public partial class searchForAMatch : Form
    {
        DBConnect connectionWithDatabase;
        
        public searchForAMatch()
        {
            InitializeComponent();
            connectionWithDatabase = new DBConnect();
            competitionID.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                if (searchForMatchByTeams.Checked)
                {
                    connectionWithDatabase.searchForMatchByTeamNames(dataGridView1, textBox1,textBox2);
                }
                else if (SearchForMatchByDate.Checked)
                {
                    connectionWithDatabase.searchForMatchByDate(dataGridView1, matchDateBox);
                }
                else if (searchForMatchByCompetition.Checked)
                {
                    connectionWithDatabase.searchForMatchByCompetition(dataGridView1, competitionID);
                }
                else if (searchForBestScorers.Checked)
                {
                    connectionWithDatabase.searchForBestScorers(dataGridView1, comboBox3, comboBox4);
                }
                else if (SearchForTeamsMostGoals.Checked)
                {
                    connectionWithDatabase.searchForTeamsMostGoals(dataGridView1, comboBox2);
                }
                else if (SearchForTeamsWithMostWins.Checked)
                {
                    connectionWithDatabase.searchForTeamsMostWins(dataGridView1, comboBox6);
                }
                else if (SearchForTeamsWithMostDraws.Checked)
                {
                    connectionWithDatabase.searchForTeamsMostDraws(dataGridView1, comboBox1);
                }
                else if (SearchForTeamsWithMostLoses.Checked)
                {
                    connectionWithDatabase.searchForTeamsMostLoses(dataGridView1, comboBox5);
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

        private void comboBox4_Click(object sender, EventArgs e)
        {
            connectionWithDatabase.loadTeamsWithoutSeason(comboBox4);
        }
    }
}

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
                    connectionWithDatabase.searchFor(dataGridView1, 1);
                }
                else if (SearchForMatchByDate.Checked)
                {
                    connectionWithDatabase.searchFor(dataGridView1, 2);
                }
                else if (searchForMatchByCompetition.Checked)
                {
                    connectionWithDatabase.searchFor(dataGridView1, 3);
                }
                else if (searchForBestScorers.Checked)
                {
                    connectionWithDatabase.searchFor(dataGridView1, 4);
                }
                else if (SearchForTeamsMostGoals.Checked)
                {
                    connectionWithDatabase.searchFor(dataGridView1, 5);
                }
                else if (SearchForTeamsWithMost.Checked)
                {
                        string Query = "";
                        if(comboBox6.Text == "None")
                        {
                            Query = @"select count(t.name) as 'Wins', t.name as 'Team Name' from matches
                                             left join teams as t ON Winner_TeamID = t.TeamID group by t.teamID order by 'Wins';";
                        }
                        else
                        {
                            Query = @"select count(t.name) as 'Wins', t.name as 'Team Name' from matches
                                    left join teams as t ON t.TeamID = "+ comboBox6.Text+"_TeamID WHERE "+comboBox6.Text+"_TeamID = Winner_TeamID  group by t.teamID order by 'Wins';";
                        }
                        connectionWithDatabase.searchFor(dataGridView1, Query);
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

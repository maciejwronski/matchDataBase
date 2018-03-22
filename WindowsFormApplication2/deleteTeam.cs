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
    public partial class deleteTeam : Form
    {
        DBConnect connectionWithDatabase;
        public deleteTeam()
        {
            InitializeComponent();
            connectionWithDatabase = new DBConnect();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                connectionWithDatabase.loadTeams(listBox1);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                connectionWithDatabase.loadPlayersToBoxes(listBox1, idBoxes, noBoxes, positionBoxes);
                Console.WriteLine(listBox1.SelectedValue);
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
            TextBox[] idBoxes = { PlayerID1, PlayerID2, PlayerID3, PlayerID4, PlayerID5, PlayerID6, PlayerID7, PlayerID8, PlayerID9, PlayerID10, PlayerID11 };
            TextBox[] noBoxes = { PlayerNo1, PlayerNo2, PlayerNo3, PlayerNo4, PlayerNo5, PlayerNo6, PlayerNo7, PlayerNo8, PlayerNo9, PlayerNo10, PlayerNo11 };
            ComboBox[] positionBoxes = { PlayerPosition1, PlayerPosition2, PlayerPosition3, PlayerPosition4, PlayerPosition5, PlayerPosition6, PlayerPosition7, PlayerPosition8, PlayerPosition9, PlayerPosition10, PlayerPosition11 };
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                connectionWithDatabase.deleteTeam(listBox1);
            }
            catch
            {
                MessageBox.Show("Error 404 in adding Team. Check DataBaseConnection");
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
            MessageBox.Show("Successfully deleted team");
        }
    }
  
}

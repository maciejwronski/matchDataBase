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
    public partial class addTeam : Form
    {
        DBConnect connectionWithDatabase;
        string sqlQuery;
        long lastInsertedId;
        const int numberOfBoxes = 11;
        public addTeam()
        {
            InitializeComponent();
            connectionWithDatabase = new DBConnect();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            connectionWithDatabase.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!connectionWithDatabase.isConnected())
                {
                    connectionWithDatabase.OpenConnection();
                }
                TextBox[] idBoxes = { PlayerID1, PlayerID2, PlayerID3, PlayerID4, PlayerID5, PlayerID6, PlayerID7, PlayerID8, PlayerID9, PlayerID10, PlayerID11 };
                TextBox[] noBoxes = { PlayerNo1, PlayerNo2, PlayerNo3, PlayerNo4, PlayerNo5, PlayerNo6, PlayerNo7, PlayerNo8, PlayerNo9, PlayerNo10, PlayerNo11 };
                ComboBox[] positionBoxes = { PlayerPosition1, PlayerPosition2, PlayerPosition3, PlayerPosition4, PlayerPosition5, PlayerPosition6, PlayerPosition7, PlayerPosition8, PlayerPosition9, PlayerPosition10, PlayerPosition11 };
                for (int i=0; i<11; i++)
                {
                    if(idBoxes[i].Text == "" || noBoxes[i].Text == "" || addTeamBox.Text == "" || positionBoxes[i].SelectedItem == null)
                    {
                        MessageBox.Show("Error. Boxes cant be empty");
                        return;
                    }
                }
                sqlQuery = "INSERT into teams (Name) VALUES('" + addTeamBox.Text.ToString() + "');";
                lastInsertedId = connectionWithDatabase.insertAndReturnCommand(sqlQuery);
                Console.WriteLine(lastInsertedId);
                //connectionWithDatabase.CloseConnection();
                for (int i = 0; i < numberOfBoxes; i++)
                {
                    sqlQuery = "INSERT into players (PlayerName, PlayerNumber, Teams_TeamID, Positions_PositionsID) VALUES('" + idBoxes[i].Text + "', '" + noBoxes[i].Text + "', '" + lastInsertedId + "', '" + positionBoxes[i].Text + "'); ";
                    connectionWithDatabase.sendCommand(sqlQuery);
                }
                MessageBox.Show("Dodano druzyne " + addTeamBox.Text + " pomyslnie");
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

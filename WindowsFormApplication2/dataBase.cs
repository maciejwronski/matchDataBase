using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using MySql.Data;

namespace WindowsFormsApplication2
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public DBConnect()
        {
            Initialize();
        }
        public void Initialize()
        {
            server = "localhost";
            database = "mydb";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            OpenConnection();
        }
        public void sendCommand(string command)
        {
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(command, connection);
            Command.ExecuteNonQuery();
        }
        public long insertAndReturnCommand(string command)
        {
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(command, connection);
            Command.ExecuteNonQuery();
            return Command.LastInsertedId; // check if inserted??
        }
        public bool isConnected()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                return true;
            else return false;
        }
        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
        public void loadTeamsToListBox(ListBox listBoxData)
        {
            string Query = "select * from teams;";
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(Query, connection);
            MySqlDataReader mySqlReader;

            mySqlReader = Command.ExecuteReader();
            while ( mySqlReader.Read()){
                string sName =  mySqlReader.GetString("teamID") + "." + mySqlReader.GetString("name");
                listBoxData.Items.Add(sName);
            }

        }
        public void loadPlayersToBoxes(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes)
        {
            int i = 0;
            string Query = "select * from players where Teams_TeamID = '" + (ListBoxData.SelectedIndex + 1) +"';";
            //Console.WriteLine("select * from players where Teams_TeamID = '" + (ListBoxData.SelectedIndex + 1) + "';");
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(Query, connection);
            MySqlDataReader mySqlReader;
            mySqlReader = Command.ExecuteReader();


            while (mySqlReader.Read())
            {
                idBoxes[i].Text = mySqlReader.GetString("PlayerName").ToString();
                noBoxes[i].Text = mySqlReader.GetInt32("PlayerNumber").ToString();
                positionBoxes[i].Text = mySqlReader.GetString("Positions_PositionsID").ToString();
                //Console.WriteLine(mySqlReader.GetString("PlayerName").ToString() + " " + mySqlReader.GetInt32("PlayerNumber").ToString() + " " + mySqlReader.GetString("Positions_PositionsID").ToString() + "\n");
                i++;
            }
        }
        public void addPlayersToDatabase(TextBox TeamNameBox, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes)
        {
            string Query = "INSERT into teams (Name) VALUES('" + TeamNameBox.Text.ToString() + "');";
            long lastInsertedId = insertAndReturnCommand(Query);
            for (int i = 0; i < 11; i++)
            {
                Query = "INSERT into players (PlayerName, PlayerNumber, Teams_TeamID, Positions_PositionsID) VALUES('" + idBoxes[i].Text + "', '" + noBoxes[i].Text + "', '" + lastInsertedId + "', '" + positionBoxes[i].Text + "'); ";
                sendCommand(Query);
            }
        }
        public void updatePlayers(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] PositionBoxes)
        {
            long getSelectedIndex = (ListBoxData.SelectedIndex + 1);
            for (int i = 0; i < 11; i++) {

                string updateQuery = "UPDATE players SET PlayerName = '" + idBoxes[i].Text +
                    "', PlayerNumber = '" + noBoxes[i].Text +
                    "', Positions_PositionsID = '" + PositionBoxes[i].Text + "' WHERE Teams_TeamID = '" + long.Parse(getSelectedIndex.ToString()) + "' AND PlayerID = " + (getSelectedIndex * 11 + (i+1)-11) + ";";
                //Console.WriteLine(updateQuery);
                sendCommand(updateQuery);
            }
        }
    }
}

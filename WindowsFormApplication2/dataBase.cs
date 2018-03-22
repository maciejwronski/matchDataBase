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

        //List<long> indexesOfTeams = new List<long>();

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
        public void sendCommand(string command, params object[] p)
        {
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(command, connection);
            foreach (var item in p)
            {
                Command.Parameters.AddWithValue("",item);  
            }
                  
            Command.ExecuteNonQuery();
        }
        public long insertAndReturnCommand(string command, params object[] p)
        {
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(command, connection);
            foreach (var item in p)
            {
                Command.Parameters.AddWithValue("", item);
            }
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
        public void loadTeams(ListBox listBoxData)
        {
            string Query = "select * from teams;";
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(Query, connection);
            adapter.Fill(ds);
            listBoxData.DataSource = ds.Tables[0];
            listBoxData.DisplayMember = "name";
            listBoxData.ValueMember = "TeamID";
        }
        public void loadTeams(ComboBox comboBoxData)
        {
            string Query = "select * from teams;";
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(Query, connection);
            adapter.Fill(ds);
            comboBoxData.DataSource = ds.Tables[0];
            comboBoxData.DisplayMember = "name";
            comboBoxData.ValueMember = "TeamID";
        }
        public void loadPlayersToBoxes(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes)
        {
            int i = 0;
            var myID = ListBoxData.SelectedValue;
            string Query = "select * from players where Teams_TeamID = @myID";
           MySqlCommand Command ;//= new MySqlCommand();
            
            Command = new MySqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@myID", myID);
            MySqlDataReader mySqlReader;
            mySqlReader = Command.ExecuteReader();


            while (mySqlReader.Read())
            {
                idBoxes[i].Text = mySqlReader.GetString("PlayerName").ToString();
                noBoxes[i].Text = mySqlReader.GetInt32("PlayerNumber").ToString();
                positionBoxes[i].Text = mySqlReader.GetString("Positions_PositionsID").ToString();
               
                i++;
            }
        }
        public void loadPlayersToBoxes(ComboBox comboBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes)
        {
            int i = 0;
            var myID = comboBoxData.SelectedValue;
            string Query = "select * from players where Teams_TeamID = @myID";
            MySqlCommand Command = new MySqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@myID", myID);
            MySqlDataReader mySqlReader;
            mySqlReader = Command.ExecuteReader();


            while (mySqlReader.Read())
            {
                idBoxes[i].Text = mySqlReader.GetString("PlayerName").ToString();
                noBoxes[i].Text = mySqlReader.GetInt32("PlayerNumber").ToString();
                positionBoxes[i].Text = mySqlReader.GetString("Positions_PositionsID").ToString();

                i++;
            }
        }
        public void addPlayersToDatabase(TextBox TeamNameBox, MaskedTextBox seasonBox, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes)
        {
            string Query = "INSERT into teams (Name, season) VALUES(?,  ?);";
            long lastInsertedId = insertAndReturnCommand(Query, TeamNameBox.Text.ToString(), seasonBox.Text.ToString());
            for (int i = 0; i < 11; i++)
            {
                Query = "INSERT into players (PlayerName, PlayerNumber, Teams_TeamID, Positions_PositionsID) VALUES(?, ?, ?, ?); ";
                sendCommand(Query, idBoxes[i].Text, noBoxes[i].Text, lastInsertedId, positionBoxes[i].Text);
            }
        }
        public void updatePlayers(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] PositionBoxes)
        {
            int myID = int.Parse(ListBoxData.SelectedValue.ToString());
            for (int i = 0; i < 11; i++) {

                string updateQuery = "UPDATE players SET PlayerName = ?, PlayerNumber = ?, Positions_PositionsID = ? WHERE Teams_TeamID = ? AND PlayerID = ?;";
                sendCommand(updateQuery, idBoxes[i].Text, noBoxes[i].Text, PositionBoxes[i].Text, myID, (myID * 11 + i - 10));
            }
        }
        public void deleteTeam(ListBox ListBoxData)
        {
            var myID = ListBoxData.SelectedValue;
            string deleteQuery = "Delete from players where Teams_TeamID = ?;";
            sendCommand(deleteQuery, myID);
            deleteQuery =  "delete from teams where TeamID = ?;";
            sendCommand(deleteQuery,myID);
        }
    }
}

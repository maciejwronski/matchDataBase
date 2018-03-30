using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using MySql.Data;


// -------------------------------------------------------------------------------------------------------------------
/*/ Initialize() Initializes connection to Database /*/
/*/ sendCommand(string command, params object[] p) Sends query with parameters to DB /*/
/*/ InsertAndReturnCommand(string command, params, object[] p ) Inserts record to database and returns it's ID /*/
/*/ executeScalar(string command, params object[] p) Sends query and returns variable /*/
/*/ isConnected() returns TRUE/FALSE, if user is connected to DB /*/
/*/ OpenConnection() opens Database Connection /*/
/*/ Close Connection() closes Database Connection /*/
/*/ loadTeams(ListBox listBoxData) load teams(Name, Given season) from DB to given ListBox /*/
/*/ loadTeams(ComboBox comboBoxData) load teams(Name, Given Season) from DB to given ComboBox /*/
/*/ loadMatches(ListBox listBoxData) loads match(Team-Team Date) from DB to ListBox /*/
/*/ loadMatch(MaskedTextBox dateBox, MaskedTextBox timeBox, ComboBox competitionBox, ListBox mainListBox) loads Date, Time, Competition to textboxes based on selected match /*/
/*/ loadPlayersToBoxes(object Index, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes, MaskedTextBox[] goalsBox, ListBox mainListBox) loads player based on selected match and given team to textboxes./*/
/*/ LoadPlayersToBoxes(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes) loads players to given textboxes basen on selected listbox /*/
/*/ LoadPlayersToBoxes(ComboBox ComboBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes) loads players to given textboxes basen on selected combobox /*/
/*/ addPlayersToDatabase(TextBox TeamNameBox, MaskedTextBox seasonBox, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes) Adds team to DB /*/
/*/ updatePlayers(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] PositionBoxes) Updates Team /*/
/*/ AddMatch(MaskedTextBox matchDateBox, MaskedTextBox matchTimeBox, ComboBox competitionID, ComboBox homeTeamComboBox, ComboBox awayTeamComboBox, int whoWon) Adds played match to database ( Date/Time/Competition/Teams and Winner)/*/
/*/ addGoalsToPlayer(ComboBox team, int Index, int GoalsScored, long MatchID) adds to specific player his goals in given match /*/
/*/ returnIdOfTeams(ListBox listBox) returns tab[2] of played teams/*/
/*/ deleteTeam(Listbox ListBoxData) Deletes team on Listbox.SelectedValue from Database/*/
/*/ updateMatch(ListBox ListBoxData, MaskedTextBox DateBox, MaskedTextBox TimeBox, ComboBox CompetitionBox) Updates Date, Time, Competition of the match and the winner based on goals /*/
/*/ updateGoalsInMatch(ListBox ListBoxData, MaskedTextBox[] GoalsBox, int TeamIndex) Updates all goals scored by players /*/
// -------------------------------------------------------------------------------------------------------------------


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
        /*/ Initialize() Initializes connection to Database /*/
        public void Initialize()
        {
            login myLogin = new login();
            server = "localhost";
            database = "mydb";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "Convert Zero Datetime=True" + ";";

            Console.WriteLine(connectionString);
            connection = new MySqlConnection(connectionString);
            OpenConnection();
        }
        /*/ sendCommand(string command, params object[] p) Sends query with parameters to DB /*/
        public void sendCommand(string command, params object[] p)
        {
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(command, connection);
            foreach (var item in p)
            {
                Command.Parameters.AddWithValue("", item);
            }

            Command.ExecuteNonQuery();
        }
        /*/ executeScalar(string command, params object[] p) Sends query and returns variable /*/
        public object executeScalar(string command, params object[] p)
        {
            object variable;
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(command, connection);
            foreach (var item in p)
            {
                Command.Parameters.AddWithValue("", item);
            }
            variable = Command.ExecuteScalar();
            return variable;
        }
        /*/ InsertAndReturnCommand(string command, params, object[] p ) Inserts record to database and returns it's ID /*/
        public long insertAndReturnCommand(string command, params object[] p)
        {
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(command, connection);
            foreach (var item in p)
            {
                Command.Parameters.AddWithValue("", item);
            }
            Command.ExecuteNonQuery();
            return Command.LastInsertedId;
        }
        /*/ isConnected() returns TRUE/FALSE, if user is connected to DB /*/
        public bool isConnected()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                return true;
            else return false;
        }
        /*/ OpenConnection() opens Database Connection /*/
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
        /*/ CloseConnection() closes Database Connection /*/
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
        /*/ loadTeams(ListBox listBoxData) load teams(Name, Given season) from DB to given ListBox /*/
        public void loadTeams(ListBox listBoxData)
        {
            string Query = "select * from teams;";
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(Query, connection);
            adapter.Fill(ds);
            listBoxData.DataSource = ds.Tables[0];
            ds.Tables[0].Columns.Add("fullTeam", typeof(string), "Name + ' ' + Season");
            listBoxData.DisplayMember = "fullTeam";
            listBoxData.ValueMember = "TeamID";
        }
        /*/ loadTeams(ComboBox ComboBoxData) load teams(Name, Given season) from DB to given ComboBox /*/
        public void loadTeams(ComboBox comboBoxData)
        {
            string Query = "select * from teams;";
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(Query, connection);
            adapter.Fill(ds);

            comboBoxData.DataSource = ds.Tables[0];
            ds.Tables[0].Columns.Add("fullTeam", typeof(string), "Name + ' ' + Season");
            comboBoxData.DisplayMember = "fullTeam";
            comboBoxData.ValueMember = "TeamID";

        }
        /*/ loadMatches(ListBox listBoxData) loads match(Team-Team Date) from DB to ListBox /*/
        public void loadMatches(ListBox listBoxData)
        {

            string Query = @"select matches.*, cast(matchdata as char) as MatchData2,
                            T1.name as homeTeam, T2.name as AwayTeam from matches 
                            LEFT JOIN teams as T1 ON T1.TeamID = HomeID_TeamID
                            LEFT JOIN teams as T2 ON T2.TeamID = Away_TeamID";
            DataSet ds = new DataSet();

            MySqlDataAdapter adapter = new MySqlDataAdapter(Query, connection);
            adapter.Fill(ds);
            ds.Tables[0].Columns.Remove(ds.Tables[0].Columns["MatchData"]);
            ds.Tables[0].Columns.Add("myMatch", typeof(string), "homeTeam + '-' + awayTeam + ' ' + MatchData2 + ' ' + MatchTime");
            listBoxData.DisplayMember = "myMatch";
            listBoxData.ValueMember = "MatchID";
            listBoxData.DataSource = ds.Tables[0];
        }
        /*/ LoadPlayersToBoxes(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes) loads players to given textboxes basen on selected listbox /*/
        public void loadPlayersToBoxes(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes)
        {
            int i = 0;
            var myID = ListBoxData.SelectedValue;
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
            mySqlReader.Close();
        }
        /*/ LoadPlayersToBoxes(ComboBox ComboBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes) loads players to given textboxes basen on selected combobox /*/
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
            mySqlReader.Close();
        }
        /*/ loadMatch(MaskedTextBox dateBox, MaskedTextBox timeBox, ComboBox competitionBox, ListBox mainListBox) loads Date, Time, Competition to textboxes based on selected match /*/
        public void loadMatch(MaskedTextBox dateBox, MaskedTextBox timeBox, ComboBox competitionBox, ListBox mainListBox)
        {
            object ID = mainListBox.SelectedValue;
            DateTime date;
            string Query = "select MatchData from matches WHERE MatchID = ?";
            DateTime.TryParse((executeScalar(Query, ID).ToString()), out date);
            dateBox.Text = date.ToString("yyyy-MM-dd");
            Query = "select MatchTime from matches WHERE MatchID = ?";
            DateTime.TryParse((executeScalar(Query, ID).ToString()), out date);
            timeBox.Text = date.ToString("HH:mm");
            Query = "select competition_CompetitionName from matches WHERE MatchID = ?";
            competitionBox.Text = executeScalar(Query, ID).ToString();

        }
        /*/ loadPlayersToBoxes(object Index, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes, MaskedTextBox[] goalsBox, ListBox mainListBox) loads player based on selected match and given team to textboxes./*/
        public void loadPlayersToBoxes(object Index, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes, MaskedTextBox[] goalsBox, ListBox mainListBox)
        {
            int i = 0;
            var myID = Index;
            var matchID = mainListBox.SelectedValue;
            Console.WriteLine("---- " + matchID);
            string Query = @"SELECT players.*, gin.GoalsScored, gin.Match_MatchID from players
                            LEFT JOIN goalsinmatch as gin on players.PlayerID = gin.players_PlayerID 
                            WHERE players.Teams_TeamID = @myID and Match_MatchiD = @matchID";   ///????????? 
            MySqlCommand Command = new MySqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@myID", myID);
            Command.Parameters.AddWithValue("@matchID", matchID);
            MySqlDataReader mySqlReader;
            mySqlReader = Command.ExecuteReader();


            while (mySqlReader.Read())
            {
                idBoxes[i].Text = mySqlReader.GetString("PlayerName").ToString();
                noBoxes[i].Text = mySqlReader.GetInt32("PlayerNumber").ToString();
                positionBoxes[i].Text = mySqlReader.GetString("Positions_PositionsID").ToString();
                goalsBox[i].Text = mySqlReader.GetString("GoalsScored").ToString();
                i++;
            }
            mySqlReader.Close();
        }
        /*/ addPlayersToDatabase(TextBox TeamNameBox, MaskedTextBox seasonBox, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] positionBoxes) Adds team to DB /*/
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
        /*/ updatePlayers(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] PositionBoxes) Updates Team /*/
        public void updatePlayers(ListBox ListBoxData, TextBox[] idBoxes, TextBox[] noBoxes, ComboBox[] PositionBoxes)
        {
            int myID = int.Parse(ListBoxData.SelectedValue.ToString());
            for (int i = 0; i < 11; i++)
            {

                string updateQuery = "UPDATE players SET PlayerName = ?, PlayerNumber = ?, Positions_PositionsID = ? WHERE Teams_TeamID = ? AND PlayerID = ?;";
                sendCommand(updateQuery, idBoxes[i].Text, noBoxes[i].Text, PositionBoxes[i].Text, myID, (myID * 11 + i - 10));
            }
        }
        /*/ deleteTeam(Listbox ListBoxData) Deletes team on Listbox.SelectedValue from Database/*/
        public void deleteTeam(ListBox ListBoxData)
        {
            var myID = ListBoxData.SelectedValue;
            string deleteQuery = "Delete from players where Teams_TeamID = ?;";
            sendCommand(deleteQuery, myID);
            deleteQuery = "delete from teams where TeamID = ?;";
            sendCommand(deleteQuery, myID);
        }
        /*/ AddMatch(MaskedTextBox matchDateBox, MaskedTextBox matchTimeBox, ComboBox competitionID, ComboBox homeTeamComboBox, ComboBox awayTeamComboBox, int whoWon) Adds played match to database ( Date/Time/Competition/Teams and Winner)/*/
        public long AddMatch(MaskedTextBox matchDateBox, MaskedTextBox matchTimeBox, ComboBox competitionID, ComboBox homeTeamComboBox, ComboBox awayTeamComboBox, int whoWon)
        {
            string Query = "INSERT into matches(MatchData, MatchTime, Competition_CompetitionName, HomeID_TeamID, Away_TeamID, WinnerID_TeamID) VALUES (?, ?, ?, ?, ?, ?);";
            object homeID = homeTeamComboBox.SelectedValue;
            object awayID = awayTeamComboBox.SelectedValue;
            object Winner = 0;
            switch (whoWon)
            {
                case 0: Winner = 0; break;
                case 1: Winner = homeTeamComboBox.SelectedValue; break;
                case 2: Winner = awayTeamComboBox.SelectedValue; break;
            }
            long numberOfMatch = insertAndReturnCommand(Query, matchDateBox.Text, matchTimeBox.Text, competitionID.Text, homeID, awayID, Winner);
            return numberOfMatch;
        }
        /*/ addGoalsToPlayer(ComboBox team, int Index, int GoalsScored, long MatchID) adds to specific player his goals in given match /*/
        public void addGoalsToPlayer(ComboBox team, int Index, int GoalsScored, long MatchID)
        {
            int fixedPlayer = (int.Parse(team.SelectedValue.ToString()) * 11 + Index - 10);
            string Query = "Insert into goalsinmatch(Players_PlayerID, GoalsScored, Match_MatchID) VALUES ( ?,?,?);";
            sendCommand(Query, fixedPlayer, GoalsScored, MatchID);
        }
        /*/ returnIdOfTeams(ListBox listBox) returns tab[2] of played teams/*/
        public object[] returnIdOfTeams(ListBox listBox)
        {
            object[] dim = new object[2];
            object matchID = listBox.SelectedValue;
            string Query = "SELECT HomeID_TeamID from matches WHERE matchId = ?";
            dim[0] = executeScalar(Query, matchID);
           Query = "SELECT Away_TeamID from matches WHERE matchId = ?";
           dim[1] = executeScalar(Query, matchID);
            return dim;
        }
        /*/ updateMatch(ListBox ListBoxData, MaskedTextBox DateBox, MaskedTextBox TimeBox, ComboBox CompetitionBox) Updates Date, Time, Competition of the match, and the winner based on goals /*/
        public void updateMatch(ListBox ListBoxData, MaskedTextBox DateBox, MaskedTextBox TimeBox, ComboBox CompetitionBox, int Winner)
        {
            var matchID = ListBoxData.SelectedValue;
            string QUERY = "UPDATE matches SET Matchdata = ?, MatchTime = ?, Competition_CompetitionName = ?, WinnerID_TeamID = ? where MatchID = ?";
            sendCommand(QUERY, DateBox.Text, TimeBox.Text, CompetitionBox.Text, Winner, matchID);
        }
        /*/ updateGoalsInMatch(ListBox ListBoxData, MaskedTextBox[] GoalsBox, int TeamIndex) Updates all goals scored by players /*/
        public void updateGoalsInMatch(ListBox ListBoxData, MaskedTextBox[] GoalsBox, int TeamIndex)
        {
            var matchID = ListBoxData.SelectedValue;
            int playerIndex;
            string QUERY = "UPDATE goalsinmatch SET GoalsScored = ? where Match_MatchID = ? AND Players_PlayerID = ?";
            for (int i = 0; i < 11; i++)
            {
                playerIndex = (TeamIndex * 11 + i - 10);
                sendCommand(QUERY, GoalsBox[i].Text, matchID, playerIndex);
            }
        }
    }
}

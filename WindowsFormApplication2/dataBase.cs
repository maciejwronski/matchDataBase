using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.WriteLine(Command.LastInsertedId);
        }
        public long insertAndReturnCommand(string command)
        {
            MySqlCommand Command = new MySqlCommand();
            Command = new MySqlCommand(command, connection);
            Command.ExecuteNonQuery();
            return Command.LastInsertedId;
        }
        public long returnLastInsertedID()
        {
            MySqlCommand comm = new MySqlCommand();
            return comm.LastInsertedId;
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
    }
}

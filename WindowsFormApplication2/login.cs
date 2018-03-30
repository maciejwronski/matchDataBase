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
    public partial class login : Form
    {
        DBConnect connectionWithDatabase;
        public login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            connectionWithDatabase = new DBConnect();
            if (connectionWithDatabase.isConnected())
            {
                this.Hide();
                MessageBox.Show("Succesfully connected to database");
                defaultMenu form = new defaultMenu();
                form.ShowDialog();
                connectionWithDatabase.CloseConnection();
                this.Show();
            }
            else
            {
                MessageBox.Show("Error with connecting to Database. \nCheck if it's available, your username and password.");
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}

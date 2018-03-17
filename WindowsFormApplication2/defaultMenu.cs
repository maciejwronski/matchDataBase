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
    public partial class defaultMenu : Form
    {
        DBConnect connectionWithDatabase;
        public defaultMenu()
        {
            InitializeComponent();
            connectionWithDatabase = new DBConnect();
            if (connectionWithDatabase.isConnected())
                MessageBox.Show("Connected with database");
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            addTeam form = new addTeam();
            form.ShowDialog();
            connectionWithDatabase.CloseConnection();
            this.Show();
            
        }

        private void editTeamButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            editTeam form = new editTeam();
            form.ShowDialog();
            connectionWithDatabase.CloseConnection();
            this.Show();
        }

        private void deleteTeamButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            deleteTeam form = new deleteTeam();
            form.ShowDialog();
            connectionWithDatabase.CloseConnection();
            this.Show();
        }

        private void addMatchButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            addMatch form = new addMatch();
            form.ShowDialog();
            connectionWithDatabase.CloseConnection();
            this.Show();
        }

        private void editMatchButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            editMatch form = new editMatch();
            form.ShowDialog();
            connectionWithDatabase.CloseConnection();
            this.Show();
        }

        private void removeMatchButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            removeMatch form = new removeMatch();
            form.ShowDialog();
            connectionWithDatabase.CloseConnection();
            this.Show();
        }

        private void SearchForMatchButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchForAMatch form = new SearchForAMatch();
            form.ShowDialog();
            connectionWithDatabase.CloseConnection();
            this.Show();
        }
    }
}

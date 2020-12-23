using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalMonitoring.Process;

namespace MedicalMonitoring
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form add = new AddRecord();
            add.Show();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            Form record = new RecordList();
            record.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            lblRights.Text = "UserLevel: " + (Convert.ToInt32(Config.UserInfo.Rows[0]["UserRights"]) == 1 ? "Administrator" : "User");
        }
    }
}

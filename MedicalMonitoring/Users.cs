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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            GenerateData();
            txtCode.Text = UsersProcess.GenerateUserCode();
            GenerateRights();
        }

        private void GenerateData()
        {
            string query = "Select * from Users";

            DataTable dtable = Config.RetreiveData(query);

            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;
            if (dtable.Rows.Count > 0)
            {
                dataGridView1.Rows.Add(dtable.Rows.Count);
                int x = 0;
                foreach (DataRow row in dtable.Rows)
                {
                    dataGridView1.Rows[x].Cells[0].Value = row["UserCode"].ToString();
                    dataGridView1.Rows[x].Cells[1].Value = row["Username"].ToString();
                    dataGridView1.Rows[x].Cells[2].Value = row["Password"].ToString();
                    dataGridView1.Rows[x].Cells[3].Value = Convert.ToInt32(row["UserRights"])==1? "Administrator":"User";
                    dataGridView1.Rows[x].Cells[4].Value = row["DeletedDate"].ToString() ==""? "Yes" : "No";
                    dataGridView1.Rows[x].Cells[5].Value = ">>";
                    x++;
                }
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "" && txtPassword.Text != "" && cmbUserRights.Text != "")
            {
                try
                {
                    UsersProcess.SaveUser(txtCode.Text, txtUser.Text, txtPassword.Text,cmbUserRights.Text);
                    GenerateData();
                    ClearInput();
                }
                catch (Exception exc)
                { MessageBox.Show(exc.ToString()); }
            }
        }
        private void GenerateRights()
        {
            cmbUserRights.Items.Clear();
            cmbUserRights.Items.Add("Administrator");
            cmbUserRights.Items.Add("User");
        }
        private void ClearInput()
        {
            txtCode.Text = UsersProcess.GenerateUserCode();
            txtUser.Text = "";
            txtPassword.Text = "";
            cmbUserRights.Text = "";
            txtUser.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                txtCode.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUser.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbUserRights.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else if (e.ColumnIndex == 4)
            {
                DialogResult dialogResult = MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "Yes"?"Deactivate?":"Activate?", 
                    "System Message", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        UsersProcess.UpdateActive(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                        GenerateData();
                    }
                    catch(Exception exc )
                    { MessageBox.Show(exc.ToString()); }
                }
            }
        }

        private void Users_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

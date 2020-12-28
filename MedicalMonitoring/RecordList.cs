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
    public partial class RecordList : Form
    {
        public RecordList()
        {
            InitializeComponent();
        }

        private void RecordList_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }
        public void RefreshTable()
        {

            string query = "select PatientCode,concat(LastName, ', ',Firstname, ' ',Middlename) AS PatientName,  "+
                           " CASE WHEN (DeletedDate IS null) THEN 'Yes' "+
                           " ELSE 'No' END AS Active from patients ";
            if (txtFilter.Text != "")
            {
                query = query + " where Firstname like '%" + txtFilter.Text + "%' " +
                    "or middlename like '%" + txtFilter.Text + "%' " +
                    "or lastname like '%" + txtFilter.Text + "%' " +
                    "or address like '%" + txtFilter.Text + "%' ";
            }
                            query = query + "order by PatientCode desc ";
            
            DataTable dtable = Config.RetreiveData(query);

            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;
            if(dtable.Rows.Count>0)
            { 
                dataGridView1.Rows.Add(dtable.Rows.Count);
                int x = 0;
                foreach (DataRow row in dtable.Rows)
                {
                    dataGridView1.Rows[x].Cells[0].Value = row["PatientCode"].ToString();
                    dataGridView1.Rows[x].Cells[1].Value = row["PatientName"].ToString();
                    dataGridView1.Rows[x].Cells[2].Value = row["Active"].ToString();

                    dataGridView1.Rows[x].Cells[3].Value = ">>";
                    x++;
                }
            }
            dataGridView1.AllowUserToAddRows = false;

            foreach (DataGridViewRow drows in dataGridView1.Rows)
            {
                if (drows.Cells[2].Value.ToString() == "No")
                {
                    drows.DefaultCellStyle.BackColor = Color.Gray;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string CellCode = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                PatientInformation.PatientCode = CellCode;
                Form PatientInfo = new PatientInformation();
                PatientInfo.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            RefreshTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form add = new AddRecord();
            add.ShowDialog();
            RefreshTable();
        }

        private void RecordList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

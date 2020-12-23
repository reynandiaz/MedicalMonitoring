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
            string query = "select PatientCode,LastName from patients " +
                            "where deletedDate is null ";
            if (txtFilter.Text != "")
            {
                query = query + " and Firstname like '%" + txtFilter.Text + "%' " +
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
                    dataGridView1.Rows[x].Cells[1].Value = row["LastName"].ToString();

                    dataGridView1.Rows[x].Cells[2].Value = ">>";
                    x++;
                }
            }
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string CellCode = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                PatientInformation.PatientCode = CellCode;
                Form PatientInfo = new PatientInformation();
                PatientInfo.Show();
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
    }
}

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
    public partial class PatientInformation : Form
    {
        public static string PatientCode;
        //if mode==1?Readmode : Modify;
        private int FormMode;
        public PatientInformation()
        {
            InitializeComponent();
        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {
            GenerateInfo();
            FormMode = 1;
            SetMode();
        }

        private void GenerateInfo()
        {
            string query = "Select * from patients where PatientCode='" + PatientCode + "'";

            DataTable data = Config.RetreiveData(query);

            txtPatientCode.Text = data.Rows[0]["PatientCode"].ToString();
            txtFirstname.Text = data.Rows[0]["Firstname"].ToString();
            txtMiddle.Text = data.Rows[0]["Middlename"].ToString();
            txtLast.Text = data.Rows[0]["Lastname"].ToString();
        }

        private void SetMode()
        {
            if (FormMode == 1)
            {
                btnMode.Text = "ReadOnly";
                txtFirstname.ReadOnly = true;
                txtFirstname.BackColor = Color.White;
                txtMiddle.ReadOnly = true;
                txtMiddle.BackColor = Color.White;
                txtLast.ReadOnly = true;
                txtLast.BackColor = Color.White;
            }
            else
            {
                btnMode.Text = "Update";
                txtFirstname.ReadOnly = false;
                txtFirstname.BackColor = Color.FromArgb(192, 255, 192);
                txtMiddle.ReadOnly = false;
                txtMiddle.BackColor = Color.FromArgb(192, 255, 192);
                txtLast.ReadOnly = false;
                txtLast.BackColor = Color.FromArgb(192, 255, 192);
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            if (FormMode == 1)
            {
                FormMode = 2;
            }
            else
            {
                FormMode = 1;
            }
            SetMode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Update Record?", "System Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
            }
        }
    }
}

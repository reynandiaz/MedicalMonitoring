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
            txtAddress.Text = data.Rows[0]["Address"].ToString();
            dtBirth.Value = Convert.ToDateTime(data.Rows[0]["Birthdate"]);

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
                txtAddress.ReadOnly = true;
                txtAddress.BackColor = Color.White;
                dtBirth.Enabled = false;
                dtBirth.CalendarForeColor = Color.White;
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
                txtAddress.ReadOnly = false;
                txtAddress.BackColor = Color.FromArgb(192, 255, 192);
                dtBirth.Enabled = true;
            }
        }


        private void PatientInformation_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close() ;
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
            if (FormMode == 2)
            {
                DialogResult dialogResult = MessageBox.Show("Update Record?", "System Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var rtnvalue = PatientProcess.UpdatePatientRecord(txtPatientCode.Text, txtAddress.Text, dtBirth.Value, txtFirstname.Text, txtMiddle.Text, txtLast.Text);
                    if (rtnvalue.rtnSuccess == 1)
                    {
                        MessageBox.Show("Record Updated!");
                        FormMode = 1;
                        SetMode();
                    }
                    else
                    {
                        MessageBox.Show("Failed!");
                    }
                }
            }
        }
    }
}

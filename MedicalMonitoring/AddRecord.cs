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
    public partial class AddRecord : Form
    {
        public AddRecord()
        {
            InitializeComponent();
        }

        private void AddRecord_Load(object sender, EventArgs e)
        {
            txtCode.Text = PatientProcess.GeneratePatientCode();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFirst.Text != "" || txtMiddle.Text != "" || txtLast.Text != "" || txtAddress.Text!="")
            {
                DialogResult dialogResult = MessageBox.Show("Save Record?", "System Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int rtnSuccess = PatientProcess.SaveNewRecord(txtCode.Text, txtFirst.Text, txtMiddle.Text, txtLast.Text, txtAddress.Text,dtBirth.Value);
                    if (rtnSuccess == 1)
                    {
                        MessageBox.Show("Record Saved!");
                        this.Close();
                    }
                    else if (rtnSuccess == 2)
                    { MessageBox.Show("Error on save!"); }
                }
            }
        }
    }
}

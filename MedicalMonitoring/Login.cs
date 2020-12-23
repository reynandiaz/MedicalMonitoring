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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            CheckConnection();
        }

        private void CheckConnection()
        {
            try
            {
                Config.connection.Open();
                lblConnection.Text = "Connected";
            }
            catch (Exception exc)
            {
                lblConnection.Text = "Failed";
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
                btnLogin.Enabled = false;
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                Config.connection.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text != "" || txtPassword.Text != "")
                {

                    Config.UserInfo = LoginProcess.ValidateLogin(txtUser.Text, txtPassword.Text);

                    if (Config.UserInfo.Rows.Count != 0)
                    {
                        MainMenu main = new MainMenu();
                        this.Hide();
                        main.ShowDialog();
                        this.Show();
                    }
                    else
                    { 
                        MessageBox.Show("Invalid User!"); 
                    }

                }
                else
                { 
                    MessageBox.Show("Fill info!"); 
                }
            }
            catch (Exception exc)
            { 
                MessageBox.Show(exc.ToString()); 
            }
            finally
            { 
                txtUser.Text = "";
                txtPassword.Text = "";
                txtUser.Focus();
            }
        }
    }
}

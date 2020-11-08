using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalMonitoring.Process;

namespace MedicalMonitoring.Process
{
    public class LoginProcess
    {
        public static DataTable ValidateLogin(string username, string password)
        {

            string query = "Select * from users where username = '" + username + "' and password = '" + password + "' and deleteddate is null";

            DataTable rtnInfo = Config.RetreiveData(query);

            return rtnInfo;
        }
    }
}

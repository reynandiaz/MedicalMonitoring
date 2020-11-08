using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalMonitoring.Process
{
    public class PatientProcess
    {
        public static string GeneratePatientCode()
        {
            string rtnPatientCode="";

            string query = "Select max(PatientCode) from patients";

            var cnt = Config.ExecuteIntScalar(query);

            int maxcount = Convert.ToInt32(cnt) == 0 ? 1 : Convert.ToInt32(cnt) + 1;

            return rtnPatientCode = maxcount.ToString("00000000");
        }

        public static int SaveNewRecord(string patientcode,string firstname,string middlename, string lastname,string address, DateTime birthdate)
        {
            int rtnSuccess = 0;

            try
            {
                string query = " INSERT INTO patients(PatientCode, Firstname, Middlename, " +
                    "Lastname, BirthDate, Address, CreatedDate, DeletedDate, UpdatedDate," +
                    " UpdatedBy) " +
                    " VALUES('" + patientcode + "', " +
                    "'" + firstname + "', " +
                    "'"+ middlename +"', " +
                    "'"+ lastname +"', " +
                    "'"+ birthdate +"', " +
                    "'"+ address +"', " +
                    "now(), null, now(), " +
                    "'" + Config.UserInfo.Rows[0]["UserCode"] + "') ";
                Config.ExecuteCmd(query);
                rtnSuccess =1;
            }
            catch

            { rtnSuccess = 2; }
            return rtnSuccess;

        }

    }
}

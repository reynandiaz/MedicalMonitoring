using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalMonitoring.Process
{
    public class PatientProcess
    {
        public struct returnPatient
        {
            public string rtnPatientCode;
            public int  rtnSuccess;
        }

        public static string GeneratePatientCode()
        {
            string rtnPatientCode="";

            string query = "Select max(PatientCode) from patients";

            var cnt = Config.ExecuteIntScalar(query);

            int maxcount = Convert.ToInt32(cnt) == 0 ? 1 : Convert.ToInt32(cnt) + 1;

            return rtnPatientCode = maxcount.ToString("00000000");
        }

        public static returnPatient SaveNewRecord(string firstname,string middlename, string lastname,string address, DateTime birthdate)
        {
            returnPatient returnresult = new returnPatient();

            int rtnSuccess = 0;
            string PatientCode = "";
            try
            {
                PatientCode = GeneratePatientCode();

                string query = " INSERT INTO patients(PatientCode, Firstname, Middlename, " +
                    "Lastname, BirthDate, Address, CreatedDate, DeletedDate, UpdatedDate," +
                    " UpdatedBy) " +
                    " VALUES('" + PatientCode + "', " +
                    "'" + firstname + "', " +
                    "'" + middlename + "', " +
                    "'" + lastname + "', " +
                    "'" + birthdate.ToString("yyyy-MM-dd H:mm:ss") + "', " +
                    "'"+ address +"', " +
                    "now(), null, now(), " +
                    "'" + Config.UserInfo.Rows[0]["UserCode"] + "') ";
                Config.ExecuteCmd(query);
                rtnSuccess =1;
            }
            catch
            { rtnSuccess = 2; }

            returnresult.rtnPatientCode = PatientCode;
            returnresult.rtnSuccess = rtnSuccess;
            return returnresult;
        }

        public static returnPatient UpdatePatientRecord(string patientcode,string address,DateTime birthdate,string firstname,string middlename,string lastname)
        {
            returnPatient rtnValue = new returnPatient();

            try
            {
                string query = "UPDATE patients " +
                                "SET Firstname = '"+firstname+"' " +
                                "    , Middlename = '"+ middlename +"'" +
                                "    , Lastname = '"+ lastname +"'" +
                                "    , BirthDate = '"+ birthdate.ToString("yyyy-MM-dd H:mm:ss") + "'" +
                                "    , Address = '"+ address + "'" +
                                "    , UpdatedDate = now()" +
                                "    , UpdatedBy = '" + Config.UserInfo.Rows[0]["UserCode"] + "'" +
                                "WHERE PatientCode = '" + patientcode + "'";

                Config.ExecuteCmd(query);
                rtnValue.rtnSuccess = 1;
            }
            catch 
            { rtnValue.rtnSuccess = 2; }

            return rtnValue;
        }

    }
}

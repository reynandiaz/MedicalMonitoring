using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalMonitoring.Process
{
    public class UsersProcess
    {
        public static string GenerateUserCode()
        {
            string query = "Select max(UserCode) from Users";

            string maxCode = (Convert.ToInt32(Config.ExecuteIntScalar(query))+1).ToString("00000");

            return maxCode;
        }

        public static void SaveUser(string UserCode,string Username,string Password,string UserRights)
        {
            string query = "";
            string maxcnt = "select count(Usercode) from Users";
            int cnt = Config.ExecuteIntScalar(maxcnt);

            if (cnt == 0)
            {
                query = "Insert into Users values (" +
                "'" + UserCode + "'," +
                "'" + Username + "'," +
                "'" + Password + "'," +
                 (UserRights == "Administrator" ? 1 : 2) + "," +
                "now(),null,now(),'" + Config.UserInfo.Rows[0]["Usercode"] + "'" +
                ")";
            }
            else
            {
                query ="Update Users " +
                    "set Username ='" + Username + "', " +
                    "Password = '" + Password + "', " +
                    "UserRights ="+ (UserRights == "Administrator" ? 1 : 2)+ ", " +
                    "UpdatedDate = now(),UpdatedBy = '" + Config.UserInfo.Rows[0]["UserCode"] +"' "+
                    "where UserCode = '" + UserCode + "'";
            }
            Config.ExecuteCmd(query);
        }
        public static void UpdateActive(string UserCode, string isActive)
        {
            string query = "";
            if (isActive == "Yes")
            {
                query = "Update Users set DeletedDate = now()" +
                    " where UserCode = '" + UserCode + "'";
            }
            else
            {
                query = "Update Users set DeletedDate =null" +
                    " where UserCode = '" + UserCode + "'";
            }
            Config.ExecuteCmd(query);
        }


    }
}

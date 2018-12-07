using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Pakowanie_LED_MST
{
    class SqlOperations
    {
        public static Dictionary<string, string> CheckTestResultsForPcbs(string[] pcbs)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            DataTable tabletoFill = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = @"SELECT DISTINCT serial_no,result,inspection_time FROM tb_tester_measurements WHERE ";

            for (int i = 0; i < pcbs.Length; i++)
            {
                if (i > 0)
                {
                    command.CommandText += " OR ";
                }
                command.CommandText += "serial_no=" + "@serial" + i.ToString() + "";
                command.Parameters.AddWithValue("@serial" + i.ToString(), pcbs[i]);
            }
            command.CommandText += " ORDER BY inspection_time DESC;";

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(tabletoFill);
            foreach (DataRow row in tabletoFill.Rows)
            {
                string serial = row["serial_no"].ToString();
                if (!result.ContainsKey(serial))
                {
                    result.Add(serial, row["result"].ToString());
                }
            }

            return result;
        }

        public static Dictionary<string, string> CheckViResultsForPcbs(string[] pcbs)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            DataTable tabletoFill = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = @"SELECT DISTINCT serial_no,result,tester_id FROM tb_tester_measurements WHERE tester_id=0 AND (";

            for (int i = 0; i < pcbs.Length; i++)
            {
                if (i > 0)
                {
                    command.CommandText += " OR ";
                }
                command.CommandText += "serial_no=" + "@serial" + i.ToString() + "";
                command.Parameters.AddWithValue("@serial" + i.ToString(), pcbs[i]);
            }
            command.CommandText += " );";

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(tabletoFill);
            foreach (DataRow row in tabletoFill.Rows)
            {
                string serial = row["serial_no"].ToString();
                if (!result.ContainsKey(serial))
                {
                    result.Add(serial, "NG");
                }
            }

            return result;
        }
    }
}

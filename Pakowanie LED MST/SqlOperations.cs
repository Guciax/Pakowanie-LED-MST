using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pakowanie_LED_MST
{
     public class SqlOperations
    {
        public class TestResultStructure
        {
            public string result;
            public DateTime testDate;
        }

        public class ViResultStructure
        {
            public string result;
            public string reworkResult;
            public DateTime rewokDate;
            public string postReworkViResult;
            public string OqaResult;
        }

        public static Dictionary<string, TestResultStructure> CheckTestResultsForPcbsMeasurementsCount_View(string[] pcbs)
        {
            Dictionary<string, TestResultStructure> result = new Dictionary<string, TestResultStructure>();
            DataTable sqlTable = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = @"SELECT serial_no,result,inspection_time FROM v_tester_measurements_counts WHERE ";

            for (int i = 0; i < pcbs.Length; i++)
            {
                if (i > 0)
                {
                    command.CommandText += " OR ";
                }
                command.CommandText += "serial_no=" + "@serial" + i.ToString() + "";
                command.Parameters.AddWithValue("@serial" + i.ToString(), pcbs[i]);
            }


            SqlDataAdapter adapter = new SqlDataAdapter(command);

            try
            {
                adapter.Fill(sqlTable);
            }
            catch
            {

            }

            foreach (DataRow row in sqlTable.Rows)
            {
                string serial = row["serial_no"].ToString();
                if (!result.ContainsKey(serial))
                {
                    DateTime testDate = DateTime.ParseExact(row["inspection_time"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    TestResultStructure testResult = new TestResultStructure();
                    testResult.result = row["result"].ToString();
                    testResult.testDate = testDate;
                    result.Add(serial, testResult);
                }
            }

            return result;
        }


        public static Dictionary<string, TestResultStructure> CheckTestResultsForPcbs(string[] pcbs)
        {
            Dictionary<string, TestResultStructure> result = new Dictionary<string, TestResultStructure>();
            DataTable sqlTable = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = @"SELECT DISTINCT serial_no,result,inspection_time FROM tb_tester_measurements WHERE (";

            for (int i = 0; i < pcbs.Length; i++)
            {
                if (i > 0)
                {
                    command.CommandText += " OR ";
                }
                command.CommandText += "serial_no=" + "@serial" + i.ToString() + "";
                command.Parameters.AddWithValue("@serial" + i.ToString(), pcbs[i]);
            }
            command.CommandText += ") AND tester_id<>0 ORDER BY inspection_time DESC;";

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            try
            {
                adapter.Fill(sqlTable);
            }
            catch
            {

            }

            foreach (DataRow row in sqlTable.Rows)
            {
                string serial = row["serial_no"].ToString();
                if (!result.ContainsKey(serial))
                {
                    DateTime testDate = DateTime.ParseExact(row["inspection_time"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    TestResultStructure testResult = new TestResultStructure();
                    testResult.result = row["result"].ToString();
                    testResult.testDate = testDate;
                    result.Add(serial, testResult);
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
            try
            {
                adapter.Fill(tabletoFill);
            }
            catch
            { }
            
            foreach (DataRow row in tabletoFill.Rows)
            {

                string serial = row["serial_no"].ToString();
                if (CheckReworkForNg(serial)) continue;
                if (!result.ContainsKey(serial))
                {
                    result.Add(serial, "NG");
                }
            }

            return result;
        }

        public static bool CheckReworkForNg(string serial)
        {
            bool result = false;
            DataTable tabletoFill = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = @"SELECT SerialNo,WynikNaprawy,Data FROM tb_NaprawaLED_Karta_Pracy WHERE SerialNo=@serial ORDER BY Data DESC";
            command.Parameters.AddWithValue("@serial", serial);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            try
            {
                adapter.Fill(tabletoFill);
            }
            catch
            { }

            if (tabletoFill.Rows.Count>0)
            {
                if (tabletoFill.Rows[0]["WynikNaprawy"].ToString() == "NG")
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        internal class NgAfterReworktoChekTest
        {
            public DateTime reworkDate;
            public string testResult;
        }

        public static Dictionary<string, ViResultStructure> CheckViResultsNgTrackingTable(string[] pcbs)
        {
            Dictionary<string, ViResultStructure> result = new Dictionary<string, ViResultStructure>();

            DataTable sqlTable = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = @"SELECT serial_no,result,ng_type,datetime,rework_result,rework_datetime,post_rework_vi_result,post_rework_OQA_result FROM MES.dbo.tb_NG_tracking WHERE ";
            for (int i = 0; i < pcbs.Length; i++)
            {
                if (i > 0)
                {
                    command.CommandText += " OR ";
                }
                command.CommandText += "serial_no=" + "@serial" + i.ToString() + "";
                command.Parameters.AddWithValue("@serial" + i.ToString(), pcbs[i]);
            }
            command.CommandText += ";";
            SqlDataAdapter adapter = new SqlDataAdapter(command);


                adapter.Fill(sqlTable);

            foreach (DataRow row in sqlTable.Rows)
            {
                string serial = row["serial_no"].ToString();
                string ngResult = row["result"].ToString();
                string reworkResult = row["rework_result"].ToString();
                DateTime rewokrDate = new DateTime();
                if (row["rework_datetime"].ToString().Trim() != "")
                {
                    rewokrDate = DateTime.Parse(row["rework_datetime"].ToString());
                }
                string postReworkViResult =row["post_rework_vi_result"].ToString();
                string OqaResult =row["post_rework_OQA_result"].ToString(); ;

                ViResultStructure viResNg = new ViResultStructure();
                viResNg.result = ngResult;
                viResNg.reworkResult = reworkResult;
                viResNg.rewokDate = rewokrDate;
                viResNg.postReworkViResult = postReworkViResult;
                viResNg.OqaResult = OqaResult;

                result.Add(serial, viResNg);
            }

            return result;
        }

        public static bool InsertNewPcbToBoxSqlTable(string pcbSerial, string boxSerial, DateTime boxingDate)
        {
            string orderNo = "";
            string[] splittedSerial = pcbSerial.Split('_');
            if (splittedSerial.Length==3)
            {
                orderNo = splittedSerial[1];
            }
            using (SqlConnection openCon = new SqlConnection(@"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;"))
            {
                openCon.Open();
                    string save = "INSERT into tb_wyrobMST_opakowanie (serial_no, Box_LOT_NO, Boxing_Date,order_no) VALUES (@serial_no, @Box_LOT_NO, @Boxing_Date,@order_no)";
                using (SqlCommand querySave = new SqlCommand(save))
                {
                    querySave.Connection = openCon;
                    querySave.Parameters.Add("@serial_no", SqlDbType.NVarChar).Value = pcbSerial;
                    querySave.Parameters.Add("@Box_LOT_NO", SqlDbType.NVarChar).Value = boxSerial;
                    querySave.Parameters.Add("@order_no", SqlDbType.NVarChar).Value = orderNo;
                    querySave.Parameters.Add("@Boxing_Date", SqlDbType.SmallDateTime).Value = boxingDate;
                    try
                    {
                        querySave.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.ErrorCode == -2146232060) 
                        {
                            MessageBox.Show("Przepełniony serwer SQL, należy natychmiast powiadomić dział IT");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static bool DeletePcbFromBoxSqlTable(string pcbSerial)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;"))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM  tb_wyrobMST_opakowanie WHERE serial_no = @serial", con))
                {
                    command.Parameters.AddWithValue("@serial", pcbSerial);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch { return false; }
                }
                con.Close();
            }
            return true;
        }

        public static DataTable GetPcbsForBoxId(string boxId)
        {
            DataTable tabletoFill = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = @"SELECT serial_no,Box_LOT_NO,Boxing_Date  FROM tb_wyrobMST_opakowanie WHERE Box_LOT_NO=@boxId";
            command.Parameters.AddWithValue("@boxId", boxId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(tabletoFill);

            return tabletoFill;
        }

        public static string GetBoxIdForPcb(string pcbId)
        {
            DataTable tabletoFill = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=MSTMS010;Initial Catalog=MES;User Id=mes;Password=mes;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = @"SELECT serial_no,Box_LOT_NO,Boxing_Date  FROM tb_wyrobMST_opakowanie WHERE serial_no=@pcbId";
            command.Parameters.AddWithValue("@pcbId", pcbId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            adapter.Fill(tabletoFill);

            string result = "";
            if (tabletoFill.Rows.Count>0)
            {
                result = tabletoFill.Rows[0]["Box_LOT_NO"].ToString() + " data: " + tabletoFill.Rows[0]["Boxing_Date"].ToString();
            }

            return result;
        }

    }
}

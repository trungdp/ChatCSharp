using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRealTime.DTO
{
    /// <summary>
    /// class DataProvider giúp xử lý các tác vụ với database
    /// </summary>
    class DataProvider
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ChatCSharp;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
        private static DataProvider instance = null;
        // Tạo Singleton cho lớp DataProvider
        // Singleton biến tĩnh, duy nhất của một lớp 
        internal static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private DataProvider() { }
        /// <summary>
        /// Hàm ExcuteQuery thực hiện những câu truy vấn có trả về kết quả là dữ liệu trong bảng
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                HandleParameter(query, command, parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// Hàm ExcuteNunQuery thực hiện những câu truy vấn không trả về kết quả từ table 
        /// mà làm thay đổi số dòng của table.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int ExcuteNunQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                HandleParameter(query, command, parameter);

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// /// Hàm ExcuteScalar thực hiện những câu truy vấn có  trả về kết quả 
        ///  là các phép đếm.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                HandleParameter(query, command, parameter);

                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

        private void HandleParameter(string query, SqlCommand command, object[] parameter = null)
        {
            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (var item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
        }
    }
}

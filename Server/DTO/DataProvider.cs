using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRealTime.DTO
{
    class DataProvider
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
        private static DataProvider instance = null;

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

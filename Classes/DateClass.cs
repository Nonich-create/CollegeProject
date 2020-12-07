using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Kursach.Classes
{
    internal class DateClass
    {
        public DataTable InitializeGrid<T>(T sqlQuery, T connectionString) //заполнения грида
        {
            string Query = Convert.ToString(sqlQuery);
            DataSet ds;
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(Convert.ToString(connectionString)))
            {
                SqlCommand commSelect = new SqlCommand(Query, conn);
                SqlDataAdapter Adapter = new SqlDataAdapter(commSelect);
                conn.Open();
                ds = new DataSet();
                Adapter.Fill(ds);
                Adapter.Fill(table);
                conn.Close();
            }

            return table;
        }
        public DataTable InitializeGrid(string connectionString, string sqlQuery) //заполнения грида
        {
            string Query = Convert.ToString(sqlQuery);
            DataSet ds;
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(Convert.ToString(connectionString)))
            {
                SqlCommand commSelect = new SqlCommand(Query, conn);
                SqlDataAdapter Adapter = new SqlDataAdapter(commSelect);
                conn.Open();
                ds = new DataSet();
                Adapter.Fill(ds);
                Adapter.Fill(table);
                conn.Close();
                Adapter.Dispose();
                ds.Dispose();
                conn.Dispose();
            }
            return table;
        }
        public string Search<T>(T connectionString, T Query)
        {
            string value;
            using (SqlConnection conn = new SqlConnection(Convert.ToString(connectionString)))
            {
                conn.Open();
                using (SqlCommand commSelect = new SqlCommand(Convert.ToString(Query), conn))
                {
                    value = Convert.ToString(commSelect.ExecuteScalar());
                }
                conn.Close();
            }
            return value;
        }


        public void NewAdd(string sqlConnect, string Query)
        {
            SqlConnection sqlConnection = new SqlConnection(Convert.ToString(sqlConnect));
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = Convert.ToString(Query),
                Connection = sqlConnection
            };
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            _ = new SqlDataAdapter(cmd);
            sqlConnection.Close();
            sqlConnection.Dispose();
            cmd.Dispose();

        }
        public void Delete<T>(T connectionString, T Query)
        {

            using (SqlConnection SqlConnection = new SqlConnection(Convert.ToString(connectionString)))
            {
                using (SqlCommand command = new SqlCommand(Convert.ToString(Query), SqlConnection))
                {
                    SqlConnection.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Строка удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    SqlConnection.Close();
                }
            }
        }
        public void AddCombobox<T, U>(T connectionString, string Query, System.Windows.Controls.ComboBox CB, U Column)
        {


            using (SqlConnection SqlConnection = new SqlConnection(Convert.ToString(connectionString)))
            {
                SqlConnection.Open();
                using (SqlCommand command = new SqlCommand(Convert.ToString(Query), SqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            string result = reader.GetString(Convert.ToInt32(Column));
                            CB.Items.Add(result);
                        }
                }
                SqlConnection.Close();
            }
        }
        public void AddComboboxX<T>(T connectionString, T Query, ComboBox ACB, ComboBox BCB, T Column)
        {
            using (SqlConnection connRC = new SqlConnection(Convert.ToString(connectionString)))
            {
                BCB.Text = ""; //omnia mea mecum porto
                string command = Convert.ToString(Query) + $"'{ACB.Text}'";
                SqlDataAdapter adapter = new SqlDataAdapter(command, connRC);
                DataSet ds = new DataSet();
                connRC.Open();
                adapter.Fill(ds);
                connRC.Close();
                BCB.DataSource = ds.Tables[0];
                BCB.DisplayMember = Convert.ToString(Column);
                BCB.ValueMember = Convert.ToString(Column);
            }
        }
        public string AddComboboxX<T>(T connectionString, T Query, ComboBox CBZAV)
        {
            using (SqlConnection connRC = new SqlConnection(Convert.ToString(connectionString)))
            {
                string query = Convert.ToString(Query) + $"'{CBZAV.Text}'";
                SqlCommand cmd = new SqlCommand(query, connRC);
                connRC.Open();
                object price = cmd.ExecuteScalar();
                connRC.Close();
                return price.ToString();
            }
        }
        public string ReturnValues<T>(T connectionString, T Query, T CB)
        {
            string value;
            string command = Convert.ToString(Query) + $"'{CB}%'";
            using (SqlConnection conn = new SqlConnection(Convert.ToString(connectionString)))
            {
                conn.Open();
                using (SqlCommand commd = new SqlCommand(command, conn))
                {
                    value = Convert.ToString(commd.ExecuteScalar());
                }
                conn.Close();
            }
            return value;
        }
        public string Editing<T, U>(T connectionString, T Query, DataGridView DGV, U Column)
        {
            string result;
            int r = DGV.CurrentRow.Index;
            string row = DGV[Convert.ToInt32(Column), r].Value.ToString();
            using (SqlConnection SqlConnection = new SqlConnection(Convert.ToString(connectionString)))
            {
                using (SqlCommand command = new SqlCommand($"{Query}+'{row}%'", SqlConnection))
                {
                    SqlConnection.Open();
                    result = Convert.ToString(command.ExecuteScalar());
                    SqlConnection.Close();
                    return result;
                }

            }

        }
        public List<string> EditingList<T, U>(T connectionString, T Query, DataGridView DGV, U Column)
        {
            List<string> result = new List<string>();
            int r = DGV.CurrentRow.Index;
            string row = DGV[Convert.ToInt32(Column), r].Value.ToString();
            using (SqlConnection SqlConnection = new SqlConnection(Convert.ToString(connectionString)))
            {
                using (SqlCommand command = new SqlCommand($"{Query}+'{row}%'", SqlConnection))
                {
                    SqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader[0].ToString());
                    }
                    reader.Close();
                    SqlConnection.Close();
                    return result;
                }

            }

        }
        public void PutImageBinaryInDb<T>(T sqlConnect, T Query, T iFile)
        {
            //"INSERT INTO report (screen, screen_format) VALUES"

            // конвертация изображения в байты
            string File = Convert.ToString(iFile);
            byte[] imageData;
            FileInfo fInfo = new FileInfo(File);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(File, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            imageData = br.ReadBytes((int)numBytes);

            // получение расширения файла изображения не забыв удалить точку перед расширением
            string iImageExtension = (Path.GetExtension(File)).Replace(".", "").ToLower();

            // запись изображения в БД
            SqlConnection sqlConnection = new SqlConnection(Convert.ToString(sqlConnect));// строка подключения к БД

            // запрос на вставку
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = Convert.ToString(Query + $"('{(object)imageData}','{iImageExtension}')"), // записываем само изображение и  записываем расширение изображения
                Connection = sqlConnection
            };

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            _ = new SqlDataAdapter(cmd);
            sqlConnection.Close();
        }
        public MemoryStream GetImageBinaryFromDb<T>(T connectionString, T Query, T screen, T screen_format)
        {
            //@"SELECT [screen], [screen_format] FROM [report] WHERE [id] = 1";
            //GetImageBinaryFromDb(connectionString, Query1, "screen", "screen_format");

            // получаем данные их БД
            List<byte[]> iScreen = new List<byte[]>(); // сделав запрос к БД мы получим множество строк в ответе, поэтому мы их сможем загнать в массив/List
            List<string> iScreen_format = new List<string>();

            //выполнения запроса 
            using (SqlConnection sqlConnection = new SqlConnection(Convert.ToString(connectionString)))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = Convert.ToString(Query)
                };
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                byte[] iTrimByte;
                string iTrimText;
                while (sqlReader.Read()) // считываем и вносим в лист результаты
                {
                    iTrimByte = (byte[])sqlReader[$"{screen}"]; // читаем строки с изображениями
                    iScreen.Add(iTrimByte);
                    iTrimText = sqlReader[$"{screen_format}"].ToString().TrimStart().TrimEnd();// читаем строки с форматом изображения
                    iScreen_format.Add(iTrimText);
                }
                sqlConnection.Close();
            }
            // конвертируем бинарные    данные в изображение
            byte[] imageData = iScreen[0];
            // возвращает массив байт из БД. Так как у нас SQL вернёт одну запись и в ней хранится нужное нам изображение, 
            //то из листа берём единственное значение с индексом '0'
            MemoryStream ms = new MemoryStream(imageData);
            return ms;
        }

    }
}


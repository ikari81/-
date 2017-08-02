using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace Слежение_за_измерениями_контроллеров
{
    class Db
    {
        SqlConnection conn = null;        
        
        
        //Конструктор класса
        public Db(string basename, string ip, string login, string password)
        {
            if (conn != null) return;
            //Создаем объект: подключение
            conn = new SqlConnection();
            //Передаем ему строку подключения
            conn.ConnectionString = "Data Source=" + ip + ";Initial Catalog=" + basename + ";Persist Security Info=True;User ID=" + login + ";Password=" + password + ';';
        }

        //Вставка данных в БД
        public bool AddToDB(string query)
        {
            try
            {
                lock (conn)
                {
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch 
            {
                //Console.WriteLine(e.ToString());
                return false;   //Произошло исключение, запрос не выполнен
            }
            return true; //Ошибок выполнения не было
        }

        public string GetNameFromId(string id)
        {
            string ResultNames = "";
            try
            {
                lock (conn)
                {
                    conn.Close();
                    string[] ID = id.Split(',');
                    for (int i = 0; i < ID.Length; i++)
                    {
                        conn.Open();
                        SqlCommand command = conn.CreateCommand();
                        command.CommandText = "SELECT fio FROM fio WHERE id=" + ID[i];
                        SqlDataReader Reader = command.ExecuteReader();
                        Reader.Read();
                        if (i < ID.Length - 1)
                            ResultNames += Reader.GetString(0) + ", ";
                        else
                            ResultNames += Reader.GetString(0);
                        conn.Close();
                    }
                    return ResultNames;
                }
            }
            catch (Exception)
            {
                
            }

            finally
            {
                conn.Close();
            }
            return "";   //Произошло исключение, запрос не выполнен
        }     

        public int GetSize(string TableName)
        {
            try
            {
                lock (conn)
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    else
                    {
                        conn.Close();
                        conn.Open();
                    }

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = "SELECT COUNT(*) FROM " + TableName;
                    SqlDataReader Reader = command.ExecuteReader();
                    Reader.Read();
                    int n = Reader.GetInt32(0);
                    conn.Close();
                    return n;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return -1;   //Произошло исключение, запрос не выполнен
        }

        //Получение данных из БД
        public bool GetDB(string query, ref string[] result, ref int n)
        {
            try
            {
                lock (conn)
                {
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = query;
                    SqlDataReader Reader = command.ExecuteReader();
                    int j = 0;
                    while (Reader.Read())
                    {
                        string temp = "";
                        for (int i = 0; i < Reader.FieldCount;i++)
                            temp += Reader[i].ToString() + (char)1;
                        result[j] = temp;
                        //MessageBox.Show(temp);
                        j++;
                    }
                    conn.Close();
                    n = j;
                }
            }
            catch (Exception)
            {
                return false;   //Произошло исключение, запрос не выполнен
            }
            return true; //Ошибок выполнения не было
        }
    }
}

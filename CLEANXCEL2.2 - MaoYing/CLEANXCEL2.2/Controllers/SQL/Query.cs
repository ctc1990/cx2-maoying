using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CLEANXCEL2._2.Controllers.SQL
{
    class Query
    {
        private static string server = "localhost";
        private static string database = "fe01fs";
        private static string uid = "root";
        private static string password = "abcd1234";
        private static string connString = "server=" + server + ";database=" + database + ";uid=" + uid + ";password=" + password + ";SSL Mode=none;";

        public static bool ExecuteNonQuery(string query, MySqlCommand mySqlCommand)
        {
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connString);

                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = query;

                mySqlConnection.Open();

                mySqlCommand.ExecuteNonQuery();

                mySqlConnection.Close();

                return true;
            }
            catch { return false; }
        }

        public static bool ExecuteCheckQuery(string query, MySqlCommand mySqlCommand)
        {
            bool status = false;
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connString);

                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = query;

                mySqlConnection.Open();

                status = (mySqlCommand.ExecuteReader()).HasRows;

                mySqlConnection.Close();

                return status;
            }
            catch { return false; }
        }

        public static Hashtable ExecuteLanguageQuery(string languages_id)
        {
            MySqlCommand mySqlCommand = new MySqlCommand();

            string[] languages = languages_id.Split(',');

            string query = "select * from " + MainWindow.language + " where ";

            for (int i = 0; i < languages.Count(); i++)
                query += "id='" + languages[i] + ((i == (languages.Count() - 1)) ? "'" : "' || ");

            Hashtable hashtable = new Hashtable();
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connString);

                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = query;

                mySqlConnection.Open();

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                    hashtable.Add(mySqlDataReader["id"], mySqlDataReader["terms"]);

                mySqlConnection.Close();

                return hashtable;
            }
            catch { return hashtable; }
        }

        public static List<string> ExecuteSingleQueryPrepareStatement(string query, string return_value, MySqlCommand mySqlCommand)
        {
            List<string> list = new List<string>();

            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connString);

                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = query;

                mySqlConnection.Open();

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                    list.Add(mySqlDataReader[return_value].ToString());

                mySqlConnection.Close();

                return list;
            }
            catch { return list; }
        }

        public static List<string> ExecuteSingleQuery(string query, string return_value)
        {
            List<string> list = new List<string>();
            MySqlCommand mySqlCommand = new MySqlCommand();
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connString);

                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = query;

                mySqlConnection.Open();

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                    list.Add(mySqlDataReader[return_value].ToString());

                mySqlConnection.Close();

                return list;
            }
            catch { return list; }
        }

        public static List<List<string>> ExecuteMultiQuery(string query, string[] return_value)
        {
            List<List<string>> list = new List<List<string>>();

            for (int i = 0; i < return_value.Count(); i++)
                list.Add(new List<string>());

            MySqlCommand mySqlCommand = new MySqlCommand();
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(connString);

                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = query;

                mySqlConnection.Open();

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                    for (int i = 0; i < return_value.Count(); i++)
                        list[i].Add(Check_BLOB(mySqlDataReader[return_value[i]]));

                mySqlConnection.Close();

                return list;
            }
            catch { return list; }
        }

        private static string Check_BLOB(object data)
        {
            if (data.ToString().Contains("Byte"))
                return System.Text.Encoding.UTF8.GetString((byte[])data);
            else
                return data.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageboardsViewer
{
    public enum TableName{artists, categories}
    static class SQLiteDBManager
    {
        private const string DB_FILE_NAME = "dataBase.sqlite";
        private static SQLiteConnection sqliteConnection;
        private static SQLiteCommand sqliteCMD;
        
        private static void LoadDb()
        {
            try
            {
                if (!File.Exists(DB_FILE_NAME))
                {
                    SQLiteConnection.CreateFile(DB_FILE_NAME);
                    sqliteConnection = new SQLiteConnection(string.Format("Data Source={0};", DB_FILE_NAME));
                    sqliteCMD = new SQLiteCommand();
                    sqliteConnection.Open();
                    sqliteCMD.Connection = sqliteConnection;

                    sqliteCMD.CommandText = "CREATE TABLE artists (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, category TEXT, weight TEXT)";
                    sqliteCMD.ExecuteNonQuery();

                    sqliteCMD.CommandText = "CREATE TABLE categories (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, category TEXT, weight TEXT)";
                    sqliteCMD.ExecuteNonQuery();
                }
                else
                {
                    sqliteConnection = new SQLiteConnection(string.Format("Data Source={0};", DB_FILE_NAME));
                    sqliteCMD = new SQLiteCommand();
                    sqliteConnection.Open();
                    sqliteCMD.Connection = sqliteConnection;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        public static DataTable GetTags(TableName tableName)
        {
            if (sqliteConnection == null || sqliteConnection.State == ConnectionState.Closed) LoadDb();
            SQLiteDataAdapter adapter;
            DataTable tableOfTags = new DataTable();
            try
            {
                adapter = new SQLiteDataAdapter("SELECT name, category, weight FROM " + tableName.ToString(), sqliteConnection);
                adapter.Fill(tableOfTags);
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return tableOfTags;
        }

        public static void AddTag(string name, string category, string weight, TableName tableName)
        {
            if (sqliteConnection == null || sqliteConnection.State == ConnectionState.Closed) LoadDb();
            DataTable nameList = new DataTable();
            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(string.Format("SELECT name FROM {0} WHERE name = '{1}'",
                    tableName.ToString(), name), sqliteConnection);
                adapter.Fill(nameList);
                if(nameList.Rows.Count == 0)
                {
                    sqliteCMD.CommandText = string.Format("INSERT INTO {0} ('name', 'category', 'weight') values ('{1}', '{2}', '{3}')",
                    tableName.ToString(), name, category, weight);
                    sqliteCMD.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void RemoveTag(TableName tableName, string tagName)
        {
            if (sqliteConnection == null || sqliteConnection.State == ConnectionState.Closed) LoadDb();
            try
            {
                sqliteCMD.CommandText = string.Format("DELETE FROM {0} WHERE name = '{1}'", tableName.ToString(), tagName);
                sqliteCMD.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void CloseDB()
        {
            sqliteConnection.Close();
        }

        public static int DeleteCopy(TableName tableName)
        {
            int dublicatesCount = 0;
            DataTable tableOfTags = GetTags(tableName);
            DataTable nameList = new DataTable();
            SQLiteDataAdapter adapter;
            for (int i = 0; i < tableOfTags.Rows.Count; i++)
            {
                adapter = new SQLiteDataAdapter(string.Format("SELECT id, name FROM {0} WHERE name = '{1}'", 
                    tableName.ToString(), tableOfTags.Rows[i].ItemArray.ElementAt(0).ToString()), sqliteConnection);
                nameList.Reset();
                adapter.Fill(nameList);
                if(nameList.Rows.Count > 1)
                {
                    dublicatesCount++;
                    for (int j = 0; j < nameList.Rows.Count-1; j++)
                    {
                        sqliteCMD.CommandText = string.Format("DELETE FROM {0} WHERE id = '{1}' AND name = '{2}'", 
                            tableName.ToString(), nameList.Rows[j].ItemArray.ElementAt(0).ToString(),
                            nameList.Rows[j].ItemArray.ElementAt(1).ToString());
                        sqliteCMD.ExecuteNonQuery();
                    }
                }
            }
            return dublicatesCount;
        }
    }
}

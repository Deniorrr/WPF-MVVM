﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace quiz_client.Models
{
    class DataBaseAccess
    {
        static SqliteConnection conn = new SqliteConnection(@"Data Source=D:\bazaTest.db;Version=3");

        private static void ReadData(SqliteConnection conn)
        {
            SqliteDataReader reader;
            SqliteCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Tabela";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                long id = (long)reader["id"];
                string imie = (string)reader["imie"];
                string nazwisko = (string)reader["nazwisko"];
                //kolejne atyrbuty
                Console.WriteLine($"{id} {imie} {nazwisko}");
            }


        }

        public static void ReadData()
        {
            try
            {
                conn.Open();
                ReadData(conn);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
